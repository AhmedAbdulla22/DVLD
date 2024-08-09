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

            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            AddNewPerson();
        }

        private void LoadTheDataGridView()
        {
            DataTable dt = clsPerson.getAllPeople();
            dgvPeople.DataSource = dt;
            //#Records Rows
            lblRecords.Text = "#Records" + ' ' + (dgvPeople.RowCount).ToString();
        }

        private void dgvPeople_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                //row that you clicked on location
                var hitTestInfo = dgvPeople.HitTest(e.X, e.Y);

                if (hitTestInfo.RowIndex >= 0)
                {
                    dgvPeople.ClearSelection();
                    dgvPeople.Rows[hitTestInfo.RowIndex].Selected = true;

                    contextMenuStrip1.Show(dgvPeople,new Point(e.X,e.Y));
                }
            }
        }

        

        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            int personID = -1;
            personID = Convert.ToInt32(dgvPeople.SelectedRows[0].Cells[0].Value);

            if (dgvPeople.SelectedRows.Count == 1)
            {
                switch(e.ClickedItem.Text)
                {
                    case "Edit":
                        {
                            
                            if (personID >= 0)
                            {
                                EditPerson(personID);
                            }
                            break;
                        }
                    case "Show Details":
                        {
                            using (Person_Details frmDetails = new Person_Details(personID))
                            {
                                frmDetails.ShowDialog();
                            }
                            break;
                        }
                    case "Delete":
                        {
                            if (MessageBox.Show("Are You Sure You Want to Delete this Person?","",MessageBoxButtons.YesNo,MessageBoxIcon.Warning) == DialogResult.Yes)
                            {
                                if (clsPerson.Delete(personID))
                                {
                                    MessageBox.Show("Person Deleted Succesfully", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    MessageBox.Show("Person Cannot Be Deleted", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }

                            }

                            break;
                        }
                    case "Add New Person":
                        {
                            AddNewPerson();
                            break;
                        }
                    default:
                        MessageBox.Show("Still in Work", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        break;
                }


            }
        }

        private void AddNewPerson()
        {
            using (frmAddPerson frm = new frmAddPerson())
            {
                frm.ShowDialog();
            }
            
        }

        private void EditPerson(int PersonID)
        {
            using (frmAddPerson frmEdit = new frmAddPerson(PersonID))
            {
                frmEdit.ShowDialog();
            }
        }

        private void frmPeople_Activated(object sender, EventArgs e)
        {

            LoadTheDataGridView();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //To Show Filter Box
            tbFilter.Visible = (comboBox1.SelectedItem.ToString() != "None");

            //switch (comboBox1.SelectedItem.ToString())
            //{
            //    case "PersonID":
            //        {
            //            dgvPeople.DataSource = clsPerson.getPeopleByPersonID(1);
            //            break;
            //        }
            //    case "National No.":
            //        {
            //            dgvPeople.DataSource = clsPerson.getPeopleByNationalNo("n");

            //            break;
            //        }
            //    case "FirstName":
            //        {

            //            break;
            //        }
            //    case "SecondName":
            //        {

            //            break;
            //        }
            //    case "ThirdName":
            //        {

            //            break;
            //        }
            //    case "LastName":
            //        {

            //            break;
            //        }
            //    case "Nationality":
            //        {

            //            break;
            //        }
            //    case "Gender":
            //        {

            //            break;
            //        }
            //    case "Phone":
            //        {

            //            break;
            //        }
            //    case "Email":
            //        {

            //            break;
            //        }
            //}
        }
    }
}
