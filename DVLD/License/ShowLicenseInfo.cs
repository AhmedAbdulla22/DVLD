using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.License
{
    public partial class ShowLicenseInfo : Form
    {
        private int _LicenseID = -1;
        public ShowLicenseInfo(int LicenseID = -1)
        {
            InitializeComponent();

            _LicenseID = LicenseID;
        }

        private void ShowLicenseInfo_Load(object sender, EventArgs e)
        {
            uctrlDriverLicenseInfo1.LicenseID = _LicenseID;
        }
    }
}
