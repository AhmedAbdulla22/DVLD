namespace DVLD.License.InternationalDrivingLicense
{
    partial class NewInternationalLicense
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
            this.lblFormLabel = new System.Windows.Forms.Label();
            this.lnklblShowLicensesHistory = new System.Windows.Forms.LinkLabel();
            this.lnklblShowLicensesInfo = new System.Windows.Forms.LinkLabel();
            this.uctrl_IApplicationInfo1 = new DVLD.ApplicationForms.uctrl_IApplicationInfo();
            this.uctrl_DriverLicenseInfo1 = new DVLD.License.uctrl_DriverLicenseInfo();
            this.uctrlFindLDLicense1 = new DVLD.License.InternationalDrivingLicense.uctrlFindLDLicense();
            this.btnIssue = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblFormLabel
            // 
            this.lblFormLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFormLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFormLabel.ForeColor = System.Drawing.Color.DarkRed;
            this.lblFormLabel.Location = new System.Drawing.Point(69, 7);
            this.lblFormLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFormLabel.Name = "lblFormLabel";
            this.lblFormLabel.Size = new System.Drawing.Size(515, 34);
            this.lblFormLabel.TabIndex = 40;
            this.lblFormLabel.Text = "International License Application";
            this.lblFormLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lnklblShowLicensesHistory
            // 
            this.lnklblShowLicensesHistory.AutoSize = true;
            this.lnklblShowLicensesHistory.Enabled = false;
            this.lnklblShowLicensesHistory.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnklblShowLicensesHistory.Location = new System.Drawing.Point(14, 608);
            this.lnklblShowLicensesHistory.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lnklblShowLicensesHistory.Name = "lnklblShowLicensesHistory";
            this.lnklblShowLicensesHistory.Size = new System.Drawing.Size(125, 15);
            this.lnklblShowLicensesHistory.TabIndex = 46;
            this.lnklblShowLicensesHistory.TabStop = true;
            this.lnklblShowLicensesHistory.Text = "Show Licenses History";
            this.lnklblShowLicensesHistory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnklblShowLicensesHistory_LinkClicked);
            // 
            // lnklblShowLicensesInfo
            // 
            this.lnklblShowLicensesInfo.AutoSize = true;
            this.lnklblShowLicensesInfo.Enabled = false;
            this.lnklblShowLicensesInfo.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnklblShowLicensesInfo.Location = new System.Drawing.Point(143, 608);
            this.lnklblShowLicensesInfo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lnklblShowLicensesInfo.Name = "lnklblShowLicensesInfo";
            this.lnklblShowLicensesInfo.Size = new System.Drawing.Size(104, 15);
            this.lnklblShowLicensesInfo.TabIndex = 47;
            this.lnklblShowLicensesInfo.TabStop = true;
            this.lnklblShowLicensesInfo.Text = "Show License Info";
            this.lnklblShowLicensesInfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnklblShowLicensesInfo_LinkClicked);
            // 
            // uctrl_IApplicationInfo1
            // 
            this.uctrl_IApplicationInfo1.IApplicationID = -1;
            this.uctrl_IApplicationInfo1.ILicenseID = -1;
            this.uctrl_IApplicationInfo1.LDLicenseID = -1;
            this.uctrl_IApplicationInfo1.Location = new System.Drawing.Point(14, 466);
            this.uctrl_IApplicationInfo1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.uctrl_IApplicationInfo1.Name = "uctrl_IApplicationInfo1";
            this.uctrl_IApplicationInfo1.Size = new System.Drawing.Size(629, 130);
            this.uctrl_IApplicationInfo1.TabIndex = 43;
            // 
            // uctrl_DriverLicenseInfo1
            // 
            this.uctrl_DriverLicenseInfo1.LicenseID = -1;
            this.uctrl_DriverLicenseInfo1.Location = new System.Drawing.Point(14, 141);
            this.uctrl_DriverLicenseInfo1.Margin = new System.Windows.Forms.Padding(2);
            this.uctrl_DriverLicenseInfo1.Name = "uctrl_DriverLicenseInfo1";
            this.uctrl_DriverLicenseInfo1.Size = new System.Drawing.Size(629, 321);
            this.uctrl_DriverLicenseInfo1.TabIndex = 42;
            // 
            // uctrlFindLDLicense1
            // 
            this.uctrlFindLDLicense1.Location = new System.Drawing.Point(72, 60);
            this.uctrlFindLDLicense1.Margin = new System.Windows.Forms.Padding(4);
            this.uctrlFindLDLicense1.Name = "uctrlFindLDLicense1";
            this.uctrlFindLDLicense1.Size = new System.Drawing.Size(512, 76);
            this.uctrlFindLDLicense1.TabIndex = 41;
            // 
            // btnIssue
            // 
            this.btnIssue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnIssue.BackColor = System.Drawing.Color.Transparent;
            this.btnIssue.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnIssue.Enabled = false;
            this.btnIssue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIssue.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIssue.Image = global::DVLD.Properties.Resources.Map;
            this.btnIssue.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIssue.Location = new System.Drawing.Point(562, 600);
            this.btnIssue.Margin = new System.Windows.Forms.Padding(2);
            this.btnIssue.Name = "btnIssue";
            this.btnIssue.Size = new System.Drawing.Size(81, 33);
            this.btnIssue.TabIndex = 45;
            this.btnIssue.Text = "Issue";
            this.btnIssue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnIssue.UseVisualStyleBackColor = false;
            this.btnIssue.Click += new System.EventHandler(this.btnIssue_Click);
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
            this.btnClose.Location = new System.Drawing.Point(476, 600);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(81, 33);
            this.btnClose.TabIndex = 44;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // NewInternationalLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(652, 639);
            this.Controls.Add(this.lnklblShowLicensesInfo);
            this.Controls.Add(this.lnklblShowLicensesHistory);
            this.Controls.Add(this.btnIssue);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.uctrl_IApplicationInfo1);
            this.Controls.Add(this.uctrl_DriverLicenseInfo1);
            this.Controls.Add(this.uctrlFindLDLicense1);
            this.Controls.Add(this.lblFormLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "NewInternationalLicense";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "NewInternationalLicense";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblFormLabel;
        private uctrlFindLDLicense uctrlFindLDLicense1;
        private uctrl_DriverLicenseInfo uctrl_DriverLicenseInfo1;
        private ApplicationForms.uctrl_IApplicationInfo uctrl_IApplicationInfo1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnIssue;
        private System.Windows.Forms.LinkLabel lnklblShowLicensesHistory;
        private System.Windows.Forms.LinkLabel lnklblShowLicensesInfo;
    }
}