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
        public ScheduleTest(int DLAppID,clsTestAppointments.TestType enTestType, bool isRetake = false)
        {
            InitializeComponent();

            uctrlScheduleTest1.SetControl(DLAppID, enTestType, isRetake);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
