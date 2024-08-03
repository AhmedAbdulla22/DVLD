namespace DVLD.PeopleForm
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
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.uctrlAddPerson1 = new DVLD.uctrlAddPerson();
            this.SuspendLayout();
            // 
            // lblPersondID1
            // 
            this.lblPersondID1.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPersondID1.Image = global::DVLD.Properties.Resources.Display1;
            this.lblPersondID1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblPersondID1.Location = new System.Drawing.Point(8, 22);
            this.lblPersondID1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPersondID1.Name = "lblPersondID1";
            this.lblPersondID1.Size = new System.Drawing.Size(100, 23);
            this.lblPersondID1.TabIndex = 1;
            this.lblPersondID1.Text = "Person ID:";
            this.lblPersondID1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblFormLabel
            // 
            this.lblFormLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFormLabel.ForeColor = System.Drawing.Color.DarkRed;
            this.lblFormLabel.Location = new System.Drawing.Point(219, 6);
            this.lblFormLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFormLabel.Name = "lblFormLabel";
            this.lblFormLabel.Size = new System.Drawing.Size(169, 34);
            this.lblFormLabel.TabIndex = 2;
            this.lblFormLabel.Text = "Add New Person";
            this.lblFormLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPersonID2
            // 
            this.lblPersonID2.AutoSize = true;
            this.lblPersonID2.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPersonID2.Location = new System.Drawing.Point(112, 24);
            this.lblPersonID2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPersonID2.Name = "lblPersonID2";
            this.lblPersonID2.Size = new System.Drawing.Size(35, 19);
            this.lblPersonID2.TabIndex = 3;
            this.lblPersonID2.Text = "N/A";
            this.lblPersonID2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uctrlAddPerson1
            // 
            this.uctrlAddPerson1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.uctrlAddPerson1.BackColor = System.Drawing.Color.Transparent;
            this.uctrlAddPerson1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uctrlAddPerson1.Location = new System.Drawing.Point(8, 51);
            this.uctrlAddPerson1.Margin = new System.Windows.Forms.Padding(1);
            this.uctrlAddPerson1.Name = "uctrlAddPerson1";
            this.uctrlAddPerson1.Size = new System.Drawing.Size(590, 235);
            this.uctrlAddPerson1.TabIndex = 0;
            this.uctrlAddPerson1.Load += new System.EventHandler(this.uctrlAddPerson1_Load);
            // 
            // frmAddPerson
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(607, 322);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblPersonID2);
            this.Controls.Add(this.lblFormLabel);
            this.Controls.Add(this.lblPersondID1);
            this.Controls.Add(this.uctrlAddPerson1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(2);
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
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
    }
}