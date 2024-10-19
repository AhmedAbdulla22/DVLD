using BusinessLayer;
using DVLD.License.ReplaceLicenseForDamagedOrLost;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.License.DetainLicense
{
    public partial class DetainLicenseApplication : Form
    {
        int _LicenseID = -1;
        public DetainLicenseApplication()
        {
            InitializeComponent();
            uctrlFindLDLicense1.OnFilterSucceded += FilterSucceded;

            btnDetain.Image = Utilites.ResizeImage(btnDetain.Image, 25, 25);
        }

        private void FilterSucceded(int LicenseID)
        {
            uctrl_DriverLicenseInfo1.LicenseID = uctrlDetainInfo1.LicenseID = _LicenseID = LicenseID;

            clsLicense License = clsLicense.GetLicenseByLicenseID(LicenseID);

            lnklblShowLicensesHistory.Enabled = true;

            var message = string.Empty;

            if (License != null)
            {
                if (License.isDetained())
                {
                    message = "This License Is Already Detaind";
                }
                else if (!License.IsActive)
                {
                    message = "This License Is Not Active";
                }



                if (!string.IsNullOrEmpty(message))
                {
                    MessageBox.Show(message, "Attempt Denied", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnDetain.Enabled = false;
                    return;
                }

            }

            //if those conditions don't meet then the issue button get enabled
            btnDetain.Enabled = true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void btnDetain_Click(object sender, EventArgs e)
        {
            clsLicense License = clsLicense.GetLicenseByLicenseID(_LicenseID);

            if (MessageBox.Show($"Are You Sure You Want To Detain the License For This Person with ID = {License?.LicenseID ?? -1}?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //issue License
                if (DetainLicense(License))
                {
                    //deaActivate the OLD License
                    License.DeactivateLicense();


                    uctrlDetainInfo1.LicenseID = _LicenseID;
                    uctrl_DriverLicenseInfo1.UpdateControl();
                    lnklblShowLicensesInfo.Enabled = true;
                    btnDetain.Enabled = false;


                    MessageBox.Show($"This License Detained Successfully for this License ID of = {uctrlDetainInfo1.LicenseID}.", "Detained Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("This License Detain Failed for this Person", "Detain Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }

        private bool DetainLicense(clsLicense License)
        {
            bool isDetained = false;


            if (License == null)
            {
                return isDetained;
            }

            
                clsDetainedLicenses newDLicense = new clsDetainedLicenses();
                newDLicense.IsReleased = false;
                newDLicense.LicenseID = License.LicenseID;
                newDLicense.DetainDate = DateTime.Today;
                newDLicense.FineFees = uctrlDetainInfo1.FineFees;
                newDLicense.CreatedByUserID = clsLog.User.UserID;

                if (newDLicense.Save())
                {
                    uctrlDetainInfo1.DetainID = newDLicense.DetainID;
                    isDetained = true;
                }
            





            return isDetained;
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
