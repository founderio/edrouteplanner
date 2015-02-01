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

		public MainScreen mainScreen;

		public StationData stationData;
		public StationData nextStationData;

		private CommoditySorter sorter;

		public CommoditySelection(MainScreen mainScreen)
		{
			this.mainScreen = mainScreen;
			InitializeComponent();
			sorter = new CommoditySorter();
			listView1.ListViewItemSorter = sorter;
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
					CommodityPrice ourPrice = null;
					CommodityPrice theirPrice = null;
					if (stationData != null)
					{
						ourPrice = stationData.GetPrice(commodity);
						if (nextStationData != null)
						{
							theirPrice = nextStationData.GetPrice(commodity);
						}
					}
					int amount = selectedAmount == 0 ? mainScreen.pilotData.maxCargo : selectedAmount;
					ComparedCommodity compared = new ComparedCommodity(commodity, amount, ourPrice, theirPrice);

					ListViewItem li = new ListViewItem(new string[] {
						compared.Commodity,
						compared.Demand,
						compared.PriceSell,
						compared.PriceBuy,
						compared.ProfitPer,
						compared.Profit
					}, group);
					li.Tag = compared;
					if (compared.profitPer == 0)
					{
						//li.BackColor = Color.Yellow;
						//li.ForeColor = Color.OrangeRed;
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

		private int sortedColumn = -1;

		private void listView1_ColumnClick(object sender, ColumnClickEventArgs e)
		{
			if (e.Column == sortedColumn)
			{
				if (sorter.sortOrder == SortOrder.None)
				{
					listView1.ShowGroups = false;
					sorter.sortOrder = SortOrder.Ascending;
				}
				else if (sorter.sortOrder == SortOrder.Ascending)
				{
					listView1.ShowGroups = false;
					sorter.sortOrder = SortOrder.Descending;
				}
				else
				{
					listView1.ShowGroups = true;
					sorter.sortOrder = SortOrder.None;
					sorter.criteria = CommoditySorterCriteria.Group;
					UpdateDisplay();
				}
			}
			else
			{
				sortedColumn = e.Column;
				sorter.sortOrder = SortOrder.Ascending;
				listView1.ShowGroups = false;
				switch (e.Column)
				{
					case 0:
						sorter.criteria = CommoditySorterCriteria.Commodity;
						break;
					case 1:
						sorter.criteria = CommoditySorterCriteria.Demand;
						break;
					case 2:
						sorter.criteria = CommoditySorterCriteria.PriceSell;
						break;
					case 3:
						sorter.criteria = CommoditySorterCriteria.PriceBuy;
						break;
					case 4:
					case 5:
						sorter.criteria = CommoditySorterCriteria.Profit;
						break;
					default:
						break;
				}
			}
			listView1.ListViewItemSorter = sorter;
			listView1.Sort();
		}
	}
}
