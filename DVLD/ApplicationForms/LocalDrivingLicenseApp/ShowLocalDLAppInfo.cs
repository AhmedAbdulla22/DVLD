using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.ApplicationForms.LocalDrivingLicenseApp
{
    public partial class ShowLocalDLAppInfo : Form
    {
        public ShowLocalDLAppInfo(int LocalDLAppID)
        {
            InitializeComponent();

            uctrlDrivingLicenseApplicationInfo1.DLAppID = LocalDLAppID;
        }

        private void ShowLocalDLAppInfo_Load(object sender, EventArgs e)
        {

        }
    }
}
