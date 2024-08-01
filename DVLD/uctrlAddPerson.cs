using BusinessLayer;
using DVLD.Properties;
using System;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace DVLD
{
    public partial class uctrlAddPerson : UserControl
    {
        string imageDirPath = @"C:\DVLD IMAGES\";

        //Get Countries from DB 
        Dictionary<string, int> CountryDict = clsCountry.GetAllCountries();
        
        public string FirstName { get { return tbFirstName.Text; } set {tbFirstName.Text = value ; } }
        public string SecondName { get { return tbSecondName.Text; } set { tbSecondName.Text = value; } }

        public string ThirdName { get { return tbThirdName.Text; } set { tbThirdName.Text = value; } }
        public string LastName { get { return tbLastName.Text; } set { tbLastName.Text = value; } }
        public string NationalNo { get { return tbNationalNo.Text; } set { tbNationalNo.Text = value; } }
        public DateTime DateOfBirth { get { return dtpDateOfBirth.Value; } set { dtpDateOfBirth.Value = value; } }
        public string Phone { get { return tbPhone.Text; } set { tbPhone.Text = value; } }
        public string Address { get { return tbAddress.Text; } set { tbAddress.Text = value; } }
        public string Email { get { return tbEmail.Text; } set { tbEmail.Text = value; } }
        public int CountryID { get { return CountryDict[cbCountry.Text]; } 
            set {
                var CountryName = CountryDict.FirstOrDefault(x => x.Value == value).Key;

                if (!string.IsNullOrEmpty(CountryName))
                {
                    cbCountry.Text = CountryName; 
                }
                else
                {
                    throw new KeyNotFoundException("The Country Does not Exist in Dictionary!");
                }
            } 
        }
        
        public int PersonID { get { return PersonID; } set { PersonID = value; } }

        public short GenderID { get { return (radbtnMale.Checked) ? (short)0 : (short)1; } 
            set { if (value == 0) { radbtnMale.Checked = true; } else {radbtnFemale.Checked = true;}} } 
        public string pbPath { get { return pbProfilePic.ImageLocation; } 
            set { pbProfilePic.ImageLocation = value; } }







        public uctrlAddPerson()
        {
            InitializeComponent();
        }

        private void ValidateDateTimePicker()
        {
            //Validate the DateOfBirth +18 
            TimeSpan timeSpan = TimeSpan.FromDays(6574);//18 years * 365.25 days = 6574.5 days
            dtpDateOfBirth.MaxDate = DateTime.Now - timeSpan;
            dtpDateOfBirth.Value = dtpDateOfBirth.MaxDate;
        }

        private void ValidatingIsEmailValid(object sender, CancelEventArgs e)
        {
            
            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            if (!string.IsNullOrEmpty(tbEmail.Text) && !Regex.IsMatch(tbEmail.Text,emailPattern))
            {
                //prevent losing focus
                e.Cancel = true;
                errorProvider1.SetError(tbEmail, "Email isn't Valid Format!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(tbEmail, "");
            }
        }


        private void ValidatingIsNationalNoExist(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrEmpty(tbNationalNo.Text))
            {
                //since the validateboxes set error we don't need to
                return;
            }

            if (clsPerson.isNationalNumberExist(tbNationalNo.Text))
            {
                //prevent losing focus
                e.Cancel = true;
                errorProvider1.SetError(tbNationalNo, "this National Number is Exist!");
            }
            else
            {
                e.Cancel = false;
                //errorProvider1.Clear();
                errorProvider1.SetError(tbNationalNo, "");


            }

        }

        private void ValidateName(object sender, KeyEventArgs e)
        {
            if (char.IsLetter((char)e.KeyValue) || e.KeyCode == Keys.Space || e.KeyCode == Keys.Back || e.KeyCode == Keys.Left || e.KeyCode == Keys.Right)
            {
                e.Handled = false;
                e.SuppressKeyPress = false;
            }
            else
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void ValidateBoxes(object sender, CancelEventArgs e)
        {
            if (sender is TextBox tb)
            {
                if (string.IsNullOrEmpty(tb.Text))
                {
                    e.Cancel = true;
                    errorProvider1.SetError(tb, "can't be empty");
                    return;
                }
                else
                {
                    e.Cancel = false;
                    errorProvider1.SetError(tb, "");

                }
            }
            
        }




        private void uctrlAddPerson_Load(object sender, EventArgs e)
        {
            ValidateDateTimePicker();


            //fill COuntry combobox
            foreach (var Country in CountryDict)
            {
                cbCountry.Items.Add(Country.Key);
            }            

            var indexOfIraq = cbCountry.Items.IndexOf("Iraq");
            if (indexOfIraq != -1)
            {
            cbCountry.SelectedItem = cbCountry.Items[cbCountry.Items.IndexOf("Iraq")];
            }
            
  

            //resize icons
            radbtnMale.Image = Utilites.ResizeImage(radbtnMale.Image, 15, 15);
            radbtnFemale.Image = Utilites.ResizeImage(radbtnFemale.Image, 15, 15);




            //Invoke Events Handler
            tbNationalNo.Validating += ValidatingIsNationalNoExist;

            //in Update Mode Checking if picBox not empty then let remove be visable
            if (!string.IsNullOrEmpty(pbProfilePic.ImageLocation))
            {
                lblRemove.Visible = true;
            }
        }

        private void tbPhone_KeyDown(object sender, KeyEventArgs e)
        {
            if (char.IsDigit((char)e.KeyValue) || e.KeyCode == Keys.Space || e.KeyCode == Keys.Back || e.KeyCode == Keys.Left || e.KeyCode == Keys.Right)
            {
                e.SuppressKeyPress = false;
                e.Handled = false;
            }
            else
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
            }
        }

        private void lnklblSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.DefaultExt = "img";
            fileDialog.Filter = "Image File|*.png;*.jpg;*.jpeg;*.bmp;";

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {

                //make remove label visible
                lblRemove.Visible = true;
                pbProfilePic.ImageLocation = fileDialog.FileName;
            }

        }

        private void radbtnMale_CheckedChanged(object sender, EventArgs e)
        {
            if (radbtnMale.Checked)
            {
                pbProfilePic.Image = Resources.User_Male;
            }
        }

        private void radbtnFemale_CheckedChanged(object sender, EventArgs e)
        {
            if (radbtnFemale.Checked)
            {
                pbProfilePic.Image = Resources.Female_User;
            }
        }


        private void lblRemove_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            lblRemove.Visible = false;

            pbProfilePic.Image = (radbtnMale.Checked) ? Resources.User_Male: Resources.Female_User;

            pbProfilePic.ImageLocation = null;
        }


        public bool isEveryRequiredFieldFilled()
        {
            List<TextBox> list = new List<TextBox>
            { tbFirstName,tbSecondName,tbThirdName,tbLastName,tbNationalNo,tbPhone,tbAddress};
            bool Result = true;

            foreach (TextBox txt in list)
            {
                if (string.IsNullOrEmpty(txt.Text))
                {
                    errorProvider1.SetError(txt, "this Field Can't Be Empty!");
                    Result = false;
                }

            }
            return Result;
        }

        private void Save()
        {
            //if (!isEveryRequiredFieldFilled())
            //{
            //    return;
            //}



            //Before Saving Person Save Update ImageLocation And Save IT in ImgDir
            if (pbProfilePic.ImageLocation != null)
            {
                var newGuid = Guid.NewGuid().ToString();
                var newLocation = @"C:\DVLD IMAGES\" + newGuid + ".png";
                //copy the image for DVLV FOLDER
                if (Directory.Exists(@"C:\DVLD IMAGES\"))
                {
                    File.Copy(pbProfilePic.ImageLocation, newLocation, overwrite: true);

                }
                else
                {
                    Directory.CreateDirectory(@"C:\DVLD IMAGES\");
                    File.Copy(pbProfilePic.ImageLocation, newLocation, overwrite: true);
                }

                pbProfilePic.ImageLocation = newLocation;
            }

            short gender;
            gender = (radbtnMale.Checked) ? (short)0 : (short)1;

            
            
                ////Save
                //if ((_PersonID = PeopleBusinessLayer.SavePerson(tbFirstName.Text, tbLastName.Text, tbThirdName.Text, tbLastName.Text, tbNationalNo.Text, dtpDateOfBirth.Value, gender, tbPhone.Text, tbEmail.Text, CountryDict[cbCountry.Text], tbAddress.Text, pbProfilePic.ImageLocation)) != -1)
                //{

                //}
             

            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!isEveryRequiredFieldFilled())
            {
                return;
            }


            //getting new Location for the imagePath
            //string OldLocation = uctrlAddPerson1.pbPath;
            var newGuid = string.Empty;
            var NewLocation = string.Empty;
            var OriginalLocation = string.Empty;

            if (!string.IsNullOrEmpty(pbProfilePic.ImageLocation))
            {
                newGuid = Guid.NewGuid().ToString();
                NewLocation = imageDirPath + newGuid + ".png";
                OriginalLocation = pbProfilePic.ImageLocation;
                pbProfilePic.ImageLocation = NewLocation;
            }

            //get Informations ToThe Person
            GetOrFillBoxes(false);






            if (_Person.Save())
            {
                CopyImage(OriginalLocation, NewLocation);

                if (_ctrlMode == ctrlMode.Add)
                {
                    _ctrlMode = ctrlMode.Update;
                }

                //update old image path
                OldImagePath = NewLocation;

                MessageBox.Show("Person Saved Succesfully.");
            }
            else
            {
                MessageBox.Show("Failed To Save Person Information!");
            }



            UpdateForm();
        }
    }
}
