namespace DVLD.UserForm
{
    partial class frmChangePassword
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChangePassword));
            this.uctrlLoginInformation1 = new DVLD.userControls.uctrlLoginInformation();
            this.uctrPersonDetails1 = new DVLD.uctrPersonDetails();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.tbCnfPassword = new System.Windows.Forms.TextBox();
            this.tbNewPassword = new System.Windows.Forms.TextBox();
            this.lblConfirmPassword = new System.Windows.Forms.Label();
            this.lblNewPassword = new System.Windows.Forms.Label();
            this.tbCurrentPassword = new System.Windows.Forms.TextBox();
            this.lblCurrentPassword = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // uctrlLoginInformation1
            // 
            this.uctrlLoginInformation1.Location = new System.Drawing.Point(11, 198);
            this.uctrlLoginInformation1.Margin = new System.Windows.Forms.Padding(2);
            this.uctrlLoginInformation1.Name = "uctrlLoginInformation1";
            this.uctrlLoginInformation1.Size = new System.Drawing.Size(608, 64);
            this.uctrlLoginInformation1.TabIndex = 2;
            // 
            // uctrPersonDetails1
            // 
            this.uctrPersonDetails1.Location = new System.Drawing.Point(11, 12);
            this.uctrPersonDetails1.Margin = new System.Windows.Forms.Padding(2);
            this.uctrPersonDetails1.Name = "uctrPersonDetails1";
            this.uctrPersonDetails1.PersonID = -1;
            this.uctrPersonDetails1.Size = new System.Drawing.Size(608, 182);
            this.uctrPersonDetails1.TabIndex = 0;
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
            this.btnSave.Location = new System.Drawing.Point(538, 387);
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
            this.btnClose.Location = new System.Drawing.Point(452, 387);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(81, 32);
            this.btnClose.TabIndex = 18;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // tbCnfPassword
            // 
            this.tbCnfPassword.Location = new System.Drawing.Point(319, 331);
            this.tbCnfPassword.Margin = new System.Windows.Forms.Padding(2);
            this.tbCnfPassword.MaxLength = 32;
            this.tbCnfPassword.Name = "tbCnfPassword";
            this.tbCnfPassword.PasswordChar = '*';
            this.tbCnfPassword.Size = new System.Drawing.Size(103, 20);
            this.tbCnfPassword.TabIndex = 24;
            // 
            // tbNewPassword
            // 
            this.tbNewPassword.Location = new System.Drawing.Point(319, 307);
            this.tbNewPassword.Margin = new System.Windows.Forms.Padding(2);
            this.tbNewPassword.MaxLength = 32;
            this.tbNewPassword.Name = "tbNewPassword";
            this.tbNewPassword.PasswordChar = '*';
            this.tbNewPassword.Size = new System.Drawing.Size(103, 20);
            this.tbNewPassword.TabIndex = 22;
            // 
            // lblConfirmPassword
            // 
            this.lblConfirmPassword.AutoSize = true;
            this.lblConfirmPassword.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConfirmPassword.Image = ((System.Drawing.Image)(resources.GetObject("lblConfirmPassword.Image")));
            this.lblConfirmPassword.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblConfirmPassword.Location = new System.Drawing.Point(154, 331);
            this.lblConfirmPassword.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblConfirmPassword.Name = "lblConfirmPassword";
            this.lblConfirmPassword.Size = new System.Drawing.Size(166, 19);
            this.lblConfirmPassword.TabIndex = 23;
            this.lblConfirmPassword.Text = "Confirm Password:          ";
            this.lblConfirmPassword.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblNewPassword
            // 
            this.lblNewPassword.AutoSize = true;
            this.lblNewPassword.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNewPassword.Image = ((System.Drawing.Image)(resources.GetObject("lblNewPassword.Image")));
            this.lblNewPassword.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblNewPassword.Location = new System.Drawing.Point(175, 307);
            this.lblNewPassword.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNewPassword.Name = "lblNewPassword";
            this.lblNewPassword.Size = new System.Drawing.Size(144, 19);
            this.lblNewPassword.TabIndex = 21;
            this.lblNewPassword.Text = "New Password:          ";
            this.lblNewPassword.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbCurrentPassword
            // 
            this.tbCurrentPassword.Location = new System.Drawing.Point(319, 284);
            this.tbCurrentPassword.Margin = new System.Windows.Forms.Padding(2);
            this.tbCurrentPassword.MaxLength = 32;
            this.tbCurrentPassword.Name = "tbCurrentPassword";
            this.tbCurrentPassword.PasswordChar = '*';
            this.tbCurrentPassword.Size = new System.Drawing.Size(103, 20);
            this.tbCurrentPassword.TabIndex = 26;
            this.tbCurrentPassword.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbCurrentPassword_KeyUp);
            // 
            // lblCurrentPassword
            // 
            this.lblCurrentPassword.AutoSize = true;
            this.lblCurrentPassword.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentPassword.Image = ((System.Drawing.Image)(resources.GetObject("lblCurrentPassword.Image")));
            this.lblCurrentPassword.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblCurrentPassword.Location = new System.Drawing.Point(157, 284);
            this.lblCurrentPassword.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCurrentPassword.Name = "lblCurrentPassword";
            this.lblCurrentPassword.Size = new System.Drawing.Size(162, 19);
            this.lblCurrentPassword.TabIndex = 25;
            this.lblCurrentPassword.Text = "Current Password:          ";
            this.lblCurrentPassword.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // errorProvider1
            // 
            this.errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider1.ContainerControl = this;
            // 
            // frmChangePassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(630, 430);
            this.Controls.Add(this.uctrlLoginInformation1);
            this.Controls.Add(this.uctrPersonDetails1);
            this.Controls.Add(this.tbCurrentPassword);
            this.Controls.Add(this.lblCurrentPassword);
            this.Controls.Add(this.tbCnfPassword);
            this.Controls.Add(this.tbNewPassword);
            this.Controls.Add(this.lblConfirmPassword);
            this.Controls.Add(this.lblNewPassword);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmChangePassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Change Password";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private uctrPersonDetails uctrPersonDetails1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox tbCnfPassword;
        private System.Windows.Forms.TextBox tbNewPassword;
        private System.Windows.Forms.Label lblConfirmPassword;
        private System.Windows.Forms.Label lblNewPassword;
        private System.Windows.Forms.TextBox tbCurrentPassword;
        private System.Windows.Forms.Label lblCurrentPassword;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private userControls.uctrlLoginInformation uctrlLoginInformation1;
    }
}