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

            if (clsUser.GetUser(uctrPersonDetails1.PersonID) != null)
            {
                MessageBox.Show("This Person is Already User", "Select Another Person", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                tabControl1.SelectTab(tabLogin);
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
            GoingForNextTab();

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
            if (clsUser.GetUser(tbUserName.Text) != null)
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

        }
    }
}
