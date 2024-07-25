using BusinessLayer;
using DVLD.Properties;
using System;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.IO;
using System.Collections.Generic;

namespace DVLD
{
    public partial class uctrlAddPerson : UserControl
    {
        int _PersonID = -1;

        //Get Countries from DB 
        Dictionary<string, int> CountryDict = CountryBusinessLayer.GetAllCountries();

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

            if (PeopleBusinessLayer.isNationalNumberExist(tbNationalNo.Text))
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
            btnClose.Image = Utilites.ResizeImage(btnClose.Image, 20, 20);
            btnSave.Image = Utilites.ResizeImage(btnSave.Image, 20, 20);




            //Invoke Events Handler
            tbNationalNo.Validating += ValidatingIsNationalNoExist;
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
                //Delete the Current Pbox image if exist
                if (!string.IsNullOrEmpty( pbProfilePic.ImageLocation))
                {
                File.Delete(pbProfilePic.ImageLocation);
                }

                //make remove label visible
                lblRemove.Visible = true;

                var newGuid = Guid.NewGuid().ToString();
                //copy the image for DVLV FOLDER
                if (Directory.Exists(@"C:\DVLD IMAGES\"))
                {
                    File.Copy(fileDialog.FileName, @"C:\DVLD IMAGES\" + newGuid + ".png", overwrite: true);

                }
                else
                {
                    Directory.CreateDirectory(@"C:\DVLD IMAGES\");
                    File.Copy(fileDialog.FileName, @"C:\DVLD IMAGES\" + Guid.NewGuid() + ".png", overwrite: true);
                }

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

            //delete it from file
            File.Delete(pbProfilePic.ImageLocation);

            pbProfilePic.ImageLocation = null;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Form ParentForm = this.FindForm();

            if (ParentForm != null)
            {
                ParentForm.Close();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //save the Result
            //check if required controls filled
            //if ()
            //{

            //}
            //else
            //{
            //    //save
            //}
            short gender;
            gender = (radbtnMale.Checked) ? (short)0 : (short)1;


            //Before Saving Person Save Update ImageLocation And Save IT in ImgDir
            if (pbProfilePic.ImageLocation != null)
            {
                var newGuid = Guid.NewGuid().ToString();
                var newLocation = @"C:\DVLD IMAGES\" + newGuid + ".png";
                //copy the image for DVLV FOLDER
                if (Directory.Exists(@"C:\DVLD IMAGES\"))
                {
                    File.Copy(pbProfilePic.ImageLocation,newLocation , overwrite: true);

                }
                else
                {
                    Directory.CreateDirectory(@"C:\DVLD IMAGES\");
                    File.Copy(pbProfilePic.ImageLocation, newLocation, overwrite: true);
                }

                pbProfilePic.ImageLocation = newLocation;
            }

            //Save
            _PersonID = PeopleBusinessLayer.SavePerson(tbFirstName.Text, tbLastName.Text, tbThirdName.Text, tbLastName.Text, tbNationalNo.Text, dtpDateOfBirth.Value, gender, tbPhone.Text, tbEmail.Text, CountryDict[cbCountry.Text], tbAddress.Text, pbProfilePic.ImageLocation);
            
            if (_PersonID != -1)
            {
                lblPersonID2.Text = _PersonID.ToString();
                
                
            }
        }
    }
}
