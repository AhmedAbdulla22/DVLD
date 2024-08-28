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
        enum ctrlMode { Add = 1, Update = 2 };
        ctrlMode _ctrlMode = ctrlMode.Add;
        private clsUser user = new clsUser();

        public frmAddUser(int PersonID = -1)
        {

            InitializeComponent();

            uctrlFilterBy1.OnFilterSucceded += GettingPersonIDWhenFilterSucceded;

            //set uctrl PersonDetails
            uctrPersonDetails1.PersonID = PersonID;

            if (PersonID == -1)
            {
                _ctrlMode = ctrlMode.Add;
            }
            else
            {
                _ctrlMode = ctrlMode.Update;
                user = clsUser.GetUser(PersonID);

                tbUserName.Text = user.UserName;
                tbPassword.Text = user.Password;
                tbCnfPassword.Text = user.Password;
                chkIsActive.Checked = user.isActive;
                lblUserID2.Text = user.UserID.ToString();
            }
        }

        

        private bool GoingForNextTab()
        {
            bool GoToNextTab = false;
            if (uctrPersonDetails1.PersonID == -1)
            {
                MessageBox.Show("First Find A Person That is Not User Already", "Find A Person", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return GoToNextTab;
            }

            if (_ctrlMode == ctrlMode.Add && clsUser.GetUser(uctrPersonDetails1.PersonID) != null)
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
            if (!string.IsNullOrEmpty(tbUserName.Text) && user.UserName != tbUserName.Text && clsUser.GetUser(tbUserName.Text) != null)
            {
                errorProvider1.SetError(tbUserName, "This UserName is Already Exist!");
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
            if (_ctrlMode == ctrlMode.Add)
            {

                user.PersonID = uctrPersonDetails1.PersonID;
                user.UserName = tbUserName.Text;
                user.Password = tbPassword.Text;
                user.isActive = chkIsActive.Checked;
            }
            else
            {
                user = new clsUser(user.UserID, uctrPersonDetails1.PersonID,tbUserName.Text,tbPassword.Text,chkIsActive.Checked);
            }


            if (user.Save())
            {
                string ModeStr;
                if (_ctrlMode == ctrlMode.Add)
                {
                    ModeStr = "Saved";
                    _ctrlMode = ctrlMode.Update;
                    lblUserID2.Text = user.UserID.ToString();
                }
                else
                {
                    ModeStr = "Updated";
                }

                MessageBox.Show($"User {ModeStr} Succesfully.", ModeStr, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            UpdateForm();
            }
            else
            {
                MessageBox.Show("User Not Saved.", "Not Saved", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void UpdateForm()
        {
            if (_ctrlMode == ctrlMode.Update)
            {
                lblFormLabel.Text = "Update User";
                //disable groupbox of filter
                groupBox1.Enabled = false;

            }
            else
            {
                lblFormLabel.Text = "Add New User";
                tbCnfPassword.Text = string.Empty;
                tbPassword.Text = string.Empty;
                tbUserName.Text = string.Empty;
                lblUserID2.Text = string.Empty;
                chkIsActive.Checked = false;
            }
        }

     

        private void frmAddUser_Load(object sender, EventArgs e)
        {
            UpdateForm();
        }

    }
}
