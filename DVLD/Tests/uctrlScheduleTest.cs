using BusinessLayer;
using DVLD.Properties;
using DVLD.Tests.Vison_Test;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Tests
{
    public partial class uctrlScheduleTest : UserControl
    {
        clsLocalDLA _DLApp;
        clsApplication _Application;
        private int _ID = -1;
        clsTestAppointments.TestType enTestType;
        bool _IsRetakeTest;

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
        public uctrlScheduleTest()
        {
            InitializeComponent();

            //Modify DateTimePicker
            dtpDate.MinDate = DateTime.Now;
        }

        public void SetControl(int DLAppID,clsTestAppointments.TestType enTestType,bool IsRetakeTest)
        {
            _IsRetakeTest = IsRetakeTest;
            this.enTestType = enTestType;
            this.DLAppID = DLAppID;

            //picturebox
            switch (enTestType)
            {
                case clsTestAppointments.TestType.VisionTest:
                    {
                        pictureBox1.Image = Resources.eye;
                        lblFormLabel.Text = "Vision Test Appointments";
                        break;
                    }
                case clsTestAppointments.TestType.WrittenTest:
                    {
                        pictureBox1.Image = Resources.writing;
                        lblFormLabel.Text = "Written Test Appointments";
                        break;
                    }
                default:
                    {
                        pictureBox1.Image = Resources.street;
                        lblFormLabel.Text = "Street Test Appointments";
                        break;
                    }
            }

            //Label
            if (IsRetakeTest)
            {
                lblFormLabel.Text = "Schedule Retake Test";
                gbRetakeTestInfo.Enabled = true;
            }
            else
            {
                switch (enTestType)
                {
                    case clsTestAppointments.TestType.VisionTest:
                        {
                            pictureBox1.Image = Resources.eye;
                            lblFormLabel.Text = "Vision Test Appointments";
                            break;
                        }
                    case clsTestAppointments.TestType.WrittenTest:
                        {
                            pictureBox1.Image = Resources.writing;
                            lblFormLabel.Text = "Written Test Appointments";
                            break;
                        }
                    default:
                        {
                            pictureBox1.Image = Resources.street;
                            lblFormLabel.Text = "Street Test Appointments";
                            break;
                        }
                }
            }
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
            if (DLAppID != -1)
            {
                //Schedule Info
                lbl_DLA_ID2.Text = DLAppID.ToString();
                lbl_DClass2.Text = _DLApp.ClassName();
                lblName2.Text = clsPerson.Find(_Application.ApplicantPersonID).FullName;
                lbl_Trial2.Text = clsTestAppointments.GetTrails(DLAppID, enTestType).ToString();    
                decimal fees = clsTestType.GetTestType((int)enTestType).Fees;
                lbl_Fees2.Text = fees.ToString("0.00");
                dtpDate.Value = DateTime.Now;

                //retake test info
                if (_IsRetakeTest)
                {
                    decimal RetakeFees = clsApplicationType.GetApplicationType(7).Fees;
                    lblTotalFees2.Text = (fees + RetakeFees).ToString("0.00");
                    lblRAppFees2.Text = RetakeFees.ToString("0.00");
                }
                else
                {
                    lblTotalFees2.Text = fees.ToString();
                    lblRAppFees2.Text = "0";
                }



            }
         
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_IsRetakeTest)
            {
                
            }
            else
            {
                
            }
        }
    }
}
