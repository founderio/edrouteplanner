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

		public CmdrsLogData data;

		public CommoditySelection(CmdrsLogData data)
		{
			this.data = data;
			InitializeComponent();
			updateDisplay();
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
		}

		public void updateDisplay()
		{
			listView1.Items.Clear();
			listView1.Groups.Clear();
			foreach (KeyValuePair<string, string[]> commodityGroup in data.commodities)
			{
				ListViewGroup group = listView1.Groups.Add(commodityGroup.Key, commodityGroup.Key);

				foreach (string commodity in commodityGroup.Value)
				{
					listView1.Items.Add(new ListViewItem(commodity, group));
				}
			}
		}
	}
}
