using BusinessLayer;
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
                case "Application":
                    {
                        MessageBox.Show("Still in Work", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                        break;
                    }
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
                        MessageBox.Show("Still in Work", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

        private void accountSettingsToolStripMenuItem_MouseHover(object sender, EventArgs e)
        {
            accountSettingsToolStripMenuItem.ShowDropDown();
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
    }
}
