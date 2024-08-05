﻿using BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.PeopleForm
{
    public partial class frmAddPerson : Form
    {
        enum ctrlMode { Add = 1, Update = 2 };
        ctrlMode _ctrlMode = ctrlMode.Add;
        
        public frmAddPerson(int PersonID = -1)
        {
            InitializeComponent();

            uctrlAddPerson1.PersonID = PersonID;

            if(PersonID == -1)
            {
                _ctrlMode = ctrlMode.Add;
            }
            else
            {
                _ctrlMode = ctrlMode.Update;
            }

            
            

        }

        private void frmAddPerson_Load(object sender, EventArgs e)
        {
            UpdateForm();
        }

        private void UpdateForm()
        {
            if (_ctrlMode == ctrlMode.Add)
            {
                lblFormLabel.Text = "Add New Person";
            }
            else
            {
                lblFormLabel.Text = "Update Person";
            }
        }

        
        private void uctrlAddPerson1_Load(object sender, EventArgs e)
        {
           

        }

        

        

        

    }
}
