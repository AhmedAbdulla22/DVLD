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

namespace DVLD
{
    public partial class ManageApplicationType : Form
    {
        public ManageApplicationType()
        {
            InitializeComponent();
        }

        private void LoadTheDataGridView()
        {
            DataTable dt = clsApplicationType.getAllApplicationTypes();
            dgvApplicationType.DataSource = dt;
            //#Records Rows
            lblRecords.Text = "#Records" + ' ' + (dgvApplicationType.RowCount).ToString();


        }

        private void ManageApplicationType_Load(object sender, EventArgs e)
        {
            LoadTheDataGridView();
        }
    }

    
}
