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
    public partial class frmUser : Form
    {
        public frmUser()
        {
            InitializeComponent();
        }

        private void LoadTheDataGridView()
        {
            DataTable dt = clsUser.getAllUsers();
            dgvPeople.DataSource = dt;
            //#Records Rows
            lblRecords.Text = "#Records" + ' ' + (dgvPeople.RowCount).ToString();
        }

        private void frmUser_Load(object sender, EventArgs e)
        {
            LoadTheDataGridView();

            //set cb to none
            cbFilter.SelectedIndex = 0;
            cbActiveFilter.SelectedIndex = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            using(frmAddUser AddUserForm = new frmAddUser())
            {
                AddUserForm.ShowDialog();
            }
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

        
    }
}
