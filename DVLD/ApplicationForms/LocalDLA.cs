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

namespace DVLD.ApplicationForms
{
    public partial class LocalDLA : Form
    {
        public LocalDLA()
        {
            InitializeComponent();    
            
            //set cb to none
            cbFilter.SelectedIndex = 0;
            cbActiveFilter.SelectedIndex = 0;
        }

        private void LoadTheDataGridView()
        {
            DataTable dt = clsApplicationType.getAllApplicationTypes();
            dgvLocalDLA.DataSource = dt;
            //#Records Rows
            lblRecords.Text = "#Records" + ' ' + (dgvLocalDLA.RowCount).ToString();


        }

        private void dgvApplicationType_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                //row that you clicked on location
                var hitTestInfo = dgvLocalDLA.HitTest(e.X, e.Y);

                if (hitTestInfo.RowIndex >= 0)
                {
                    dgvLocalDLA.ClearSelection();
                    dgvLocalDLA.Rows[hitTestInfo.RowIndex].Selected = true;

                    contextMenuStrip1.Show(dgvLocalDLA, new Point(e.X, e.Y));
                }
            }
        }
        private void LocalDLA_Load(object sender, EventArgs e)
        {
            LoadTheDataGridView();
        }

        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            //int UserID = -1, PersonID = -1;
            //UserID = Convert.ToInt32(dgvLocalDLA.SelectedRows[0].Cells["UserID"].Value);
            //PersonID = Convert.ToInt32(dgvLocalDLA.SelectedRows[0].Cells["PersonID"].Value);


            //if (dgvLocalDLA.SelectedRows.Count == 1)
            //{
            //    switch (e.ClickedItem.Text)
            //    {
            //        case "Edit":
            //            {

            //                if (PersonID >= 0)
            //                {
            //                    EditUser(PersonID);
            //                }
            //                break;
            //            }
            //    }


            //}
        }

        private void btnAddLocalDLA_Click(object sender, EventArgs e)
        {
            AddNewLocalDLA();
        }

        private void AddNewLocalDLA()
        {
            using(NewLocalDLA frmNewLocaDLA = new NewLocalDLA())
            {
                frmNewLocaDLA.ShowDialog();

                LoadTheDataGridView();
            }
        }
    }

}
