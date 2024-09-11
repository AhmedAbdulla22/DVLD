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
        public TestAppointments(int LocalDLAppID, clsTestAppointments.TestType enTestType = clsTestAppointments.TestType.VisionTest)
        {
            InitializeComponent();
            this.enTestType = enTestType;
            this._LocalDLAppID = LocalDLAppID;

            SetTheForm();
        }
        private void dgvAppointments_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                //row that you clicked on location
                var hitTestInfo = dgvAppointments.HitTest(e.X, e.Y);

                if (hitTestInfo.RowIndex >= 0)
                {
                    dgvAppointments.ClearSelection();
                    dgvAppointments.Rows[hitTestInfo.RowIndex].Selected = true;

                    contextMenuStrip1.Show(dgvAppointments, new Point(e.X, e.Y));
                }
            }
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
            uctrlDrivingLicenseApplicationInfo1.DLAppID = _LocalDLAppID;


            _LoadDataGridView();
        }

        private void _LoadDataGridView()
        {
            DataTable dt = clsTestAppointments.GetTestAppointments(_LocalDLAppID, enTestType);

            dgvAppointments.DataSource = dt;

            //#Records Rows
            lblRecords.Text = "#Records" + ' ' + (dgvAppointments.RowCount).ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddTestAppointment_Click(object sender, EventArgs e)
        {
            // if have no appointments already
            if (dgvAppointments.RowCount == 0)
            {
                using (ScheduleTest frmScheduleTest = new ScheduleTest(_LocalDLAppID, enTestType))
                {
                    frmScheduleTest.ShowDialog();
                }
            }//if have appointments but not locked
            else if (Convert.ToBoolean(dgvAppointments.Rows[dgvAppointments.RowCount - 1].Cells["Is Locked"].Value) == false)
            {
                MessageBox.Show("this Person Already Have an Active Appointment for this Test, You Cannot Add New Appointment.", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //if last Appointment failed the test
            else if (clsTests.GetTestResult(Convert.ToInt32(dgvAppointments.Rows[dgvAppointments.RowCount - 1].Cells["Appointment ID"].Value)) == false)
            {
                using (ScheduleTest frmScheduleTest = new ScheduleTest(_LocalDLAppID, enTestType,true))
                {
                    frmScheduleTest.ShowDialog();
                }
            }
            //if passed the test
            else
            {
                MessageBox.Show("this Person Already Passed This Test.", "Passed the Test", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            int TestAppointmentID = Convert.ToInt32(dgvAppointments.SelectedRows[0].Cells["Appointment ID"].Value);

            switch (e.ClickedItem.Text)
            {
                case "Test Info":
                    {
                        using (TestInfo frmTestInfo = new TestInfo(TestAppointmentID,enTestType))
                        {
                            frmTestInfo.ShowDialog();
                        }
                        break;
                    }
                case "Take Test":
                    {
                        if(Convert.ToBoolean(dgvAppointments.SelectedRows[0].Cells["Is Locked"].Value) == false)
                        {
                            using (TakeTest frmTakeTest = new TakeTest(TestAppointmentID, enTestType))
                            {
                                frmTakeTest.ShowDialog();
                                _LoadDataGridView();
                            }
                        }
                        else
                        {
                            MessageBox.Show("this Person Already took this Test.", "Test Already Taken", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        break;
                    }

            }
        }
    }
}
