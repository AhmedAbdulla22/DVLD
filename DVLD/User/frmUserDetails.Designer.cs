namespace DVLD.UserForm
{
    partial class frmUserDetails
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
            this.uctrPersonDetails1 = new DVLD.uctrPersonDetails();
            this.uctrlLoginInformation1 = new DVLD.userControls.uctrlLoginInformation();
            this.SuspendLayout();
            // 
            // uctrPersonDetails1
            // 
            this.uctrPersonDetails1.Location = new System.Drawing.Point(11, 11);
            this.uctrPersonDetails1.Margin = new System.Windows.Forms.Padding(2);
            this.uctrPersonDetails1.Name = "uctrPersonDetails1";
            this.uctrPersonDetails1.PersonID = -1;
            this.uctrPersonDetails1.Size = new System.Drawing.Size(608, 191);
            this.uctrPersonDetails1.TabIndex = 0;
            // 
            // uctrlLoginInformation1
            // 
            this.uctrlLoginInformation1.Location = new System.Drawing.Point(11, 206);
            this.uctrlLoginInformation1.Margin = new System.Windows.Forms.Padding(2);
            this.uctrlLoginInformation1.Name = "uctrlLoginInformation1";
            this.uctrlLoginInformation1.Size = new System.Drawing.Size(608, 61);
            this.uctrlLoginInformation1.TabIndex = 1;
            // 
            // frmUserDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(630, 277);
            this.Controls.Add(this.uctrlLoginInformation1);
            this.Controls.Add(this.uctrPersonDetails1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmUserDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmUserDetails";
            this.ResumeLayout(false);

        }

        #endregion

        private uctrPersonDetails uctrPersonDetails1;
        private userControls.uctrlLoginInformation uctrlLoginInformation1;
    }
}