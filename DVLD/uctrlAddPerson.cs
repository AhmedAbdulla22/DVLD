using BusinessLayer;
using DVLD.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD
{
    public partial class uctrlAddPerson : UserControl
    {

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
            if (char.IsLetter((char)e.KeyValue) || e.KeyCode == Keys.Back)
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

            //Get Countries from DB then set it to Iraq
            cbCountry.DataSource = CountryBusinessLayer.GetAllCountries();

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
            if (char.IsDigit((char)e.KeyValue) || e.KeyCode == Keys.Back)
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
                pbProfilePic.ImageLocation =  fileDialog.FileName;
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
    }
}
