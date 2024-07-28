using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.PeopleForm
{
    public partial class frmAddPerson : Form
    {
        int _PersonID = -1;
        enum ctrlMode { Add = 1, Update = 2 };
        ctrlMode _ctrlMode = ctrlMode.Add;

        public frmAddPerson(int PersonID = -1)
        {
            InitializeComponent();

            if((_PersonID = PersonID) == -1)
            {
                _ctrlMode = ctrlMode.Add;
            }
            else
            {
                _ctrlMode = ctrlMode.Update;
            }

            //resize btnClose icon 
            btnClose.Image = Utilites.ResizeImage(btnClose.Image, 20, 20);

            

        }

        private void frmAddPerson_Load(object sender, EventArgs e)
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void uctrlAddPerson1_Load(object sender, EventArgs e)
        {
            //set focus to btn
            btnClose.Focus();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!uctrlAddPerson1.isEveryRequiredFieldFilled())
            {
                return;
            }
            else
            {
                save   
            }

        }
    }
}
