using BusinessLayer;
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
    public partial class ScheduleTest : Form
    {
        enum ctrlMode { Add = 1, Update = 2 };
        ctrlMode _ctrlMode = ctrlMode.Add;

        //To Add Appointment
        public ScheduleTest(int DLAppID,clsTestAppointments.TestType enTestType, bool isRetake = false)
        {
            InitializeComponent();

            uctrlScheduleTest1.SetControl(DLAppID, enTestType, isRetake);
        }

        //To Edit TestAppointment
        public ScheduleTest(int TestAppointmentID, bool isRetake = false)
        {
            InitializeComponent();
            clsTestAppointments TestAppointment = new clsTestAppointments();
            if (TestAppointmentID != -1)
            {
                TestAppointment = clsTestAppointments.FindTestAppointment(TestAppointmentID);
                if(TestAppointment.RetakeTestApplicationID != -1) { isRetake = true; }
                uctrlScheduleTest1.SetControl(TestAppointment.LocalDrivingLicenseApplicationID, TestAppointment.enTestType, isRetake, TestAppointment);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
