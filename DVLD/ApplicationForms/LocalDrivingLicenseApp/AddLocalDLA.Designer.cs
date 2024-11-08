namespace DVLD.ApplicationForms
{
    partial class AddLocalDLA
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPersonalInfo = new System.Windows.Forms.TabPage();
            this.uctrPersonDetails1 = new DVLD.uctrPersonDetails();
            this.uctrlFilterBy1 = new DVLD.userControls.uctrlFilterBy();
            this.btnNext = new System.Windows.Forms.Button();
            this.tabApplication = new System.Windows.Forms.TabPage();
            this.cbLicenseClasses = new System.Windows.Forms.ComboBox();
            this.lblCreatedBy2 = new System.Windows.Forms.Label();
            this.lblApplicationFees2 = new System.Windows.Forms.Label();
            this.lblApplicationDate2 = new System.Windows.Forms.Label();
            this.lblCreatedBy = new System.Windows.Forms.Label();
            this.lblApplicationFees = new System.Windows.Forms.Label();
            this.lblLicenseClass = new System.Windows.Forms.Label();
            this.lblApplicationDate = new System.Windows.Forms.Label();
            this.lblDLApplicationID2 = new System.Windows.Forms.Label();
            this.lblDLApplicationID1 = new System.Windows.Forms.Label();
            this.lblFormLabel = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPersonalInfo.SuspendLayout();
            this.tabApplication.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPersonalInfo);
            this.tabControl1.Controls.Add(this.tabApplication);
            this.tabControl1.Location = new System.Drawing.Point(8, 72);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(735, 384);
            this.tabControl1.TabIndex = 5;
            this.tabControl1.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tabControl1_Selecting);
            // 
            // tabPersonalInfo
            // 
            this.tabPersonalInfo.BackColor = System.Drawing.Color.White;
            this.tabPersonalInfo.Controls.Add(this.uctrPersonDetails1);
            this.tabPersonalInfo.Controls.Add(this.uctrlFilterBy1);
            this.tabPersonalInfo.Controls.Add(this.btnNext);
            this.tabPersonalInfo.Location = new System.Drawing.Point(4, 22);
            this.tabPersonalInfo.Margin = new System.Windows.Forms.Padding(2);
            this.tabPersonalInfo.Name = "tabPersonalInfo";
            this.tabPersonalInfo.Padding = new System.Windows.Forms.Padding(2);
            this.tabPersonalInfo.Size = new System.Drawing.Size(727, 358);
            this.tabPersonalInfo.TabIndex = 0;
            this.tabPersonalInfo.Text = "Personal Info";
            // 
            // uctrPersonDetails1
            // 
            this.uctrPersonDetails1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uctrPersonDetails1.Location = new System.Drawing.Point(55, 114);
            this.uctrPersonDetails1.Margin = new System.Windows.Forms.Padding(2);
            this.uctrPersonDetails1.Name = "uctrPersonDetails1";
            this.uctrPersonDetails1.PersonID = -1;
            this.uctrPersonDetails1.Size = new System.Drawing.Size(633, 196);
            this.uctrPersonDetails1.TabIndex = 1;
            // 
            // uctrlFilterBy1
            // 
            this.uctrlFilterBy1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.uctrlFilterBy1.BackColor = System.Drawing.Color.White;
            this.uctrlFilterBy1.Location = new System.Drawing.Point(55, 21);
            this.uctrlFilterBy1.Margin = new System.Windows.Forms.Padding(4);
            this.uctrlFilterBy1.Name = "uctrlFilterBy1";
            this.uctrlFilterBy1.Size = new System.Drawing.Size(633, 67);
            this.uctrlFilterBy1.TabIndex = 0;
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.BackColor = System.Drawing.Color.Transparent;
            this.btnNext.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNext.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.Image = global::DVLD.Properties.Resources.Forward;
            this.btnNext.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNext.Location = new System.Drawing.Point(632, 314);
            this.btnNext.Margin = new System.Windows.Forms.Padding(2);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(81, 32);
            this.btnNext.TabIndex = 15;
            this.btnNext.Text = "Next";
            this.btnNext.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNext.UseVisualStyleBackColor = false;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // tabApplication
            // 
            this.tabApplication.BackColor = System.Drawing.Color.White;
            this.tabApplication.Controls.Add(this.cbLicenseClasses);
            this.tabApplication.Controls.Add(this.lblCreatedBy2);
            this.tabApplication.Controls.Add(this.lblApplicationFees2);
            this.tabApplication.Controls.Add(this.lblApplicationDate2);
            this.tabApplication.Controls.Add(this.lblCreatedBy);
            this.tabApplication.Controls.Add(this.lblApplicationFees);
            this.tabApplication.Controls.Add(this.lblLicenseClass);
            this.tabApplication.Controls.Add(this.lblApplicationDate);
            this.tabApplication.Controls.Add(this.lblDLApplicationID2);
            this.tabApplication.Controls.Add(this.lblDLApplicationID1);
            this.tabApplication.Location = new System.Drawing.Point(4, 22);
            this.tabApplication.Name = "tabApplication";
            this.tabApplication.Padding = new System.Windows.Forms.Padding(3);
            this.tabApplication.Size = new System.Drawing.Size(727, 358);
            this.tabApplication.TabIndex = 1;
            this.tabApplication.Text = "Application Info";
            // 
            // cbLicenseClasses
            // 
            this.cbLicenseClasses.FormattingEnabled = true;
            this.cbLicenseClasses.Location = new System.Drawing.Point(326, 141);
            this.cbLicenseClasses.Name = "cbLicenseClasses";
            this.cbLicenseClasses.Size = new System.Drawing.Size(207, 21);
            this.cbLicenseClasses.TabIndex = 15;
            // 
            // lblCreatedBy2
            // 
            this.lblCreatedBy2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCreatedBy2.AutoSize = true;
            this.lblCreatedBy2.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreatedBy2.Location = new System.Drawing.Point(322, 200);
            this.lblCreatedBy2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCreatedBy2.Name = "lblCreatedBy2";
            this.lblCreatedBy2.Size = new System.Drawing.Size(35, 19);
            this.lblCreatedBy2.TabIndex = 14;
            this.lblCreatedBy2.Text = "N/A";
            this.lblCreatedBy2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblApplicationFees2
            // 
            this.lblApplicationFees2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblApplicationFees2.AutoSize = true;
            this.lblApplicationFees2.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApplicationFees2.Location = new System.Drawing.Point(322, 171);
            this.lblApplicationFees2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblApplicationFees2.Name = "lblApplicationFees2";
            this.lblApplicationFees2.Size = new System.Drawing.Size(35, 19);
            this.lblApplicationFees2.TabIndex = 13;
            this.lblApplicationFees2.Text = "N/A";
            this.lblApplicationFees2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblApplicationDate2
            // 
            this.lblApplicationDate2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblApplicationDate2.AutoSize = true;
            this.lblApplicationDate2.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApplicationDate2.Location = new System.Drawing.Point(322, 113);
            this.lblApplicationDate2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblApplicationDate2.Name = "lblApplicationDate2";
            this.lblApplicationDate2.Size = new System.Drawing.Size(35, 19);
            this.lblApplicationDate2.TabIndex = 12;
            this.lblApplicationDate2.Text = "N/A";
            this.lblApplicationDate2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCreatedBy
            // 
            this.lblCreatedBy.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCreatedBy.AutoSize = true;
            this.lblCreatedBy.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreatedBy.Image = global::DVLD.Properties.Resources.user_3_;
            this.lblCreatedBy.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblCreatedBy.Location = new System.Drawing.Point(186, 200);
            this.lblCreatedBy.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCreatedBy.Name = "lblCreatedBy";
            this.lblCreatedBy.Size = new System.Drawing.Size(127, 19);
            this.lblCreatedBy.TabIndex = 11;
            this.lblCreatedBy.Text = "Created By:            ";
            this.lblCreatedBy.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblApplicationFees
            // 
            this.lblApplicationFees.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblApplicationFees.AutoSize = true;
            this.lblApplicationFees.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApplicationFees.Image = global::DVLD.Properties.Resources.Fees;
            this.lblApplicationFees.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblApplicationFees.Location = new System.Drawing.Point(155, 171);
            this.lblApplicationFees.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblApplicationFees.Name = "lblApplicationFees";
            this.lblApplicationFees.Size = new System.Drawing.Size(163, 19);
            this.lblApplicationFees.TabIndex = 10;
            this.lblApplicationFees.Text = "Application Fees:            ";
            this.lblApplicationFees.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblLicenseClass
            // 
            this.lblLicenseClass.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLicenseClass.AutoSize = true;
            this.lblLicenseClass.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLicenseClass.Image = global::DVLD.Properties.Resources.Versions;
            this.lblLicenseClass.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblLicenseClass.Location = new System.Drawing.Point(176, 142);
            this.lblLicenseClass.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblLicenseClass.Name = "lblLicenseClass";
            this.lblLicenseClass.Size = new System.Drawing.Size(142, 19);
            this.lblLicenseClass.TabIndex = 9;
            this.lblLicenseClass.Text = "License Class:            ";
            this.lblLicenseClass.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblApplicationDate
            // 
            this.lblApplicationDate.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblApplicationDate.AutoSize = true;
            this.lblApplicationDate.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApplicationDate.Image = global::DVLD.Properties.Resources.Tear_Off_Calendar;
            this.lblApplicationDate.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblApplicationDate.Location = new System.Drawing.Point(154, 113);
            this.lblApplicationDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblApplicationDate.Name = "lblApplicationDate";
            this.lblApplicationDate.Size = new System.Drawing.Size(165, 19);
            this.lblApplicationDate.TabIndex = 8;
            this.lblApplicationDate.Text = "Application Date:            ";
            this.lblApplicationDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDLApplicationID2
            // 
            this.lblDLApplicationID2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDLApplicationID2.AutoSize = true;
            this.lblDLApplicationID2.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDLApplicationID2.Location = new System.Drawing.Point(322, 84);
            this.lblDLApplicationID2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDLApplicationID2.Name = "lblDLApplicationID2";
            this.lblDLApplicationID2.Size = new System.Drawing.Size(35, 19);
            this.lblDLApplicationID2.TabIndex = 7;
            this.lblDLApplicationID2.Text = "N/A";
            this.lblDLApplicationID2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDLApplicationID1
            // 
            this.lblDLApplicationID1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDLApplicationID1.AutoSize = true;
            this.lblDLApplicationID1.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDLApplicationID1.Image = global::DVLD.Properties.Resources.Display1;
            this.lblDLApplicationID1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblDLApplicationID1.Location = new System.Drawing.Point(148, 84);
            this.lblDLApplicationID1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDLApplicationID1.Name = "lblDLApplicationID1";
            this.lblDLApplicationID1.Size = new System.Drawing.Size(172, 19);
            this.lblDLApplicationID1.TabIndex = 6;
            this.lblDLApplicationID1.Text = "D.L.Application ID:            ";
            this.lblDLApplicationID1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblFormLabel
            // 
            this.lblFormLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblFormLabel.AutoSize = true;
            this.lblFormLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFormLabel.ForeColor = System.Drawing.Color.DarkRed;
            this.lblFormLabel.Location = new System.Drawing.Point(127, 9);
            this.lblFormLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFormLabel.Name = "lblFormLabel";
            this.lblFormLabel.Size = new System.Drawing.Size(481, 37);
            this.lblFormLabel.TabIndex = 6;
            this.lblFormLabel.Text = "New Local Driving License Application";
            this.lblFormLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = global::DVLD.Properties.Resources.diskette_1_;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(656, 461);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(81, 32);
            this.btnSave.TabIndex = 19;
            this.btnSave.Text = "Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
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
            this.btnClose.Location = new System.Drawing.Point(571, 461);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(81, 32);
            this.btnClose.TabIndex = 18;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // AddLocalDLA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(750, 504);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblFormLabel);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "AddLocalDLA";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "NewLocalDLA";
            this.tabControl1.ResumeLayout(false);
            this.tabPersonalInfo.ResumeLayout(false);
            this.tabApplication.ResumeLayout(false);
            this.tabApplication.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPersonalInfo;
        private System.Windows.Forms.Button btnNext;
        private uctrPersonDetails uctrPersonDetails1;
        private userControls.uctrlFilterBy uctrlFilterBy1;
        private System.Windows.Forms.Label lblFormLabel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TabPage tabApplication;
        private System.Windows.Forms.Label lblDLApplicationID2;
        private System.Windows.Forms.Label lblDLApplicationID1;
        private System.Windows.Forms.Label lblCreatedBy;
        private System.Windows.Forms.Label lblApplicationFees;
        private System.Windows.Forms.Label lblLicenseClass;
        private System.Windows.Forms.Label lblApplicationDate;
        private System.Windows.Forms.ComboBox cbLicenseClasses;
        private System.Windows.Forms.Label lblCreatedBy2;
        private System.Windows.Forms.Label lblApplicationFees2;
        private System.Windows.Forms.Label lblApplicationDate2;
    }
}