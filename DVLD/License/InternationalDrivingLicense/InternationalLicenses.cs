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

namespace DVLD.License.InternationalDrivingLicense
{
    public partial class InternationalLicenses : Form
    {
        public InternationalLicenses()
        {
            InitializeComponent();
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
    }
}
