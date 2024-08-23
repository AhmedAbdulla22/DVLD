using BusinessLayer;
using DVLD.PeopleForm;
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
    public partial class frmUser : Form
    {
        public frmUser()
        {
            InitializeComponent();

            //set cb to none
            cbFilter.SelectedIndex = 0;
            cbActiveFilter.SelectedIndex = 0;
        }

        private void LoadTheDataGridView()
        {
            DataTable dt = clsUser.getAllUsers();
            dgvUsers.DataSource = dt;
            //#Records Rows
            lblRecords.Text = "#Records" + ' ' + (dgvUsers.RowCount).ToString();


        }

        private void frmUser_Load(object sender, EventArgs e)
        {
            LoadTheDataGridView();

            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddNewUser()
        {
            using (frmAddUser AddUserForm = new frmAddUser())
            {
                AddUserForm.FormClosed += frmUser_Load;
                AddUserForm.ShowDialog();
            }
        }
        private void EditUser(int PersonID)
        {
            using (frmAddUser AddUserForm = new frmAddUser(PersonID))
            {
                AddUserForm.FormClosed += frmUser_Load;
                AddUserForm.ShowDialog();
            }
        }
        private void btnAddUser_Click(object sender, EventArgs e)
        {
            AddNewUser();
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {

            switch(cbFilter.SelectedItem.ToString())
            {
                case "None":
                    {
                        tbFilter.Visible = false;
                        cbActiveFilter.Visible = false;
                        LoadTheDataGridView();
                        break;
                    }
                case "IsActive":
                    {
                        tbFilter.Visible = false;
                        cbActiveFilter.Visible = true;
                        cbActiveFilter.SelectedIndex = 0;
                        break;
                    }
                default:
                    {
                        tbFilter.Visible = true;
                        cbActiveFilter.Visible = false;
                        break;
                    }
            }
            
        }

        private void dgvPeople_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                //row that you clicked on location
                var hitTestInfo = dgvUsers.HitTest(e.X, e.Y);

                if (hitTestInfo.RowIndex >= 0)
                {
                    dgvUsers.ClearSelection();
                    dgvUsers.Rows[hitTestInfo.RowIndex].Selected = true;

                    contextMenuStrip1.Show(dgvUsers, new Point(e.X, e.Y));
                }
            }
        }

        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            int UserID = -1,PersonID = -1;
            UserID = Convert.ToInt32(dgvUsers.SelectedRows[0].Cells["UserID"].Value);
            PersonID = Convert.ToInt32(dgvUsers.SelectedRows[0].Cells["PersonID"].Value);


            if (dgvUsers.SelectedRows.Count == 1)
            {
                switch (e.ClickedItem.Text)
                {
                    case "Edit":
                        {

                            if (PersonID >= 0)
                            {
                                EditUser(PersonID);
                            }
                            break;
                        }
                    case "Show Details":
                        {
                            using (frmUserDetails UserDetails = new frmUserDetails(PersonID))
                            {
                                UserDetails.ShowDialog();
                            }
                            break;
                        }
                    case "Delete":
                        {
                            if (MessageBox.Show("Are You Sure You Want to Delete this User?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                            {
                                if (clsUser.Delete(UserID))
                                {
                                    MessageBox.Show("User Deleted Succesfully", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    //refresh dgvPeople
                                    LoadTheDataGridView();
                                }
                                else
                                {
                                    MessageBox.Show("User Cannot Be Deleted Due Data Connected To it", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }

                            }

                            break;
                        }
                    case "Add New User":
                        {
                            AddNewUser();
                            break;
                        }
                    case "Change Password":
                        {
                            using (frmChangePassword frmPassword = new frmChangePassword(PersonID))
                            {
                                frmPassword.FormClosed += frmUser_Load;
                                frmPassword.ShowDialog();
                            }
                            break;
                        }
                    default:
                        MessageBox.Show("Still in Work", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        break;
                }


            }
        }

        private void tbFilter_KeyDown(object sender, KeyEventArgs e)
        {
            
                switch (cbFilter.SelectedItem.ToString())
                {
                    case "PersonID":
                    case "UserID":
                        {
                            if (char.IsDigit((char)e.KeyValue) || e.KeyCode == Keys.Back || e.KeyCode == Keys.Left || e.KeyCode == Keys.Right)
                            {
                                e.SuppressKeyPress = false;
                                e.Handled = false;
                            }
                            else
                            {
                                e.SuppressKeyPress = true;
                                e.Handled = true;
                            }
                            break;
                        }
                    case "Full Name":
                    case "User Name":
                        {
                            if (char.IsLetter((char)e.KeyValue) || e.KeyCode == Keys.Space || e.KeyCode == Keys.Back || e.KeyCode == Keys.Left || e.KeyCode == Keys.Right)
                            {
                                e.Handled = false;
                                e.SuppressKeyPress = false;
                            }
                            else
                            {
                                e.Handled = true;
                                e.SuppressKeyPress = true;
                            }
                            break;
                        }
                }



            
        }

        private void cbActiveFilter_SelectedIndexChanged(object sender, EventArgs e)
        {

            switch (cbActiveFilter.SelectedItem.ToString())
            {
                case "InActive":
                    {
                        dgvUsers.DataSource = clsUser.getUsersByIsActive(false);
                        break;
                    }
                case "Active":
                    {
                        dgvUsers.DataSource = clsUser.getUsersByIsActive(true);
                        break;
                    }
                default:
                    {
                        LoadTheDataGridView();
                        break;
                    }
            }
        }

        private void tbFilter_TextChanged(object sender, EventArgs e)
        {
            var filterTxt = tbFilter.Text;
            if (string.IsNullOrEmpty(filterTxt))
            {
                LoadTheDataGridView();
                return;
            }

            switch (cbFilter.SelectedItem.ToString())
            {
                case "PersonID":
                    {
                        if (int.TryParse(tbFilter.Text, out int value))
                        {
                            dgvUsers.DataSource = clsUser.getUsersByPersonID(value);
                        }
                        break;
                    }
                case "UserID":
                    {
                        if (int.TryParse(tbFilter.Text, out int value))
                        {
                            dgvUsers.DataSource = clsUser.getUsersByUserID(value);
                        }
                        break;
                    }
                case "Full Name":
                    {
                        dgvUsers.DataSource = clsUser.getUsersByFullName(filterTxt);
                        break;
                    }
                case "User Name":
                    {
                        dgvUsers.DataSource = clsUser.getUsersByUserName(filterTxt);
                        break;
                    }
            }
        }
    }
}
