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
using static System.Net.Mime.MediaTypeNames;

namespace DVLD.ApplicationForms
{
    public partial class IssueDrivingLicenseFirstTime : Form
    {
        public IssueDrivingLicenseFirstTime(int LDLAppID = -1)
        {
            InitializeComponent();

            if (LDLAppID != -1)
            {
                uctrlDrivingLicenseApplicationInfo1.DLAppID = LDLAppID;

                btnIssue.Enabled = true;
            }
            else
            {
                btnIssue.Enabled = false;
            }
        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            if (uctrlDrivingLicenseApplicationInfo1.DLAppID != -1)
            {
                clsLocalDLA LDLApp = clsLocalDLA.GetLocalDLAppByLocalDLAppID(uctrlDrivingLicenseApplicationInfo1.DLAppID);
                if (LDLApp != null)
                {
                    clsApplication App = clsApplication.GetApplicationByApplicationID(LDLApp.ApplicationID);
                    clsLicense license = new clsLicense();
                    license.ApplicationID = App.ApplicationID;
                    license.LicenseClass = LDLApp.LicenseClassID;
                    DateTime dt;
                    license.IssueDate = dt = DateTime.Today;
                    license.ExpirationDate = dt.AddYears(clsClass.GetClassByClassID(LDLApp.LicenseClassID).DefaultValidityLength); 
                    license.Notes = tbNotes.Text;
                    license.PaidFees = App.PaidFees;
                    license.IsActive = true;
                    license.IssueReason = (byte)App.ApplicationTypeID;
                    license.CreatedByUserID = clsLog.User.UserID;

                    clsDriver driver = clsDriver.GetDriverByPersonID(App.ApplicantPersonID);
                    //if driver not exist
                    if (driver == null)
                    {
                        driver = new clsDriver();
                        driver.PersonID = App.ApplicantPersonID;
                        driver.CreatedDate = DateTime.Today;
                        driver.CreatedByUserID = clsLog.User.UserID;

                        if (!driver.Save())
                        {
                            MessageBox.Show("Driver Not Been Saved Properly!","Failed Attempt",MessageBoxButtons.OK,MessageBoxIcon.Error);
                        }
                    }

                    license.DriverID = driver.DriverID;

                    if(license.Save())
                    {
                        MessageBox.Show("License Saved Successfully", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        //Update Application to COmpleted
                        App.ApplicationStatus = (byte)clsApplication.Status.Compledted;
                        App.Save();

                    }
                    else
                    {
                        MessageBox.Show("License Not Been Saved Properly!", "Failed Attempt", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
