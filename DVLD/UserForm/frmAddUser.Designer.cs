namespace DVLD.UserForm
{
    partial class frmAddUser
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPersonalInfo = new System.Windows.Forms.TabPage();
            this.btnNext = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tabLogin = new System.Windows.Forms.TabPage();
            this.chkIsActive = new System.Windows.Forms.CheckBox();
            this.tbCnfPassword = new System.Windows.Forms.TextBox();
            this.tbUserName = new System.Windows.Forms.TextBox();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.lblUserID2 = new System.Windows.Forms.Label();
            this.lblConfirmPassword = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.lblUserID1 = new System.Windows.Forms.Label();
            this.uctrPersonDetails1 = new DVLD.uctrPersonDetails();
            this.uctrlFilterBy1 = new DVLD.userControls.uctrlFilterBy();
            this.tabControl1.SuspendLayout();
            this.tabPersonalInfo.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabLogin.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblFormLabel
            // 
            this.lblFormLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFormLabel.ForeColor = System.Drawing.Color.DarkRed;
            this.lblFormLabel.Location = new System.Drawing.Point(341, 9);
            this.lblFormLabel.Name = "lblFormLabel";
            this.lblFormLabel.Size = new System.Drawing.Size(227, 42);
            this.lblFormLabel.TabIndex = 3;
            this.lblFormLabel.Text = "Add New User";
            this.lblFormLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPersonalInfo);
            this.tabControl1.Controls.Add(this.tabLogin);
            this.tabControl1.Location = new System.Drawing.Point(25, 110);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(863, 508);
            this.tabControl1.TabIndex = 4;
            this.tabControl1.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tabControl1_Selecting);
            // 
            // tabPersonalInfo
            // 
            this.tabPersonalInfo.Controls.Add(this.btnNext);
            this.tabPersonalInfo.Controls.Add(this.groupBox2);
            this.tabPersonalInfo.Controls.Add(this.groupBox1);
            this.tabPersonalInfo.Location = new System.Drawing.Point(4, 25);
            this.tabPersonalInfo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPersonalInfo.Name = "tabPersonalInfo";
            this.tabPersonalInfo.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPersonalInfo.Size = new System.Drawing.Size(855, 479);
            this.tabPersonalInfo.TabIndex = 0;
            this.tabPersonalInfo.Text = "Personal Info";
            this.tabPersonalInfo.UseVisualStyleBackColor = true;
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
            this.btnNext.Location = new System.Drawing.Point(720, 427);
            this.btnNext.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(108, 39);
            this.btnNext.TabIndex = 15;
            this.btnNext.Text = "Next";
            this.btnNext.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNext.UseVisualStyleBackColor = false;
            this.btnNext.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.uctrPersonDetails1);
            this.groupBox2.Location = new System.Drawing.Point(27, 172);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(801, 251);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Personal Information";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.uctrlFilterBy1);
            this.groupBox1.Location = new System.Drawing.Point(112, 53);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(629, 90);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filter";
            // 
            // tabLogin
            // 
            this.tabLogin.Controls.Add(this.chkIsActive);
            this.tabLogin.Controls.Add(this.tbCnfPassword);
            this.tabLogin.Controls.Add(this.tbUserName);
            this.tabLogin.Controls.Add(this.tbPassword);
            this.tabLogin.Controls.Add(this.lblUserID2);
            this.tabLogin.Controls.Add(this.lblConfirmPassword);
            this.tabLogin.Controls.Add(this.lblPassword);
            this.tabLogin.Controls.Add(this.lblUserName);
            this.tabLogin.Controls.Add(this.lblUserID1);
            this.tabLogin.Location = new System.Drawing.Point(4, 25);
            this.tabLogin.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabLogin.Name = "tabLogin";
            this.tabLogin.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabLogin.Size = new System.Drawing.Size(855, 479);
            this.tabLogin.TabIndex = 1;
            this.tabLogin.Text = "Login Info";
            this.tabLogin.UseVisualStyleBackColor = true;
            // 
            // chkIsActive
            // 
            this.chkIsActive.AutoSize = true;
            this.chkIsActive.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkIsActive.Location = new System.Drawing.Point(245, 229);
            this.chkIsActive.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chkIsActive.Name = "chkIsActive";
            this.chkIsActive.Size = new System.Drawing.Size(96, 27);
            this.chkIsActive.TabIndex = 21;
            this.chkIsActive.Text = "Is Active";
            this.chkIsActive.UseVisualStyleBackColor = true;
            // 
            // tbCnfPassword
            // 
            this.tbCnfPassword.Location = new System.Drawing.Point(281, 190);
            this.tbCnfPassword.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbCnfPassword.Name = "tbCnfPassword";
            this.tbCnfPassword.Size = new System.Drawing.Size(136, 22);
            this.tbCnfPassword.TabIndex = 20;
            // 
            // tbUserName
            // 
            this.tbUserName.Location = new System.Drawing.Point(281, 129);
            this.tbUserName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbUserName.Name = "tbUserName";
            this.tbUserName.Size = new System.Drawing.Size(136, 22);
            this.tbUserName.TabIndex = 15;
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(281, 159);
            this.tbPassword.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.Size = new System.Drawing.Size(136, 22);
            this.tbPassword.TabIndex = 17;
            // 
            // lblUserID2
            // 
            this.lblUserID2.AutoSize = true;
            this.lblUserID2.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserID2.Location = new System.Drawing.Point(280, 95);
            this.lblUserID2.Name = "lblUserID2";
            this.lblUserID2.Size = new System.Drawing.Size(41, 23);
            this.lblUserID2.TabIndex = 5;
            this.lblUserID2.Text = "N/A";
            this.lblUserID2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblConfirmPassword
            // 
            this.lblConfirmPassword.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConfirmPassword.Image = global::DVLD.Properties.Resources.Display1;
            this.lblConfirmPassword.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblConfirmPassword.Location = new System.Drawing.Point(40, 187);
            this.lblConfirmPassword.Name = "lblConfirmPassword";
            this.lblConfirmPassword.Size = new System.Drawing.Size(235, 27);
            this.lblConfirmPassword.TabIndex = 19;
            this.lblConfirmPassword.Text = "Confirm Password:";
            this.lblConfirmPassword.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPassword
            // 
            this.lblPassword.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassword.Image = global::DVLD.Properties.Resources.Display1;
            this.lblPassword.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblPassword.Location = new System.Drawing.Point(115, 159);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(160, 27);
            this.lblPassword.TabIndex = 16;
            this.lblPassword.Text = "Password:";
            this.lblPassword.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblUserName
            // 
            this.lblUserName.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserName.Image = global::DVLD.Properties.Resources.user_1_;
            this.lblUserName.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblUserName.Location = new System.Drawing.Point(108, 123);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(167, 37);
            this.lblUserName.TabIndex = 18;
            this.lblUserName.Text = "UserName:";
            this.lblUserName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblUserID1
            // 
            this.lblUserID1.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserID1.Image = global::DVLD.Properties.Resources.Display1;
            this.lblUserID1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblUserID1.Location = new System.Drawing.Point(132, 95);
            this.lblUserID1.Name = "lblUserID1";
            this.lblUserID1.Size = new System.Drawing.Size(143, 28);
            this.lblUserID1.TabIndex = 4;
            this.lblUserID1.Text = "User ID:";
            this.lblUserID1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uctrPersonDetails1
            // 
            this.uctrPersonDetails1.Location = new System.Drawing.Point(5, 22);
            this.uctrPersonDetails1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.uctrPersonDetails1.Name = "uctrPersonDetails1";
            this.uctrPersonDetails1.PersonID = -1;
            this.uctrPersonDetails1.Size = new System.Drawing.Size(789, 224);
            this.uctrPersonDetails1.TabIndex = 1;
            // 
            // uctrlFilterBy1
            // 
            this.uctrlFilterBy1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.uctrlFilterBy1.Location = new System.Drawing.Point(9, 24);
            this.uctrlFilterBy1.Margin = new System.Windows.Forms.Padding(5);
            this.uctrlFilterBy1.Name = "uctrlFilterBy1";
            this.uctrlFilterBy1.Size = new System.Drawing.Size(611, 53);
            this.uctrlFilterBy1.TabIndex = 0;
            // 
            // frmAddUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 714);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.lblFormLabel);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmAddUser";
            this.Text = "frmAddUser";
            this.tabControl1.ResumeLayout(false);
            this.tabPersonalInfo.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.tabLogin.ResumeLayout(false);
            this.tabLogin.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblFormLabel;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPersonalInfo;
        private System.Windows.Forms.TabPage tabLogin;
        private System.Windows.Forms.CheckBox chkIsActive;
        private System.Windows.Forms.TextBox tbCnfPassword;
        private System.Windows.Forms.Label lblConfirmPassword;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox tbUserName;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label lblUserID2;
        private System.Windows.Forms.Label lblUserID1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private uctrPersonDetails uctrPersonDetails1;
        private userControls.uctrlFilterBy uctrlFilterBy1;
        private System.Windows.Forms.Button btnNext;
    }
}