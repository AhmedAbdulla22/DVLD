﻿using System;
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
            using (frmAddPerson frm = new frmAddPerson(1039))
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
            if (dgvPeople.SelectedRows.Count == 1)
            {
                switch(e.ClickedItem.Text)
                {
                    case "Edit":
                        {
                            int personID = -1;
                            personID = Convert.ToInt32(dgvPeople.SelectedRows[0].Cells[0].Value);
                            if (personID >= 0)
                            {
                                frmAddPerson frmAddPerson = new frmAddPerson(personID);
                                frmAddPerson.ShowDialog();
                            }
                            break;
                        }
                    case "Show Details":
                        {
                            Person_Details frmPersonDetails = new Person_Details();
                            break;
                        }

                }

                
            }
        }
    }
}
