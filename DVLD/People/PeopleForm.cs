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

            cbFilter.SelectedIndex = 0;
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
                                    //refresh dgvPeople
                                    LoadTheDataGridView();
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
                frm.FormClosed += this.frmPeople_Load;

                frm.ShowDialog();
            }
            
        }

        private void EditPerson(int PersonID)
        {
            using (frmAddPerson frmEdit = new frmAddPerson(PersonID))
            {
                frmEdit.FormClosing += this.frmPeople_Load;

                frmEdit.ShowDialog();
                
                
                
            }
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //To Show Filter Box



            if (cbFilter.SelectedItem.ToString() == "None")
            {
            tbFilter.Visible = false;
            LoadTheDataGridView();
            }
            else
            {
                tbFilter.Visible = true;
            }
        }

        private void tbFilter_KeyDown(object sender, KeyEventArgs e)
        {
            switch(cbFilter.SelectedItem.ToString())
            {
                case "PersonID":
                case "Phone":
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
                case "FirstName":
                case "SecondName":
                case "ThirdName":
                case "LastName":
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
                case "PersonID":
                    {
                        if (int.TryParse(tbFilter.Text, out int value))
                        {
                            dgvPeople.DataSource = clsPerson.getPeopleByPersonID(value);
                        }
                        break;
                    }
                case "National No.":
                    {
                        dgvPeople.DataSource = clsPerson.getPeopleByNationalNo(tbFilter.Text);
                        break;
                    }
                case "FirstName":
                    {
                        dgvPeople.DataSource = clsPerson.getPeopleByFirstName(tbFilter.Text);
                        break;
                    }
                case "SecondName":
                    {
                        dgvPeople.DataSource = clsPerson.getPeopleBySecondName(tbFilter.Text);

                        break;
                    }
                case "ThirdName":
                    {
                        dgvPeople.DataSource = clsPerson.getPeopleByThirdName(tbFilter.Text);

                        break;
                    }
                case "LastName":
                    {
                        dgvPeople.DataSource = clsPerson.getPeopleByLastName(tbFilter.Text);

                        break;
                    }
                case "Nationality":
                    {
                        dgvPeople.DataSource = clsPerson.getPeopleByNationality(tbFilter.Text);

                        break;
                    }
                case "Gender":
                    {
                        dgvPeople.DataSource = clsPerson.getPeopleByGender(tbFilter.Text);

                        break;
                    }
                case "Phone":
                    {
                        dgvPeople.DataSource = clsPerson.getPeopleByPhone(tbFilter.Text);

                        break;
                    }
                case "Email":
                    {
                        dgvPeople.DataSource = clsPerson.getPeopleByEmail(tbFilter.Text);

                        break;
                    }
            }
        }
    }
}
