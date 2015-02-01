namespace EDRoutePlanner
{
	partial class EvaluateDestinationControl
	{
		/// <summary> 
		/// Erforderliche Designervariable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Verwendete Ressourcen bereinigen.
		/// </summary>
		/// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Vom Komponenten-Designer generierter Code

		/// <summary> 
		/// Erforderliche Methode für die Designerunterstützung. 
		/// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
		/// </summary>
		private void InitializeComponent()
		{
			this.listView1 = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
			this.lblSystemName = new System.Windows.Forms.Label();
			this.lblStationName = new System.Windows.Forms.Label();
			this.pbStationImage = new System.Windows.Forms.PictureBox();
			this.btnReplace = new System.Windows.Forms.Button();
			this.btnInsert = new System.Windows.Forms.Button();
			this.lblProfit = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.pbStationImage)).BeginInit();
			this.SuspendLayout();
			// 
			// listView1
			// 
			this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
			this.listView1.FullRowSelect = true;
			this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.listView1.Location = new System.Drawing.Point(47, 3);
			this.listView1.MultiSelect = false;
			this.listView1.Name = "listView1";
			this.listView1.Size = new System.Drawing.Size(451, 85);
			this.listView1.TabIndex = 8;
			this.listView1.UseCompatibleStateImageBehavior = false;
			this.listView1.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "Commodity";
			this.columnHeader1.Width = 130;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Amount";
			this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.columnHeader2.Width = 80;
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "Profit per Unit";
			this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.columnHeader3.Width = 100;
			// 
			// columnHeader4
			// 
			this.columnHeader4.Text = "Profit";
			this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.columnHeader4.Width = 100;
			// 
			// lblSystemName
			// 
			this.lblSystemName.AutoSize = true;
			this.lblSystemName.Location = new System.Drawing.Point(41, 91);
			this.lblSystemName.Name = "lblSystemName";
			this.lblSystemName.Size = new System.Drawing.Size(72, 13);
			this.lblSystemName.TabIndex = 7;
			this.lblSystemName.Text = "System Name";
			// 
			// lblStationName
			// 
			this.lblStationName.AutoSize = true;
			this.lblStationName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblStationName.Location = new System.Drawing.Point(41, 104);
			this.lblStationName.Name = "lblStationName";
			this.lblStationName.Size = new System.Drawing.Size(134, 24);
			this.lblStationName.TabIndex = 5;
			this.lblStationName.Text = "Station Name";
			// 
			// pbStationImage
			// 
			this.pbStationImage.Image = global::EDRoutePlanner.Properties.Resources.station;
			this.pbStationImage.Location = new System.Drawing.Point(3, 96);
			this.pbStationImage.Name = "pbStationImage";
			this.pbStationImage.Size = new System.Drawing.Size(32, 32);
			this.pbStationImage.TabIndex = 6;
			this.pbStationImage.TabStop = false;
			// 
			// btnReplace
			// 
			this.btnReplace.Location = new System.Drawing.Point(349, 123);
			this.btnReplace.Name = "btnReplace";
			this.btnReplace.Size = new System.Drawing.Size(146, 23);
			this.btnReplace.TabIndex = 9;
			this.btnReplace.Text = "Replace next Destination";
			this.btnReplace.UseVisualStyleBackColor = true;
			this.btnReplace.Click += new System.EventHandler(this.btnReplace_Click);
			// 
			// btnInsert
			// 
			this.btnInsert.Location = new System.Drawing.Point(349, 94);
			this.btnInsert.Name = "btnInsert";
			this.btnInsert.Size = new System.Drawing.Size(146, 23);
			this.btnInsert.TabIndex = 10;
			this.btnInsert.Text = "Insert next Destination";
			this.btnInsert.UseVisualStyleBackColor = true;
			this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
			// 
			// lblProfit
			// 
			this.lblProfit.AutoSize = true;
			this.lblProfit.Location = new System.Drawing.Point(44, 128);
			this.lblProfit.Name = "lblProfit";
			this.lblProfit.Size = new System.Drawing.Size(57, 13);
			this.lblProfit.TabIndex = 11;
			this.lblProfit.Text = "Profit: N/A";
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.label1.Location = new System.Drawing.Point(0, 149);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(498, 1);
			this.label1.TabIndex = 12;
			// 
			// EvaluateDestinationControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.label1);
			this.Controls.Add(this.lblProfit);
			this.Controls.Add(this.btnInsert);
			this.Controls.Add(this.btnReplace);
			this.Controls.Add(this.listView1);
			this.Controls.Add(this.lblSystemName);
			this.Controls.Add(this.lblStationName);
			this.Controls.Add(this.pbStationImage);
			this.Name = "EvaluateDestinationControl";
			this.Size = new System.Drawing.Size(498, 150);
			((System.ComponentModel.ISupportInitialize)(this.pbStationImage)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ListView listView1;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private System.Windows.Forms.Label lblSystemName;
		private System.Windows.Forms.Label lblStationName;
		private System.Windows.Forms.PictureBox pbStationImage;
		private System.Windows.Forms.Button btnReplace;
		private System.Windows.Forms.Button btnInsert;
		private System.Windows.Forms.Label lblProfit;
		private System.Windows.Forms.Label label1;
	}
}
