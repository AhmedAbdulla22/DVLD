using BusinessLayer;
using DVLD.ApplicationForms;
using DVLD.ApplicationForms.LocalDrivingLicenseApp;
using DVLD.PeopleForm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.License.InternationalDrivingLicense
{
    public partial class InternationalDLA : Form
    {
        public InternationalDLA()
        {
            InitializeComponent();

            //set cb to none
            cbFilter.SelectedIndex = 0;
            cbActiveFilter.SelectedIndex = 0;
        }

        private void LoadTheDataGridView()
        {
            DataTable dt = clsInternationalLicense.getAllInternationalLicense();
            dgvInternationalLicenses.DataSource = dt;
            //#Records Rows
            lblRecords.Text = "#Records" + ' ' + (dgvInternationalLicenses.RowCount).ToString();


        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgv_dgvInternationalLicensesMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                //row that you clicked on location
                var hitTestInfo = dgvInternationalLicenses.HitTest(e.X, e.Y);

                if (hitTestInfo.RowIndex >= 0)
                {
                    dgvInternationalLicenses.ClearSelection();
                    dgvInternationalLicenses.Rows[hitTestInfo.RowIndex].Selected = true;



                    contextMenuStrip1.Show(dgvInternationalLicenses, new Point(e.X, e.Y));
                }
            }
        }

        private void InternationalDLA_Load(object sender, EventArgs e)
        {
            LoadTheDataGridView();
        }

        private void btnAddInternationLicense_Click(object sender, EventArgs e)
        {
            using (NewInternationalLicense frmNewInternationalLicense = new NewInternationalLicense())
            {
                frmNewInternationalLicense.ShowDialog();
            }
            LoadTheDataGridView();
        }

        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            int IDLicenseID = -1;
            IDLicenseID = Convert.ToInt32(dgvInternationalLicenses.SelectedRows[0].Cells["Int.License ID"].Value);
            int DriverID = -1;
            DriverID = Convert.ToInt32(dgvInternationalLicenses.SelectedRows[0].Cells["Driver ID"].Value);
            int PersonID = clsDriver.GetDriverByDriverID(DriverID)?.PersonID ?? -1;

            //hide menu
            contextMenuStrip1.Close();//or just use .Hide()

            if (dgvInternationalLicenses.SelectedRows.Count == 1)
            {
                switch (e.ClickedItem.Text)
                {
                    case "Show Person Details":
                        {
                            using (Person_Details frmDetails = new Person_Details(PersonID))
                            {
                                frmDetails.ShowDialog();
                            }
                            break;
                        }
                    case "Show License":
                        {

                            using (InternationalLicenseInfo frmILicenseInfo = new InternationalLicenseInfo(IDLicenseID))
                            {
                                frmILicenseInfo.ShowDialog();
                            }
                            break;
                        }
                    case "Show Person License History":
                        {
                            ShowLicenseHistory(PersonID);
                            break;

                        }
                }


            }

        }

        private void ShowLicenseHistory(int PersonID)
        {
            using (LicenseHistory frmLicenseHistory = new LicenseHistory(PersonID))
            {
                frmLicenseHistory.ShowDialog();
            }
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
                        cbActiveFilter.Visible = false;
                        break;
                    }
                case "Is Active":
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

        private void tbFilter_KeyDown(object sender, KeyEventArgs e)
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

        }

        private void cbActiveFilter_SelectedIndexChanged(object sender, EventArgs e)
        {

            switch (cbActiveFilter.SelectedItem.ToString())
            {
                case "Active":
                    {
                        dgvInternationalLicenses.DataSource = clsInternationalLicense.GetInternationalLicenseApplicationsByIsActive(true);

                        break;
                    }
                case "Not Active":
                    {
                        dgvInternationalLicenses.DataSource = clsInternationalLicense.GetInternationalLicenseApplicationsByIsActive(false);

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
                case "Int.License ID":
                    {
                        if (int.TryParse(tbFilter.Text, out int value))
                        {
                        dgvInternationalLicenses.DataSource = clsInternationalLicense.GetInternationalLicenseApplicationsByIntLicenseID(value);
                        }
                        break;
                    }
                case "Application ID":
                    {
                        if (int.TryParse(tbFilter.Text, out int value))
                        {
                            dgvInternationalLicenses.DataSource = clsInternationalLicense.GetInternationalLicenseApplicationsByAppID(value);
                        }
                        break;
                    }
                case "Driver ID":
                    {
                        if (int.TryParse(tbFilter.Text, out int value))
                        {
                            dgvInternationalLicenses.DataSource = clsInternationalLicense.GetInternationalLicenseApplicationsByDriverID(value);
                        }
                        break;
                    }
                case "L.License ID":
                    {
                        if (int.TryParse(tbFilter.Text, out int value))
                        {
                            dgvInternationalLicenses.DataSource = clsInternationalLicense.GetInternationalLicenseApplicationsByLocalLicenseID(value);
                        }
                        break;
                    }

            }

        }
    }
}
