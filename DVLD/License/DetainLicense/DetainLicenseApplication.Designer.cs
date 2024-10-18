﻿namespace DVLD.License.DetainLicense
{
    partial class DetainLicenseApplication
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
            this.lnklblShowLicensesInfo = new System.Windows.Forms.LinkLabel();
            this.lnklblShowLicensesHistory = new System.Windows.Forms.LinkLabel();
            this.btnIssue = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.uctrl_DriverLicenseInfo1 = new DVLD.License.uctrl_DriverLicenseInfo();
            this.uctrlFindLDLicense1 = new DVLD.License.InternationalDrivingLicense.uctrlFindLDLicense();
            this.uctrlDetainInfo1 = new DVLD.License.DetainLicense.uctrlDetainInfo();
            this.SuspendLayout();
            // 
            // lblFormLabel
            // 
            this.lblFormLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFormLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFormLabel.ForeColor = System.Drawing.Color.DarkRed;
            this.lblFormLabel.Location = new System.Drawing.Point(0, -1);
            this.lblFormLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFormLabel.Name = "lblFormLabel";
            this.lblFormLabel.Size = new System.Drawing.Size(633, 34);
            this.lblFormLabel.TabIndex = 54;
            this.lblFormLabel.Text = "Detain License Application";
            this.lblFormLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lnklblShowLicensesInfo
            // 
            this.lnklblShowLicensesInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lnklblShowLicensesInfo.AutoSize = true;
            this.lnklblShowLicensesInfo.Enabled = false;
            this.lnklblShowLicensesInfo.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnklblShowLicensesInfo.Location = new System.Drawing.Point(135, 567);
            this.lnklblShowLicensesInfo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lnklblShowLicensesInfo.Name = "lnklblShowLicensesInfo";
            this.lnklblShowLicensesInfo.Size = new System.Drawing.Size(131, 15);
            this.lnklblShowLicensesInfo.TabIndex = 63;
            this.lnklblShowLicensesInfo.TabStop = true;
            this.lnklblShowLicensesInfo.Text = "Show New License Info";
            // 
            // lnklblShowLicensesHistory
            // 
            this.lnklblShowLicensesHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lnklblShowLicensesHistory.AutoSize = true;
            this.lnklblShowLicensesHistory.Enabled = false;
            this.lnklblShowLicensesHistory.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnklblShowLicensesHistory.Location = new System.Drawing.Point(6, 567);
            this.lnklblShowLicensesHistory.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lnklblShowLicensesHistory.Name = "lnklblShowLicensesHistory";
            this.lnklblShowLicensesHistory.Size = new System.Drawing.Size(125, 15);
            this.lnklblShowLicensesHistory.TabIndex = 62;
            this.lnklblShowLicensesHistory.TabStop = true;
            this.lnklblShowLicensesHistory.Text = "Show Licenses History";
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
            this.btnIssue.Location = new System.Drawing.Point(550, 557);
            this.btnIssue.Margin = new System.Windows.Forms.Padding(2);
            this.btnIssue.Name = "btnIssue";
            this.btnIssue.Size = new System.Drawing.Size(81, 33);
            this.btnIssue.TabIndex = 61;
            this.btnIssue.Text = "Issue";
            this.btnIssue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnIssue.UseVisualStyleBackColor = false;
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
            this.btnClose.Location = new System.Drawing.Point(464, 557);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(81, 33);
            this.btnClose.TabIndex = 60;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = false;
            // 
            // uctrl_DriverLicenseInfo1
            // 
            this.uctrl_DriverLicenseInfo1.LicenseID = -1;
            this.uctrl_DriverLicenseInfo1.Location = new System.Drawing.Point(0, 128);
            this.uctrl_DriverLicenseInfo1.Margin = new System.Windows.Forms.Padding(2);
            this.uctrl_DriverLicenseInfo1.Name = "uctrl_DriverLicenseInfo1";
            this.uctrl_DriverLicenseInfo1.Size = new System.Drawing.Size(633, 323);
            this.uctrl_DriverLicenseInfo1.TabIndex = 56;
            // 
            // uctrlFindLDLicense1
            // 
            this.uctrlFindLDLicense1.Location = new System.Drawing.Point(36, 46);
            this.uctrlFindLDLicense1.Margin = new System.Windows.Forms.Padding(4);
            this.uctrlFindLDLicense1.Name = "uctrlFindLDLicense1";
            this.uctrlFindLDLicense1.Size = new System.Drawing.Size(560, 76);
            this.uctrlFindLDLicense1.TabIndex = 55;
            // 
            // uctrlDetainInfo1
            // 
            this.uctrlDetainInfo1.DetainID = -1;
            this.uctrlDetainInfo1.LicenseID = -1;
            this.uctrlDetainInfo1.Location = new System.Drawing.Point(0, 447);
            this.uctrlDetainInfo1.Name = "uctrlDetainInfo1";
            this.uctrlDetainInfo1.Size = new System.Drawing.Size(629, 104);
            this.uctrlDetainInfo1.TabIndex = 64;
            // 
            // DetainLicenseApplication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(633, 592);
            this.Controls.Add(this.uctrlDetainInfo1);
            this.Controls.Add(this.lnklblShowLicensesInfo);
            this.Controls.Add(this.lnklblShowLicensesHistory);
            this.Controls.Add(this.btnIssue);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.uctrl_DriverLicenseInfo1);
            this.Controls.Add(this.uctrlFindLDLicense1);
            this.Controls.Add(this.lblFormLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "DetainLicenseApplication";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "DetainLicenseApplication";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private uctrl_DriverLicenseInfo uctrl_DriverLicenseInfo1;
        private InternationalDrivingLicense.uctrlFindLDLicense uctrlFindLDLicense1;
        private System.Windows.Forms.Label lblFormLabel;
        private System.Windows.Forms.LinkLabel lnklblShowLicensesInfo;
        private System.Windows.Forms.LinkLabel lnklblShowLicensesHistory;
        private System.Windows.Forms.Button btnIssue;
        private System.Windows.Forms.Button btnClose;
        private uctrlDetainInfo uctrlDetainInfo1;
    }
}