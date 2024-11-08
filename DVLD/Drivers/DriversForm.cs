using BusinessLayer;
using DVLD.License;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Drivers
{
    public partial class DriversForm : Form
    {
        public DriversForm()
        {
            InitializeComponent();
        }



        private void Drivers_Load(object sender, EventArgs e)
        {
            cbFilter.SelectedIndex = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoadTheDataGridView()
        {
            DataTable dt = clsDriver.GetDrivers();
            dgvDrivers.DataSource = dt;
            //#Records Rows
            lblRecords.Text = "#Records" + ' ' + (dgvDrivers.RowCount).ToString();
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            //To Show Filter Box



            if (cbFilter.SelectedItem.ToString() == "None")
            {
                tbFilter.Visible = false;
                LoadTheDataGridView();
            }
            else
            {
                tbFilter.Visible = true;
            }
        }

        private void tbFilter_KeyDown(object sender, KeyEventArgs e)
        {
            switch (cbFilter.SelectedItem.ToString())
            {
                case "DriverID":
                case "PersonID":
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
                case "FullName":
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
                default:
                    break;
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
                            dgvDrivers.DataSource = clsDriver.getDriversByPersonID(value);
                        }
                        break;
                    }
                case "DriverID":
                    {
                        if (int.TryParse(tbFilter.Text, out int value))
                        {
                            dgvDrivers.DataSource = clsDriver.getDriversByDriverID(value);
                        }
                        break;
                    }
                case "National No.":
                    {
                        dgvDrivers.DataSource = clsDriver.getDriversByNationalNo(tbFilter.Text);
                        break;
                    }
                case "FullName":
                    {
                        dgvDrivers.DataSource = clsDriver.getDriversByFullName(tbFilter.Text);
                        break;
                    }
                
            }
        }
        private void ShowLicenseHistory(string NationalNo)
        {
            using (LicenseHistory frmLicenseHistory = new LicenseHistory(NationalNo))
            {
                frmLicenseHistory.ShowDialog();
            }
        }
        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var NationalNo = Convert.ToString(dgvDrivers.SelectedRows[0].Cells["National No."].Value);

            ShowLicenseHistory(NationalNo);
        }

        private void dgvDrivers_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                //row that you clicked on location
                var hitTestInfo = dgvDrivers.HitTest(e.X, e.Y);

                if (hitTestInfo.RowIndex >= 0)
                {
                    dgvDrivers.ClearSelection();
                    dgvDrivers.Rows[hitTestInfo.RowIndex].Selected = true;

                    contextMenuStrip1.Show(dgvDrivers, new Point(e.X, e.Y));
                }
            }
        }
    }
}
