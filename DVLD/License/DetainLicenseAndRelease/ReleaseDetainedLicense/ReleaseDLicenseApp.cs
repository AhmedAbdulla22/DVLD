using BusinessLayer;
using DVLD.License.DetainLicense;
using DVLD.License.Renew_License;
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
    public partial class ReleaseDLicenseApp : Form
    {
        int _LicenseID = -1;

        public ReleaseDLicenseApp()
        {
            InitializeComponent();
            uctrlFindLDLicense1.OnFilterSucceded += FilterSucceded;

            btnRelease.Image = Utilites.ResizeImage(btnRelease.Image, 25, 25);
        }

        public ReleaseDLicenseApp(int LicenseID)
        {
            InitializeComponent();
            uctrlFindLDLicense1.OnFilterSucceded += FilterSucceded;

            btnRelease.Image = Utilites.ResizeImage(btnRelease.Image, 25, 25);

            //Filter
            uctrlFindLDLicense1.FindLicenseID(LicenseID);
        }

        private void FilterSucceded(int LicenseID)
        {
            uctrl_DriverLicenseInfo1.LicenseID = uctrlReleaseDLInfo1.LicenseID = _LicenseID = LicenseID;

            clsLicense License = clsLicense.GetLicenseByLicenseID(LicenseID);

            lnklblShowLicensesHistory.Enabled = true;

            var message = string.Empty;

            if (License != null)
            {
                if (!License.isDetained())
                {
                    message = "This License Is Not Detaind";
                }


                if (!string.IsNullOrEmpty(message))
                {
                    MessageBox.Show(message, "Attempt Denied", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnRelease.Enabled = false;
                    return;
                }

            }

            //if those conditions don't meet then the issue button get enabled
            btnRelease.Enabled = true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void btnRelease_Click(object sender, EventArgs e)
        {
            clsLicense License = clsLicense.GetLicenseByLicenseID(_LicenseID);

            if (MessageBox.Show($"Are You Sure You Want To Release the License For This Person with ID = {License?.LicenseID ?? -1}?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //issue License
                if (ReleaseLicense(License))
                {
                    //Activate the OLD License
                    clsLicense.ActivateLicense(_LicenseID);

                    uctrlReleaseDLInfo1.LicenseID = _LicenseID;
                    uctrl_DriverLicenseInfo1.UpdateControl();
                    lnklblShowLicensesInfo.Enabled = true;
                    btnRelease.Enabled = false;


                    MessageBox.Show($"This License Released Successfully for this License ID of = {_LicenseID}.", "Detained Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("This License Release Failed for this Person", "Detain Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }

        private bool ReleaseLicense(clsLicense License)
        {
            bool isReleased = false;


            if (License == null)
            {
                return isReleased;
            }

            clsApplication RApplication = new clsApplication();
            RApplication.ApplicationStatus = 2;
            RApplication.ApplicationDate = DateTime.Today;
            RApplication.ApplicationTypeID = 5;//Release Application Type 5
            RApplication.LastStatusDate = DateTime.Now;
            RApplication.ApplicantPersonID = clsDriver.GetDriverByDriverID(License.DriverID)?.PersonID ?? -1;
            RApplication.CreatedByUserID = clsLog.User.UserID;
            RApplication.PaidFees = clsApplicationType.GetApplicationType(5).Fees;

            if (RApplication.Save())
            {
                uctrlReleaseDLInfo1.ReleaseAppID = RApplication.ApplicationID;

                clsDetainedLicenses DetainedLicense = clsDetainedLicenses.GetDetainedLicenseByLicenseID(_LicenseID);

                DetainedLicense.ReleaseApplicationID = RApplication.ApplicationID;
                DetainedLicense.ReleaseDate = DateTime.Now;
                DetainedLicense.ReleasedByUserID = clsLog.User.UserID;
                DetainedLicense.IsReleased = true;
                

                if (DetainedLicense.Save())
                {
                    isReleased = true;
                }
            }



            return isReleased;
        }
        private void lnklblShowLicensesInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (ShowLicenseInfo frmLicenseInfo = new ShowLicenseInfo(_LicenseID))
            {
                frmLicenseInfo.ShowDialog();
            }
        }


        private void lnklblShowLicensesHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int PersonID = clsDriver.GetDriverByDriverID(clsLicense.GetLicenseByLicenseID(_LicenseID)?.DriverID ?? -1)?.PersonID ?? -1;

            using (LicenseHistory frmLicenseHistory = new LicenseHistory(PersonID))
            {
                frmLicenseHistory.ShowDialog();
            }
        }

    }
}
