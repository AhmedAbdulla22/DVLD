namespace DVLD.License
{
    partial class LicenseHistory
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.gbDriverLicenses = new System.Windows.Forms.GroupBox();
            this.tabDriverLicenses = new System.Windows.Forms.TabControl();
            this.tabLocal = new System.Windows.Forms.TabPage();
            this.lbl_DGV_Title_Local = new System.Windows.Forms.Label();
            this.lblRecordsLocal = new System.Windows.Forms.Label();
            this.dgvLocalLicensesHistory = new System.Windows.Forms.DataGridView();
            this.tabInternational = new System.Windows.Forms.TabPage();
            this.lbl_DGV_Title_International = new System.Windows.Forms.Label();
            this.lblRecordsInternational = new System.Windows.Forms.Label();
            this.dgvInternationalLicensesHistory = new System.Windows.Forms.DataGridView();
            this.btnClose = new System.Windows.Forms.Button();
            this.uctrlFilterBy1 = new DVLD.userControls.uctrlFilterBy();
            this.uctrPersonDetails1 = new DVLD.uctrPersonDetails();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.gbDriverLicenses.SuspendLayout();
            this.tabDriverLicenses.SuspendLayout();
            this.tabLocal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocalLicensesHistory)).BeginInit();
            this.tabInternational.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInternationalLicensesHistory)).BeginInit();
            this.SuspendLayout();
            // 
            // lblFormLabel
            // 
            this.lblFormLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFormLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFormLabel.ForeColor = System.Drawing.Color.DarkRed;
            this.lblFormLabel.Location = new System.Drawing.Point(285, 6);
            this.lblFormLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFormLabel.Name = "lblFormLabel";
            this.lblFormLabel.Size = new System.Drawing.Size(296, 34);
            this.lblFormLabel.TabIndex = 23;
            this.lblFormLabel.Text = "License History";
            this.lblFormLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = global::DVLD.Properties.Resources.Driver_License2;
            this.pictureBox1.Location = new System.Drawing.Point(24, 157);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(176, 135);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 22;
            this.pictureBox1.TabStop = false;
            // 
            // gbDriverLicenses
            // 
            this.gbDriverLicenses.Controls.Add(this.tabDriverLicenses);
            this.gbDriverLicenses.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbDriverLicenses.Location = new System.Drawing.Point(12, 346);
            this.gbDriverLicenses.Name = "gbDriverLicenses";
            this.gbDriverLicenses.Size = new System.Drawing.Size(804, 241);
            this.gbDriverLicenses.TabIndex = 24;
            this.gbDriverLicenses.TabStop = false;
            this.gbDriverLicenses.Text = "Driver Licenses";
            // 
            // tabDriverLicenses
            // 
            this.tabDriverLicenses.Controls.Add(this.tabLocal);
            this.tabDriverLicenses.Controls.Add(this.tabInternational);
            this.tabDriverLicenses.Location = new System.Drawing.Point(12, 19);
            this.tabDriverLicenses.Name = "tabDriverLicenses";
            this.tabDriverLicenses.SelectedIndex = 0;
            this.tabDriverLicenses.Size = new System.Drawing.Size(786, 216);
            this.tabDriverLicenses.TabIndex = 0;
            // 
            // tabLocal
            // 
            this.tabLocal.BackColor = System.Drawing.Color.White;
            this.tabLocal.Controls.Add(this.lbl_DGV_Title_Local);
            this.tabLocal.Controls.Add(this.lblRecordsLocal);
            this.tabLocal.Controls.Add(this.dgvLocalLicensesHistory);
            this.tabLocal.Location = new System.Drawing.Point(4, 22);
            this.tabLocal.Name = "tabLocal";
            this.tabLocal.Padding = new System.Windows.Forms.Padding(3);
            this.tabLocal.Size = new System.Drawing.Size(778, 190);
            this.tabLocal.TabIndex = 1;
            this.tabLocal.Text = "Local";
            // 
            // lbl_DGV_Title_Local
            // 
            this.lbl_DGV_Title_Local.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_DGV_Title_Local.AutoSize = true;
            this.lbl_DGV_Title_Local.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_DGV_Title_Local.Location = new System.Drawing.Point(14, 9);
            this.lbl_DGV_Title_Local.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_DGV_Title_Local.Name = "lbl_DGV_Title_Local";
            this.lbl_DGV_Title_Local.Size = new System.Drawing.Size(143, 17);
            this.lbl_DGV_Title_Local.TabIndex = 19;
            this.lbl_DGV_Title_Local.Text = "Local Licenses History:";
            // 
            // lblRecordsLocal
            // 
            this.lblRecordsLocal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblRecordsLocal.AutoSize = true;
            this.lblRecordsLocal.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecordsLocal.Location = new System.Drawing.Point(14, 163);
            this.lblRecordsLocal.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRecordsLocal.Name = "lblRecordsLocal";
            this.lblRecordsLocal.Size = new System.Drawing.Size(64, 17);
            this.lblRecordsLocal.TabIndex = 18;
            this.lblRecordsLocal.Text = "#Records";
            // 
            // dgvLocalLicensesHistory
            // 
            this.dgvLocalLicensesHistory.AllowUserToAddRows = false;
            this.dgvLocalLicensesHistory.AllowUserToDeleteRows = false;
            this.dgvLocalLicensesHistory.AllowUserToOrderColumns = true;
            this.dgvLocalLicensesHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvLocalLicensesHistory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLocalLicensesHistory.BackgroundColor = System.Drawing.Color.White;
            this.dgvLocalLicensesHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLocalLicensesHistory.Location = new System.Drawing.Point(17, 28);
            this.dgvLocalLicensesHistory.Margin = new System.Windows.Forms.Padding(2);
            this.dgvLocalLicensesHistory.Name = "dgvLocalLicensesHistory";
            this.dgvLocalLicensesHistory.ReadOnly = true;
            this.dgvLocalLicensesHistory.RowHeadersWidth = 62;
            this.dgvLocalLicensesHistory.RowTemplate.Height = 28;
            this.dgvLocalLicensesHistory.Size = new System.Drawing.Size(747, 133);
            this.dgvLocalLicensesHistory.TabIndex = 17;
            // 
            // tabInternational
            // 
            this.tabInternational.BackColor = System.Drawing.Color.White;
            this.tabInternational.Controls.Add(this.lbl_DGV_Title_International);
            this.tabInternational.Controls.Add(this.lblRecordsInternational);
            this.tabInternational.Controls.Add(this.dgvInternationalLicensesHistory);
            this.tabInternational.Location = new System.Drawing.Point(4, 22);
            this.tabInternational.Name = "tabInternational";
            this.tabInternational.Padding = new System.Windows.Forms.Padding(3);
            this.tabInternational.Size = new System.Drawing.Size(778, 190);
            this.tabInternational.TabIndex = 2;
            this.tabInternational.Text = "International";
            // 
            // lbl_DGV_Title_International
            // 
            this.lbl_DGV_Title_International.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_DGV_Title_International.AutoSize = true;
            this.lbl_DGV_Title_International.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_DGV_Title_International.Location = new System.Drawing.Point(14, 8);
            this.lbl_DGV_Title_International.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_DGV_Title_International.Name = "lbl_DGV_Title_International";
            this.lbl_DGV_Title_International.Size = new System.Drawing.Size(191, 17);
            this.lbl_DGV_Title_International.TabIndex = 22;
            this.lbl_DGV_Title_International.Text = "International Licenses History:";
            // 
            // lblRecordsInternational
            // 
            this.lblRecordsInternational.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblRecordsInternational.AutoSize = true;
            this.lblRecordsInternational.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecordsInternational.Location = new System.Drawing.Point(14, 162);
            this.lblRecordsInternational.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRecordsInternational.Name = "lblRecordsInternational";
            this.lblRecordsInternational.Size = new System.Drawing.Size(64, 17);
            this.lblRecordsInternational.TabIndex = 21;
            this.lblRecordsInternational.Text = "#Records";
            // 
            // dgvInternationalLicensesHistory
            // 
            this.dgvInternationalLicensesHistory.AllowUserToAddRows = false;
            this.dgvInternationalLicensesHistory.AllowUserToDeleteRows = false;
            this.dgvInternationalLicensesHistory.AllowUserToOrderColumns = true;
            this.dgvInternationalLicensesHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvInternationalLicensesHistory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvInternationalLicensesHistory.BackgroundColor = System.Drawing.Color.White;
            this.dgvInternationalLicensesHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInternationalLicensesHistory.Location = new System.Drawing.Point(17, 27);
            this.dgvInternationalLicensesHistory.Margin = new System.Windows.Forms.Padding(2);
            this.dgvInternationalLicensesHistory.Name = "dgvInternationalLicensesHistory";
            this.dgvInternationalLicensesHistory.ReadOnly = true;
            this.dgvInternationalLicensesHistory.RowHeadersWidth = 62;
            this.dgvInternationalLicensesHistory.RowTemplate.Height = 28;
            this.dgvInternationalLicensesHistory.Size = new System.Drawing.Size(747, 133);
            this.dgvInternationalLicensesHistory.TabIndex = 20;
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
            this.btnClose.Location = new System.Drawing.Point(735, 591);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(81, 33);
            this.btnClose.TabIndex = 25;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.button2_Click);
            // 
            // uctrlFilterBy1
            // 
            this.uctrlFilterBy1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.uctrlFilterBy1.Location = new System.Drawing.Point(212, 70);
            this.uctrlFilterBy1.Margin = new System.Windows.Forms.Padding(4);
            this.uctrlFilterBy1.Name = "uctrlFilterBy1";
            this.uctrlFilterBy1.Size = new System.Drawing.Size(604, 67);
            this.uctrlFilterBy1.TabIndex = 2;
            // 
            // uctrPersonDetails1
            // 
            this.uctrPersonDetails1.Location = new System.Drawing.Point(212, 133);
            this.uctrPersonDetails1.Margin = new System.Windows.Forms.Padding(2);
            this.uctrPersonDetails1.Name = "uctrPersonDetails1";
            this.uctrPersonDetails1.PersonID = -1;
            this.uctrPersonDetails1.Size = new System.Drawing.Size(604, 196);
            this.uctrPersonDetails1.TabIndex = 3;
            // 
            // LicenseHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(829, 628);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.gbDriverLicenses);
            this.Controls.Add(this.lblFormLabel);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.uctrlFilterBy1);
            this.Controls.Add(this.uctrPersonDetails1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "LicenseHistory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "LicenseHistory";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.gbDriverLicenses.ResumeLayout(false);
            this.tabDriverLicenses.ResumeLayout(false);
            this.tabLocal.ResumeLayout(false);
            this.tabLocal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocalLicensesHistory)).EndInit();
            this.tabInternational.ResumeLayout(false);
            this.tabInternational.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInternationalLicensesHistory)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private userControls.uctrlFilterBy uctrlFilterBy1;
        private uctrPersonDetails uctrPersonDetails1;
        private System.Windows.Forms.Label lblFormLabel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox gbDriverLicenses;
        private System.Windows.Forms.TabControl tabDriverLicenses;
        private System.Windows.Forms.TabPage tabLocal;
        private System.Windows.Forms.TabPage tabInternational;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lbl_DGV_Title_Local;
        private System.Windows.Forms.Label lblRecordsLocal;
        private System.Windows.Forms.DataGridView dgvLocalLicensesHistory;
        private System.Windows.Forms.Label lbl_DGV_Title_International;
        private System.Windows.Forms.Label lblRecordsInternational;
        private System.Windows.Forms.DataGridView dgvInternationalLicensesHistory;
    }
}