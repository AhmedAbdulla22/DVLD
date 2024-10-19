using BusinessLayer;
using DVLD.ApplicationForms;
using DVLD.ApplicationForms.LocalDrivingLicenseApp;
using DVLD.License.DetainLicense;
using DVLD.License.ReleaseDetainedLicense;
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
    public partial class ManageDetainedLicenses : Form
    {
        public ManageDetainedLicenses()
        {
            InitializeComponent();

            //set cb to none
            cbFilter.SelectedIndex = 0;
            cbReleasedFilter.SelectedIndex = 0;
        }

        private void LoadTheDataGridView()
        {
            DataTable dt = clsDetainedLicenses.getAllDetainedLicense();
            dgvDetainedLicenses.DataSource = dt;
            //#Records Rows
            lblRecords.Text = "#Records" + ' ' + (dgvDetainedLicenses.RowCount).ToString();


        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgv_dgvDetainedLicensesLicensesMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                //row that you clicked on location
                var hitTestInfo = dgvDetainedLicenses.HitTest(e.X, e.Y);

                if (hitTestInfo.RowIndex >= 0)
                {
                    dgvDetainedLicenses.ClearSelection();
                    dgvDetainedLicenses.Rows[hitTestInfo.RowIndex].Selected = true;


                    releaseToolStripMenuItem.Enabled = !(bool)dgvDetainedLicenses.SelectedRows[0].Cells["Is Released"].Value; // to disable release if it released
                    contextMenuStrip1.Show(dgvDetainedLicenses, new Point(e.X, e.Y));
                }
            }
        }

        private void ManageDetainedLicenses_Load(object sender, EventArgs e)
        {
            LoadTheDataGridView();
        }

        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            int LicenseID = -1;
            LicenseID = Convert.ToInt32(dgvDetainedLicenses.SelectedRows[0].Cells["L.ID"].Value);
            string NationalNo = string.Empty;
            NationalNo = Convert.ToString(dgvDetainedLicenses.SelectedRows[0].Cells["N.NO"].Value);
            int PersonID = clsPerson.Find(NationalNo)?.PersonID ?? -1;

            //hide menu
            contextMenuStrip1.Close();//or just use .Hide()

            if (dgvDetainedLicenses.SelectedRows.Count == 1)
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

                            using (ShowLicenseInfo frmILicenseInfo = new ShowLicenseInfo(LicenseID))
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
                    case "Release":
                        {
                            using (ReleaseDLicenseApp frmReleaseDLicenseApp = new ReleaseDLicenseApp(LicenseID))
                            {
                                frmReleaseDLicenseApp.ShowDialog();
                            }
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
                        cbReleasedFilter.Visible = false;
                        break;
                    }
                case "Is Released":
                    {
                        tbFilter.Visible = false;
                        cbReleasedFilter.Visible = true;
                        cbReleasedFilter.SelectedIndex = 0;
                        break;
                    }
                default:
                    {
                        tbFilter.Visible = true;
                        cbReleasedFilter.Visible = false;
                        break;
                    }
            }

        }

        private void tbFilter_KeyDown(object sender, KeyEventArgs e)
        {

            switch (cbFilter.SelectedItem.ToString())
            {
                case "License ID":
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

            switch (cbReleasedFilter.SelectedItem.ToString())
            {
                case "Released":
                    {
                        dgvDetainedLicenses.DataSource = clsDetainedLicenses.getAllDetainedLicenseByIsReleased(true);

                        break;
                    }
                case "Not Released":
                    {
                        dgvDetainedLicenses.DataSource = clsDetainedLicenses.getAllDetainedLicenseByIsReleased(false);

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
                case "License ID":
                    {
                        if (int.TryParse(tbFilter.Text, out int value))
                        {
                        dgvDetainedLicenses.DataSource = clsDetainedLicenses.getAllDetainedLicenseByLicenseID(value);
                        }
                        break;
                    }
                case "NationalNo":
                    {
                            dgvDetainedLicenses.DataSource = clsDetainedLicenses.getAllDetainedLicenseByNationalNo(tbFilter.Text);
                        
                        break;
                    }
                case "Full Name":
                    {
                            dgvDetainedLicenses.DataSource = clsDetainedLicenses.getAllDetainedLicenseByFullName(tbFilter.Text);
                        
                        break;
                    }

            }

        }

        private void btnRelease_Click(object sender, EventArgs e)
        {
            using (ReleaseDLicenseApp frmReleaseDLicenseApp = new ReleaseDLicenseApp())
            {
                frmReleaseDLicenseApp.ShowDialog();
            }
        }

        private void btnDetain_Click(object sender, EventArgs e)
        {
            using (DetainLicenseApplication frmDetainLApp = new DetainLicenseApplication())
            {
                frmDetainLApp.ShowDialog();
            }
        }
    }
}
