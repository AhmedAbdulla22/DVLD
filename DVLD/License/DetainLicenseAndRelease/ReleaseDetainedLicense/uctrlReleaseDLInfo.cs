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

namespace DVLD.License.ReleaseDetainedLicense
{
    public partial class uctrlReleaseDLInfo : UserControl
    {
        private int _LicenseID = -1;
        private int _DetainID = -1;
        private int _ReleaseAppID = -1;
        clsDetainedLicenses DLicense = null;

        public int DetainID { get { return _DetainID; } set { _DetainID = value; } }
        public int LicenseID { get { return _LicenseID; } set { _LicenseID = value; _LoadIApplicationData(); } }
        public int ReleaseAppID { get { return _ReleaseAppID; } set { _ReleaseAppID = value; lbl_ReleaseAppID2.Text = _ReleaseAppID.ToString(); } }
        public uctrlReleaseDLInfo()
        {
            InitializeComponent();
        }

        private void _LoadIApplicationData()
        {
            if (LicenseID != -1)
            {
                DLicense = clsDetainedLicenses.GetDetainedLicenseByLicenseID(LicenseID);
                if (DLicense == null)
                {

                    return;

                }



            }
            fillLabels();

        }

        private void fillLabels()
        {
            lblCreatedBy2.Text = clsLog.User?.UserName ?? "[???]";
            if (LicenseID != -1)
            {
                
                lbl_icenseID2.Text = DLicense?.LicenseID.ToString() ?? @"N\A";
                lbl_DetainID2.Text = DLicense?.DetainID.ToString() ?? @"N\A";
                lbl_DetainDate2.Text = DLicense.DetainDate.ToShortDateString();
                decimal AppFee = clsApplicationType.GetApplicationType(5)?.Fees ?? 0;//5 for Release AppType in appTypes
                decimal FineFees = DLicense?.FineFees ?? 0;
                lbl_AppFees2.Text = AppFee.ToString("0");
                lbl_FineFees2.Text = FineFees.ToString("0");
                lbl_TotalFees2.Text = (AppFee + FineFees).ToString("0");
                lbl_ReleaseAppID2.Text = (ReleaseAppID == -1) ? @"N\A":ReleaseAppID.ToString();

            }
            else
            {

                lbl_icenseID2.Text =  @"N\A";
                lbl_DetainID2.Text = @"N\A";
                lbl_DetainDate2.Text = "[???]";
                lbl_AppFees2.Text = "[$$$]";
                lbl_FineFees2.Text = "[$$$]";
                lbl_TotalFees2.Text = "[$$$]";
                lbl_ReleaseAppID2.Text = "[???]";
            }
        }

        public void UpdateControl()
        {
            _LoadIApplicationData();
        }
    }
}
