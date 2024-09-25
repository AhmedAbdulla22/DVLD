namespace DVLD.ApplicationForms
{
    partial class LocalDLA
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
            this.components = new System.ComponentModel.Container();
            this.lblFormLabel = new System.Windows.Forms.Label();
            this.tbFilter = new System.Windows.Forms.TextBox();
            this.cbFilter = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblRecords = new System.Windows.Forms.Label();
            this.dgvLocalDLA = new System.Windows.Forms.DataGridView();
            this.cbStatusFilter = new System.Windows.Forms.ComboBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ShowApplicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.editApplicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteApplicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.cancelApplicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.scheduleTestsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scheduleVisonTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scheduleWrittenTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scheduleStreetTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.issueDrivingLicenseFirstTimeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripSeparator();
            this.showLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripSeparator();
            this.showPersonLicenseHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnAddLocalDLA = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocalDLA)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblFormLabel
            // 
            this.lblFormLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFormLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFormLabel.ForeColor = System.Drawing.Color.DarkRed;
            this.lblFormLabel.Location = new System.Drawing.Point(210, 186);
            this.lblFormLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFormLabel.Name = "lblFormLabel";
            this.lblFormLabel.Size = new System.Drawing.Size(465, 34);
            this.lblFormLabel.TabIndex = 29;
            this.lblFormLabel.Text = "Local Driving License Applications";
            this.lblFormLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbFilter
            // 
            this.tbFilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbFilter.Location = new System.Drawing.Point(190, 249);
            this.tbFilter.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbFilter.Name = "tbFilter";
            this.tbFilter.Size = new System.Drawing.Size(148, 20);
            this.tbFilter.TabIndex = 27;
            this.tbFilter.Visible = false;
            this.tbFilter.TextChanged += new System.EventHandler(this.tbFilter_TextChanged);
            this.tbFilter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbFilter_KeyDown);
            // 
            // cbFilter
            // 
            this.cbFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilter.FormattingEnabled = true;
            this.cbFilter.Items.AddRange(new object[] {
            "None",
            "L.D.L.AppID",
            "National No.",
            "Full Name",
            "Status"});
            this.cbFilter.Location = new System.Drawing.Point(70, 249);
            this.cbFilter.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbFilter.Name = "cbFilter";
            this.cbFilter.Size = new System.Drawing.Size(118, 21);
            this.cbFilter.TabIndex = 26;
            this.cbFilter.SelectedIndexChanged += new System.EventHandler(this.cbFilter_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 247);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 19);
            this.label1.TabIndex = 25;
            this.label1.Text = "Filter By:";
            // 
            // lblRecords
            // 
            this.lblRecords.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblRecords.AutoSize = true;
            this.lblRecords.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecords.Location = new System.Drawing.Point(9, 520);
            this.lblRecords.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRecords.Name = "lblRecords";
            this.lblRecords.Size = new System.Drawing.Size(67, 19);
            this.lblRecords.TabIndex = 22;
            this.lblRecords.Text = "#Records";
            // 
            // dgvLocalDLA
            // 
            this.dgvLocalDLA.AllowUserToAddRows = false;
            this.dgvLocalDLA.AllowUserToDeleteRows = false;
            this.dgvLocalDLA.AllowUserToOrderColumns = true;
            this.dgvLocalDLA.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvLocalDLA.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLocalDLA.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvLocalDLA.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLocalDLA.Location = new System.Drawing.Point(9, 272);
            this.dgvLocalDLA.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvLocalDLA.Name = "dgvLocalDLA";
            this.dgvLocalDLA.ReadOnly = true;
            this.dgvLocalDLA.RowHeadersWidth = 62;
            this.dgvLocalDLA.RowTemplate.Height = 28;
            this.dgvLocalDLA.Size = new System.Drawing.Size(868, 246);
            this.dgvLocalDLA.TabIndex = 21;
            this.dgvLocalDLA.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dgvApplicationType_MouseDown);
            // 
            // cbStatusFilter
            // 
            this.cbStatusFilter.FormattingEnabled = true;
            this.cbStatusFilter.Items.AddRange(new object[] {
            "All",
            "New",
            "Canceled",
            "Completed"});
            this.cbStatusFilter.Location = new System.Drawing.Point(190, 249);
            this.cbStatusFilter.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbStatusFilter.Name = "cbStatusFilter";
            this.cbStatusFilter.Size = new System.Drawing.Size(92, 21);
            this.cbStatusFilter.TabIndex = 28;
            this.cbStatusFilter.Visible = false;
            this.cbStatusFilter.SelectedIndexChanged += new System.EventHandler(this.cbStatusFilter_SelectedIndexChanged);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ShowApplicationToolStripMenuItem,
            this.toolStripMenuItem1,
            this.editApplicationToolStripMenuItem,
            this.deleteApplicationToolStripMenuItem,
            this.toolStripMenuItem2,
            this.cancelApplicationToolStripMenuItem,
            this.toolStripMenuItem4,
            this.scheduleTestsToolStripMenuItem,
            this.toolStripMenuItem5,
            this.issueDrivingLicenseFirstTimeToolStripMenuItem,
            this.toolStripMenuItem6,
            this.showLicenseToolStripMenuItem,
            this.toolStripMenuItem7,
            this.showPersonLicenseHistoryToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(254, 280);
            this.contextMenuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenuStrip1_ItemClicked);
            // 
            // ShowApplicationToolStripMenuItem
            // 
            this.ShowApplicationToolStripMenuItem.Image = global::DVLD.Properties.Resources.project;
            this.ShowApplicationToolStripMenuItem.Name = "ShowApplicationToolStripMenuItem";
            this.ShowApplicationToolStripMenuItem.Size = new System.Drawing.Size(253, 30);
            this.ShowApplicationToolStripMenuItem.Text = "Show Application Details";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(250, 6);
            // 
            // editApplicationToolStripMenuItem
            // 
            this.editApplicationToolStripMenuItem.Image = global::DVLD.Properties.Resources.compose;
            this.editApplicationToolStripMenuItem.Name = "editApplicationToolStripMenuItem";
            this.editApplicationToolStripMenuItem.Size = new System.Drawing.Size(253, 30);
            this.editApplicationToolStripMenuItem.Text = "Edit Application";
            // 
            // deleteApplicationToolStripMenuItem
            // 
            this.deleteApplicationToolStripMenuItem.Image = global::DVLD.Properties.Resources.Remove;
            this.deleteApplicationToolStripMenuItem.Name = "deleteApplicationToolStripMenuItem";
            this.deleteApplicationToolStripMenuItem.Size = new System.Drawing.Size(253, 30);
            this.deleteApplicationToolStripMenuItem.Text = "Delete Application";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(250, 6);
            // 
            // cancelApplicationToolStripMenuItem
            // 
            this.cancelApplicationToolStripMenuItem.Image = global::DVLD.Properties.Resources.Cancel_Order;
            this.cancelApplicationToolStripMenuItem.Name = "cancelApplicationToolStripMenuItem";
            this.cancelApplicationToolStripMenuItem.Size = new System.Drawing.Size(253, 30);
            this.cancelApplicationToolStripMenuItem.Text = "Cancel Application";
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(250, 6);
            // 
            // scheduleTestsToolStripMenuItem
            // 
            this.scheduleTestsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.scheduleVisonTestToolStripMenuItem,
            this.scheduleWrittenTestToolStripMenuItem,
            this.scheduleStreetTestToolStripMenuItem});
            this.scheduleTestsToolStripMenuItem.Enabled = false;
            this.scheduleTestsToolStripMenuItem.Image = global::DVLD.Properties.Resources.Tear_Off_Calendar;
            this.scheduleTestsToolStripMenuItem.Name = "scheduleTestsToolStripMenuItem";
            this.scheduleTestsToolStripMenuItem.Size = new System.Drawing.Size(253, 30);
            this.scheduleTestsToolStripMenuItem.Text = "Schedule Tests";
            this.scheduleTestsToolStripMenuItem.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.scheduleTestsToolStripMenuItem_DropDownItemClicked);
            // 
            // scheduleVisonTestToolStripMenuItem
            // 
            this.scheduleVisonTestToolStripMenuItem.Image = global::DVLD.Properties.Resources.eye;
            this.scheduleVisonTestToolStripMenuItem.Name = "scheduleVisonTestToolStripMenuItem";
            this.scheduleVisonTestToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.scheduleVisonTestToolStripMenuItem.Text = "Schedule Vison Test";
            // 
            // scheduleWrittenTestToolStripMenuItem
            // 
            this.scheduleWrittenTestToolStripMenuItem.Image = global::DVLD.Properties.Resources.writing;
            this.scheduleWrittenTestToolStripMenuItem.Name = "scheduleWrittenTestToolStripMenuItem";
            this.scheduleWrittenTestToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.scheduleWrittenTestToolStripMenuItem.Text = "Schedule Written Test";
            // 
            // scheduleStreetTestToolStripMenuItem
            // 
            this.scheduleStreetTestToolStripMenuItem.Image = global::DVLD.Properties.Resources.street;
            this.scheduleStreetTestToolStripMenuItem.Name = "scheduleStreetTestToolStripMenuItem";
            this.scheduleStreetTestToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.scheduleStreetTestToolStripMenuItem.Text = "Schedule Practical Test";
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(250, 6);
            // 
            // issueDrivingLicenseFirstTimeToolStripMenuItem
            // 
            this.issueDrivingLicenseFirstTimeToolStripMenuItem.Name = "issueDrivingLicenseFirstTimeToolStripMenuItem";
            this.issueDrivingLicenseFirstTimeToolStripMenuItem.Size = new System.Drawing.Size(253, 30);
            this.issueDrivingLicenseFirstTimeToolStripMenuItem.Text = "Issue Driving License (First Time)";
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(250, 6);
            // 
            // showLicenseToolStripMenuItem
            // 
            this.showLicenseToolStripMenuItem.Name = "showLicenseToolStripMenuItem";
            this.showLicenseToolStripMenuItem.Size = new System.Drawing.Size(253, 30);
            this.showLicenseToolStripMenuItem.Text = "Show License";
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(250, 6);
            // 
            // showPersonLicenseHistoryToolStripMenuItem
            // 
            this.showPersonLicenseHistoryToolStripMenuItem.Name = "showPersonLicenseHistoryToolStripMenuItem";
            this.showPersonLicenseHistoryToolStripMenuItem.Size = new System.Drawing.Size(253, 30);
            this.showPersonLicenseHistoryToolStripMenuItem.Text = "Show Person License History";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::DVLD.Properties.Resources.Close;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(796, 522);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(81, 33);
            this.btnClose.TabIndex = 24;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnAddLocalDLA
            // 
            this.btnAddLocalDLA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddLocalDLA.BackColor = System.Drawing.Color.Transparent;
            this.btnAddLocalDLA.BackgroundImage = global::DVLD.Properties.Resources.new_project_1_;
            this.btnAddLocalDLA.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAddLocalDLA.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddLocalDLA.Location = new System.Drawing.Point(837, 229);
            this.btnAddLocalDLA.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnAddLocalDLA.Name = "btnAddLocalDLA";
            this.btnAddLocalDLA.Size = new System.Drawing.Size(40, 40);
            this.btnAddLocalDLA.TabIndex = 23;
            this.btnAddLocalDLA.UseVisualStyleBackColor = false;
            this.btnAddLocalDLA.Click += new System.EventHandler(this.btnAddLocalDLA_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = global::DVLD.Properties.Resources.LocalDLA;
            this.pictureBox1.Location = new System.Drawing.Point(387, 52);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(111, 132);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 20;
            this.pictureBox1.TabStop = false;
            // 
            // LocalDLA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(886, 563);
            this.Controls.Add(this.lblFormLabel);
            this.Controls.Add(this.tbFilter);
            this.Controls.Add(this.cbFilter);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnAddLocalDLA);
            this.Controls.Add(this.lblRecords);
            this.Controls.Add(this.dgvLocalDLA);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.cbStatusFilter);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "LocalDLA";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "LocalDLA";
            this.Load += new System.EventHandler(this.LocalDLA_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocalDLA)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblFormLabel;
        private System.Windows.Forms.TextBox tbFilter;
        private System.Windows.Forms.ComboBox cbFilter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnAddLocalDLA;
        private System.Windows.Forms.Label lblRecords;
        private System.Windows.Forms.DataGridView dgvLocalDLA;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox cbStatusFilter;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ShowApplicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem editApplicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteApplicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem cancelApplicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem scheduleTestsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem issueDrivingLicenseFirstTimeToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem showLicenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem7;
        private System.Windows.Forms.ToolStripMenuItem showPersonLicenseHistoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scheduleVisonTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scheduleWrittenTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scheduleStreetTestToolStripMenuItem;
    }
}