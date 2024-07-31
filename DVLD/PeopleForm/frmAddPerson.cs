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
        enum ctrlMode { Add = 1, Update = 2 };
        ctrlMode _ctrlMode = ctrlMode.Add;
        clsPerson _Person;

        public frmAddPerson(int PersonID = -1)
        {
            InitializeComponent();

            if(PersonID == -1)
            {
                _Person = new clsPerson();
                _ctrlMode = ctrlMode.Add;
            }
            else
            {
                _Person = clsPerson.Find(PersonID);
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

        private void CopyImage(string OriginalLocation, string NewLocation)
        {
            if (OriginalLocation != null)
            {

                //copy the image for DVLV FOLDER
                if (Directory.Exists(@"C:\DVLD IMAGES\"))
                {
                    File.Copy(OriginalLocation, NewLocation, overwrite: true);

                }
                else
                {
                    Directory.CreateDirectory(@"C:\DVLD IMAGES\");
                    File.Copy(OriginalLocation, NewLocation, overwrite: true);
                }

            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!uctrlAddPerson1.isEveryRequiredFieldFilled())
            {
                return;
            }


            //getting new Location for the imagePath
            var newGuid = Guid.NewGuid().ToString();
            var NewLocation = @"C:\DVLD IMAGES\" + newGuid + ".png";
            var OriginalLocation = uctrlAddPerson1.pbPath;
            uctrlAddPerson1.pbPath = NewLocation;
                
            //getLocationsToThe Person
                GetOrFillBoxes(false);


            
                


                if (_Person.Save())
                {
                    CopyImage(OriginalLocation,NewLocation);

                    if (_ctrlMode == ctrlMode.Add)
                    {
                        _ctrlMode = ctrlMode.Update;
                    }
                }
                else
                {
                MessageBox.Show("Failed To Save Person Information!");  
                }
            


            LoadForm();
        }

        private void GetOrFillBoxes(bool fillBoxes)
            {
            
            
            if (fillBoxes)
            {
                uctrlAddPerson1.FirstName = _Person.FirstName;
                uctrlAddPerson1.SecondName =  _Person.SecondName;
                uctrlAddPerson1.ThirdName =_Person.ThirdName;
                uctrlAddPerson1.LastName = _Person.LastName;
                uctrlAddPerson1.GenderID = _Person.Gender;
                uctrlAddPerson1.Phone =_Person.Phone;
                uctrlAddPerson1.DateOfBirth =  _Person.DateOfBirth;
                uctrlAddPerson1.pbPath = _Person.ImagePath;
                uctrlAddPerson1.NationalNo = _Person.NationalNo;
                uctrlAddPerson1.Address = _Person.Address;
                uctrlAddPerson1.Email = _Person.Email;
                uctrlAddPerson1.CountryID =_Person.CountryID;
            }
            else
            {
                //getting boxValues to Person
                _Person.FirstName = uctrlAddPerson1.FirstName;
                _Person.SecondName = uctrlAddPerson1.SecondName;
                _Person.ThirdName = uctrlAddPerson1.ThirdName;
                _Person.LastName = uctrlAddPerson1.LastName;
                _Person.Gender = uctrlAddPerson1.GenderID;
                _Person.Phone = uctrlAddPerson1.Phone;
                _Person.DateOfBirth = uctrlAddPerson1.DateOfBirth;
                _Person.ImagePath = uctrlAddPerson1.pbPath;
                _Person.NationalNo = uctrlAddPerson1.NationalNo;
                _Person.Address = uctrlAddPerson1.Address;
                _Person.Email = uctrlAddPerson1.Email;
                _Person.CountryID = uctrlAddPerson1.CountryID;
            }
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
                lblPersonID2.Text = _Person.PersonID.ToString();

                GetOrFillBoxes(true);

            }
        }
    }
}
