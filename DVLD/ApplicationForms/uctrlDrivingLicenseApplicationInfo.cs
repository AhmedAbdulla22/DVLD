using BusinessLayer;
using DVLD.PeopleForm;
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
        bool _isRetake = false;

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
                //enable person Info link
                lnklblPersonInfo.Enabled = true;

            }
            fillLabels();

        }

        private void fillLabels()
        {
            if (DLAppID != -1)
            {
                //_AppRow = clsLocalDLA.getLocalDLA_ByLDLAppID(DLAppID).Rows[0];
                //DLApp Info
                lbl_DLA_ID2.Text = DLAppID.ToString();
                lblAppliedForLicense2.Text = _DLApp.ClassName();
                lblPassedTests2.Text = $"{_DLApp.passedTest().ToString()}/3";
                
                //Application Info
                lbl_ID2.Text = _Application.ApplicationID.ToString();
                lbl_Status2.Text = _Application.GetStatusName();
                lbl_Fees2.Text = _Application.PaidFees.ToString();
                lbl_Type2.Text = clsApplicationType.GetApplicationType(_Application.ApplicationTypeID).Title;
                lblApplicant2.Text = clsPerson.Find(_Application.ApplicantPersonID).FullName;
                lblDate2.Text = _Application.ApplicationDate.ToShortDateString();
                lblStatusDate2.Text = _Application.LastStatusDate.ToShortDateString();
                lblCreatedBy2.Text = clsUser.Find(_Application.CreatedByUserID).UserName;
            }
            else
            {
                lbl_DLA_ID2.Text =lblAppliedForLicense2.Text = lblPassedTests2.Text = lbl_ID2.Text = lbl_Status2.Text = lbl_Fees2.Text = lbl_Type2.Text = lblApplicant2.Text =lblDate2.Text = lblStatusDate2.Text = "[???]";
            }





        }
        public void UpdateControl()
        {
            _LoadApplicationData();
        }

        private void lnklblPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int PersonID = (_Application.ApplicantPersonID > 0) ? _Application.ApplicantPersonID : -1;
            using (Person_Details frmPersonInfo = new Person_Details(PersonID))
            {
                frmPersonInfo.ShowDialog();
            }
        }

        
    }
}
