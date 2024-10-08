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

namespace DVLD.License.InternationalDrivingLicense
{
    public partial class uctrlD_I_LicenseInfo : UserControl
    {
        private int _InternationalID = -1;
        clsInternationalLicense _ILicense = new clsInternationalLicense();


        public int ILicenseID
        {
            get
            {
                return _InternationalID;
            }
            set
            {
                _InternationalID = value;
                _LoadApplicationData();
            }
        }
        public uctrlD_I_LicenseInfo()
        {
            InitializeComponent();
        }

        private void _LoadApplicationData()
        {
            if (ILicenseID != -1)
            {
                _ILicense = clsInternationalLicense.GetInternationalLicenseByInternationalLicenseID(ILicenseID);

                if (_ILicense == null)
                {
                    MessageBox.Show("Can't Find this International License with ID of " + ILicenseID + ".", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    return;

                }



            }
            fillLabels();

        }

        private void fillLabels()
        {
            if (ILicenseID != -1)
            {
                clsPerson Person = clsPerson.Find(clsDriver.GetDriverByDriverID(_ILicense.DriverID).PersonID);
                if (Person == null)
                {
                    return;
                }

                lbl_Name2.Text = Person.FullName;
                lbl_ILicenseID2.Text = ILicenseID.ToString();
                lbl_LicenseID2.Text = _ILicense.IssuedUsingLocalLicenseID.ToString();
                lblNationalNo2.Text = Person.NationalNo.ToString();
                lblGender2.Text = (Person.Gender == 0) ? "Male" : "Female";
                lbl_IssueDate2.Text = _ILicense.IssueDate.ToShortDateString();
                lbl_ApplicationID2.Text = _ILicense.ApplicationID.ToString();
                lbl_IsActive2.Text = (_ILicense.IsActive) ? "Yes" : "No";
                lbl_DateOfBirth2.Text = Person.DateOfBirth.ToShortDateString();
                lbl_DriverID2.Text = _ILicense.DriverID.ToString();
                lbl_ExpDate2.Text = _ILicense.ExpirationDate.ToShortDateString();
                if (!string.IsNullOrEmpty(Person.ImagePath))
                {
                    pbPersonPFP.ImageLocation = Person.ImagePath;
                }
                else
                {
                    pbPersonPFP.Image = (Person.Gender == 0) ? Resources.User_Male : Resources.Female_User;
                }


            }
            else
            {
                lbl_Name2.Text = lblNationalNo2.Text = lblGender2.Text = lbl_IssueDate2.Text = lbl_IsActive2.Text = lbl_DateOfBirth2.Text  = lbl_ExpDate2.Text = "[???]";
                lbl_ApplicationID2.Text = lbl_DriverID2.Text = lbl_ILicenseID2.Text = lbl_LicenseID2.Text = "N/A";
            }





        }
        public void UpdateControl()
        {
            _LoadApplicationData();
        }

    }
}
