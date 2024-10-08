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
using static System.Net.Mime.MediaTypeNames;

namespace DVLD.License
{
    public partial class uctrl_DriverLicenseInfo : UserControl
    {
        private int _ID = -1;
        clsLicense _License = new clsLicense();


        public int LicenseID
        {
            get
            {
                return _ID;
            }
            set
            {
                _ID = value;
                _LoadApplicationData();
            }
        }
        public uctrl_DriverLicenseInfo()
        {
            InitializeComponent();
        }

        private void _LoadApplicationData()
        {
            if (LicenseID != -1)
            {
                _License = clsLicense.GetLicenseByLicenseID(LicenseID);

                if (_License == null)
                {
                    MessageBox.Show("Can't Find this License with ID of " + LicenseID + ".", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    
                        return;
                    
                }

                

            }
            fillLabels();

        }

        private void fillLabels()
        {
            if (LicenseID != -1)
            {
                clsPerson Person = clsPerson.Find(clsApplication.GetApplicationByApplicationID(_License.ApplicationID).ApplicantPersonID);
                if (Person == null)
                {
                    return;
                }
                lbl_Class2.Text = clsClass.ClassName(_License.LicenseClass);
                lbl_Name2.Text = Person.FullName;
                lbl_LicenseID2.Text = LicenseID.ToString();
                lblNationalNo2.Text = Person.NationalNo.ToString();
                lblGender2.Text = (Person.Gender == 0) ? "Male" : "Female";
                lbl_IssueDate2.Text = _License.IssueDate.ToShortDateString();
                switch(_License.IssueReason)
                {
                    case 1:
                        {
                            lbl_IssueReason2.Text = "First Time";
                            break;
                        }
                    case 2:
                        {
                            lbl_IssueReason2.Text = "Renew";

                            break;
                        }
                    case 3:
                        {
                            lbl_IssueReason2.Text = "Replacement for Damaged";

                            break;

                        }
                    case 4:
                        {
                            lbl_IssueReason2.Text = "Replacement for Lost";

                            break;
                        }
                }
                lbl_Notes2.Text = _License.Notes.ToString();
                lbl_IsActive2.Text = (_License.IsActive) ? "Yes" : "No";
                lbl_DateOfBirth2.Text = Person.DateOfBirth.ToShortDateString();
                lbl_DriverID2.Text = _License.DriverID.ToString();
                lbl_ExpDate2.Text = _License.ExpirationDate.ToShortDateString();
                lbl_IsDetained2.Text = (_License.isDetained()) ? "Yes" : "No";
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
                lbl_Class2.Text=lbl_Name2.Text=lbl_LicenseID2.Text=lblNationalNo2.Text=lblGender2.Text=lbl_IssueDate2.Text=lbl_Notes2.Text=lbl_IsActive2.Text=lbl_DateOfBirth2.Text=lbl_DriverID2.Text= lbl_ExpDate2.Text = "[???]";
            }





        }
        public void UpdateControl()
        {
            _LoadApplicationData();
        }



       
    }
}
