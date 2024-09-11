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

namespace DVLD.Tests
{
    public partial class TakeTest : Form
    {
        public TakeTest(int TestAppointmentID,clsTestAppointments.TestType enTestType)
        {
            InitializeComponent();
            uctrTestInfo1.SetControl(TestAppointmentID, enTestType);
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            if (uctrTestInfo1.TestAppointmentID != -1)
            {
                if(MessageBox.Show("Are You Sure You Want To Save This Test? After Save You Can't Change Test Result!","Confirmation",MessageBoxButtons.OKCancel,MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    clsTests Test = new clsTests();
                    Test.Notes = tbNotes.Text;
                    Test.CreatedByUserID = clsLog.User.UserID;
                    Test.TestResult = rbPass.Checked;
                    Test.TestAppointmentID = uctrTestInfo1.TestAppointmentID;

                    if (Test.Save())
                    {
                        clsTestAppointments.LockTheTestAppointment(Test.TestAppointmentID);
                        MessageBox.Show("Test Saved Succesfully", "Test Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }
                

                
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
