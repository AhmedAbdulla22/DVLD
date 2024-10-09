using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.License.InternationalDrivingLicense
{
    public partial class InternationalLicenseInfo : Form
    {
        private int _ILicenseID = -1;

        public InternationalLicenseInfo(int iLicenseID = -1)
        {
            InitializeComponent();
            _ILicenseID = iLicenseID;
        }

        private void InternationalLicenseInfo_Load(object sender, EventArgs e)
        {
            uctrlD_I_LicenseInfo1.ILicenseID = _ILicenseID;
        }
    }
}
