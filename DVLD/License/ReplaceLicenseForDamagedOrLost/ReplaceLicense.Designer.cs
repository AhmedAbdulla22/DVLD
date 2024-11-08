namespace DVLD.License.ReplaceLicenseForDamagedOrLost
{
    partial class ReplaceLicense
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
            this.uctrl_DriverLicenseInfo1 = new DVLD.License.uctrl_DriverLicenseInfo();
            this.uctrlFindLDLicense1 = new DVLD.License.InternationalDrivingLicense.uctrlFindLDLicense();
            this.lblFormLabel = new System.Windows.Forms.Label();
            this.gbReplacementReason = new System.Windows.Forms.GroupBox();
            this.rbDamaged = new System.Windows.Forms.RadioButton();
            this.rbLost = new System.Windows.Forms.RadioButton();
            this.lnklblShowLicensesInfo = new System.Windows.Forms.LinkLabel();
            this.lnklblShowLicensesHistory = new System.Windows.Forms.LinkLabel();
            this.btnIssue = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.uctrlAppInfoLicenseReplacement1 = new DVLD.License.ReplaceLicenseForDamagedOrLost.uctrlAppInfoLicenseReplacement();
            this.gbReplacementReason.SuspendLayout();
            this.SuspendLayout();
            // 
            // uctrl_DriverLicenseInfo1
            // 
            this.uctrl_DriverLicenseInfo1.LicenseID = -1;
            this.uctrl_DriverLicenseInfo1.Location = new System.Drawing.Point(2, 132);
            this.uctrl_DriverLicenseInfo1.Margin = new System.Windows.Forms.Padding(2);
            this.uctrl_DriverLicenseInfo1.Name = "uctrl_DriverLicenseInfo1";
            this.uctrl_DriverLicenseInfo1.Size = new System.Drawing.Size(633, 323);
            this.uctrl_DriverLicenseInfo1.TabIndex = 53;
            // 
            // uctrlFindLDLicense1
            // 
            this.uctrlFindLDLicense1.Location = new System.Drawing.Point(2, 50);
            this.uctrlFindLDLicense1.Margin = new System.Windows.Forms.Padding(4);
            this.uctrlFindLDLicense1.Name = "uctrlFindLDLicense1";
            this.uctrlFindLDLicense1.Size = new System.Drawing.Size(560, 76);
            this.uctrlFindLDLicense1.TabIndex = 52;
            // 
            // lblFormLabel
            // 
            this.lblFormLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFormLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFormLabel.ForeColor = System.Drawing.Color.DarkRed;
            this.lblFormLabel.Location = new System.Drawing.Point(2, 3);
            this.lblFormLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFormLabel.Name = "lblFormLabel";
            this.lblFormLabel.Size = new System.Drawing.Size(633, 34);
            this.lblFormLabel.TabIndex = 51;
            this.lblFormLabel.Text = "Replace License Application";
            this.lblFormLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gbReplacementReason
            // 
            this.gbReplacementReason.Controls.Add(this.rbDamaged);
            this.gbReplacementReason.Controls.Add(this.rbLost);
            this.gbReplacementReason.Location = new System.Drawing.Point(473, 55);
            this.gbReplacementReason.Name = "gbReplacementReason";
            this.gbReplacementReason.Size = new System.Drawing.Size(155, 68);
            this.gbReplacementReason.TabIndex = 54;
            this.gbReplacementReason.TabStop = false;
            this.gbReplacementReason.Text = "Replacement For";
            // 
            // rbDamaged
            // 
            this.rbDamaged.AutoSize = true;
            this.rbDamaged.Checked = true;
            this.rbDamaged.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold);
            this.rbDamaged.Location = new System.Drawing.Point(7, 19);
            this.rbDamaged.Name = "rbDamaged";
            this.rbDamaged.Size = new System.Drawing.Size(114, 17);
            this.rbDamaged.TabIndex = 1;
            this.rbDamaged.TabStop = true;
            this.rbDamaged.Text = "Damaged License";
            this.rbDamaged.UseVisualStyleBackColor = true;
            this.rbDamaged.CheckedChanged += new System.EventHandler(this.ReplacementReasonChanged);
            // 
            // rbLost
            // 
            this.rbLost.AutoSize = true;
            this.rbLost.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold);
            this.rbLost.Location = new System.Drawing.Point(7, 42);
            this.rbLost.Name = "rbLost";
            this.rbLost.Size = new System.Drawing.Size(85, 17);
            this.rbLost.TabIndex = 0;
            this.rbLost.Text = "Lost License";
            this.rbLost.UseVisualStyleBackColor = true;
            this.rbLost.CheckedChanged += new System.EventHandler(this.ReplacementReasonChanged);
            // 
            // lnklblShowLicensesInfo
            // 
            this.lnklblShowLicensesInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lnklblShowLicensesInfo.AutoSize = true;
            this.lnklblShowLicensesInfo.Enabled = false;
            this.lnklblShowLicensesInfo.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnklblShowLicensesInfo.Location = new System.Drawing.Point(132, 575);
            this.lnklblShowLicensesInfo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lnklblShowLicensesInfo.Name = "lnklblShowLicensesInfo";
            this.lnklblShowLicensesInfo.Size = new System.Drawing.Size(131, 15);
            this.lnklblShowLicensesInfo.TabIndex = 59;
            this.lnklblShowLicensesInfo.TabStop = true;
            this.lnklblShowLicensesInfo.Text = "Show New License Info";
            this.lnklblShowLicensesInfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnklblShowLicensesInfo_LinkClicked);
            // 
            // lnklblShowLicensesHistory
            // 
            this.lnklblShowLicensesHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lnklblShowLicensesHistory.AutoSize = true;
            this.lnklblShowLicensesHistory.Enabled = false;
            this.lnklblShowLicensesHistory.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnklblShowLicensesHistory.Location = new System.Drawing.Point(3, 575);
            this.lnklblShowLicensesHistory.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lnklblShowLicensesHistory.Name = "lnklblShowLicensesHistory";
            this.lnklblShowLicensesHistory.Size = new System.Drawing.Size(125, 15);
            this.lnklblShowLicensesHistory.TabIndex = 58;
            this.lnklblShowLicensesHistory.TabStop = true;
            this.lnklblShowLicensesHistory.Text = "Show Licenses History";
            this.lnklblShowLicensesHistory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnklblShowLicensesHistory_LinkClicked);
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
            this.btnIssue.Location = new System.Drawing.Point(547, 565);
            this.btnIssue.Margin = new System.Windows.Forms.Padding(2);
            this.btnIssue.Name = "btnIssue";
            this.btnIssue.Size = new System.Drawing.Size(81, 33);
            this.btnIssue.TabIndex = 57;
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
            this.btnClose.Location = new System.Drawing.Point(461, 565);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(81, 33);
            this.btnClose.TabIndex = 56;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // uctrlAppInfoLicenseReplacement1
            // 
            this.uctrlAppInfoLicenseReplacement1.LDLicenseID = -1;
            this.uctrlAppInfoLicenseReplacement1.Location = new System.Drawing.Point(2, 449);
            this.uctrlAppInfoLicenseReplacement1.Name = "uctrlAppInfoLicenseReplacement1";
            this.uctrlAppInfoLicenseReplacement1.RApplicationID = -1;
            this.uctrlAppInfoLicenseReplacement1.RLicenseID = -1;
            this.uctrlAppInfoLicenseReplacement1.Size = new System.Drawing.Size(629, 106);
            this.uctrlAppInfoLicenseReplacement1.TabIndex = 60;
            // 
            // ReplaceLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(633, 605);
            this.Controls.Add(this.uctrlAppInfoLicenseReplacement1);
            this.Controls.Add(this.lnklblShowLicensesInfo);
            this.Controls.Add(this.lnklblShowLicensesHistory);
            this.Controls.Add(this.btnIssue);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.gbReplacementReason);
            this.Controls.Add(this.uctrl_DriverLicenseInfo1);
            this.Controls.Add(this.uctrlFindLDLicense1);
            this.Controls.Add(this.lblFormLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ReplaceLicense";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ReplaceLicense";
            this.gbReplacementReason.ResumeLayout(false);
            this.gbReplacementReason.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private uctrl_DriverLicenseInfo uctrl_DriverLicenseInfo1;
        private InternationalDrivingLicense.uctrlFindLDLicense uctrlFindLDLicense1;
        private System.Windows.Forms.Label lblFormLabel;
        private System.Windows.Forms.GroupBox gbReplacementReason;
        private System.Windows.Forms.RadioButton rbLost;
        private System.Windows.Forms.RadioButton rbDamaged;
        private System.Windows.Forms.LinkLabel lnklblShowLicensesInfo;
        private System.Windows.Forms.LinkLabel lnklblShowLicensesHistory;
        private System.Windows.Forms.Button btnIssue;
        private System.Windows.Forms.Button btnClose;
        private uctrlAppInfoLicenseReplacement uctrlAppInfoLicenseReplacement1;
    }
}