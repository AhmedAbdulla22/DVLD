using BusinessLayer;
using DVLD.UserForm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DVLD.ApplicationForms
{
    public partial class LocalDLA : Form
    {
        
        public LocalDLA()
        {
            InitializeComponent();    
            
            //set cb to none
            cbFilter.SelectedIndex = 0;
            cbStatusFilter.SelectedIndex = 0;
        }

        private void LoadTheDataGridView()
        {
            DataTable dt = clsLocalDLA.getAllLocalDLA();
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
            int LDLAppID = -1;
            LDLAppID = Convert.ToInt32(dgvLocalDLA.SelectedRows[0].Cells["L.D.L.AppID"].Value);


            if (dgvLocalDLA.SelectedRows.Count == 1)
            {
                switch (e.ClickedItem.Text)
                {
                    case "Edit Application":
                        {

                            if (LDLAppID >= 0)
                            {
                                EditLocalDLA(LDLAppID);
                            }
                            break;
                        }
                }


            }
        }

        private void btnAddLocalDLA_Click(object sender, EventArgs e)
        {
            AddNewLocalDLA();
        }

        private void AddNewLocalDLA()
        {
            using (AddLocalDLA frmNewLocaDLA = new AddLocalDLA())
            {
                frmNewLocaDLA.ShowDialog();

                LoadTheDataGridView();
            }
        }

        private void EditLocalDLA(int LDLAppID)
        {
            using (AddLocalDLA frmNewLocaDLA = new AddLocalDLA(LDLAppID))
            {
                frmNewLocaDLA.ShowDialog();

                LoadTheDataGridView();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            //to referesh DGV
            LoadTheDataGridView();

            switch (cbFilter.SelectedItem.ToString())
            {
                case "None":
                    {
                        tbFilter.Visible = false;
                        cbStatusFilter.Visible = false;
                        break;
                    }
                case "Status":
                    {
                        tbFilter.Visible = false;
                        cbStatusFilter.Visible = true;
                        cbStatusFilter.SelectedIndex = 0;
                        break;
                    }
                default:
                    {
                        tbFilter.Visible = true;
                        cbStatusFilter.Visible = false;
                        break;
                    }
            }

        }

        private void tbFilter_KeyDown(object sender, KeyEventArgs e)
        {

            switch (cbFilter.SelectedItem.ToString())
            {
                case "L.D.L.AppID":
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
                case "National No.":
                case "Full Name":
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

        private void cbStatusFilter_SelectedIndexChanged(object sender, EventArgs e)
        {

            switch (cbStatusFilter.SelectedItem.ToString())
            {
                case "New":
                    {
                        dgvLocalDLA.DataSource = clsLocalDLA.getLocalDLA_ByStatus(1);
                        break;
                    }
                case "Canceled":
                    {
                        dgvLocalDLA.DataSource = clsLocalDLA.getLocalDLA_ByStatus(2);

                        break;
                    }
                case "Completed":
                    {
                        dgvLocalDLA.DataSource = clsLocalDLA.getLocalDLA_ByStatus(3);

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
                case "L.D.L.AppID":
                    {
                        if (int.TryParse(tbFilter.Text, out int value))
                        {
                            dgvLocalDLA.DataSource = clsLocalDLA.getLocalDLA_ByLDLAppID(value);
                        }
                        break;
                    }
                case "National No.":
                    {
                        dgvLocalDLA.DataSource = clsLocalDLA.getLocalDLA_ByNationalNo(filterTxt);
                        
                        break;
                    }
                case "Full Name":
                    {
                            dgvLocalDLA.DataSource = clsLocalDLA.getLocalDLA_ByFullName(filterTxt);
                        
                        break;
                    }

            }

        }
    }

}
