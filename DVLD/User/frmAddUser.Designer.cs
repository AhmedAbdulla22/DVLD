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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddUser));
            this.lblFormLabel = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPersonalInfo = new System.Windows.Forms.TabPage();
            this.uctrlFilterBy1 = new DVLD.userControls.uctrlFilterBy();
            this.uctrPersonDetails1 = new DVLD.uctrPersonDetails();
            this.btnNext = new System.Windows.Forms.Button();
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
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPersonalInfo.SuspendLayout();
            this.tabLogin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblFormLabel
            // 
            this.lblFormLabel.AutoSize = true;
            this.lblFormLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFormLabel.ForeColor = System.Drawing.Color.DarkRed;
            this.lblFormLabel.Location = new System.Drawing.Point(228, 7);
            this.lblFormLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFormLabel.Name = "lblFormLabel";
            this.lblFormLabel.Size = new System.Drawing.Size(191, 37);
            this.lblFormLabel.TabIndex = 3;
            this.lblFormLabel.Text = "Add New User";
            this.lblFormLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPersonalInfo);
            this.tabControl1.Controls.Add(this.tabLogin);
            this.tabControl1.Location = new System.Drawing.Point(19, 51);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(647, 413);
            this.tabControl1.TabIndex = 4;
            this.tabControl1.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tabControl1_Selecting);
            // 
            // tabPersonalInfo
            // 
            this.tabPersonalInfo.BackColor = System.Drawing.Color.White;
            this.tabPersonalInfo.Controls.Add(this.uctrlFilterBy1);
            this.tabPersonalInfo.Controls.Add(this.uctrPersonDetails1);
            this.tabPersonalInfo.Controls.Add(this.btnNext);
            this.tabPersonalInfo.Location = new System.Drawing.Point(4, 22);
            this.tabPersonalInfo.Margin = new System.Windows.Forms.Padding(2);
            this.tabPersonalInfo.Name = "tabPersonalInfo";
            this.tabPersonalInfo.Padding = new System.Windows.Forms.Padding(2);
            this.tabPersonalInfo.Size = new System.Drawing.Size(639, 387);
            this.tabPersonalInfo.TabIndex = 0;
            this.tabPersonalInfo.Text = "Personal Info";
            // 
            // uctrlFilterBy1
            // 
            this.uctrlFilterBy1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.uctrlFilterBy1.BackColor = System.Drawing.Color.White;
            this.uctrlFilterBy1.Location = new System.Drawing.Point(17, 56);
            this.uctrlFilterBy1.Margin = new System.Windows.Forms.Padding(4);
            this.uctrlFilterBy1.Name = "uctrlFilterBy1";
            this.uctrlFilterBy1.Size = new System.Drawing.Size(604, 67);
            this.uctrlFilterBy1.TabIndex = 0;
            // 
            // uctrPersonDetails1
            // 
            this.uctrPersonDetails1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.uctrPersonDetails1.Location = new System.Drawing.Point(17, 143);
            this.uctrPersonDetails1.Margin = new System.Windows.Forms.Padding(2);
            this.uctrPersonDetails1.Name = "uctrPersonDetails1";
            this.uctrPersonDetails1.PersonID = -1;
            this.uctrPersonDetails1.Size = new System.Drawing.Size(604, 196);
            this.uctrPersonDetails1.TabIndex = 1;
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
            this.btnNext.Location = new System.Drawing.Point(540, 347);
            this.btnNext.Margin = new System.Windows.Forms.Padding(2);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(81, 32);
            this.btnNext.TabIndex = 15;
            this.btnNext.Text = "Next";
            this.btnNext.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNext.UseVisualStyleBackColor = false;
            this.btnNext.Click += new System.EventHandler(this.button2_Click);
            // 
            // tabLogin
            // 
            this.tabLogin.BackColor = System.Drawing.Color.White;
            this.tabLogin.Controls.Add(this.chkIsActive);
            this.tabLogin.Controls.Add(this.tbCnfPassword);
            this.tabLogin.Controls.Add(this.tbUserName);
            this.tabLogin.Controls.Add(this.tbPassword);
            this.tabLogin.Controls.Add(this.lblUserID2);
            this.tabLogin.Controls.Add(this.lblConfirmPassword);
            this.tabLogin.Controls.Add(this.lblPassword);
            this.tabLogin.Controls.Add(this.lblUserName);
            this.tabLogin.Controls.Add(this.lblUserID1);
            this.tabLogin.Location = new System.Drawing.Point(4, 22);
            this.tabLogin.Margin = new System.Windows.Forms.Padding(2);
            this.tabLogin.Name = "tabLogin";
            this.tabLogin.Padding = new System.Windows.Forms.Padding(2);
            this.tabLogin.Size = new System.Drawing.Size(639, 387);
            this.tabLogin.TabIndex = 1;
            this.tabLogin.Text = "Login Info";
            // 
            // chkIsActive
            // 
            this.chkIsActive.AutoSize = true;
            this.chkIsActive.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkIsActive.Location = new System.Drawing.Point(184, 186);
            this.chkIsActive.Margin = new System.Windows.Forms.Padding(2);
            this.chkIsActive.Name = "chkIsActive";
            this.chkIsActive.Size = new System.Drawing.Size(81, 23);
            this.chkIsActive.TabIndex = 21;
            this.chkIsActive.Text = "Is Active";
            this.chkIsActive.UseVisualStyleBackColor = true;
            // 
            // tbCnfPassword
            // 
            this.tbCnfPassword.Location = new System.Drawing.Point(211, 154);
            this.tbCnfPassword.Margin = new System.Windows.Forms.Padding(2);
            this.tbCnfPassword.MaxLength = 32;
            this.tbCnfPassword.Name = "tbCnfPassword";
            this.tbCnfPassword.PasswordChar = '*';
            this.tbCnfPassword.Size = new System.Drawing.Size(103, 20);
            this.tbCnfPassword.TabIndex = 20;
            this.tbCnfPassword.Leave += new System.EventHandler(this.tbCnfPassword_Leave);
            // 
            // tbUserName
            // 
            this.tbUserName.Location = new System.Drawing.Point(211, 105);
            this.tbUserName.Margin = new System.Windows.Forms.Padding(2);
            this.tbUserName.MaxLength = 32;
            this.tbUserName.Name = "tbUserName";
            this.tbUserName.Size = new System.Drawing.Size(103, 20);
            this.tbUserName.TabIndex = 15;
            this.tbUserName.Leave += new System.EventHandler(this.tbUserName_Leave);
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(211, 129);
            this.tbPassword.Margin = new System.Windows.Forms.Padding(2);
            this.tbPassword.MaxLength = 32;
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.PasswordChar = '*';
            this.tbPassword.Size = new System.Drawing.Size(103, 20);
            this.tbPassword.TabIndex = 17;
            // 
            // lblUserID2
            // 
            this.lblUserID2.AutoSize = true;
            this.lblUserID2.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserID2.Location = new System.Drawing.Point(210, 77);
            this.lblUserID2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblUserID2.Name = "lblUserID2";
            this.lblUserID2.Size = new System.Drawing.Size(35, 19);
            this.lblUserID2.TabIndex = 5;
            this.lblUserID2.Text = "N/A";
            this.lblUserID2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblConfirmPassword
            // 
            this.lblConfirmPassword.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConfirmPassword.Image = ((System.Drawing.Image)(resources.GetObject("lblConfirmPassword.Image")));
            this.lblConfirmPassword.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblConfirmPassword.Location = new System.Drawing.Point(31, 152);
            this.lblConfirmPassword.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblConfirmPassword.Name = "lblConfirmPassword";
            this.lblConfirmPassword.Size = new System.Drawing.Size(175, 22);
            this.lblConfirmPassword.TabIndex = 19;
            this.lblConfirmPassword.Text = "Confirm Password:";
            this.lblConfirmPassword.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPassword
            // 
            this.lblPassword.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassword.Image = ((System.Drawing.Image)(resources.GetObject("lblPassword.Image")));
            this.lblPassword.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblPassword.Location = new System.Drawing.Point(86, 129);
            this.lblPassword.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(120, 22);
            this.lblPassword.TabIndex = 16;
            this.lblPassword.Text = "Password:";
            this.lblPassword.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblUserName
            // 
            this.lblUserName.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserName.Image = global::DVLD.Properties.Resources.user_1_;
            this.lblUserName.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblUserName.Location = new System.Drawing.Point(80, 100);
            this.lblUserName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(126, 30);
            this.lblUserName.TabIndex = 18;
            this.lblUserName.Text = "UserName:";
            this.lblUserName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblUserID1
            // 
            this.lblUserID1.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserID1.Image = global::DVLD.Properties.Resources.Display1;
            this.lblUserID1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblUserID1.Location = new System.Drawing.Point(99, 77);
            this.lblUserID1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblUserID1.Name = "lblUserID1";
            this.lblUserID1.Size = new System.Drawing.Size(107, 23);
            this.lblUserID1.TabIndex = 4;
            this.lblUserID1.Text = "User ID:";
            this.lblUserID1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
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
            this.btnSave.Location = new System.Drawing.Point(581, 470);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(81, 32);
            this.btnSave.TabIndex = 17;
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
            this.btnClose.Location = new System.Drawing.Point(496, 470);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(81, 32);
            this.btnClose.TabIndex = 16;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmAddUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(675, 513);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.lblFormLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmAddUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmAddUser";
            this.Load += new System.EventHandler(this.frmAddUser_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPersonalInfo.ResumeLayout(false);
            this.tabLogin.ResumeLayout(false);
            this.tabLogin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private uctrPersonDetails uctrPersonDetails1;
        private userControls.uctrlFilterBy uctrlFilterBy1;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
    }
}