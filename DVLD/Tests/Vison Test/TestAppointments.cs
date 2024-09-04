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
    public partial class TestAppointments : Form
    {
        clsTestAppointments.TestType enTestType;
        int _LocalDLAppID = -1;
        public TestAppointments(int LocalDLAppID,clsTestAppointments.TestType enTestType = clsTestAppointments.TestType.VisionTest)
        {
            InitializeComponent();
            this.enTestType = enTestType;
            this._LocalDLAppID = LocalDLAppID;

            SetTheForm();
        }

        private void SetTheForm()
        {
            //label and picturebox
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

            //Application information uctrl
            uctrlDrivingLicenseApplicationInfo1.DLAppID= _LocalDLAppID;


            _LoadDataGridView();
        }

        private void _LoadDataGridView()
        {
            DataTable dt = clsTestAppointments.GetTestAppointments(_LocalDLAppID,enTestType);

            dgvAppointments.DataSource = dt;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddTestAppointment_Click(object sender, EventArgs e)
        {
            if (dgvAppointments.RowCount == 0)
            {
                using (ScheduleTest frmScheduleTest = new ScheduleTest(_LocalDLAppID,enTestType))
                {
                    frmScheduleTest.ShowDialog();
                }
            }
            else if(Convert.ToBoolean(dgvAppointments.Rows[0].Cells["Is Locked"].Value) == true)
            {
                MessageBox.Show("this Person Already Have an Active Appointment for this Test, You Cannot Add New Appointment.", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            ;
        }
    }
}
