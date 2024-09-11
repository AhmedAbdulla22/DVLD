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
    public partial class TestInfo : Form
    {
        public TestInfo(int TestAppointmentID, clsTestAppointments.TestType enTestType)
        {
            InitializeComponent();

            uctrTestInfo1.SetControl(TestAppointmentID, enTestType);
        }
    }
}
