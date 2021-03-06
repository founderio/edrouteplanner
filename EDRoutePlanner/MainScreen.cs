﻿/* Copyright 2015 Oliver Kahrmann
 * 
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 * 
 *    http://www.apache.org/licenses/LICENSE-2.0
 * 
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;

namespace EDRoutePlanner
{
	public partial class MainScreen : Form
	{
		public List<Route> routes;
		public Route currentRoute;
		public Defaults defaults;
		public PilotData pilotData;
		public Data data;

		public int totalProfit = 0;

		private List<StationControl> stationControls;
		private StationSelection stationSelection;
		public CommoditySelection commoditySelection;
		private DefaultsForm defaultsForm;
		private EvaluateDestinationForm evaluateDestinationForm;

		public MainScreen()
		{
			loadDefaults();

			stationControls = new List<StationControl>();
			InitializeComponent();
			stationSelection = new StationSelection(this);
			commoditySelection = new CommoditySelection(this);
			defaultsForm = new DefaultsForm(this);
			evaluateDestinationForm = new EvaluateDestinationForm(this);

			loadPilotData();
			loadRouteData();

			forceReloadData();
			updateDisplay();
		}

		public void forceReloadData()
		{
			IDataSourceCommodities dsCommodities = new CmdrsLogCommoditiesData(defaults.pathCommodityData);
			IDataSourceStations dsStations;

			switch (defaults.typeStationData)
			{
				default:
				case DataSourceType.RegulatedNoise:
					dsStations = new RegulatedNoiseData(defaults.pathStationData);
					break;
				case DataSourceType.CmdrsLogV1:
					dsStations = new CmdrsLogStationData(defaults.pathStationData);
					break;

			}
			data = new Data(dsStations, dsCommodities);
			stationSelection.UpdateDisplay();
			commoditySelection.UpdateDisplay();

			fswCommodityData.Path = Util.GetFileDirectorySafe(defaults.pathCommodityData);
			fswCommodityData.Filter = Util.GetFileNameSafe(defaults.pathCommodityData);
			fswSystemData.Path = Util.GetFileDirectorySafe(defaults.pathStationData);
			fswSystemData.Filter = Util.GetFileNameSafe(defaults.pathStationData);
		}

		public void reloadData()
		{
			data.Reload();
			stationSelection.UpdateDisplay();
			commoditySelection.UpdateDisplay();
			updateDisplay();
		}

		public void updateDisplay()
		{
			if (currentRoute == null)
			{
				if (routes.Count == 0)
				{
					routes.Add(new Route());
				}
				currentRoute = routes[0];
			}
			totalProfit = 0;
			// Cut off controls we don't need anymore
			if (stationControls.Count > currentRoute.destinations.Count)
			{
				for (int i = stationControls.Count - 1; i >= currentRoute.destinations.Count; i--)
				{
					stationControls[i].Dispose();
					stationControls.RemoveAt(i);
				}
				stationControls.TrimExcess();
			}
			// Add missing controls & update existing ones
			stationControls.Capacity = currentRoute.destinations.Count;
			for (int i = 0; i < currentRoute.destinations.Count; i++)
			{
				StationControl ctrl;
				if (i >= stationControls.Count)
				{
					ctrl = new StationControl();
					stationControls.Add(ctrl);
					ctrl.mainScreen = this;
					ctrl.Parent = flowLayoutPanel1;
				}
				else
				{
					ctrl = stationControls[i];
				}
				ctrl.index = i;
				ctrl.destination = currentRoute.destinations[i];
				ctrl.updateDisplay();
				totalProfit += ctrl.overallProfit;
			}
			tbProfit.Text = totalProfit.ToString("N0");
			nudBalance.Value = pilotData.balance;
			nudMaxCargo.Value = pilotData.maxCargo;
			tbRouteName.Text = currentRoute.name;
			cbLoopRoute.Checked = currentRoute.loopRoute;
			saveRouteData();
			savePilotData();
		}

		#region Persistence

		public T loadFile<T>(string filename) where T : new() {
			T fileData = default(T);
			if(File.Exists(filename)) {
				XmlSerializer ser = new XmlSerializer(typeof(T));
				TextReader reader = new StreamReader(filename);
				fileData = (T)ser.Deserialize(reader);
				reader.Close();
			}
			if(fileData == null) {
				fileData = new T();
			}
			return fileData;
		}

		public void saveFile<T>(string filename, T fileData)
		{
			XmlSerializer ser = new XmlSerializer(typeof(T));
			TextWriter writer = new StreamWriter(filename);
			ser.Serialize(writer, fileData);
			writer.Close();
		}

		public void saveRouteData()
		{
			saveFile(Defaults.FILENAME_ROUTES, routes);
		}

		public void savePilotData()
		{
			saveFile(Defaults.FILENAME_PILOT_DATA, pilotData);
		}

		public void saveDefaults()
		{
			saveFile(Defaults.FILENAME_DEFAULTS, defaults);
		}

		public void loadRouteData()
		{
			routes = loadFile<List<Route>>(Defaults.FILENAME_ROUTES);
		}

		public void loadPilotData()
		{
			pilotData = loadFile<PilotData>(Defaults.FILENAME_PILOT_DATA);
		}

		public void loadDefaults()
		{
			defaults = loadFile<Defaults>(Defaults.FILENAME_DEFAULTS);
		}

		#endregion Persistence

		#region StationControl callbacks

		public void deleteDestination(int index)
		{
			currentRoute.destinations.RemoveAt(index);
			updateDisplay();
		}

		public void editDestination(int index)
		{
			if (stationSelection.ShowDialog(this) == DialogResult.OK)
			{
				Destination dest = currentRoute.destinations[index];
				dest.system = stationSelection.selectedSystem;
				dest.station = stationSelection.selectedStation;
				updateDisplay();
			}
		}

		public void insertDestination(int index)
		{
			if (stationSelection.ShowDialog(this) == DialogResult.OK)
			{
				Destination dest = new Destination(stationSelection.selectedSystem, stationSelection.selectedStation);
				currentRoute.destinations.Insert(index + 1, dest);
				updateDisplay();
			}
		}

		public void evaluateOptions(int index)
		{
			evaluateDestinationForm.index = index;
			evaluateDestinationForm.UpdateDisplay();
			evaluateDestinationForm.ShowDialog(this);
			updateDisplay();
		}

		public Destination getNextDestination(int index)
		{
			if (index < currentRoute.destinations.Count - 1)
			{
				return currentRoute.destinations[index + 1];
			}
			else if (currentRoute.loopRoute && index == currentRoute.destinations.Count - 1)
			{
				return currentRoute.destinations[0];
			}
			else
			{
				return null;
			}
		}

		#endregion StationControl callbacks

		#region Buttons
		
		private void btnDefaults_Click(object sender, EventArgs e)
		{
			defaultsForm.UpdateDisplay();
			defaultsForm.ShowDialog(this);
		}

		private void btnNewRoute_Click(object sender, EventArgs e)
		{

		}

		private void btnReloadTradeData_Click(object sender, EventArgs e)
		{
			reloadData();
		}

		private void btnAddDestination_Click(object sender, EventArgs e)
		{
			// Insert destination at last index
			insertDestination(currentRoute.destinations.Count - 1);
		}

		private void btnPayDay_Click(object sender, EventArgs e)
		{
			pilotData.balance += totalProfit;
			updateDisplay();
		}

		#endregion Buttons

		private void lvRoutes_SelectedIndexChanged(object sender, EventArgs e)
		{

		}

		#region Data Fields

		private void nudMaxCargo_ValueChanged(object sender, EventArgs e)
		{
			pilotData.maxCargo = (int)nudMaxCargo.Value;
			updateDisplay();
		}

		private void nudBalance_ValueChanged(object sender, EventArgs e)
		{
			pilotData.balance = (int)nudBalance.Value;
			updateDisplay();
		}

		private void tbRouteName_TextChanged(object sender, EventArgs e)
		{
			currentRoute.name = tbRouteName.Text;
			updateDisplay();
		}

		private void cbLoopRoute_CheckedChanged(object sender, EventArgs e)
		{
			currentRoute.loopRoute = cbLoopRoute.Checked;
			updateDisplay();
		}

		#endregion Data Fields

		private void MainScreen_Load(object sender, EventArgs e)
		{
			lblCopyright.Text = String.Format("{0} {1}\n{2}", BuildInfo.AssemblyTitle, BuildInfo.AssemblyVersion, BuildInfo.AssemblyCopyright);
			this.Icon = Properties.Resources.Icon;
		}

		private void fswCommodityData_Changed(object sender, FileSystemEventArgs e)
		{
			reloadData();
		}

		private void fswSystemData_Changed(object sender, FileSystemEventArgs e)
		{
			reloadData();
		}


	}
}
