namespace DVLD
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.pnlTopBanner = new System.Windows.Forms.Panel();
            this.btnAccSettings = new System.Windows.Forms.Button();
            this.btnUsers = new System.Windows.Forms.Button();
            this.btnDrivers = new System.Windows.Forms.Button();
            this.btnApplication = new System.Windows.Forms.Button();
            this.btnPeople = new System.Windows.Forms.Button();
            this.uctrlAddPerson1 = new DVLD.uctrlAddPerson();
            this.pnlTopBanner.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTopBanner
            // 
            this.pnlTopBanner.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(237)))), ((int)(((byte)(243)))));
            this.pnlTopBanner.Controls.Add(this.btnAccSettings);
            this.pnlTopBanner.Controls.Add(this.btnUsers);
            this.pnlTopBanner.Controls.Add(this.btnDrivers);
            this.pnlTopBanner.Controls.Add(this.btnApplication);
            this.pnlTopBanner.Controls.Add(this.btnPeople);
            this.pnlTopBanner.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopBanner.Location = new System.Drawing.Point(0, 0);
            this.pnlTopBanner.Margin = new System.Windows.Forms.Padding(2);
            this.pnlTopBanner.Name = "pnlTopBanner";
            this.pnlTopBanner.Size = new System.Drawing.Size(1047, 48);
            this.pnlTopBanner.TabIndex = 0;
            // 
            // btnAccSettings
            // 
            this.btnAccSettings.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAccSettings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(237)))), ((int)(((byte)(243)))));
            this.btnAccSettings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnAccSettings.FlatAppearance.BorderSize = 0;
            this.btnAccSettings.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnAccSettings.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnAccSettings.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btnAccSettings.Image = ((System.Drawing.Image)(resources.GetObject("btnAccSettings.Image")));
            this.btnAccSettings.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAccSettings.Location = new System.Drawing.Point(382, 2);
            this.btnAccSettings.Margin = new System.Windows.Forms.Padding(2);
            this.btnAccSettings.Name = "btnAccSettings";
            this.btnAccSettings.Size = new System.Drawing.Size(143, 44);
            this.btnAccSettings.TabIndex = 3;
            this.btnAccSettings.Text = "Account Settings";
            this.btnAccSettings.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAccSettings.UseVisualStyleBackColor = false;
            this.btnAccSettings.Click += new System.EventHandler(this.btnAccSettings_Click);
            // 
            // btnUsers
            // 
            this.btnUsers.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnUsers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(237)))), ((int)(((byte)(243)))));
            this.btnUsers.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnUsers.FlatAppearance.BorderSize = 0;
            this.btnUsers.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnUsers.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnUsers.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btnUsers.Image = global::DVLD.Properties.Resources.Admin_Settings_Male;
            this.btnUsers.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUsers.Location = new System.Drawing.Point(291, 2);
            this.btnUsers.Margin = new System.Windows.Forms.Padding(2);
            this.btnUsers.Name = "btnUsers";
            this.btnUsers.Size = new System.Drawing.Size(87, 44);
            this.btnUsers.TabIndex = 3;
            this.btnUsers.Text = "Users";
            this.btnUsers.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUsers.UseVisualStyleBackColor = false;
            this.btnUsers.Click += new System.EventHandler(this.btnUsers_Click);
            // 
            // btnDrivers
            // 
            this.btnDrivers.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnDrivers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(237)))), ((int)(((byte)(243)))));
            this.btnDrivers.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnDrivers.FlatAppearance.BorderSize = 0;
            this.btnDrivers.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnDrivers.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnDrivers.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btnDrivers.Image = global::DVLD.Properties.Resources.Driver_License;
            this.btnDrivers.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDrivers.Location = new System.Drawing.Point(201, 2);
            this.btnDrivers.Margin = new System.Windows.Forms.Padding(2);
            this.btnDrivers.Name = "btnDrivers";
            this.btnDrivers.Size = new System.Drawing.Size(86, 44);
            this.btnDrivers.TabIndex = 2;
            this.btnDrivers.Text = "Drivers";
            this.btnDrivers.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDrivers.UseVisualStyleBackColor = false;
            this.btnDrivers.Click += new System.EventHandler(this.btnDrivers_Click);
            // 
            // btnApplication
            // 
            this.btnApplication.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnApplication.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(237)))), ((int)(((byte)(243)))));
            this.btnApplication.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnApplication.FlatAppearance.BorderSize = 0;
            this.btnApplication.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnApplication.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnApplication.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btnApplication.Image = global::DVLD.Properties.Resources.Document;
            this.btnApplication.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnApplication.Location = new System.Drawing.Point(4, 2);
            this.btnApplication.Margin = new System.Windows.Forms.Padding(2);
            this.btnApplication.Name = "btnApplication";
            this.btnApplication.Size = new System.Drawing.Size(104, 44);
            this.btnApplication.TabIndex = 0;
            this.btnApplication.Text = "Application";
            this.btnApplication.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnApplication.UseVisualStyleBackColor = false;
            this.btnApplication.Click += new System.EventHandler(this.btnApplication_Click);
            // 
            // btnPeople
            // 
            this.btnPeople.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnPeople.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(237)))), ((int)(((byte)(243)))));
            this.btnPeople.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnPeople.FlatAppearance.BorderSize = 0;
            this.btnPeople.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnPeople.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnPeople.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btnPeople.Image = global::DVLD.Properties.Resources.People;
            this.btnPeople.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPeople.Location = new System.Drawing.Point(112, 2);
            this.btnPeople.Margin = new System.Windows.Forms.Padding(2);
            this.btnPeople.Name = "btnPeople";
            this.btnPeople.Size = new System.Drawing.Size(85, 44);
            this.btnPeople.TabIndex = 1;
            this.btnPeople.Text = "People";
            this.btnPeople.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPeople.UseVisualStyleBackColor = false;
            this.btnPeople.Click += new System.EventHandler(this.btnManagePeople_Click);
            // 
            // uctrlAddPerson1
            // 
            this.uctrlAddPerson1.BackColor = System.Drawing.Color.White;
            this.uctrlAddPerson1.Location = new System.Drawing.Point(215, 124);
            this.uctrlAddPerson1.Margin = new System.Windows.Forms.Padding(2);
            this.uctrlAddPerson1.Name = "uctrlAddPerson1";
            this.uctrlAddPerson1.Size = new System.Drawing.Size(640, 296);
            this.uctrlAddPerson1.TabIndex = 1;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(14)))), ((int)(((byte)(21)))));
            this.BackgroundImage = global::DVLD.Properties.Resources._87f519db_8efe_46d1_8881_9e7d58b3e705_1_;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(1047, 503);
            this.Controls.Add(this.uctrlAddPerson1);
            this.Controls.Add(this.pnlTopBanner);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.pnlTopBanner.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTopBanner;
        private System.Windows.Forms.Button btnPeople;
        private System.Windows.Forms.Button btnApplication;
        private System.Windows.Forms.Button btnDrivers;
        private System.Windows.Forms.Button btnUsers;
        private System.Windows.Forms.Button btnAccSettings;
        private uctrlAddPerson uctrlAddPerson1;
    }
}

