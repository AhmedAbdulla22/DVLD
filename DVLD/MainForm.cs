using BusinessLayer;
using DVLD.ApplicationForms;
using DVLD.Drivers;
using DVLD.License.DetainLicense;
using DVLD.License.InternationalDrivingLicense;
using DVLD.License.ReleaseDetainedLicense;
using DVLD.License.Renew_License;
using DVLD.License.ReplaceLicenseForDamagedOrLost;
using DVLD.Properties;
using DVLD.TestType;
using DVLD.UserForm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinForm = System.Windows.Controls;
using System.Windows.Forms;

namespace DVLD
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            ChangeSideBarIconSize();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            //disable active controls like button TabIndex 0
            this.ActiveControl = null;
        }


        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Text)
            {
                case "People":
                    {
                        //using (frmPeople frmPeople = new frmPeople())
                        //{
                        //    frmPeople.ShowDialog();

                        //}
                        Control People = new frmPeople();
                        addControlToPanel(ref People);
                        People.Show();

                        break;

                    }
                case "Drivers":
                    {
                        using (DriversForm frmDrivers = new DriversForm())
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
                        using (InternationalDLA frmInternationalLicenses = new InternationalDLA())
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
                case "Release Detained Driving License":
                    {
                        using (ReleaseDLicenseApp frmReleaseDLicenseApp = new ReleaseDLicenseApp())
                        {
                            frmReleaseDLicenseApp.ShowDialog();
                        }
                        break;
                    }
                case "Retake Test":
                    {
                        using (LocalDLA frmLocalDLA = new LocalDLA())
                        {
                            frmLocalDLA.ShowDialog();
                        }
                        break;
                    }

            }
        }

        private void toolStripMenuItem4_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Text)
            {
                case "Manage Detained Licenses":
                    {
                        using (ManageDetainedLicenses frmManageDetainLicense = new ManageDetainedLicenses())
                        {
                            frmManageDetainLicense.ShowDialog();
                        }
                        break;
                    }
                case "Detain License":
                    {
                        using (DetainLicenseApplication frmDetainLApp = new DetainLicenseApplication())
                        {
                            frmDetainLApp.ShowDialog();
                        }
                        break;
                    }
                case "Release Detained License":
                    {
                        using (ReleaseDLicenseApp frmReleaseDLicenseApp = new ReleaseDLicenseApp())
                        {
                            frmReleaseDLicenseApp.ShowDialog();
                        }
                        break;
                    }

            }
        }

        private void addControlToPanel(ref Control control)
        {
            if (control is Form frm)
            {
                frm.FormBorderStyle = FormBorderStyle.None;
                pnlMain.Controls.Clear();
                frm.TopLevel = false;
                frm.Parent = pnlMain;
                frm.Dock = DockStyle.Fill;
                pnlMain.Controls.Add(frm);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dashboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Control frmDash = new Dashboard();
            addControlToPanel(ref frmDash);
            frmDash.Show();
        }

        private void btnMaxMin_Click(object sender, EventArgs e)
        {
            if(this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
                //change btn Image_Back_g to minimize
                btnMaxMin.BackgroundImage = Resources.minimizeSize;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
                //change btn Image_Back_g to maximize
                btnMaxMin.BackgroundImage = Resources.maximize;
            }
        }

        private void btnMinimizeHide_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //folding and unfold side bar
            Size ClosedSize = new System.Drawing.Size(50, 529), OpenedSize = new System.Drawing.Size(175, 529);
            pnlSideBar.Size = (pnlSideBar.Size.Width == ClosedSize.Width) ?  OpenedSize:ClosedSize;

            //change menustrip mode
            ToolStripItemDisplayStyle toolStripItemDisplayStyle = menuStrip1.Items[0].DisplayStyle;
            foreach (ToolStripItem item in menuStrip1.Items)
            {
                item.DisplayStyle = (toolStripItemDisplayStyle == ToolStripItemDisplayStyle.ImageAndText) ? ToolStripItemDisplayStyle.Image : ToolStripItemDisplayStyle.ImageAndText;
            }
            
        }

        private void ChangeSideBarIconSize()
        {
            int w = 33, h = 33;
            foreach (ToolStripItem item in menuStrip1.Items)
            {
                item.Image = Utilites.ResizeImage(item.Image, w, h);
            }

        }
        private Point MousePoint;
        private void pnlTopBar_MouseDown(object sender, MouseEventArgs e)
        {
                MousePoint = e.Location;
        }

        private void pnlTopBar_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - MousePoint.X;
                this.Top+= e.Y - MousePoint.Y;
            }
        }
    }    
}
