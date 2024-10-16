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

namespace DVLD.License.ReplaceLicenseForDamagedOrLost
{
    public partial class uctrlAppInfoLicenseReplacement : UserControl
    {
        private int _LDLicenseID = -1;
        private int _RApplicationID = -1;
        private int _RLicenseID = -1;
        public enum ReplacementFor { Damaged = 3, Lost = 4 }
        private ReplacementFor enReplacementReason = ReplacementFor.Damaged;
        public ReplacementFor ReplacementReason {set { enReplacementReason = value; UpdateApplicationFee(); } }
        clsLicense license = null;

        public int RApplicationID { get { return _RApplicationID; } set { _RApplicationID = value; } }
        public int RLicenseID { get { return _RLicenseID; } set { _RLicenseID = value; } }
        public int LDLicenseID
        {
            get { return _LDLicenseID; }
            set { _LDLicenseID = value; _LoadIApplicationData(); }
        }
        public uctrlAppInfoLicenseReplacement()
        {
            InitializeComponent();
        }

        private void _LoadIApplicationData()
        {
            if (LDLicenseID != -1)
            {
                license = clsLicense.GetLicenseByLicenseID(LDLicenseID);

                if (license == null)
                {
                    MessageBox.Show("Can't Find this License with ID of " + LDLicenseID + ".", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    return;

                }



            }
            fillLabels();

        }

        private void fillLabels()
        {
            lblCreatedBy2.Text = clsLog.User?.UserName ?? "[???]";
            UpdateApplicationFee();
            lbl_ApplicationDate2.Text = DateTime.Today.ToShortDateString();
            if (LDLicenseID != -1)
            {
                clsPerson Person = clsPerson.Find(clsApplication.GetApplicationByApplicationID(license.ApplicationID)?.ApplicantPersonID ?? -1);
                if (Person == null)
                {
                    return;
                }

                lbl_OldLicenseID2.Text = license.LicenseID.ToString();
                lbl_LRApplicationID2.Text = (RApplicationID == -1) ? @"N\A" : RApplicationID.ToString();
                lbl_RLicenseID2.Text = (RLicenseID == -1) ? @"N\A" : RLicenseID.ToString();


            }
            else
            {

                lbl_LRApplicationID2.Text = lbl_OldLicenseID2.Text = lbl_RLicenseID2.Text = @"N\A";
            }
        }
        public void UpdateControl()
        {
            _LoadIApplicationData();
        }

        private void UpdateApplicationFee()
        {
            decimal AppFee = clsApplicationType.GetApplicationType((int)enReplacementReason)?.Fees ?? 0;
            lbl_ApplicationFees2.Text = AppFee.ToString() ?? "[???]";
        }

    }
}
