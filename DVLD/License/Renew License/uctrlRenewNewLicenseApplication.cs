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

namespace DVLD.License.Renew_License
{
    public partial class uctrlNewLicenseApplication : UserControl
    {
        private int _LDLicenseID = -1;
        private int _RApplicationID = -1;
        private int _RLicenseID = -1;
        clsLicense license = null;

        public int RApplicationID { get { return _RApplicationID; } set { _RApplicationID = value; } }
        public int RLicenseID { get { return _RLicenseID; } set { _RLicenseID = value; } }
        public int LDLicenseID
        {
            get { return _LDLicenseID; }
            set { _LDLicenseID = value; _LoadIApplicationData(); }
        }
        public string Note { get { return tbNotes.Text; } }
        public uctrlNewLicenseApplication()
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
            decimal AppFee = clsApplicationType.GetApplicationType(2)?.Fees ?? 0, LicenseFees = clsClass.GetClassByClassID(license?.LicenseClass ?? -1)?.ClassFees ?? 0;
            lbl_ApplicationFees2.Text = AppFee.ToString() ?? "[???]";//2 for Renew AppType in appTypes
            lbl_LicenseFees2.Text = LicenseFees.ToString() ?? "[???]";
            lbl_TotalFees2.Text = (AppFee + LicenseFees).ToString(); 
            lbl_IssueDate2.Text = lbl_ApplicationDate2.Text = DateTime.Today.ToShortDateString();
            lbl_ExpDate2.Text = DateTime.Today.AddYears((int)(clsClass.GetClassByClassID(license?.LicenseClass ?? -1)?.DefaultValidityLength ?? 0)).ToShortDateString();

            if (LDLicenseID != -1)
            {
                clsPerson Person = clsPerson.Find(clsApplication.GetApplicationByApplicationID(license.ApplicationID)?.ApplicantPersonID ?? -1);
                if (Person == null)
                {
                    return;
                }

                lbl_OldLicenseID2.Text = license.LicenseID.ToString();
                lbl_RLApplicationID2.Text = (RApplicationID == -1) ? @"N\A" : RApplicationID.ToString();
                lbl_RenewLicenseID2.Text = (RLicenseID == -1) ? @"N\A" : RLicenseID.ToString();


            }
            else
            {

                lbl_RLApplicationID2.Text = lbl_OldLicenseID2.Text = lbl_RenewLicenseID2.Text = @"N\A";
            }
        }
        public void UpdateControl()
        {
            _LoadIApplicationData();
        }
    }
}
