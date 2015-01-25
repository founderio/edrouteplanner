using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EDRoutePlanner
{
	public partial class MainScreen : Form
	{
		private List<StationControl> stationControls;

		private List<Destination> destinations;

		public bool loopRoute = false;

		public CmdrsLogData data;

		public StationSelection stationSelection;

		public MainScreen()
		{
			destinations = new List<Destination>();
			stationControls = new List<StationControl>();
			data = new CmdrsLogData("C:\\Users\\Oliver\\Downloads\\Cmdr's Log v1.6b\\Cmdr's Log v1.6b");
			InitializeComponent();
			stationSelection = new StationSelection(data);
		}

		public void updateDisplay()
		{
			// Cut off controls we don't need anymore
			if (stationControls.Count > destinations.Count)
			{
				for (int i = stationControls.Count - 1; i >= destinations.Count; i--)
				{
					stationControls[i].Dispose();
					stationControls.RemoveAt(i);
				}
				stationControls.TrimExcess();
			}
			// Add missing controls & update existing ones
			stationControls.Capacity = destinations.Count;
			for (int i = 0; i < destinations.Count; i++)
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
				ctrl.destination = destinations[i];
				ctrl.updateDisplay();
			}
		}

		public void deleteDestination(int index)
		{
			destinations.RemoveAt(index);
			updateDisplay();
		}

		public void editDestination(int index)
		{
			if (stationSelection.ShowDialog(this) == DialogResult.OK)
			{
				Destination dest = destinations[index];
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
				destinations.Insert(index + 1, dest);
				updateDisplay();
			}
		}

		public void evaluateOptions(int index)
		{

		}

		public Destination getNextDestination(int index)
		{
			if (index < destinations.Count - 1 || (loopRoute && index == destinations.Count - 1))
			{
				return destinations[index + 1];
			}
			else
			{
				return null;
			}
		}

		private void btnAddDestination_Click(object sender, EventArgs e)
		{
			// Insert destination at last index
			insertDestination(destinations.Count - 1);
		}
	}
}
