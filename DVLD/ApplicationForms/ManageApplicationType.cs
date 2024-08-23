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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvApplicationType_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                //row that you clicked on location
                var hitTestInfo = dgvApplicationType.HitTest(e.X, e.Y);

                if (hitTestInfo.RowIndex >= 0)
                {
                    dgvApplicationType.ClearSelection();
                    dgvApplicationType.Rows[hitTestInfo.RowIndex].Selected = true;

                    contextMenuStrip1.Show(dgvApplicationType, new Point(e.X, e.Y));
                }
            }
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {

            int ID = Convert.ToInt32(dgvApplicationType.SelectedRows[0].Cells[0].Value);

            using(UpdatApplicationType frmUpdate = new UpdatApplicationType(ID))
            {
                frmUpdate.ShowDialog();
                LoadTheDataGridView();
            }

        }
    }

    
}
