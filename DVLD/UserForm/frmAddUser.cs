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

namespace DVLD.UserForm
{
    public partial class frmAddUser : Form
    {
        private int _UserID = -1;
        private string _SavedUserName = string.Empty;
        public frmAddUser()
        {

            InitializeComponent();

            uctrlFilterBy1.OnFilterSucceded += GettingPersonIDWhenFilterSucceded;

        }

        

        private bool GoingForNextTab()
        {
            bool GoToNextTab = false;
            if (uctrPersonDetails1.PersonID == -1)
            {
                MessageBox.Show("First Find A Person That is Not User Already", "Find A Person", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return GoToNextTab;
            }

            if (clsUser.GetUser(uctrPersonDetails1.PersonID) != null && _UserID == -1)
            {
                MessageBox.Show("This Person is Already User", "Select Another Person", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                GoToNextTab = true;
            }

            return GoToNextTab;
        }
        private void GettingPersonIDWhenFilterSucceded(int PersonID)
        {
                uctrPersonDetails1.PersonID = PersonID;
                uctrPersonDetails1.UpdateControl();
            //update form in case that it is in update mode and you want to add new user
            if (_UserID != -1)
            {
                _UserID = -1;
                UpdateForm();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (GoingForNextTab())
            {
                tabControl1.SelectTab(tabLogin);
            }


        }

        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (!GoingForNextTab())
            {
                e.Cancel = true;
            }
        }

        private void tbUserName_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbUserName.Text) && _SavedUserName != tbUserName.Text && clsUser.GetUser(tbUserName.Text) != null)
            {
                errorProvider1.SetError(tbUserName, "This UserName is Already Exist!");
                tbUserName.Focus();
            }
            else
            {
                errorProvider1.SetError(tbUserName, "");
            }

        }

        private void tbCnfPassword_Leave(object sender, EventArgs e)
        {
            if (tbPassword.Text != tbCnfPassword.Text)
            {
                errorProvider1.SetError(tbCnfPassword, "Confirmation Password Must Be Same As The New Password!");
                tbCnfPassword.Focus();
            }
            else
            {
                errorProvider1.SetError(tbCnfPassword, "");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(tabControl1.SelectedTab == tabPersonalInfo)
            {
                MessageBox.Show("First Find A Person That is Not User Already", "Find A Person", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Control[] controls = { tbUserName, tbPassword,tbCnfPassword };

                

                foreach(Control control in controls)
                {
                    if (string.IsNullOrEmpty(control.Text))
                    {
                        MessageBox.Show("There is Boxes You Need To Fill Before!", "Fill Boxes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }

                    foreach (Control control in controls)
                    {
                        if (!string.IsNullOrEmpty(errorProvider1.GetError(control)))
                        {
                            MessageBox.Show("There is Mistakes You Need To Take Care of First!", "Fix Mistakes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                //Now Save him As User
                SaveUser();
            }
        }

        private void SaveUser()
        {
            clsUser user = new clsUser();
            if (_UserID == -1)
            {

                user.PersonID = uctrPersonDetails1.PersonID;
                user.UserName = tbUserName.Text;
                user.Password = tbPassword.Text;
                user.isActive = chkIsActive.Checked;
            }
            else
            {
                user = new clsUser(_UserID, uctrPersonDetails1.PersonID,tbUserName.Text,tbPassword.Text,chkIsActive.Checked);
            }


            if (user.Save())
            {
                string ModeStr;
                if (_UserID == -1)
                {
                    ModeStr = "Saved";
                    _UserID = user.UserID;
                    _SavedUserName = user.UserName;
                }
                else
                {
                    ModeStr = "Updated";
                }
                MessageBox.Show($"User {ModeStr} Succesfully.", ModeStr, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            lblUserID2.Text = user.UserID.ToString();
                            UpdateForm();
            }
            else
            {
                MessageBox.Show("User Not Saved.", "Not Saved", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void UpdateForm()
        {
            if (_UserID != -1)
            {
                lblFormLabel.Text = "Update User";
            }
            else
            {
                lblFormLabel.Text = "Add New User";
                tbCnfPassword.Text = string.Empty;
                tbPassword.Text = string.Empty;
                tbUserName.Text = string.Empty;
                lblUserID2.Text = string.Empty;
                _SavedUserName = string.Empty;
                chkIsActive.Checked = false;
            }
        }

     

        private void frmAddUser_Load(object sender, EventArgs e)
        {

        }
    }
}
