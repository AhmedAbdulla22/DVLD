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

namespace DVLD.Tests.Vison_Test
{
    public partial class uctrTestInfo : UserControl
    {
        private int _ID = -1;
        clsTestAppointments.TestType enTestType;
        clsTestAppointments _TestAppointment = new clsTestAppointments();


        public int TestAppointmentID
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


        public uctrTestInfo()
        {
            InitializeComponent();
        }

        public void SetControl(int TestAppointmentID,clsTestAppointments.TestType enTestType)
        {
            this.enTestType = enTestType;

            //picturebox & labels
            switch (enTestType)
            {
                case clsTestAppointments.TestType.VisionTest:
                    {
                        pictureBox1.Image = Resources.eye_scan;
                        lblFormLabel.Text = "Vision Test Appointments";

                        break;
                    }
                case clsTestAppointments.TestType.WrittenTest:
                    {
                        lblFormLabel.Text = "Written Test Appointments";
                        pictureBox1.Image = Resources.test;
                        break;
                    }
                default:
                    {
                        lblFormLabel.Text = "Street Test Appointments";
                        pictureBox1.Image = Resources.steering_wheel;
                        break;
                    }
            }


            this.TestAppointmentID = TestAppointmentID;

        }

        private void _LoadApplicationData()
        {
            if (TestAppointmentID != -1)
            {
                _TestAppointment = clsTestAppointments.FindTestAppointment(TestAppointmentID);

                if (_TestAppointment == null)
                {
                    if (MessageBox.Show("Can't Find this Application with ID of " + TestAppointmentID + ".", "", MessageBoxButtons.OK, MessageBoxIcon.Warning) == DialogResult.OK)
                    {
                        this.ParentForm.Close();
                    }

                }


            fillLabels();
            }

        }

        private void fillLabels()
        {
            if (_TestAppointment != null)
            {
                clsLocalDLA _DLApp = clsLocalDLA.GetLocalDLAppByLocalDLAppID(_TestAppointment.LocalDrivingLicenseApplicationID);
                if (_DLApp != null)
                {
                    clsApplication _App = clsApplication.GetApplicationByApplicationID(_DLApp.ApplicationID);

                    //Schedule Info
                    lbl_DLA_ID2.Text = TestAppointmentID.ToString();
                    lbl_DClass2.Text = _DLApp.ClassName();
                    lbl_Name2.Text = clsPerson.Find(_App.ApplicantPersonID).FullName;
                    lbl_Trail2.Text = clsTestAppointments.GetTrailsBeforeAppointment(TestAppointmentID,_DLApp.LocalDrivingLicenseApplicationID, enTestType).ToString();
                    decimal fees = clsTestType.GetTestType((int)enTestType).Fees;
                    lbl_Fees2.Text = fees.ToString("0.00");
                    lblDate2.Text = _TestAppointment.AppointmentDate.ToString();
                    clsTests Test = clsTests.GetTestByTestAppointmentID(_TestAppointment.TestAppointmentID);
                    lblTestID2.Text = (Test != null) ? Test.TestID.ToString() : "Not Taken Yet";
                }
                
            }

        }
    }
}
