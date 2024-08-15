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
using System.IO;

namespace DVLD
{
    public partial class frmLogin : Form
    {
        string _RememberMePath = @"C:\\Users\\Ahmed\\Documents\\RememberMe.txt";
        string delim = "#//#";
        public frmLogin()
        {
            InitializeComponent();


        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            clsUser User = clsUser.GetUser(tbUserName.Text,tbPassword.Text);

            if (User == null)
            {
                MessageBox.Show("Wrong UserName/Password","Try Again",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            else
            {
                if (!User.isActive)
                {
                MessageBox.Show("This User is InActive Please Contact the Admin","InActive User",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
                else
                {
                    if (chkRemember.Checked)
                    {
                        if (!File.Exists(_RememberMePath))
                        {
                            File.Create(_RememberMePath).Close();
                        }
                        File.WriteAllText(_RememberMePath,tbUserName.Text +delim+tbPassword.Text);

                    }
                    else
                    {
                        File.WriteAllText(_RememberMePath, "");
                    }
                    frmMain frmMain = new frmMain();
                    frmMain.FormClosing += formClosing;
                    //make the the login form parent of the main form
                    frmMain.Owner = this;


                    this.Visible = false;
                    frmMain.ShowDialog();
                }
            }


            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void formClosing(object sender, FormClosingEventArgs e)
        {
            if (!this.Visible)
            {
            this.Close();
            }
            else
            {
                FormLoad();
            }
        }

        private bool isRememberChecked()
        {
            bool result = false;
            
            if (File.Exists(_RememberMePath))
            {
                string str = File.ReadAllText(_RememberMePath);
                string[] SplitedStr = str.Split(new string[] {delim},StringSplitOptions.RemoveEmptyEntries);
                if (SplitedStr.Length != 0)
                {
                    //fill tboxes
                    tbUserName.Text = SplitedStr[0];
                    tbPassword.Text = SplitedStr[1];

                    //check checkbox of RemMe
                    chkRemember.Checked = true;

                    result = true;
                }
                else
                {
                    tbUserName.Text = tbPassword.Text = "";
                }
            }



            return result;
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            FormLoad();
        }

        private void FormLoad()
        {
            isRememberChecked();
        }
    }
}
