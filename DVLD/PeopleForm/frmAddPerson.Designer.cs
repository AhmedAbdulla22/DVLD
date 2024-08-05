﻿namespace DVLD.PeopleForm
{
    partial class frmAddPerson
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
            this.lblPersondID1 = new System.Windows.Forms.Label();
            this.lblFormLabel = new System.Windows.Forms.Label();
            this.lblPersonID2 = new System.Windows.Forms.Label();
            this.uctrlAddPerson1 = new DVLD.uctrlAddPerson();
            this.SuspendLayout();
            // 
            // lblPersondID1
            // 
            this.lblPersondID1.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPersondID1.Image = global::DVLD.Properties.Resources.Display1;
            this.lblPersondID1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblPersondID1.Location = new System.Drawing.Point(12, 34);
            this.lblPersondID1.Name = "lblPersondID1";
            this.lblPersondID1.Size = new System.Drawing.Size(150, 35);
            this.lblPersondID1.TabIndex = 1;
            this.lblPersondID1.Text = "Person ID:";
            this.lblPersondID1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblFormLabel
            // 
            this.lblFormLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFormLabel.ForeColor = System.Drawing.Color.DarkRed;
            this.lblFormLabel.Location = new System.Drawing.Point(328, 9);
            this.lblFormLabel.Name = "lblFormLabel";
            this.lblFormLabel.Size = new System.Drawing.Size(254, 52);
            this.lblFormLabel.TabIndex = 2;
            this.lblFormLabel.Text = "Add New Person";
            this.lblFormLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPersonID2
            // 
            this.lblPersonID2.AutoSize = true;
            this.lblPersonID2.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPersonID2.Location = new System.Drawing.Point(168, 37);
            this.lblPersonID2.Name = "lblPersonID2";
            this.lblPersonID2.Size = new System.Drawing.Size(48, 28);
            this.lblPersonID2.TabIndex = 3;
            this.lblPersonID2.Text = "N/A";
            this.lblPersonID2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uctrlAddPerson1
            // 
            this.uctrlAddPerson1.Address = "";
            this.uctrlAddPerson1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.uctrlAddPerson1.BackColor = System.Drawing.Color.Transparent;
            this.uctrlAddPerson1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctrlAddPerson1.CountryID = 83;
            this.uctrlAddPerson1.DateOfBirth = new System.DateTime(2006, 8, 6, 2, 56, 6, 842);
            this.uctrlAddPerson1.Email = "";
            this.uctrlAddPerson1.FirstName = "";
            this.uctrlAddPerson1.GenderID = ((short)(0));
            this.uctrlAddPerson1.LastName = "";
            this.uctrlAddPerson1.Location = new System.Drawing.Point(12, 78);
            this.uctrlAddPerson1.Margin = new System.Windows.Forms.Padding(2);
            this.uctrlAddPerson1.Name = "uctrlAddPerson1";
            this.uctrlAddPerson1.NationalNo = "";
            this.uctrlAddPerson1.pbPath = null;
            this.uctrlAddPerson1.PersonID = -1;
            this.uctrlAddPerson1.Phone = "";
            this.uctrlAddPerson1.SecondName = "";
            this.uctrlAddPerson1.Size = new System.Drawing.Size(884, 406);
            this.uctrlAddPerson1.TabIndex = 0;
            this.uctrlAddPerson1.ThirdName = "";
            this.uctrlAddPerson1.Load += new System.EventHandler(this.uctrlAddPerson1_Load);
            // 
            // frmAddPerson
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(910, 495);
            this.Controls.Add(this.lblPersonID2);
            this.Controls.Add(this.lblFormLabel);
            this.Controls.Add(this.lblPersondID1);
            this.Controls.Add(this.uctrlAddPerson1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmAddPerson";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add/Update Person";
            this.Load += new System.EventHandler(this.frmAddPerson_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private uctrlAddPerson uctrlAddPerson1;
        private System.Windows.Forms.Label lblPersondID1;
        private System.Windows.Forms.Label lblFormLabel;
        private System.Windows.Forms.Label lblPersonID2;
    }
}