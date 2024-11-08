namespace DVLD.ApplicationForms.LocalDrivingLicenseApp
{
    partial class ShowLocalDLAppInfo
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
            this.uctrlDrivingLicenseApplicationInfo1 = new DVLD.ApplicationForms.uctrlDrivingLicenseApplicationInfo();
            this.SuspendLayout();
            // 
            // uctrlDrivingLicenseApplicationInfo1
            // 
            this.uctrlDrivingLicenseApplicationInfo1.BackColor = System.Drawing.Color.White;
            this.uctrlDrivingLicenseApplicationInfo1.DLAppID = -1;
            this.uctrlDrivingLicenseApplicationInfo1.Location = new System.Drawing.Point(0, 0);
            this.uctrlDrivingLicenseApplicationInfo1.Name = "uctrlDrivingLicenseApplicationInfo1";
            this.uctrlDrivingLicenseApplicationInfo1.Size = new System.Drawing.Size(640, 280);
            this.uctrlDrivingLicenseApplicationInfo1.TabIndex = 0;
            // 
            // ShowLocalDLAppInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 281);
            this.Controls.Add(this.uctrlDrivingLicenseApplicationInfo1);
            this.Name = "ShowLocalDLAppInfo";
            this.Text = "ShowLocalDLAppInfo";
            this.Load += new System.EventHandler(this.ShowLocalDLAppInfo_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private uctrlDrivingLicenseApplicationInfo uctrlDrivingLicenseApplicationInfo1;
    }
}