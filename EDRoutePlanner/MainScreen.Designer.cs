namespace EDRoutePlanner
{
	partial class MainScreen
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.lvRoutes = new System.Windows.Forms.ListView();
			this.splitContainer2 = new System.Windows.Forms.SplitContainer();
			this.panel1 = new System.Windows.Forms.Panel();
			this.btnDefaults = new System.Windows.Forms.Button();
			this.btnNewRoute = new System.Windows.Forms.Button();
			this.cbLoopRoute = new System.Windows.Forms.CheckBox();
			this.label4 = new System.Windows.Forms.Label();
			this.tbRouteName = new System.Windows.Forms.TextBox();
			this.btnReloadTradeData = new System.Windows.Forms.Button();
			this.btnPayDay = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.tbProfit = new System.Windows.Forms.TextBox();
			this.nudBalance = new System.Windows.Forms.NumericUpDown();
			this.label2 = new System.Windows.Forms.Label();
			this.nudMaxCargo = new System.Windows.Forms.NumericUpDown();
			this.label1 = new System.Windows.Forms.Label();
			this.lblCopyright = new System.Windows.Forms.Label();
			this.btnAddDestination = new System.Windows.Forms.Button();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.splitContainer2.Panel1.SuspendLayout();
			this.splitContainer2.Panel2.SuspendLayout();
			this.splitContainer2.SuspendLayout();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudBalance)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nudMaxCargo)).BeginInit();
			this.SuspendLayout();
			// 
			// flowLayoutPanel1
			// 
			this.flowLayoutPanel1.AutoScroll = true;
			this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Size = new System.Drawing.Size(524, 500);
			this.flowLayoutPanel1.TabIndex = 0;
			this.flowLayoutPanel1.WrapContents = false;
			// 
			// splitContainer1
			// 
			this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(0, 0);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.lvRoutes);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
			this.splitContainer1.Size = new System.Drawing.Size(949, 502);
			this.splitContainer1.SplitterDistance = 191;
			this.splitContainer1.TabIndex = 1;
			// 
			// lvRoutes
			// 
			this.lvRoutes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.lvRoutes.Location = new System.Drawing.Point(-1, -1);
			this.lvRoutes.Name = "lvRoutes";
			this.lvRoutes.Size = new System.Drawing.Size(191, 502);
			this.lvRoutes.TabIndex = 0;
			this.lvRoutes.UseCompatibleStateImageBehavior = false;
			this.lvRoutes.View = System.Windows.Forms.View.List;
			this.lvRoutes.SelectedIndexChanged += new System.EventHandler(this.lvRoutes_SelectedIndexChanged);
			// 
			// splitContainer2
			// 
			this.splitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
			this.splitContainer2.IsSplitterFixed = true;
			this.splitContainer2.Location = new System.Drawing.Point(0, 0);
			this.splitContainer2.Name = "splitContainer2";
			// 
			// splitContainer2.Panel1
			// 
			this.splitContainer2.Panel1.Controls.Add(this.flowLayoutPanel1);
			// 
			// splitContainer2.Panel2
			// 
			this.splitContainer2.Panel2.Controls.Add(this.panel1);
			this.splitContainer2.Size = new System.Drawing.Size(754, 502);
			this.splitContainer2.SplitterDistance = 526;
			this.splitContainer2.TabIndex = 0;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.lblCopyright);
			this.panel1.Controls.Add(this.btnDefaults);
			this.panel1.Controls.Add(this.btnNewRoute);
			this.panel1.Controls.Add(this.cbLoopRoute);
			this.panel1.Controls.Add(this.label4);
			this.panel1.Controls.Add(this.tbRouteName);
			this.panel1.Controls.Add(this.btnReloadTradeData);
			this.panel1.Controls.Add(this.btnPayDay);
			this.panel1.Controls.Add(this.btnAddDestination);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Controls.Add(this.tbProfit);
			this.panel1.Controls.Add(this.nudBalance);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.nudMaxCargo);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(222, 500);
			this.panel1.TabIndex = 0;
			// 
			// btnDefaults
			// 
			this.btnDefaults.Location = new System.Drawing.Point(91, 11);
			this.btnDefaults.Name = "btnDefaults";
			this.btnDefaults.Size = new System.Drawing.Size(120, 23);
			this.btnDefaults.TabIndex = 14;
			this.btnDefaults.Text = "Defaults";
			this.btnDefaults.UseVisualStyleBackColor = true;
			this.btnDefaults.Click += new System.EventHandler(this.btnDefaults_Click);
			// 
			// btnNewRoute
			// 
			this.btnNewRoute.Enabled = false;
			this.btnNewRoute.Location = new System.Drawing.Point(3, 40);
			this.btnNewRoute.Name = "btnNewRoute";
			this.btnNewRoute.Size = new System.Drawing.Size(82, 23);
			this.btnNewRoute.TabIndex = 13;
			this.btnNewRoute.Text = "New Route";
			this.btnNewRoute.UseVisualStyleBackColor = true;
			this.btnNewRoute.Click += new System.EventHandler(this.btnNewRoute_Click);
			// 
			// cbLoopRoute
			// 
			this.cbLoopRoute.AutoSize = true;
			this.cbLoopRoute.Enabled = false;
			this.cbLoopRoute.Location = new System.Drawing.Point(91, 95);
			this.cbLoopRoute.Name = "cbLoopRoute";
			this.cbLoopRoute.Size = new System.Drawing.Size(82, 17);
			this.cbLoopRoute.TabIndex = 12;
			this.cbLoopRoute.Text = "Loop Route";
			this.cbLoopRoute.UseVisualStyleBackColor = true;
			this.cbLoopRoute.CheckedChanged += new System.EventHandler(this.cbLoopRoute_CheckedChanged);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(3, 72);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(67, 13);
			this.label4.TabIndex = 11;
			this.label4.Text = "Route Name";
			// 
			// tbRouteName
			// 
			this.tbRouteName.Location = new System.Drawing.Point(91, 69);
			this.tbRouteName.Name = "tbRouteName";
			this.tbRouteName.Size = new System.Drawing.Size(120, 20);
			this.tbRouteName.TabIndex = 10;
			this.tbRouteName.TextChanged += new System.EventHandler(this.tbRouteName_TextChanged);
			// 
			// btnReloadTradeData
			// 
			this.btnReloadTradeData.Location = new System.Drawing.Point(91, 40);
			this.btnReloadTradeData.Name = "btnReloadTradeData";
			this.btnReloadTradeData.Size = new System.Drawing.Size(120, 23);
			this.btnReloadTradeData.TabIndex = 9;
			this.btnReloadTradeData.Text = "Reload Trade Data";
			this.btnReloadTradeData.UseVisualStyleBackColor = true;
			this.btnReloadTradeData.Click += new System.EventHandler(this.btnReloadTradeData_Click);
			// 
			// btnPayDay
			// 
			this.btnPayDay.Location = new System.Drawing.Point(6, 173);
			this.btnPayDay.Name = "btnPayDay";
			this.btnPayDay.Size = new System.Drawing.Size(79, 23);
			this.btnPayDay.TabIndex = 8;
			this.btnPayDay.Text = "Payday";
			this.btnPayDay.UseVisualStyleBackColor = true;
			this.btnPayDay.Click += new System.EventHandler(this.btnPayDay_Click);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(3, 150);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(31, 13);
			this.label3.TabIndex = 6;
			this.label3.Text = "Profit";
			// 
			// tbProfit
			// 
			this.tbProfit.Location = new System.Drawing.Point(91, 147);
			this.tbProfit.Name = "tbProfit";
			this.tbProfit.Size = new System.Drawing.Size(120, 20);
			this.tbProfit.TabIndex = 5;
			// 
			// nudBalance
			// 
			this.nudBalance.Location = new System.Drawing.Point(91, 228);
			this.nudBalance.Maximum = new decimal(new int[] {
            -727379968,
            232,
            0,
            0});
			this.nudBalance.Name = "nudBalance";
			this.nudBalance.Size = new System.Drawing.Size(120, 20);
			this.nudBalance.TabIndex = 4;
			this.nudBalance.ValueChanged += new System.EventHandler(this.nudBalance_ValueChanged);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(3, 230);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(46, 13);
			this.label2.TabIndex = 3;
			this.label2.Text = "Balance";
			// 
			// nudMaxCargo
			// 
			this.nudMaxCargo.Location = new System.Drawing.Point(91, 202);
			this.nudMaxCargo.Maximum = new decimal(new int[] {
            -727379968,
            232,
            0,
            0});
			this.nudMaxCargo.Name = "nudMaxCargo";
			this.nudMaxCargo.Size = new System.Drawing.Size(120, 20);
			this.nudMaxCargo.TabIndex = 2;
			this.nudMaxCargo.ValueChanged += new System.EventHandler(this.nudMaxCargo_ValueChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(3, 204);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(58, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Max Cargo";
			// 
			// lblCopyright
			// 
			this.lblCopyright.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.lblCopyright.AutoSize = true;
			this.lblCopyright.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblCopyright.ForeColor = System.Drawing.SystemColors.GrayText;
			this.lblCopyright.Location = new System.Drawing.Point(3, 480);
			this.lblCopyright.Name = "lblCopyright";
			this.lblCopyright.Size = new System.Drawing.Size(63, 12);
			this.lblCopyright.TabIndex = 15;
			this.lblCopyright.Text = "Copyright Info";
			// 
			// btnAddDestination
			// 
			this.btnAddDestination.Image = global::EDRoutePlanner.Properties.Resources.flag;
			this.btnAddDestination.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnAddDestination.Location = new System.Drawing.Point(91, 118);
			this.btnAddDestination.Name = "btnAddDestination";
			this.btnAddDestination.Size = new System.Drawing.Size(120, 23);
			this.btnAddDestination.TabIndex = 7;
			this.btnAddDestination.Text = "Add Destination";
			this.btnAddDestination.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnAddDestination.UseVisualStyleBackColor = true;
			this.btnAddDestination.Click += new System.EventHandler(this.btnAddDestination_Click);
			// 
			// MainScreen
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(949, 502);
			this.Controls.Add(this.splitContainer1);
			this.MinimumSize = new System.Drawing.Size(965, 320);
			this.Name = "MainScreen";
			this.Text = "EDRoutePlanner";
			this.Load += new System.EventHandler(this.MainScreen_Load);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.ResumeLayout(false);
			this.splitContainer2.Panel1.ResumeLayout(false);
			this.splitContainer2.Panel2.ResumeLayout(false);
			this.splitContainer2.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudBalance)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nudMaxCargo)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.SplitContainer splitContainer2;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox tbProfit;
		private System.Windows.Forms.NumericUpDown nudBalance;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.NumericUpDown nudMaxCargo;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnAddDestination;
		private System.Windows.Forms.Button btnPayDay;
		private System.Windows.Forms.Button btnReloadTradeData;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox tbRouteName;
		private System.Windows.Forms.CheckBox cbLoopRoute;
		private System.Windows.Forms.ListView lvRoutes;
		private System.Windows.Forms.Button btnNewRoute;
		private System.Windows.Forms.Button btnDefaults;
		private System.Windows.Forms.Label lblCopyright;
	}
}