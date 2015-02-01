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
	public partial class EvaluateDestinationForm : Form
	{
		public int index = 0;
		public int showResults = 50;
		public bool respectBalance = false;
		public bool sliceTransactions = false;
		public MainScreen mainScreen;
		private List<EvaluateDestinationControl> destinationControls;
		private List<Evaluation> evaluations;

		public EvaluateDestinationForm(MainScreen mainScreen)
		{
			this.mainScreen = mainScreen;
			destinationControls = new List<EvaluateDestinationControl>();
			evaluations = new List<Evaluation>();
			InitializeComponent();
		}

		private class Evaluation
		{
			public Destination destination;
			public Destination nextDestination;
			public int profit;

			public Evaluation(Destination destination, Destination nextDestination, int profit)
			{
				this.destination = destination;
				this.nextDestination = nextDestination;
				this.profit = profit;
			}
		}

		private class EvaluationSorter : IComparer<Evaluation>
		{
			public int Compare(Evaluation x, Evaluation y)
			{
				return y.profit - x.profit;
			}
		}

		public void UpdateDisplay()
		{
			evaluations.Clear();
			Destination currentData = mainScreen.currentRoute.destinations[index];
			StationData currentStation = mainScreen.data.GetStation(currentData.system, currentData.station);
			CommoditySorter sorter = new CommoditySorter();
			sorter.criteria = CommoditySorterCriteria.Profit;
			sorter.sortOrder = SortOrder.Descending;
			foreach (StationData station in mainScreen.data.Stations)
			{
				if (station == currentStation)
				{
					continue;
				}
				List<ComparedCommodity> compared = new List<ComparedCommodity>();
				int amount = mainScreen.pilotData.maxCargo;
				foreach (string commodity in mainScreen.data.allCommodities)
				{
					compared.Add(new ComparedCommodity(commodity, amount, currentStation.GetPrice(commodity), station.GetPrice(commodity)));
				}
				compared.Sort(sorter);
				Destination destination = new Destination(currentData);
				int profit = 0;
				if(respectBalance) {
					if(sliceTransactions) {
						//TODO: go from most to least profitable and add transactions with as much as we can afford
					} else {
						//TODO: go from most to least profitable and add a single transaction once we can afford a full load.
					}
					//TODO: What to do if we cannot afford anything? Fallback?
				} else {
					ComparedCommodity comm = compared.First();
					profit += comm.profitPer * amount;
					destination.transactions.Add(new Transaction(comm.commodity, 0));
				}
				evaluations.Add(new Evaluation(destination, new Destination(station), profit));
			}
			evaluations.Sort(new EvaluationSorter());

			if (evaluations.Count > showResults)
			{
				evaluations.RemoveRange(evaluations.Count, evaluations.Count - showResults);
			}

			// Cut off controls we don't need anymore
			if (destinationControls.Count > evaluations.Count)
			{
				for (int i = destinationControls.Count - 1; i >= evaluations.Count; i--)
				{
					destinationControls[i].Dispose();
					destinationControls.RemoveAt(i);
				}
				destinationControls.TrimExcess();
			}
			// Add missing controls & update existing ones
			destinationControls.Capacity = evaluations.Count;
			for (int i = 0; i < evaluations.Count; i++)
			{
				EvaluateDestinationControl ctrl;
				if (i >= destinationControls.Count)
				{
					ctrl = new EvaluateDestinationControl(this);
					destinationControls.Add(ctrl);
					ctrl.Parent = flowLayoutPanel1;
				}
				else
				{
					ctrl = destinationControls[i];
				}
				ctrl.index = i;
				ctrl.destination = evaluations[i].destination;
				ctrl.nextDestination = evaluations[i].nextDestination;
				ctrl.updateDisplay();
			}
		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
		}

		public void InsertDestination(Destination destination, Destination nextDestination)
		{
			mainScreen.currentRoute.destinations[index].transactions = destination.transactions;
			mainScreen.currentRoute.destinations.Insert(index + 1, nextDestination);
			this.DialogResult = DialogResult.OK;
			Close();
		}

		public void ReplaceDestination(Destination destination, Destination nextDestination)
		{
			if (index + 1 >= mainScreen.currentRoute.destinations.Count)
			{
				if (mainScreen.currentRoute.loopRoute)
				{
					mainScreen.currentRoute.destinations[index].transactions = destination.transactions;
					nextDestination.transactions = mainScreen.currentRoute.destinations[0].transactions;
					mainScreen.currentRoute.destinations[0] = nextDestination;
				}
				else
				{
					InsertDestination(destination, nextDestination);
				}
			}
			else
			{
				mainScreen.currentRoute.destinations[index].transactions = destination.transactions;
				nextDestination.transactions = mainScreen.currentRoute.destinations[index + 1].transactions;
				mainScreen.currentRoute.destinations[index + 1] = nextDestination;
			}
			this.DialogResult = DialogResult.OK;
			Close();
		}
	}
}
