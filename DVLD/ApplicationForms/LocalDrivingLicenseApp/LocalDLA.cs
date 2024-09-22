using BusinessLayer;
using DVLD.ApplicationForms.LocalDrivingLicenseApp;
using DVLD.License;
using DVLD.Tests.Vison_Test;
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

                    //update
                    UpdateContextMenuStrip();

                    contextMenuStrip1.Show(dgvLocalDLA, new Point(e.X, e.Y));
                }
            }
        }

        private void UpdateContextMenuStrip( )
        {

            

            int passedTests = Convert.ToInt32(dgvLocalDLA.SelectedRows[0].Cells["Passed Tests"].Value);
            if (Convert.ToString(dgvLocalDLA.SelectedRows[0].Cells["Status"].Value) == "New")
            {
                Dictionary<ToolStripItem, int> dict = new Dictionary<ToolStripItem, int>();

                dict.Add(scheduleVisonTestToolStripMenuItem, 0);
                dict.Add(scheduleWrittenTestToolStripMenuItem, 1);
                dict.Add(scheduleStreetTestToolStripMenuItem, 2);

                //showLicense
                showLicenseToolStripMenuItem.Enabled = false;
                editApplicationToolStripMenuItem.Enabled = true;
                deleteApplicationToolStripMenuItem.Enabled = true;
                cancelApplicationToolStripMenuItem.Enabled = true;

                switch (passedTests)
                {
                    case 0:
                    case 1:
                    case 2:
                        {
                            issueDrivingLicenseFirstTimeToolStripMenuItem.Enabled = false;

                            scheduleTestsToolStripMenuItem.Enabled = true;
                            //check schedule test permession
                            if (dgvLocalDLA.RowCount != 0)
                            {

                                foreach (var item in dict)
                                {
                                    ToolStripItem tsItem = item.Key;

                                    if (item.Value == passedTests)
                                    {
                                        tsItem.Enabled = true;
                                    }
                                    else
                                    {
                                        tsItem.Enabled = false;
                                    }
                                }

                            }
                            break;
                        }
                    case 3:
                        {
                            issueDrivingLicenseFirstTimeToolStripMenuItem.Enabled = true;
                            scheduleTestsToolStripMenuItem.Enabled = false;

                            break;
                        }
                }

            }
            else
            {
                issueDrivingLicenseFirstTimeToolStripMenuItem.Enabled = scheduleTestsToolStripMenuItem.Enabled = false;
                editApplicationToolStripMenuItem.Enabled = false;
                deleteApplicationToolStripMenuItem.Enabled = false;
                cancelApplicationToolStripMenuItem.Enabled = false;
                scheduleTestsToolStripMenuItem.Enabled = false;

                if (Convert.ToString(dgvLocalDLA.SelectedRows[0].Cells["Status"].Value) == "Completed")
                {
                    showLicenseToolStripMenuItem.Enabled = true;                   
                }
                else
                {
                    showLicenseToolStripMenuItem.Enabled = false;
                }
            }


        }

        private void LocalDLA_Load(object sender, EventArgs e)
        {
            LoadTheDataGridView();
        }

        private void issueDriverLicense(int LDLAppID)
        {
            using (IssueDrivingLicenseFirstTime frmIssueLicense = new IssueDrivingLicenseFirstTime(LDLAppID))
            {
                frmIssueLicense.ShowDialog();
            }
                LoadTheDataGridView();
        }

        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            int LDLAppID = -1;
            LDLAppID = Convert.ToInt32(dgvLocalDLA.SelectedRows[0].Cells["L.D.L.AppID"].Value);
            string NationalNo = string.Empty;
            NationalNo = Convert.ToString(dgvLocalDLA.SelectedRows[0].Cells["National No."].Value);

            //hide menu
            contextMenuStrip1.Close();//or just use .Hide()

            if (dgvLocalDLA.SelectedRows.Count == 1)
            {
                switch (e.ClickedItem.Text)
                {
                    case "Show Application Details":
                        {
                            using(ShowLocalDLAppInfo frmShowLDLAppInfo = new ShowLocalDLAppInfo(LDLAppID))
                            {
                                frmShowLDLAppInfo.ShowDialog();
                            }
                        }
                        break;
                    case "Edit Application":
                        {

                            if (LDLAppID >= 0)
                            {
                                EditLocalDLA(LDLAppID);
                            }
                            break;
                        }
                    case "Delete Application":
                        {
                            if (MessageBox.Show("Are You Sure You Want to Delete This Application?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                clsLocalDLA LocalDLA = clsLocalDLA.GetLocalDLAppByLocalDLAppID(LDLAppID);
                                int AppID = LocalDLA?.ApplicationID ?? -1;

                                if (LocalDLA?.Delete() ?? false)
                                {
                                    if (clsApplication.GetApplicationByApplicationID(AppID)?.Delete() ?? false)
                                    {
                                        LoadTheDataGridView();
                                    }
                                }
                                
                            }
                            break;
                        }
                    case "Cancel Application":
                        {
                                if (MessageBox.Show("Are You Sure You Want to Cancel This Application?","Confirmation",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
                                {
                                int AppID = clsLocalDLA.GetLocalDLAppByLocalDLAppID(LDLAppID)?.ApplicationID ?? -1;
                                    if (clsApplication.GetApplicationByApplicationID(AppID)?.SetToCancel() ?? false)
                                    {
                                        LoadTheDataGridView();
                                    }
                                }
                            
                            break;
                        }
                    case "Issue Driving License (First Time)":
                        {
                            issueDriverLicense(LDLAppID);   
                                break;
                        }
                    case "Show Person License History":
                        {
                            ShowLicenseHistory(NationalNo);
                            break;

                        }
                    case "Show License":
                        {
                            ShowLicenseInfo(LDLAppID);
                            break;
                        }
                }


            }
        }

        private void ShowLicenseInfo(int LDLAppID = -1)
        {
            int LicenseID = -1, ApplicationID;
            ApplicationID = clsLocalDLA.GetLocalDLAppByLocalDLAppID(LDLAppID)?.ApplicationID ?? -1;
            LicenseID = clsLicense.GetLicenseByApplicationID(ApplicationID)?.LicenseID ?? -1;


            using (ShowLicenseInfo frmLicenseInfo = new ShowLicenseInfo(LicenseID))
            {
                //it only show the form when the form exist and not disposed due to not finding license
                if (!frmLicenseInfo.IsDisposed)
                {
                    frmLicenseInfo.ShowDialog();
                }
            }
        }


        private void ShowLicenseHistory(string NationalNo)
        {
            using(LicenseHistory frmLicenseHistory = new LicenseHistory(NationalNo))
            {
                frmLicenseHistory.ShowDialog();
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
                        dgvLocalDLA.DataSource = clsLocalDLA.getLocalDLA_ByStatus((byte)clsApplication.Status.New);
                        break;
                    }
                case "Canceled":
                    {
                        dgvLocalDLA.DataSource = clsLocalDLA.getLocalDLA_ByStatus((byte)clsApplication.Status.Canceled);

                        break;
                    }
                case "Completed":
                    {
                        dgvLocalDLA.DataSource = clsLocalDLA.getLocalDLA_ByStatus((byte)clsApplication.Status.Compledted);

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

        private void scheduleTestsToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            int LDLAppID = -1;
            LDLAppID = Convert.ToInt32(dgvLocalDLA.SelectedRows[0].Cells["L.D.L.AppID"].Value);


            if (dgvLocalDLA.SelectedRows.Count == 1)
            {
                switch (e.ClickedItem.Text)
                {
                    case "Schedule Vison Test":
                        {
                            using (TestAppointments frmVisionTestAppointments = new TestAppointments(LDLAppID,clsTestAppointments.TestType.VisionTest))
                            {
                                frmVisionTestAppointments.ShowDialog();
                            }
                        break;
                        }
                    case "Schedule Written Test":
                        {
                            using (TestAppointments frmWrittenTestAppointments = new TestAppointments(LDLAppID, clsTestAppointments.TestType.WrittenTest))
                            {
                                frmWrittenTestAppointments.ShowDialog();
                            }
                            break;
                        }
                    case "Schedule Practical Test":
                        {
                            using (TestAppointments frmPracticalTestAppointments = new TestAppointments(LDLAppID, clsTestAppointments.TestType.PracticalTest))
                            {
                                frmPracticalTestAppointments.ShowDialog();
                            }
                            break;
                        }
                }

                //update changes
                LoadTheDataGridView();


            }
        }
    }

}
