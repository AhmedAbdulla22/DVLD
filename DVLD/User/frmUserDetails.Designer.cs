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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.uctrPersonDetails1 = new DVLD.uctrPersonDetails();
            this.gbLoginInfo = new System.Windows.Forms.GroupBox();
            this.uctrlLoginInformation1 = new DVLD.userControls.uctrlLoginInformation();
            this.groupBox1.SuspendLayout();
            this.gbLoginInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.uctrPersonDetails1);
            this.groupBox1.Location = new System.Drawing.Point(9, 10);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(612, 206);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Personal Information";
            // 
            // uctrPersonDetails1
            // 
            this.uctrPersonDetails1.Location = new System.Drawing.Point(5, 16);
            this.uctrPersonDetails1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.uctrPersonDetails1.Name = "uctrPersonDetails1";
            this.uctrPersonDetails1.PersonID = -1;
            this.uctrPersonDetails1.Size = new System.Drawing.Size(601, 182);
            this.uctrPersonDetails1.TabIndex = 0;
            // 
            // gbLoginInfo
            // 
            this.gbLoginInfo.Controls.Add(this.uctrlLoginInformation1);
            this.gbLoginInfo.Location = new System.Drawing.Point(10, 230);
            this.gbLoginInfo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gbLoginInfo.Name = "gbLoginInfo";
            this.gbLoginInfo.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gbLoginInfo.Size = new System.Drawing.Size(612, 81);
            this.gbLoginInfo.TabIndex = 3;
            this.gbLoginInfo.TabStop = false;
            this.gbLoginInfo.Text = "Login Information";
            // 
            // uctrlLoginInformation1
            // 
            this.uctrlLoginInformation1.Location = new System.Drawing.Point(22, 17);
            this.uctrlLoginInformation1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.uctrlLoginInformation1.Name = "uctrlLoginInformation1";
            this.uctrlLoginInformation1.Size = new System.Drawing.Size(568, 52);
            this.uctrlLoginInformation1.TabIndex = 1;
            // 
            // frmUserDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(630, 323);
            this.Controls.Add(this.gbLoginInfo);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "frmUserDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmUserDetails";
            this.groupBox1.ResumeLayout(false);
            this.gbLoginInfo.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private uctrPersonDetails uctrPersonDetails1;
        private userControls.uctrlLoginInformation uctrlLoginInformation1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox gbLoginInfo;
    }
}