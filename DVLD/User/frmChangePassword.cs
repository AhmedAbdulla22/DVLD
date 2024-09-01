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
    public partial class frmChangePassword : Form
    {
        clsUser _User;
        public frmChangePassword(int PersonID = -1)
        {
            InitializeComponent();
            tbCurrentPassword.Leave += textBoxEmptyValidation;

            tbNewPassword.Leave += textBoxEmptyValidation;
            
            tbCnfPassword.Leave += textBoxEmptyValidation;
            tbCnfPassword.Leave += tbCnfPassword_Leave;





            if (PersonID > -1)
            {
                _User = clsUser.GetUser(PersonID);
                uctrlLoginInformation1.PersonID = uctrPersonDetails1.PersonID = PersonID;
                uctrPersonDetails1.UpdateControl();
                uctrlLoginInformation1.UpdateControl();
            }
        }


        private void textBoxEmptyValidation(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (string.IsNullOrEmpty(tb.Text))
            {
                errorProvider1.SetError(tb, "Required!");
            }
            else
            {
                errorProvider1.SetError(tb, "");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Control[] controls = { tbCurrentPassword, tbNewPassword, tbCnfPassword };



            foreach (Control control in controls)
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

            //Now Save 
            ChangePassword();
        }

        private void ChangePassword()
        {
            _User.Password = tbNewPassword.Text;
            if (_User.Save())
            {
                MessageBox.Show("Password Successfuly Changed", "Password Changed",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Password Can't Be Changed", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void tbCurrentPassword_KeyUp(object sender, KeyEventArgs e)
        {
            if (string.IsNullOrEmpty(tbCurrentPassword.Text))
            {
                return;
            }

            if (tbCurrentPassword.Text != _User.Password)
            {
                errorProvider1.SetError(tbCurrentPassword, "Current Password is incorrect!");
            }
            else
            {
                errorProvider1.SetError(tbCurrentPassword, "");
            }
        }

        private void tbCnfPassword_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbCnfPassword.Text))
            {
                return;
            }

            if (tbNewPassword.Text != tbCnfPassword.Text)
            {
                errorProvider1.SetError(tbCnfPassword, "Confirmation Password Must Be Same As The New Password!");
            }
            else
            {
                errorProvider1.SetError(tbCnfPassword, "");
            }
        }

    
    }
}
