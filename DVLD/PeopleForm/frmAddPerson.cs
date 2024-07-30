using BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
        clsPerson _Person;

        public frmAddPerson(int PersonID = -1)
        {
            InitializeComponent();

            if((_PersonID = PersonID) == -1)
            {
                _Person = new clsPerson();
                _ctrlMode = ctrlMode.Add;
            }
            else
            {
                _Person = new clsPerson();
                _ctrlMode = ctrlMode.Update;
            }

            //resize btnClose icon 
            btnClose.Image = Utilites.ResizeImage(btnClose.Image, 20, 20);

            

        }

        private void frmAddPerson_Load(object sender, EventArgs e)
        {

            LoadForm();

            

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

            if (_ctrlMode == ctrlMode.Update)
            {
                
            }
            else
            {
                var newGuid = Guid.NewGuid().ToString();
                var newLocation = @"C:\DVLD IMAGES\" + newGuid + ".png";
                uctrlAddPerson1.pbPath = newLocation;

                if ((_PersonID = clsPerson.SavePerson(uctrlAddPerson1.FirstName, uctrlAddPerson1.SecondName, uctrlAddPerson1.ThirdName, uctrlAddPerson1.LastName, uctrlAddPerson1.NationalNo, uctrlAddPerson1.DateOfBirth, uctrlAddPerson1.GenderID, uctrlAddPerson1.Phone, uctrlAddPerson1.Email, uctrlAddPerson1.CountryID, uctrlAddPerson1.Address, uctrlAddPerson1.pbPath)) != -1)
                {
                    if (uctrlAddPerson1.pbPath != null)
                    {
                        
                        //copy the image for DVLV FOLDER
                        if (Directory.Exists(@"C:\DVLD IMAGES\"))
                        {
                            File.Copy(uctrlAddPerson1.pbPath, newLocation, overwrite: true);

                        }
                        else
                        {
                            Directory.CreateDirectory(@"C:\DVLD IMAGES\");
                            File.Copy(uctrlAddPerson1.pbPath, newLocation, overwrite: true);
                        }

                    }

                    _ctrlMode = ctrlMode.Update;
                }
                else
                {
                    
                }
            }


            LoadForm();
        }

        private void LoadForm()
        {
            if (_ctrlMode == ctrlMode.Add)
            {
                lblFormLabel.Text = "Add New Person";
            }
            else
            {
                lblFormLabel.Text = "Update Person";
                lblPersonID2.Text = _PersonID.ToString();
            }
        }
    }
}
