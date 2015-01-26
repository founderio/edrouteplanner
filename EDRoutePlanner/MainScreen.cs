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

		
		public int maxCargo = 4;
		public int balance = 1000;
		public int totalProfit = 0;


		public Data data;

		public StationSelection stationSelection;
		public CommoditySelection commoditySelection;

		public MainScreen()
		{
			stationControls = new List<StationControl>();
			CmdrsLogData cmdrsLogData = new CmdrsLogData("C:\\Users\\Oliver\\Downloads\\Cmdr's Log v1.6b\\Cmdr's Log v1.6b");
			RegulatedNoiseData regulatedNoiseData = new RegulatedNoiseData("C:\\Users\\Oliver\\Downloads\\RegulatedNoise.v1.83\\AutoSave.csv");
			data = new Data(regulatedNoiseData, cmdrsLogData);
			InitializeComponent();
			stationSelection = new StationSelection(data);
			commoditySelection = new CommoditySelection(data);
			loadRouteData();
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
			tbProfit.Text = totalProfit.ToString();
			nudBalance.Value = balance;
			nudMaxCargo.Value = maxCargo;
			tbRouteName.Text = currentRoute.name;
			cbLoopRoute.Checked = currentRoute.loopRoute;
			saveRouteData();
		}

		public void saveRouteData()
		{
			XmlSerializer ser = new XmlSerializer(typeof(List<Route>));
			TextWriter writer = new StreamWriter("routes.xml");
			ser.Serialize(writer, routes);
			writer.Close();
		}

		public void loadRouteData()
		{
			if (File.Exists("routes.xml"))
			{
				XmlSerializer ser = new XmlSerializer(typeof(List<Route>));
				TextReader reader = new StreamReader("routes.xml");
				routes = (List<Route>)ser.Deserialize(reader);
				reader.Close();
			}
			if (routes == null)
			{
				routes = new List<Route>();
			}
		}

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
			}
			updateDisplay();
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
			if (index < currentRoute.destinations.Count - 1 || (currentRoute.loopRoute && index == currentRoute.destinations.Count - 1))
			{
				return currentRoute.destinations[index + 1];
			}
			else
			{
				return null;
			}
		}

		private void btnAddDestination_Click(object sender, EventArgs e)
		{
			// Insert destination at last index
			insertDestination(currentRoute.destinations.Count - 1);
		}

		private void btnPayDay_Click(object sender, EventArgs e)
		{
			balance += totalProfit;
			updateDisplay();
		}

		private void nudMaxCargo_ValueChanged(object sender, EventArgs e)
		{
			maxCargo = (int)nudMaxCargo.Value;
			updateDisplay();
		}

		private void nudBalance_ValueChanged(object sender, EventArgs e)
		{
			balance = (int)nudBalance.Value;
			updateDisplay();
		}

		private void btnReloadTradeData_Click(object sender, EventArgs e)
		{
			data.Reload();
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

		private void lvRoutes_SelectedIndexChanged(object sender, EventArgs e)
		{

		}
	}
}
