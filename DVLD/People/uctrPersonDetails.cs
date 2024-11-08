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


            

            //modify lblName Color
            lblName2.ForeColor = Color.Red;

       

        }


        private void fillLabels()
        {
            if (PersonID != -1)
            {
                lblPersonID2.Text = _Person.PersonID.ToString();
                lblName2.Text =  _Person.FirstName + ' ' + _Person.SecondName + ' ' + _Person.ThirdName + ' ' + _Person.LastName;
                lblNationalNo2.Text = _Person.NationalNo.ToString();
                lblPhone2.Text = _Person.Phone.ToString();
                lblEmail2.Text = _Person.Email.ToString();
                lblDateOfBirth2.Text = _Person.DateOfBirth.ToShortDateString();
                lblAddress2.Text = _Person.Address.ToString();
                lblGender2.Text = (_Person.Gender == 0) ? "Male" : "Female";
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
                        pictureBox1.Image = Resources.gif_male;
                    }
                    else
                    {
                        pictureBox1.Image = Resources.gif_female;
                    }
                }
                else
                {
                    pictureBox1.ImageLocation = _Person.ImagePath;
                }

                lnklblEdit.Visible = true;

            }
            else
            {
                lblPersonID2.Text = lblName2.Text = lblNationalNo2.Text = lblPhone2.Text = lblEmail2.Text = lblDateOfBirth2.Text = lblAddress2.Text = lblGender2.Text = lblCountry2.Text = "[????]";
                pictureBox1.Image = Resources.gif_male;
                lnklblEdit.Visible = false;
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

            }
            fillLabels();

        }

        public void UpdateControl()
        {
            _LoadPersonData();
        }

      

        private void lnklblEdit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAddPerson frmAdd = new frmAddPerson(PersonID);
            frmAdd.ShowDialog();

            UpdateControl();
        }
    }
}
