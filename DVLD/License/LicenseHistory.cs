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

namespace DVLD.License
{
    public partial class LicenseHistory : Form
    {
        public LicenseHistory(int PersonID = -1)
        {
            InitializeComponent();


                uctrlFilterBy1.OnFilterSucceded += GettingPersonIDWhenFilterSucceded;
            
            if (PersonID != -1)
            {
                uctrlFilterBy1.Enabled = false;

                //set uctrl PersonDetails
                uctrlFilterBy1.FindPersonByPersonID(PersonID);

            }

        }

        public LicenseHistory(string NationalNo = "")
        {
            InitializeComponent();

            uctrlFilterBy1.OnFilterSucceded += GettingPersonIDWhenFilterSucceded;


            if (!string.IsNullOrEmpty(NationalNo))
            {
                uctrlFilterBy1.Enabled = false;

                //set uctrl PersonDetails
                uctrlFilterBy1.FindPersonByNationalNo(NationalNo);
            }

        }
        private void LoadDataGrids()
        {
            LoadLocalDataGridView();
            LoadInternationalDataGridView();
        }

        private void GettingPersonIDWhenFilterSucceded(int PersonID)
        {
            uctrPersonDetails1.PersonID = PersonID;
            uctrPersonDetails1.UpdateControl();
            LoadDataGrids();
        }

        private void LoadLocalDataGridView()
        {
            DataTable dt = clsLicense.GetLocalLicenseHistoryByPersonID(uctrPersonDetails1.PersonID);
            dgvLocalLicensesHistory.DataSource = dt;
            //#Records Rows
            lblRecordsLocal.Text = "#Records" + ' ' + (dgvLocalLicensesHistory.RowCount).ToString();
        }

        private void LoadInternationalDataGridView()
        {
            DataTable dt = clsInternationalLicense.GetInternationalLicenseHistoryByPersonID(uctrPersonDetails1.PersonID);
            dgvInternationalLicensesHistory.DataSource = dt;
            //#Records Rows
            lblRecordsInternational.Text = "#Records" + ' ' + (dgvInternationalLicensesHistory.RowCount).ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
