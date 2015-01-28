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
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EDRoutePlanner
{
	public partial class CommoditySelection : Form
	{
		public string selectedCommodity;
		public int selectedAmount;
		public int maxCargo;

		public MainScreen mainScreen;

		public StationData stationData;
		public StationData nextStationData;

		public CommoditySelection(MainScreen mainScreen)
		{
			this.mainScreen = mainScreen;
			InitializeComponent();
		}

		public void UpdateDisplay()
		{
			listView1.Items.Clear();
			listView1.Groups.Clear();
			foreach (KeyValuePair<string, string[]> commodityGroup in mainScreen.data.commodities)
			{
				ListViewGroup group = listView1.Groups.Add(commodityGroup.Key, commodityGroup.Key);

				foreach (string commodity in commodityGroup.Value)
				{
					int profitPer = 0;
					string priceBuy = "";
					string priceSell = "";
					string demand = "";

					if (stationData != null)
					{
						CommodityPrice ourPrice = stationData.GetPrice(commodity);
						if (ourPrice != null)
						{
							if (ourPrice.priceBuy > 0)
							{
								priceBuy = ourPrice.priceBuy.ToString("N0");
							}
							if (ourPrice.priceSell > 0)
							{
								priceSell = ourPrice.priceSell.ToString("N0");
							}
							demand = ourPrice.demandType.ToString();
						}
						if (nextStationData != null)
						{
							CommodityPrice theirPrice = nextStationData.GetPrice(commodity);
							if (ourPrice != null && theirPrice != null && theirPrice.priceSell > 0 && ourPrice.priceBuy > 0)
							{
								profitPer = theirPrice.priceSell - ourPrice.priceBuy;
							}
						}
					}
					int profit = profitPer * (selectedAmount == 0 ? maxCargo : selectedAmount);

					ListViewItem li = new ListViewItem(new string[] {
						commodity,
						demand,
						priceSell,
						priceBuy,
						profitPer.ToString("N0"),
						profit.ToString("N0")
					}, group);
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
		}

		private void btnUseSelected_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.OK;
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
		}

		private void listView1_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (listView1.SelectedItems.Count == 0)
			{
				btnUseSelected.Enabled = false;
			}
			else
			{
				btnUseSelected.Enabled = true;
				selectedCommodity = listView1.SelectedItems[0].Text;
			}
		}

		private void numericUpDown1_ValueChanged(object sender, EventArgs e)
		{
			selectedAmount = (int)numericUpDown1.Value;
			UpdateDisplay();
		}

		private void listView1_DoubleClick(object sender, EventArgs e)
		{
			submit();
		}

		private void submit()
		{
			if (btnUseSelected.Enabled && selectedCommodity != null)
			{
				this.DialogResult = DialogResult.OK;
				this.Close();
			}
		}

		private void listView1_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Return || e.KeyCode == Keys.Enter)
			{
				submit();
			}
		}

		private void CommoditySelection_Load(object sender, EventArgs e)
		{
			this.Icon = Properties.Resources.Icon;
		}
	}
}
