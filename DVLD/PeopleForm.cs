using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer;

namespace DVLD
{
    public partial class frmPeople : Form
    {
        public frmPeople()
        {
            InitializeComponent();



            button2.Image = Utilites.ResizeImage(Properties.Resources.Close, 20, 20);

            DataTable dt = PeopleBusinessLayer.getAllPeople();
            dgvPeople.DataSource = dt;
        }

        private void frmPeople_Load(object sender, EventArgs e)
        {
            //#Records Rows
            lblRecords.Text += ' ' + (dgvPeople.RowCount).ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
