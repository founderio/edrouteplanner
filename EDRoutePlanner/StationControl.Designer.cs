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
	partial class StationControl
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
			this.components = new System.ComponentModel.Container();
			this.lblStationName = new System.Windows.Forms.Label();
			this.lblSystemName = new System.Windows.Forms.Label();
			this.listView1 = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.btnInsertDestination = new System.Windows.Forms.Button();
			this.btnEvaluateOptions = new System.Windows.Forms.Button();
			this.btnAddTransaction = new System.Windows.Forms.Button();
			this.btnDelTransaction = new System.Windows.Forms.Button();
			this.btnDelDestination = new System.Windows.Forms.Button();
			this.pbStationImage = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.pbStationImage)).BeginInit();
			this.SuspendLayout();
			// 
			// lblStationName
			// 
			this.lblStationName.AutoSize = true;
			this.lblStationName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblStationName.Location = new System.Drawing.Point(41, 16);
			this.lblStationName.Name = "lblStationName";
			this.lblStationName.Size = new System.Drawing.Size(134, 24);
			this.lblStationName.TabIndex = 1;
			this.lblStationName.Text = "Station Name";
			this.lblStationName.DoubleClick += new System.EventHandler(this.lblStationName_DoubleClick);
			// 
			// lblSystemName
			// 
			this.lblSystemName.AutoSize = true;
			this.lblSystemName.Location = new System.Drawing.Point(41, 3);
			this.lblSystemName.Name = "lblSystemName";
			this.lblSystemName.Size = new System.Drawing.Size(72, 13);
			this.lblSystemName.TabIndex = 2;
			this.lblSystemName.Text = "System Name";
			// 
			// listView1
			// 
			this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
			this.listView1.FullRowSelect = true;
			this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.listView1.Location = new System.Drawing.Point(44, 43);
			this.listView1.MultiSelect = false;
			this.listView1.Name = "listView1";
			this.listView1.Size = new System.Drawing.Size(451, 85);
			this.listView1.TabIndex = 3;
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
			// btnInsertDestination
			// 
			this.btnInsertDestination.Image = global::EDRoutePlanner.Properties.Resources.flag;
			this.btnInsertDestination.Location = new System.Drawing.Point(3, 75);
			this.btnInsertDestination.Name = "btnInsertDestination";
			this.btnInsertDestination.Size = new System.Drawing.Size(35, 23);
			this.btnInsertDestination.TabIndex = 8;
			this.toolTip1.SetToolTip(this.btnInsertDestination, "Insert a new destination after this one");
			this.btnInsertDestination.UseVisualStyleBackColor = true;
			this.btnInsertDestination.Click += new System.EventHandler(this.btnInsertDestination_Click);
			// 
			// btnEvaluateOptions
			// 
			this.btnEvaluateOptions.Enabled = false;
			this.btnEvaluateOptions.Image = global::EDRoutePlanner.Properties.Resources.compass;
			this.btnEvaluateOptions.Location = new System.Drawing.Point(3, 134);
			this.btnEvaluateOptions.Name = "btnEvaluateOptions";
			this.btnEvaluateOptions.Size = new System.Drawing.Size(35, 23);
			this.btnEvaluateOptions.TabIndex = 7;
			this.toolTip1.SetToolTip(this.btnEvaluateOptions, "Evaluate Options");
			this.btnEvaluateOptions.UseVisualStyleBackColor = true;
			this.btnEvaluateOptions.Click += new System.EventHandler(this.btnEvaluateOptions_Click);
			// 
			// btnAddTransaction
			// 
			this.btnAddTransaction.Image = global::EDRoutePlanner.Properties.Resources.insert_row;
			this.btnAddTransaction.Location = new System.Drawing.Point(44, 134);
			this.btnAddTransaction.Name = "btnAddTransaction";
			this.btnAddTransaction.Size = new System.Drawing.Size(35, 23);
			this.btnAddTransaction.TabIndex = 6;
			this.toolTip1.SetToolTip(this.btnAddTransaction, "Insert Transaction");
			this.btnAddTransaction.UseVisualStyleBackColor = true;
			this.btnAddTransaction.Click += new System.EventHandler(this.btnAddTransaction_Click);
			// 
			// btnDelTransaction
			// 
			this.btnDelTransaction.Image = global::EDRoutePlanner.Properties.Resources.delete_row;
			this.btnDelTransaction.Location = new System.Drawing.Point(85, 134);
			this.btnDelTransaction.Name = "btnDelTransaction";
			this.btnDelTransaction.Size = new System.Drawing.Size(35, 23);
			this.btnDelTransaction.TabIndex = 5;
			this.toolTip1.SetToolTip(this.btnDelTransaction, "Remove selected Transaction");
			this.btnDelTransaction.UseVisualStyleBackColor = true;
			this.btnDelTransaction.Click += new System.EventHandler(this.btnDelTransaction_Click);
			// 
			// btnDelDestination
			// 
			this.btnDelDestination.Image = global::EDRoutePlanner.Properties.Resources.denied;
			this.btnDelDestination.Location = new System.Drawing.Point(3, 46);
			this.btnDelDestination.Name = "btnDelDestination";
			this.btnDelDestination.Size = new System.Drawing.Size(35, 23);
			this.btnDelDestination.TabIndex = 4;
			this.toolTip1.SetToolTip(this.btnDelDestination, "Remove this destination");
			this.btnDelDestination.UseVisualStyleBackColor = true;
			this.btnDelDestination.Click += new System.EventHandler(this.btnDelDestination_Click);
			// 
			// pbStationImage
			// 
			this.pbStationImage.Image = global::EDRoutePlanner.Properties.Resources.station;
			this.pbStationImage.Location = new System.Drawing.Point(3, 8);
			this.pbStationImage.Name = "pbStationImage";
			this.pbStationImage.Size = new System.Drawing.Size(32, 32);
			this.pbStationImage.TabIndex = 0;
			this.pbStationImage.TabStop = false;
			this.pbStationImage.DoubleClick += new System.EventHandler(this.pbStationImage_DoubleClick);
			// 
			// StationControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.btnInsertDestination);
			this.Controls.Add(this.btnEvaluateOptions);
			this.Controls.Add(this.btnAddTransaction);
			this.Controls.Add(this.btnDelTransaction);
			this.Controls.Add(this.btnDelDestination);
			this.Controls.Add(this.listView1);
			this.Controls.Add(this.lblSystemName);
			this.Controls.Add(this.lblStationName);
			this.Controls.Add(this.pbStationImage);
			this.Name = "StationControl";
			this.Size = new System.Drawing.Size(498, 162);
			((System.ComponentModel.ISupportInitialize)(this.pbStationImage)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox pbStationImage;
		private System.Windows.Forms.Label lblStationName;
		private System.Windows.Forms.Label lblSystemName;
		private System.Windows.Forms.ListView listView1;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private System.Windows.Forms.Button btnDelDestination;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.Button btnDelTransaction;
		private System.Windows.Forms.Button btnAddTransaction;
		private System.Windows.Forms.Button btnEvaluateOptions;
		private System.Windows.Forms.Button btnInsertDestination;
	}
}
