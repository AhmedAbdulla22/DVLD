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
using DVLD.PeopleForm;

namespace DVLD
{
    public partial class frmPeople : Form
    {

        public frmPeople()
        {
            InitializeComponent();



            button2.Image = Utilites.ResizeImage(Properties.Resources.Close, 20, 20);
        }

        private void frmPeople_Load(object sender, EventArgs e)
        {

            LoadTheDataGridView();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            using (frmAddPerson frm = new frmAddPerson())
            {
                frm.ShowDialog() ;
                
                LoadTheDataGridView();
                

            }
        }

        private void LoadTheDataGridView()
        {
            DataTable dt = clsPerson.getAllPeople();
            dgvPeople.DataSource = dt;
            //#Records Rows
            lblRecords.Text = "#Records" + ' ' + (dgvPeople.RowCount).ToString();
        }
    }
}
