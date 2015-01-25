namespace EDRoutePlanner
{
	partial class StationSelection
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
			this.listView1 = new System.Windows.Forms.ListView();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnUseSelected = new System.Windows.Forms.Button();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.SuspendLayout();
			// 
			// listView1
			// 
			this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
			this.listView1.Location = new System.Drawing.Point(12, 12);
			this.listView1.Name = "listView1";
			this.listView1.Size = new System.Drawing.Size(260, 203);
			this.listView1.TabIndex = 0;
			this.listView1.UseCompatibleStateImageBehavior = false;
			this.listView1.View = System.Windows.Forms.View.Details;
			this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(197, 227);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 1;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnUseSelected
			// 
			this.btnUseSelected.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnUseSelected.Location = new System.Drawing.Point(53, 227);
			this.btnUseSelected.Name = "btnUseSelected";
			this.btnUseSelected.Size = new System.Drawing.Size(138, 23);
			this.btnUseSelected.TabIndex = 2;
			this.btnUseSelected.Text = "Use Selected Station";
			this.btnUseSelected.UseVisualStyleBackColor = true;
			this.btnUseSelected.Click += new System.EventHandler(this.btnUseSelected_Click);
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "Station Name";
			this.columnHeader1.Width = 200;
			// 
			// StationSelection
			// 
			this.AcceptButton = this.btnUseSelected;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(284, 262);
			this.Controls.Add(this.btnUseSelected);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.listView1);
			this.Name = "StationSelection";
			this.Text = "Select a Station";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ListView listView1;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnUseSelected;
		private System.Windows.Forms.ColumnHeader columnHeader1;
	}
}