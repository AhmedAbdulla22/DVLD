using BusinessLayer;
using DVLD.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using DVLD.PeopleForm;

namespace DVLD
{
    public partial class uctrPersonDetails : UserControl
    {
        clsPerson _Person;
        private int _ID = -1;
        public int PersonID
        { 
            get
            {
                return _ID; 
            } 
            set 
            {
                _ID = value ;
                _LoadPersonData();
            }
        }
        
        Dictionary<string, int> CountryDict = clsCountry.GetAllCountries();

        public uctrPersonDetails()
        {
            InitializeComponent();


            //resize lbl images
            lblName.Image = Utilites.ResizeImage(lblPhone.Image, 20, 20);
            lblNationalNo.Image = Utilites.ResizeImage(lblNationalNo.Image, 20, 20);
            lblGender.Image = Utilites.ResizeImage(lblGender.Image, 20, 20);
            lblDateOfBirth.Image = Utilites.ResizeImage(lblDateOfBirth.Image, 20, 20);
            lblCountry.Image = Utilites.ResizeImage(lblCountry.Image, 20, 20);
            lblAddress.Image = Utilites.ResizeImage(lblAddress.Image, 20, 20);
            lblPhone.Image = Utilites.ResizeImage(lblPhone.Image, 20, 20);
            lblEmail.Image = Utilites.ResizeImage(lblEmail.Image, 20, 20);

            //modify lblName Color
            lblName2.ForeColor = Color.Red;

            //Get Countries from DB 

        }

        private void fillLabels()
        {
            lblPersonID2.Text = _Person.PersonID.ToString();
            lblName2.Text = _Person.FirstName + ' ' + _Person.SecondName + ' ' + _Person.ThirdName + ' ' + _Person.LastName;
            lblNationalNo2.Text = _Person.NationalNo.ToString();
            lblPhone2.Text = _Person.Phone.ToString();
            lblEmail2.Text = _Person.Email.ToString();
            lblDateOfBirth2.Text = _Person.DateOfBirth.ToShortDateString();
            lblAddress2.Text = _Person.Address.ToString();
            lblGender2.Text = (_Person.Gender == 0) ? "Male":"Female";
            lblCountry2.Text = CountryDict.FirstOrDefault(x => x.Value == _Person.CountryID).Key;

            //validating if image missing
            if (!string.IsNullOrEmpty(_Person.ImagePath) && !File.Exists(_Person.ImagePath))
            {
                _Person.ImagePath = null;
            }

            if (string.IsNullOrEmpty(_Person.ImagePath))
            {
                if (_Person.Gender == 0)
                {
                    pictureBox1.Image = Resources.User_Male;
                }
                else
                {
                    pictureBox1.Image = Resources.Female_User;
                }
            }
            else
            {
                pictureBox1.ImageLocation = _Person.ImagePath;
            }
        }

        private void _LoadPersonData()
        {
            if (PersonID != -1)
            {
                _Person = clsPerson.Find(PersonID);

                if (_Person == null)
                {
                    if (MessageBox.Show("Can't Find this Person with ID of " + PersonID + ".", "", MessageBoxButtons.OK, MessageBoxIcon.Warning) == DialogResult.OK)
                    {
                        this.ParentForm.Close();
                    }

                }

            fillLabels();
            }

        }

        public void UpdateControl()
        {
            _LoadPersonData();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            
        }

        private void lnklblEdit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAddPerson frmAdd = new frmAddPerson(PersonID);
            frmAdd.ShowDialog();
        }
    }
}
