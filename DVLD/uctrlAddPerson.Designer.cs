namespace DVLD
{
    partial class uctrlAddPerson
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(uctrlAddPerson));
            this.label2 = new System.Windows.Forms.Label();
            this.tbFirstName = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tbSecondName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbThirdName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbLastName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbNationalNo = new System.Windows.Forms.TextBox();
            this.dtpDateOfBirth = new System.Windows.Forms.DateTimePicker();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.tbPhone = new System.Windows.Forms.TextBox();
            this.tbEmail = new System.Windows.Forms.TextBox();
            this.cbCountry = new System.Windows.Forms.ComboBox();
            this.tbAddress = new System.Windows.Forms.TextBox();
            this.lnklblSetImage = new System.Windows.Forms.LinkLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pbProfilePic = new System.Windows.Forms.PictureBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblNationalNumber = new System.Windows.Forms.Label();
            this.lblPhone = new System.Windows.Forms.Label();
            this.radbtnFemale = new System.Windows.Forms.RadioButton();
            this.label7 = new System.Windows.Forms.Label();
            this.radbtnMale = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblPersonID1 = new System.Windows.Forms.Label();
            this.lblPersonID2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbProfilePic)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(249, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "First:";
            // 
            // tbFirstName
            // 
            this.tbFirstName.Location = new System.Drawing.Point(177, 55);
            this.tbFirstName.Name = "tbFirstName";
            this.tbFirstName.Size = new System.Drawing.Size(182, 26);
            this.tbFirstName.TabIndex = 2;
            this.tbFirstName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ValidateName);
            this.tbFirstName.Validating += new System.ComponentModel.CancelEventHandler(this.ValidateBoxes);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // tbSecondName
            // 
            this.tbSecondName.Location = new System.Drawing.Point(368, 55);
            this.tbSecondName.Name = "tbSecondName";
            this.tbSecondName.Size = new System.Drawing.Size(182, 26);
            this.tbSecondName.TabIndex = 5;
            this.tbSecondName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ValidateName);
            this.tbSecondName.Validating += new System.ComponentModel.CancelEventHandler(this.ValidateBoxes);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(429, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 25);
            this.label3.TabIndex = 4;
            this.label3.Text = "Second:";
            // 
            // tbThirdName
            // 
            this.tbThirdName.Location = new System.Drawing.Point(558, 55);
            this.tbThirdName.Name = "tbThirdName";
            this.tbThirdName.Size = new System.Drawing.Size(182, 26);
            this.tbThirdName.TabIndex = 7;
            this.tbThirdName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ValidateName);
            this.tbThirdName.Validating += new System.ComponentModel.CancelEventHandler(this.ValidateBoxes);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(624, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 25);
            this.label4.TabIndex = 6;
            this.label4.Text = "Third:";
            // 
            // tbLastName
            // 
            this.tbLastName.Location = new System.Drawing.Point(748, 55);
            this.tbLastName.Name = "tbLastName";
            this.tbLastName.Size = new System.Drawing.Size(182, 26);
            this.tbLastName.TabIndex = 9;
            this.tbLastName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ValidateName);
            this.tbLastName.Validating += new System.ComponentModel.CancelEventHandler(this.ValidateBoxes);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(818, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 25);
            this.label5.TabIndex = 8;
            this.label5.Text = "Last:";
            // 
            // tbNationalNo
            // 
            this.tbNationalNo.Location = new System.Drawing.Point(177, 102);
            this.tbNationalNo.Name = "tbNationalNo";
            this.tbNationalNo.Size = new System.Drawing.Size(182, 26);
            this.tbNationalNo.TabIndex = 11;
            this.tbNationalNo.Validating += new System.ComponentModel.CancelEventHandler(this.ValidateBoxes);
            // 
            // dtpDateOfBirth
            // 
            this.dtpDateOfBirth.Location = new System.Drawing.Point(554, 98);
            this.dtpDateOfBirth.MinDate = new System.DateTime(1940, 1, 25, 23, 59, 59, 999);
            this.dtpDateOfBirth.Name = "dtpDateOfBirth";
            this.dtpDateOfBirth.Size = new System.Drawing.Size(194, 26);
            this.dtpDateOfBirth.TabIndex = 13;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label6.Location = new System.Drawing.Point(8, 149);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(158, 34);
            this.label6.TabIndex = 15;
            this.label6.Text = "Gender:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbPhone
            // 
            this.tbPhone.Location = new System.Drawing.Point(558, 148);
            this.tbPhone.Name = "tbPhone";
            this.tbPhone.Size = new System.Drawing.Size(182, 26);
            this.tbPhone.TabIndex = 19;
            this.tbPhone.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbPhone_KeyDown);
            // 
            // tbEmail
            // 
            this.tbEmail.Location = new System.Drawing.Point(132, 235);
            this.tbEmail.Name = "tbEmail";
            this.tbEmail.Size = new System.Drawing.Size(182, 26);
            this.tbEmail.TabIndex = 21;
            this.tbEmail.Validating += new System.ComponentModel.CancelEventHandler(this.ValidatingIsEmailValid);
            // 
            // cbCountry
            // 
            this.cbCountry.FormattingEnabled = true;
            this.cbCountry.Location = new System.Drawing.Point(558, 234);
            this.cbCountry.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbCountry.Name = "cbCountry";
            this.cbCountry.Size = new System.Drawing.Size(180, 28);
            this.cbCountry.TabIndex = 23;
            // 
            // tbAddress
            // 
            this.tbAddress.Location = new System.Drawing.Point(132, 275);
            this.tbAddress.Multiline = true;
            this.tbAddress.Name = "tbAddress";
            this.tbAddress.Size = new System.Drawing.Size(606, 102);
            this.tbAddress.TabIndex = 25;
            this.tbAddress.Validating += new System.ComponentModel.CancelEventHandler(this.ValidateBoxes);
            // 
            // lnklblSetImage
            // 
            this.lnklblSetImage.AutoSize = true;
            this.lnklblSetImage.Location = new System.Drawing.Point(798, 266);
            this.lnklblSetImage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lnklblSetImage.Name = "lnklblSetImage";
            this.lnklblSetImage.Size = new System.Drawing.Size(83, 20);
            this.lnklblSetImage.TabIndex = 27;
            this.lnklblSetImage.TabStop = true;
            this.lnklblSetImage.Text = "Set Image";
            this.lnklblSetImage.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnklblSetImage_LinkClicked);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pbProfilePic);
            this.groupBox1.Controls.Add(this.lnklblSetImage);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tbFirstName);
            this.groupBox1.Controls.Add(this.tbAddress);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.tbSecondName);
            this.groupBox1.Controls.Add(this.cbCountry);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.tbThirdName);
            this.groupBox1.Controls.Add(this.tbEmail);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.tbLastName);
            this.groupBox1.Controls.Add(this.tbPhone);
            this.groupBox1.Controls.Add(this.lblNationalNumber);
            this.groupBox1.Controls.Add(this.lblPhone);
            this.groupBox1.Controls.Add(this.tbNationalNo);
            this.groupBox1.Controls.Add(this.radbtnFemale);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.radbtnMale);
            this.groupBox1.Controls.Add(this.dtpDateOfBirth);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(27, 51);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(939, 409);
            this.groupBox1.TabIndex = 28;
            this.groupBox1.TabStop = false;
            // 
            // pbProfilePic
            // 
            this.pbProfilePic.Image = global::DVLD.Properties.Resources.User_Male;
            this.pbProfilePic.Location = new System.Drawing.Point(758, 94);
            this.pbProfilePic.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pbProfilePic.Name = "pbProfilePic";
            this.pbProfilePic.Size = new System.Drawing.Size(165, 168);
            this.pbProfilePic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbProfilePic.TabIndex = 26;
            this.pbProfilePic.TabStop = false;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Image = global::DVLD.Properties.Resources.home;
            this.label10.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label10.Location = new System.Drawing.Point(8, 269);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(118, 40);
            this.label10.TabIndex = 24;
            this.label10.Text = "Address:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Image = global::DVLD.Properties.Resources.maps;
            this.label9.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label9.Location = new System.Drawing.Point(432, 228);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(118, 40);
            this.label9.TabIndex = 22;
            this.label9.Text = "Country:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Image = global::DVLD.Properties.Resources.arroba;
            this.label8.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label8.Location = new System.Drawing.Point(8, 229);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(118, 40);
            this.label8.TabIndex = 20;
            this.label8.Text = "Email:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblNationalNumber
            // 
            this.lblNationalNumber.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNationalNumber.Image = global::DVLD.Properties.Resources.Display1;
            this.lblNationalNumber.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblNationalNumber.Location = new System.Drawing.Point(8, 98);
            this.lblNationalNumber.Name = "lblNationalNumber";
            this.lblNationalNumber.Size = new System.Drawing.Size(158, 34);
            this.lblNationalNumber.TabIndex = 10;
            this.lblNationalNumber.Text = "National .No:";
            this.lblNationalNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPhone
            // 
            this.lblPhone.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhone.Image = global::DVLD.Properties.Resources.phone_call_1_;
            this.lblPhone.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblPhone.Location = new System.Drawing.Point(434, 145);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(118, 40);
            this.lblPhone.TabIndex = 18;
            this.lblPhone.Text = "Phone:";
            this.lblPhone.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // radbtnFemale
            // 
            this.radbtnFemale.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.radbtnFemale.Image = global::DVLD.Properties.Resources.user_2_;
            this.radbtnFemale.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.radbtnFemale.Location = new System.Drawing.Point(238, 146);
            this.radbtnFemale.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.radbtnFemale.Name = "radbtnFemale";
            this.radbtnFemale.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.radbtnFemale.Size = new System.Drawing.Size(123, 42);
            this.radbtnFemale.TabIndex = 17;
            this.radbtnFemale.Text = "Female";
            this.radbtnFemale.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.radbtnFemale.UseVisualStyleBackColor = true;
            this.radbtnFemale.CheckedChanged += new System.EventHandler(this.radbtnFemale_CheckedChanged);
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Image = global::DVLD.Properties.Resources.Tear_Off_Calendar;
            this.label7.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label7.Location = new System.Drawing.Point(381, 95);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(171, 40);
            this.label7.TabIndex = 12;
            this.label7.Text = "Date Of Birth:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // radbtnMale
            // 
            this.radbtnMale.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.radbtnMale.Checked = true;
            this.radbtnMale.Image = global::DVLD.Properties.Resources.user_3_;
            this.radbtnMale.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.radbtnMale.Location = new System.Drawing.Point(129, 149);
            this.radbtnMale.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.radbtnMale.Name = "radbtnMale";
            this.radbtnMale.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.radbtnMale.Size = new System.Drawing.Size(100, 38);
            this.radbtnMale.TabIndex = 16;
            this.radbtnMale.TabStop = true;
            this.radbtnMale.Text = "Male";
            this.radbtnMale.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.radbtnMale.UseVisualStyleBackColor = true;
            this.radbtnMale.CheckedChanged += new System.EventHandler(this.radbtnMale_CheckedChanged);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Image = global::DVLD.Properties.Resources.user_1_;
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label1.Location = new System.Drawing.Point(8, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 46);
            this.label1.TabIndex = 14;
            this.label1.Text = "Name:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnClose
            // 
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(694, 480);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(122, 46);
            this.btnClose.TabIndex = 28;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = global::DVLD.Properties.Resources.diskette_1_;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(825, 480);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(141, 46);
            this.btnSave.TabIndex = 29;
            this.btnSave.Text = "Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // lblPersonID1
            // 
            this.lblPersonID1.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPersonID1.Image = global::DVLD.Properties.Resources.Display1;
            this.lblPersonID1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblPersonID1.Location = new System.Drawing.Point(22, 12);
            this.lblPersonID1.Name = "lblPersonID1";
            this.lblPersonID1.Size = new System.Drawing.Size(130, 34);
            this.lblPersonID1.TabIndex = 28;
            this.lblPersonID1.Text = "Person ID:";
            this.lblPersonID1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPersonID2
            // 
            this.lblPersonID2.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPersonID2.Location = new System.Drawing.Point(159, 12);
            this.lblPersonID2.Name = "lblPersonID2";
            this.lblPersonID2.Size = new System.Drawing.Size(142, 34);
            this.lblPersonID2.TabIndex = 30;
            this.lblPersonID2.Text = "N/A";
            this.lblPersonID2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uctrlAddPerson
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lblPersonID2);
            this.Controls.Add(this.lblPersonID1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupBox1);
            this.Name = "uctrlAddPerson";
            this.Size = new System.Drawing.Size(999, 545);
            this.Load += new System.EventHandler(this.uctrlAddPerson_Load);
            this.Validating += new System.ComponentModel.CancelEventHandler(this.ValidateBoxes);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbProfilePic)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbFirstName;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.TextBox tbSecondName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbThirdName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbLastName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbNationalNo;
        private System.Windows.Forms.Label lblNationalNumber;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtpDateOfBirth;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radbtnMale;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RadioButton radbtnFemale;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.TextBox tbPhone;
        private System.Windows.Forms.TextBox tbEmail;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbAddress;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cbCountry;
        private System.Windows.Forms.PictureBox pbProfilePic;
        private System.Windows.Forms.LinkLabel lnklblSetImage;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblPersonID1;
        private System.Windows.Forms.Label lblPersonID2;
    }
}
