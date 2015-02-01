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
	public partial class EvaluateDestinationControl : UserControl
	{
		public int index = 0;
		public int overallProfit = 0;
		public Destination destination;
		public Destination nextDestination;

		public EvaluateDestinationForm form;
		public EvaluateDestinationControl(EvaluateDestinationForm form)
		{
			this.form = form;
			InitializeComponent();
		}

		public void updateDisplay()
		{
			lblStationName.Text = nextDestination.station;
			lblSystemName.Text = nextDestination.system;

			listView1.Items.Clear();
			overallProfit = 0;

			StationData stationData = form.mainScreen.data.GetStation(destination.system, destination.station);
			StationData nextStationData = null;

			if (nextDestination != null)
			{
				nextStationData = form.mainScreen.data.GetStation(nextDestination.system, nextDestination.station);
			}

			foreach (Transaction transaction in destination.transactions)
			{
				CommodityPrice ourPrice = null;
				CommodityPrice theirPrice = null;
				if (stationData != null)
				{
					ourPrice = stationData.GetPrice(transaction.commodity);
					if (nextStationData != null)
					{
						theirPrice = nextStationData.GetPrice(transaction.commodity);
					}
				}
				ComparedCommodity compared = new ComparedCommodity(transaction.commodity, transaction.GetAmount(form.mainScreen.pilotData.maxCargo), ourPrice, theirPrice);

				overallProfit += compared.profit;
				ListViewItem li = new ListViewItem(new string[] {
					transaction.commodity,
					transaction.amount == 0 ? String.Format("MAX ({0:N0})", form.mainScreen.pilotData.maxCargo) : transaction.amount.ToString("N0"),
					compared.ProfitPer,
					compared.Profit
				});

				if (compared.profitPer == 0)
				{
					li.BackColor = Color.Yellow;
					li.ForeColor = Color.OrangeRed;
				}
				else if (compared.profitPer < 0)
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
			lblProfit.Text = String.Format("Profit: ({0:N0})", overallProfit);
		}

		private void btnInsert_Click(object sender, EventArgs e)
		{
			form.InsertDestination(destination, nextDestination);
		}

		private void btnReplace_Click(object sender, EventArgs e)
		{
			form.ReplaceDestination(destination, nextDestination);
		}
	}
}
