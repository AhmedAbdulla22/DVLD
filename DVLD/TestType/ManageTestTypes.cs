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

namespace DVLD.TestType
{
    public partial class ManageTestTypes : Form
    {
        public ManageTestTypes()
        {
            InitializeComponent();
        }

        private void LoadTheDataGridView()
        {
            DataTable dt = clsTestType.getAllTestTypes();
            dgvTestType.DataSource = dt;
            //#Records Rows
            lblRecords.Text = "#Records" + ' ' + (dgvTestType.RowCount).ToString();


        }

        private void ManageTestType_Load(object sender, EventArgs e)
        {
            LoadTheDataGridView();
        }



        private void dgvTestType_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                //row that you clicked on location
                var hitTestInfo = dgvTestType.HitTest(e.X, e.Y);

                if (hitTestInfo.RowIndex >= 0)
                {
                    dgvTestType.ClearSelection();
                    dgvTestType.Rows[hitTestInfo.RowIndex].Selected = true;

                    contextMenuStrip1.Show(dgvTestType, new Point(e.X, e.Y));
                }
            }
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(dgvTestType.SelectedRows[0].Cells[0].Value);

            using (UpdateTestType frmUpdate = new UpdateTestType(ID))
            {
                frmUpdate.ShowDialog();
                LoadTheDataGridView();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
