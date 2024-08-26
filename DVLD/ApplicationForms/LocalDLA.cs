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


        private void LocalDLA_Load(object sender, EventArgs e)
        {
            LoadTheDataGridView();
        }
    }
}
