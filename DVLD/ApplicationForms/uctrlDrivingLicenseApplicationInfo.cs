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

namespace DVLD.ApplicationForms
{
    public partial class uctrlDrivingLicenseApplicationInfo : UserControl
    {
        clsLocalDLA _DLApp;
        clsApplication _Application;
        private int _ID = -1;

        public int DLAppID
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
        
        public uctrlDrivingLicenseApplicationInfo()
        {
            InitializeComponent();

        }


        private void _LoadApplicationData()
        {
            if (DLAppID != -1)
            {
                _DLApp = clsLocalDLA.GetLocalDLAppByLocalDLAppID(DLAppID);

                if (_DLApp == null)
                {
                    if (MessageBox.Show("Can't Find this Application with ID of " + DLAppID + ".", "", MessageBoxButtons.OK, MessageBoxIcon.Warning) == DialogResult.OK)
                    {
                        this.ParentForm.Close();
                    }

                }

                _Application = clsApplication.GetApplicationByApplicationID(_DLApp.ApplicationID);

            }
            fillLabels();

        }

        private void fillLabels()
        {
            //if (DLAppID != -1)
            //{

            //    //DLApp Info
            //    lbl_DLA_ID2.Text = DLAppID.ToString();
            //    lblAppliedForLicense2.Text = clsClass.ClassName(_DLApp.LicenseClassID);
            //    lblPassedTests2.Text = 
            //    //Application Info
            //    lblPassedTests2.Text = clsLocalDLA.GetLocalDLAppByLocalDLAppID(DLAppID)



            //    lblApplicant2.Text = clsPerson.Find(_App.ApplicantPersonID).FullName;
            //    lblAppliedForLicense2.Text = clsClass.ClassName() ;



            //}
            //else
            //{
            //    lblPersonID2.Text = lblName2.Text = lblNationalNo2.Text = lblPhone2.Text = lblEmail2.Text = lblDateOfBirth2.Text = lblAddress2.Text = lblGender2.Text = lblCountry2.Text = "[????]";
            //    pictureBox1.Image = Resources.User_Male;
            //}





        }
        public void UpdateControl()
        {
            _LoadApplicationData();
        }

    }
}
