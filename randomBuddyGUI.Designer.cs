
namespace randomBuddy
{
	partial class randomBuddyGUI
	{
		private System.ComponentModel.IContainer components = null;
		
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		private void InitializeComponent()
		{
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.blackspots = new System.Windows.Forms.CheckBox();
			this.optimize = new System.Windows.Forms.CheckBox();
			this.more_random = new System.Windows.Forms.CheckBox();
			this.key = new System.Windows.Forms.TextBox();
			this.save_close = new System.Windows.Forms.Button();
			//this.label5 = new System.Windows.Forms.Label();
			//this.xmlFile = new System.Windows.Forms.TextBox();
			this.amount = new System.Windows.Forms.NumericUpDown();
			this.refreshmins = new System.Windows.Forms.NumericUpDown();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.freebag = new System.Windows.Forms.NumericUpDown();
			this.label10 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.durability = new System.Windows.Forms.DomainUpDown();
			this.zone = new System.Windows.Forms.CheckedListBox();
			this.route_optimize = new System.Windows.Forms.CheckBox();
			((System.ComponentModel.ISupportInitialize)(this.amount)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.refreshmins)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.freebag)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(12, 12);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(65, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "API Key:";
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(12, 35);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(65, 23);
			this.label2.TabIndex = 1;
			this.label2.Text = "Zone:";
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(12, 58);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(90, 23);
			this.label3.TabIndex = 2;
			this.label3.Text = "# of Hotspots:";
			// 
			// blackspots
			// 
			this.blackspots.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.blackspots.Location = new System.Drawing.Point(15, 128);
			this.blackspots.Name = "blackspots";
			this.blackspots.Size = new System.Drawing.Size(123, 24);
			this.blackspots.TabIndex = 5;
			this.blackspots.Text = "add Blackspots";
			this.blackspots.UseVisualStyleBackColor = true;
			// 
			// optimize
			// 
			this.optimize.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.optimize.Location = new System.Drawing.Point(315, 128);
			this.optimize.Name = "optimize";
			this.optimize.Size = new System.Drawing.Size(77, 24);
			this.optimize.TabIndex = 7;
			this.optimize.Text = "optimize";
			this.optimize.UseVisualStyleBackColor = true;
			// 
			// more_random
			// 
			this.more_random.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.more_random.Location = new System.Drawing.Point(156, 128);
			this.more_random.Name = "more_random";
			this.more_random.Size = new System.Drawing.Size(149, 24);
			this.more_random.TabIndex = 6;
			this.more_random.Text = "add random Offsets";
			this.more_random.UseVisualStyleBackColor = true;
			// 
			// key
			// 
			this.key.Location = new System.Drawing.Point(112, 11);
			this.key.Name = "key";
			this.key.Size = new System.Drawing.Size(276, 20);
			this.key.TabIndex = 1;
			this.key.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.key.DoubleClick += new System.EventHandler(this.KeyDoubleClick);
			this.key.MouseEnter += new System.EventHandler(this.key_Enter);
			// 
			// save_close
			// 
			this.save_close.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.save_close.Location = new System.Drawing.Point(140, 252);
			this.save_close.Name = "save_close";
			this.save_close.Size = new System.Drawing.Size(136, 33);
			this.save_close.TabIndex = 10;
			this.save_close.Text = "Save and Close";
			this.save_close.UseVisualStyleBackColor = true;
			this.save_close.Click += new System.EventHandler(this.Save_closeClick);
			// 
			// label5
			// 
			//this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			//this.label5.Location = new System.Drawing.Point(12, 158);
			//this.label5.Name = "label5";
			//this.label5.Size = new System.Drawing.Size(90, 23);
			//this.label5.TabIndex = 12;
			//this.label5.Text = "Profile Name:";
			// 
			// xmlFile
			// 
			//this.xmlFile.Location = new System.Drawing.Point(112, 157);
			//this.xmlFile.Name = "xmlFile";
			//this.xmlFile.Size = new System.Drawing.Size(276, 20);
			//this.xmlFile.TabIndex = 8;
			//this.xmlFile.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			//this.xmlFile.MouseEnter += new System.EventHandler(this.xmlFile_Enter);
			// 
			// amount
			// 
			this.amount.Location = new System.Drawing.Point(112, 57);
			this.amount.Maximum = new decimal(new int[] {
									85,
									0,
									0,
									0});
			this.amount.Minimum = new decimal(new int[] {
									5,
									0,
									0,
									0});
			this.amount.Name = "amount";
			this.amount.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.amount.Size = new System.Drawing.Size(276, 20);
			this.amount.TabIndex = 3;
			this.amount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.amount.Value = new decimal(new int[] {
									85,
									0,
									0,
									0});
			// 
			// refreshmins
			// 
			this.refreshmins.Location = new System.Drawing.Point(112, 187);
			this.refreshmins.Maximum = new decimal(new int[] {
									30,
									0,
									0,
									0});
			this.refreshmins.Minimum = new decimal(new int[] {
									5,
									0,
									0,
									0});
			this.refreshmins.Name = "refreshmins";
			this.refreshmins.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.refreshmins.Size = new System.Drawing.Size(276, 20);
			this.refreshmins.TabIndex = 9;
			this.refreshmins.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.refreshmins.Value = new decimal(new int[] {
									10,
									0,
									0,
									0});
			// 
			// label6
			// 
			this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label6.Location = new System.Drawing.Point(12, 181);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(96, 39);
			this.label6.TabIndex = 16;
			this.label6.Text = "Refresh Profile every X min:";
			// 
			// label7
			// 
			this.label7.ForeColor = System.Drawing.Color.BlueViolet;
			this.label7.Location = new System.Drawing.Point(13, 265);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(100, 23);
			this.label7.TabIndex = 17;
			this.label7.Text = "created by piotr55";
			// 
			// label8
			// 
			this.label8.ForeColor = System.Drawing.Color.BlueViolet;
			this.label8.Location = new System.Drawing.Point(309, 265);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(88, 23);
			this.label8.TabIndex = 19;
			this.label8.Text = "credits to roboto";
			// 
			// freebag
			// 
			this.freebag.Location = new System.Drawing.Point(112, 80);
			this.freebag.Name = "freebag";
			this.freebag.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.freebag.Size = new System.Drawing.Size(276, 20);
			this.freebag.TabIndex = 22;
			this.freebag.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.freebag.Value = new decimal(new int[] {
									1,
									0,
									0,
									0});
			// 
			// label10
			// 
			this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label10.Location = new System.Drawing.Point(12, 81);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(96, 23);
			this.label10.TabIndex = 21;
			this.label10.Text = "Min. Bag Slots:";
			// 
			// label11
			// 
			this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label11.Location = new System.Drawing.Point(12, 104);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(96, 23);
			this.label11.TabIndex = 23;
			this.label11.Text = "Min. Durability:";
			// 
			// durability
			// 
			this.durability.BackColor = System.Drawing.SystemColors.Window;
			this.durability.Items.Add("1.0");
			this.durability.Items.Add("0.9");
			this.durability.Items.Add("0.8");
			this.durability.Items.Add("0.7");
			this.durability.Items.Add("0.6");
			this.durability.Items.Add("0.5");
			this.durability.Items.Add("0.4");
			this.durability.Items.Add("0.3");
			this.durability.Items.Add("0.2");
			this.durability.Items.Add("0.1");
			this.durability.Location = new System.Drawing.Point(112, 103);
			this.durability.Name = "durability";
			this.durability.ReadOnly = true;
			this.durability.SelectedIndex = 6;
			this.durability.Size = new System.Drawing.Size(276, 20);
			this.durability.TabIndex = 25;
			this.durability.Text = "0.4";
			this.durability.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// zone
			// 
			this.zone.FormattingEnabled = true;
			this.zone.Location = new System.Drawing.Point(112, 34);
			this.zone.Name = "zone";
			this.zone.Size = new System.Drawing.Size(276, 19);
			this.zone.TabIndex = 2;
			this.zone.Click += new System.EventHandler(this.ZoneClick);
			this.zone.Leave += new System.EventHandler(this.ZoneLeave);
			this.zone.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ZoneMouseDown);
			// 
			// route_optimize
			// 
			this.route_optimize.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.route_optimize.Location = new System.Drawing.Point(15, 220);
			this.route_optimize.Name = "route_optimize";
			this.route_optimize.Size = new System.Drawing.Size(389, 24);
			this.route_optimize.TabIndex = 27;
			this.route_optimize.Text = "use Optimization based on current Player Position";
			this.route_optimize.UseVisualStyleBackColor = true;
			// 
			// randomBuddyGUI
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(400, 294);
			this.Controls.Add(this.route_optimize);
			this.Controls.Add(this.zone);
			this.Controls.Add(this.durability);
			this.Controls.Add(this.label11);
			this.Controls.Add(this.freebag);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.refreshmins);
			this.Controls.Add(this.amount);
			//this.Controls.Add(this.xmlFile);
			//this.Controls.Add(this.label5);
			this.Controls.Add(this.save_close);
			this.Controls.Add(this.key);
			this.Controls.Add(this.more_random);
			this.Controls.Add(this.optimize);
			this.Controls.Add(this.blackspots);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "randomBuddyGUI";
			this.ShowIcon = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "randomBuddy Settings";
			this.Load += new System.EventHandler(this.RandomBuddyGUILoad);
			this.Click += new System.EventHandler(this.RandomBuddyGUIClick);
			((System.ComponentModel.ISupportInitialize)(this.amount)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.refreshmins)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.freebag)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.CheckBox route_optimize;
		private System.Windows.Forms.CheckedListBox zone;
		private System.Windows.Forms.DomainUpDown durability;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.NumericUpDown freebag;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.NumericUpDown refreshmins;
		//private System.Windows.Forms.TextBox xmlFile;
		//private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Button save_close;
		private System.Windows.Forms.NumericUpDown amount;
		private System.Windows.Forms.TextBox key;
		private System.Windows.Forms.CheckBox more_random;
		private System.Windows.Forms.CheckBox optimize;
		private System.Windows.Forms.CheckBox blackspots;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		
	}
}
