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

namespace DVLD.License.InternationalDrivingLicense
{
    public partial class NewInternationalLicense : Form
    {
        int _LicenseID = -1;
        public NewInternationalLicense(int LicenseID = -1)
        {
            InitializeComponent();

            uctrlFindLDLicense1.OnFilterSucceded += FilterSucceded;

            btnIssue.Image = Utilites.ResizeImage(btnIssue.Image, 25, 25);

            //Find License
            uctrlFindLDLicense1.FindLicenseID(LicenseID);

        }

        private void FilterSucceded(int LicenseID)
        {
            uctrl_DriverLicenseInfo1.LicenseID = uctrl_IApplicationInfo1.LDLicenseID = _LicenseID = LicenseID;

            clsLicense License = clsLicense.GetLicenseByLicenseID(LicenseID);
            clsInternationalLicense ILicense = clsInternationalLicense.GetInternationalLicenseByLocalDrivingLicenseID(License?.LicenseID ?? -1);

            lnklblShowLicensesHistory.Enabled = true;

            var message = string.Empty;

            if (ILicense != null)
            {
                if (ILicense.IsActive)
                {
                    message = $"This Person Already Got Active International License, License ID = {ILicense.InternationalLicenseID}.";
                }
            }

            if (License != null)
            {
                if (License.LicenseClass != 3)
                {
                    message = "This License Is Not Ordinary Class";
                }
                else if(!License.IsActive)
                {
                    message = "This License Is Not Active";
                }
                else if(License.isDetained())
                {
                    message = "This License Is Detaind";
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

        private void lnklblShowLicensesHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int PersonID = clsDriver.GetDriverByDriverID(clsLicense.GetLicenseByLicenseID(_LicenseID)?.DriverID ?? -1)?.PersonID ?? -1;

            using (LicenseHistory frmLicenseHistory = new LicenseHistory(PersonID))
            {
                frmLicenseHistory.ShowDialog();
            }
        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            clsLicense License = clsLicense.GetLicenseByLicenseID(_LicenseID);

            if(MessageBox.Show("Are You Sure You Want To Issue International License For This Person?","Confirmation",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //issue License
                if (IssueLicense(License))
                {
                    uctrl_IApplicationInfo1.LDLicenseID = _LicenseID;
                    lnklblShowLicensesInfo.Enabled = true;
                    btnIssue.Enabled = false;

                    MessageBox.Show($"This International License Issued Successfully for this Person with ID of = {uctrl_IApplicationInfo1.ILicenseID}.", "Issued Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("This International License Issue Failed for this Person", "License Issued Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }

            
        }

        private bool IssueLicense(clsLicense License)
        {
            bool isIssued = false;


            if (License == null)
            {
                return isIssued;
            }
            
            clsApplication newIApplication = new clsApplication();
            newIApplication.ApplicationStatus = 2;
            newIApplication.ApplicationDate = DateTime.Today;
            newIApplication.ApplicationTypeID = 6;//international Application 6
            newIApplication.LastStatusDate = DateTime.Today;
            newIApplication.ApplicantPersonID = clsDriver.GetDriverByDriverID(License.DriverID)?.PersonID ?? -1;
            newIApplication.CreatedByUserID = clsLog.User.UserID;
            newIApplication.PaidFees = clsApplicationType.GetApplicationType(6).Fees;

            if (newIApplication.Save())
            {
                uctrl_IApplicationInfo1.IApplicationID = newIApplication.ApplicationID; 

                clsInternationalLicense newILicense = new clsInternationalLicense();
                newILicense.IsActive = true;
                newILicense.IssuedUsingLocalLicenseID = _LicenseID;
                newILicense.ApplicationID = newIApplication.ApplicationID;
                newILicense.IssueDate = DateTime.Today;
                newILicense.ExpirationDate = DateTime.Today.AddYears((int)clsClass.GetClassByClassID(3).DefaultValidityLength);
                newILicense.CreatedByUserID = clsLog.User.UserID;
                newILicense.DriverID = License.DriverID;

                if (newILicense.Save())
                {
                    uctrl_IApplicationInfo1.ILicenseID = newILicense.InternationalLicenseID;
                    isIssued = true;
                }
            }



            

            return isIssued;
        }

        private void lnklblShowLicensesInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
    }
}
