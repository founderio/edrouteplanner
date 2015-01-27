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
	public partial class StationSelection : Form
	{
		public string selectedSystem;
		public string selectedStation;

		public MainScreen mainScreen;

		public StationSelection(MainScreen mainScreen)
		{
			this.mainScreen = mainScreen;
			InitializeComponent();
			updateDisplay();
		}

		public void updateDisplay()
		{
			listView1.Items.Clear();
			listView1.Groups.Clear();
			foreach(SystemData system in mainScreen.data.systems.Values) {
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

		private void submit()
		{
			if (btnUseSelected.Enabled && selectedStation != null && selectedSystem != null)
			{
				this.DialogResult = DialogResult.OK;
				this.Close();
			}
		}

		private void listView1_DoubleClick(object sender, EventArgs e)
		{
			submit();
		}

		private void listView1_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Return || e.KeyCode == Keys.Enter)
			{
				submit();
			}
		}
	}
}
