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
		private const string FILENAME_PILOT_DATA = "pilot.xml";
		private const string FILENAME_ROUTES = "routes.xml";
		private const string FILENAME_DEFAULTS = "defaults.xml";


		private List<Route> routes;
		private Route currentRoute;

		public class Route
		{
			public String name;
			public List<Destination> destinations;
			public bool loopRoute = false;

			public Route()
			{
				this.name = "New Route";
				destinations = new List<Destination>();
			}
		}

		private List<StationControl> stationControls;

		public int totalProfit = 0;

		public Defaults defaults;
		public PilotData pilotData;

		public Data data;

		public StationSelection stationSelection;
		public CommoditySelection commoditySelection;
		public DefaultsForm defaultsForm;

		public MainScreen()
		{
			loadDefaults();
			loadPilotData();
			stationControls = new List<StationControl>();
			InitializeComponent();
			forceReloadData();
			stationSelection = new StationSelection(this);
			commoditySelection = new CommoditySelection(this);
			defaultsForm = new DefaultsForm(this);
			loadRouteData();
			updateDisplay();
		}

		public void forceReloadData()
		{
			IDataSourceCommodities dsCommodities;
			IDataSourceStations dsStations;
			CmdrsLogCommoditiesData cmdrsLogData = new CmdrsLogCommoditiesData(defaults.pathCommodityData);
			dsCommodities = cmdrsLogData;

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
			tbProfit.Text = totalProfit.ToString();
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
			saveFile(FILENAME_ROUTES, routes);
		}

		public void savePilotData()
		{
			saveFile(FILENAME_PILOT_DATA, pilotData);
		}

		public void saveDefaults()
		{
			saveFile(FILENAME_DEFAULTS, defaults);
		}

		public void loadRouteData()
		{
			routes = loadFile<List<Route>>(FILENAME_ROUTES);
		}

		public void loadPilotData()
		{
			pilotData = loadFile<PilotData>(FILENAME_PILOT_DATA);
		}

		public void loadDefaults()
		{
			defaults = loadFile<Defaults>(FILENAME_DEFAULTS);
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
				Destination dest = new Destination();
				dest.system = stationSelection.selectedSystem;
				dest.station = stationSelection.selectedStation;
				currentRoute.destinations.Insert(index + 1, dest);
				updateDisplay();
			}
		}

		public void evaluateOptions(int index)
		{

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
			data.Reload();
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


	}
}
