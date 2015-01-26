using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EDRoutePlanner
{
	public partial class StationControl : UserControl
	{
		public int index = 0;
		public int overallProfit = 0;
		public Destination destination;

		public MainScreen mainScreen;

		public StationControl()
		{
			InitializeComponent();
		}

		public void updateDisplay()
		{
			lblStationName.Text = destination.station;
			lblSystemName.Text = destination.system;

			listView1.Items.Clear();
			overallProfit = 0;

			Destination nextDestination = mainScreen.getNextDestination(index);
			StationData stationData = mainScreen.data.GetStation(destination.system, destination.station);
			StationData nextStationData = null;

			if (nextDestination != null)
			{
				nextStationData = mainScreen.data.GetStation(nextDestination.system, nextDestination.station);
			}

			foreach (Transaction transaction in destination.transactions)
			{
				int profitPer = 0;

				if (stationData != null && nextStationData != null)
				{
					CommodityPrice ourPrice = stationData.GetPrice(transaction.commodity);
					CommodityPrice theirPrice = nextStationData.GetPrice(transaction.commodity);
					//TODO: Check Demand types?
					if (ourPrice != null && theirPrice != null && ourPrice.price > 0 && theirPrice.price > 0)
					{
						profitPer = theirPrice.price - ourPrice.price;
					}
				}

				int profit = profitPer * transaction.amount;
				overallProfit += profit;
				ListViewItem li = new ListViewItem(new string[] {
					transaction.commodity,
					transaction.amount.ToString(),
					profitPer.ToString(),
					profit.ToString()
				});

				if (profit == 0)
				{
					li.BackColor = Color.Yellow;
					li.ForeColor = Color.OrangeRed;
				}
				else if (profit < 0)
				{
					li.BackColor = Color.Red;
					li.ForeColor = Color.Yellow;
				}
				else
				{
					li.BackColor = Color.Green;
					li.ForeColor = Color.LightGreen;
				}
				listView1.Items.Add(li);
			}
		}

		private void btnDelDestination_Click(object sender, EventArgs e)
		{
			mainScreen.deleteDestination(index);
		}

		private void lblStationName_DoubleClick(object sender, EventArgs e)
		{
			mainScreen.editDestination(index);
		}

		private void pbStationImage_DoubleClick(object sender, EventArgs e)
		{
			mainScreen.editDestination(index);
		}

		private void btnInsertDestination_Click(object sender, EventArgs e)
		{
			mainScreen.insertDestination(index);
		}

		private void btnEvaluateOptions_Click(object sender, EventArgs e)
		{
			mainScreen.evaluateOptions(index);
		}

		private void btnAddTransaction_Click(object sender, EventArgs e)
		{
			Destination nextDestination = mainScreen.getNextDestination(index);
			StationData stationData = mainScreen.data.GetStation(destination.system, destination.station);
			StationData nextStationData = null;

			if (nextDestination != null)
			{
				nextStationData = mainScreen.data.GetStation(nextDestination.system, nextDestination.station);
			}
			mainScreen.commoditySelection.stationData = stationData;
			mainScreen.commoditySelection.nextStationData = nextStationData;
			mainScreen.commoditySelection.maxCargo = mainScreen.maxCargo;
			mainScreen.commoditySelection.updateDisplay();

			if (mainScreen.commoditySelection.ShowDialog(mainScreen) == DialogResult.OK)
			{
				Transaction ta = new Transaction();
				ta.amount = mainScreen.commoditySelection.selectedAmount;
				if (ta.amount == 0)
				{
					ta.amount = mainScreen.maxCargo;
				}
				ta.commodity = mainScreen.commoditySelection.selectedCommodity;
				destination.transactions.Add(ta);
				mainScreen.updateDisplay();
			}
		}

		private void btnDelTransaction_Click(object sender, EventArgs e)
		{
			if (listView1.SelectedIndices.Count > 0)
			{
				destination.transactions.RemoveAt(listView1.SelectedIndices[0]);
				mainScreen.updateDisplay();
			}
		}
	}
}
