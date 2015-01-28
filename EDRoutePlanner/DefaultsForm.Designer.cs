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
namespace EDRoutePlanner
{
	partial class DefaultsForm
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
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnSave = new System.Windows.Forms.Button();
			this.btnReload = new System.Windows.Forms.Button();
			this.tbStationData = new System.Windows.Forms.TextBox();
			this.cbTypeStation = new System.Windows.Forms.ComboBox();
			this.tbCommodityData = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.btnBrowseCommodity = new System.Windows.Forms.Button();
			this.buttonBrowseStation = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(556, 96);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 0;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnSave
			// 
			this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSave.Location = new System.Drawing.Point(475, 96);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(75, 23);
			this.btnSave.TabIndex = 1;
			this.btnSave.Text = "Save";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// btnReload
			// 
			this.btnReload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnReload.Location = new System.Drawing.Point(12, 96);
			this.btnReload.Name = "btnReload";
			this.btnReload.Size = new System.Drawing.Size(157, 23);
			this.btnReload.TabIndex = 7;
			this.btnReload.Text = "Reload Defaults from Disk";
			this.btnReload.UseVisualStyleBackColor = true;
			this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
			// 
			// tbStationData
			// 
			this.tbStationData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.tbStationData.Location = new System.Drawing.Point(166, 41);
			this.tbStationData.Name = "tbStationData";
			this.tbStationData.Size = new System.Drawing.Size(263, 20);
			this.tbStationData.TabIndex = 4;
			// 
			// cbTypeStation
			// 
			this.cbTypeStation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.cbTypeStation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbTypeStation.FormattingEnabled = true;
			this.cbTypeStation.Items.AddRange(new object[] {
            "RegulatedNoise csv",
            "Cmdrs Log txt"});
			this.cbTypeStation.Location = new System.Drawing.Point(497, 41);
			this.cbTypeStation.Name = "cbTypeStation";
			this.cbTypeStation.Size = new System.Drawing.Size(121, 21);
			this.cbTypeStation.TabIndex = 6;
			// 
			// tbCommodityData
			// 
			this.tbCommodityData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.tbCommodityData.Location = new System.Drawing.Point(166, 12);
			this.tbCommodityData.Name = "tbCommodityData";
			this.tbCommodityData.Size = new System.Drawing.Size(263, 20);
			this.tbCommodityData.TabIndex = 2;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(29, 15);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(131, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Load commodity data from";
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(473, 15);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(88, 13);
			this.label2.TabIndex = 0;
			this.label2.Text = "as Cmdrs Log txt.";
			// 
			// btnBrowseCommodity
			// 
			this.btnBrowseCommodity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnBrowseCommodity.Location = new System.Drawing.Point(435, 10);
			this.btnBrowseCommodity.Name = "btnBrowseCommodity";
			this.btnBrowseCommodity.Size = new System.Drawing.Size(32, 23);
			this.btnBrowseCommodity.TabIndex = 3;
			this.btnBrowseCommodity.Text = "...";
			this.btnBrowseCommodity.UseVisualStyleBackColor = true;
			this.btnBrowseCommodity.Click += new System.EventHandler(this.btnBrowseCommodity_Click);
			// 
			// buttonBrowseStation
			// 
			this.buttonBrowseStation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonBrowseStation.Location = new System.Drawing.Point(435, 39);
			this.buttonBrowseStation.Name = "buttonBrowseStation";
			this.buttonBrowseStation.Size = new System.Drawing.Size(32, 23);
			this.buttonBrowseStation.TabIndex = 5;
			this.buttonBrowseStation.Text = "...";
			this.buttonBrowseStation.UseVisualStyleBackColor = true;
			this.buttonBrowseStation.Click += new System.EventHandler(this.buttonBrowseStation_Click);
			// 
			// label3
			// 
			this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(473, 44);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(18, 13);
			this.label3.TabIndex = 0;
			this.label3.Text = "as";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(12, 44);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(148, 13);
			this.label4.TabIndex = 0;
			this.label4.Text = "Load station && trade data from";
			// 
			// DefaultsForm
			// 
			this.AcceptButton = this.btnSave;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(643, 131);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.buttonBrowseStation);
			this.Controls.Add(this.btnBrowseCommodity);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.tbCommodityData);
			this.Controls.Add(this.cbTypeStation);
			this.Controls.Add(this.tbStationData);
			this.Controls.Add(this.btnReload);
			this.Controls.Add(this.btnSave);
			this.Controls.Add(this.btnCancel);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MinimizeBox = false;
			this.Name = "DefaultsForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Defaults";
			this.Load += new System.EventHandler(this.DefaultsForm_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.Button btnReload;
		private System.Windows.Forms.TextBox tbStationData;
		private System.Windows.Forms.ComboBox cbTypeStation;
		private System.Windows.Forms.TextBox tbCommodityData;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button btnBrowseCommodity;
		private System.Windows.Forms.Button buttonBrowseStation;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
	}
}