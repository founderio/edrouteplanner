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

			//TODO: update transaction list
		}

		private void btnDelDestination_Click(object sender, EventArgs e)
		{
			mainScreen.deleteDestination(index);
		}

		private void btnEditDestination_Click(object sender, EventArgs e)
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
			//TODO: Implement
		}

		private void btnDelTransaction_Click(object sender, EventArgs e)
		{
			//TODO: Implement
		}
	}
}
