/* Copyright 2015 Oliver Kahrmann
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
				ComparedCommodity compared = new ComparedCommodity(transaction.commodity, transaction.GetAmount(mainScreen.pilotData.maxCargo), ourPrice, theirPrice);

				overallProfit += compared.profit;
				ListViewItem li = new ListViewItem(new string[] {
					transaction.commodity,
					transaction.amount == 0 ? String.Format("MAX ({0:0})", mainScreen.pilotData.maxCargo) : transaction.amount.ToString("N0"),
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
			mainScreen.commoditySelection.UpdateDisplay();

			if (mainScreen.commoditySelection.ShowDialog(mainScreen) == DialogResult.OK)
			{
				Transaction ta = new Transaction();
				ta.amount = mainScreen.commoditySelection.selectedAmount;
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
