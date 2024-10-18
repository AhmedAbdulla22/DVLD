using BusinessLayer;
using DVLD.ApplicationForms;
using DVLD.Drivers;
using DVLD.License.DetainLicense;
using DVLD.License.InternationalDrivingLicense;
using DVLD.License.Renew_License;
using DVLD.License.ReplaceLicenseForDamagedOrLost;
using DVLD.TestType;
using DVLD.UserForm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();

            
            //Resize Background
            this.BackgroundImage = Utilites.ResizeImage(Properties.Resources._87f519db_8efe_46d1_8881_9e7d58b3e705, 300, 300);

        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            //disable active controls like button TabIndex 0
            this.ActiveControl = null;
        }


        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch(e.ClickedItem.Text)
            {
                case "People":
                    {
                        using (frmPeople frmPeople = new frmPeople())
                        {
                            frmPeople.ShowDialog();

                        }
                        break;

                    }
                case "Drivers":
                    {
                        using(DriversForm frmDrivers = new DriversForm())
                        {
                            frmDrivers.ShowDialog();
                        }
                        break;
                    }
                case "Users":
                    {
                        using (frmUser frmUser = new frmUser())
                        {

                            frmUser.ShowDialog();
                        }
                        break;
                    }
                case "Current User Info":
                    {
                        using(frmUserDetails frmUDetails = new frmUserDetails(clsLog.User.PersonID))
                        {
                            frmUDetails.ShowDialog();
                        }
                        break;
                    }
                case "Change Password":
                    {
                        using (frmChangePassword frmChgPass = new frmChangePassword(clsLog.User.PersonID))
                        {
                            frmChgPass.ShowDialog();
                        }
                        break;
                    }
            }
        }


        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Owner.Visible = true;
            
            this.Close();
            
        }


        private void accountSettingsToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Text)
            {
                case "Current User Info":
                    {
                        using (frmUserDetails frmUDetails = new frmUserDetails(clsLog.User.PersonID))
                        {
                            frmUDetails.ShowDialog();
                        }
                        break;
                    }
                case "Change Password":
                    {
                        using (frmChangePassword frmChgPass = new frmChangePassword(clsLog.User.PersonID))
                        {
                            frmChgPass.ShowDialog();
                        }
                        break;
                    }
            }
        }

        private void applicationToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Text)
            {
                //case "Local Driving License Application":
                //    {
                //        using (LocalDLA frmLocalDLA = new LocalDLA())
                //        {
                //            frmLocalDLA.ShowDialog();
                //        }
                //        break;
                //    }
                case "Manage Application Types":
                    {
                        using (ManageApplicationType frmManageApplicationType = new ManageApplicationType())
                        {
                            frmManageApplicationType.ShowDialog();
                        }
                        break;

                    }
                case "Manage Test Types":
                    {
                        using (ManageTestTypes frmManageTestType = new ManageTestTypes())
                        {
                            frmManageTestType.ShowDialog();
                        }
                        break;
                    }


            }
        }

        private void toolStripMenuItem3_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Text)
            {
                case "Local Driving License Application":
                    {
                        using (LocalDLA frmLocalDLA = new LocalDLA())
                        {
                            frmLocalDLA.ShowDialog();
                        }
                        break;
                    }
                case "International Driving License Application":
                    {
                        using(InternationalDLA frmInternationalLicenses = new InternationalDLA())
                        {
                            frmInternationalLicenses.ShowDialog();
                        }
                    break;
                    }

            }
        }

        private void newDrivingLicenseToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Text)
            {
                case "Local License":
                    {
                        using (AddLocalDLA frmAddLocalDLA = new AddLocalDLA())
                        {
                            frmAddLocalDLA.ShowDialog();
                        }
                        break;
                    }
                case "International License":
                    {
                        using (NewInternationalLicense frmIssueILicense = new NewInternationalLicense())
                        {
                            frmIssueILicense.ShowDialog();
                        }
                        break;
                    }


            }
        }

        private void toolStripMenuItem2_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Text)
            {
                case "Renew Driving License":
                    {
                        using (RenewLicense frmRenewLicense = new RenewLicense())
                        {
                            frmRenewLicense.ShowDialog();
                        }
                        break;
                    }
                case "Replacement for Lost or Damaged Licnese":
                    {
                        using (ReplaceLicense frmReplaceLicense = new ReplaceLicense())
                        {
                            frmReplaceLicense.ShowDialog();
                        }
                        break;
                    }

            }
        }

        private void toolStripMenuItem4_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Text)
            {
                case "Detain License":
                    {
                        using (DetainLicenseApplication frmDetainLApp = new DetainLicenseApplication())
                        {
                            frmDetainLApp.ShowDialog();
                        }
                        break;
                    }

            }
        }
    }
}
