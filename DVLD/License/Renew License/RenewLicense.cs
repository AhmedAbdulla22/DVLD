using BusinessLayer;
using DVLD.ApplicationForms;
using DVLD.License.InternationalDrivingLicense;
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
    public partial class RenewLicense : Form
    {
        int _LicenseID = -1;

        public RenewLicense()
        {
            InitializeComponent();

            uctrlFindLDLicense1.OnFilterSucceded += FilterSucceded;

            btnIssue.Image = Utilites.ResizeImage(btnIssue.Image, 25, 25);


        }

        private void FilterSucceded(int LicenseID)
        {
            uctrl_DriverLicenseInfo1.LicenseID = uctrlNewLicenseApplication1.LDLicenseID = _LicenseID = LicenseID;

            clsLicense License = clsLicense.GetLicenseByLicenseID(LicenseID);

            lnklblShowLicensesHistory.Enabled = true;

            var message = string.Empty;

            if (License != null)
            {
                if (!License.IsActive)
                {
                    message = "This License Is Not Active";
                }
                else if (License.isDetained())
                {
                    message = "This License Is Detaind";
                }
                else if (License.ExpirationDate > DateTime.Now)
                {
                    message = "This License Is Not Expired Yet";
                }


                if (!string.IsNullOrEmpty(message))
                {
                    MessageBox.Show(message, "Attempt Denied", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnIssue.Enabled = false;
                    return;
                }

            }

            //if those conditions don't meet then the issue button get enabled
            btnIssue.Enabled = true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            clsLicense License = clsLicense.GetLicenseByLicenseID(_LicenseID);

            if (MessageBox.Show($"Are You Sure You Want To Renew the License For This Person with ID = {License?.LicenseID ?? -1}?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //issue License
                if (IssueLicense(License))
                {
                    //deaActivate the OLD License
                    License.DeactivateLicense();


                    uctrlNewLicenseApplication1.LDLicenseID = _LicenseID;
                    uctrl_DriverLicenseInfo1.UpdateControl();
                    lnklblShowLicensesInfo.Enabled = true;
                    btnIssue.Enabled = false;


                    MessageBox.Show($"This Renewed License Issued Successfully for this Person with ID of = {uctrlNewLicenseApplication1.RLicenseID}.", "Issued Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("This Renewed License Issue Failed for this Person", "License Issued Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }

        private void lnklblShowLicensesInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (ShowLicenseInfo frmLicenseInfo = new ShowLicenseInfo(uctrlNewLicenseApplication1.RLicenseID))
            {
                frmLicenseInfo.ShowDialog();
            }
        }

        private bool IssueLicense(clsLicense License)
        {
            bool isIssued = false;


            if (License == null)
            {
                return isIssued;
            }

            clsApplication newRApplication = new clsApplication();
            newRApplication.ApplicationStatus = 2;
            newRApplication.ApplicationDate = DateTime.Today;
            newRApplication.ApplicationTypeID = 2;//international Application 6
            newRApplication.LastStatusDate = DateTime.Today;
            newRApplication.ApplicantPersonID = clsDriver.GetDriverByDriverID(License.DriverID)?.PersonID ?? -1;
            newRApplication.CreatedByUserID = clsLog.User.UserID;
            newRApplication.PaidFees = clsApplicationType.GetApplicationType(2).Fees;

            if (newRApplication.Save())
            {
                uctrlNewLicenseApplication1.RApplicationID = newRApplication.ApplicationID;

                clsLicense newRLicense = new clsLicense();
                newRLicense.IsActive = true;
                newRLicense.Notes = uctrlNewLicenseApplication1.Note;
                newRLicense.ApplicationID = newRApplication.ApplicationID;
                newRLicense.IssueDate = DateTime.Today;
                newRLicense.IssueReason = (byte)clsLicense.enIssueReason.Renew;
                newRLicense.ExpirationDate = DateTime.Today.AddYears((int)clsClass.GetClassByClassID(3).DefaultValidityLength);
                newRLicense.CreatedByUserID = clsLog.User.UserID;
                newRLicense.DriverID = License.DriverID;
                newRLicense.LicenseClass = License.LicenseClass;

                if (newRLicense.Save())
                {
                    uctrlNewLicenseApplication1.RLicenseID = newRLicense.LicenseID;
                    isIssued = true;
                }
            }





            return isIssued;
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
