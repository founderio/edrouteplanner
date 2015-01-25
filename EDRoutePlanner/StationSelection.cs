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
	public partial class StationSelection : Form
	{
		public string selectedSystem;
		public string selectedStation;

		public Data data;

		public StationSelection(Data data)
		{
			this.data = data;
			InitializeComponent();
			updateDisplay();
		}

		public void updateDisplay()
		{
			listView1.Items.Clear();
			listView1.Groups.Clear();
			foreach(SystemData system in data.systems.Values) {
				ListViewGroup group = listView1.Groups.Add(system.name, system.name);
				
				foreach (StationData station in system.stations.Values)
				{
					listView1.Items.Add(new ListViewItem(station.name, group));
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
			if(listView1.SelectedItems.Count == 0) {
				btnUseSelected.Enabled = false;
				selectedSystem = null;
				selectedStation = null;
			} else {
				btnUseSelected.Enabled = true;
				selectedStation = listView1.SelectedItems[0].Text;
				selectedSystem = listView1.SelectedItems[0].Group.Header;
			}
		}
	}
}
