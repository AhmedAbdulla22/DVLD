using BusinessLayer;
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
                //Fill Boxes
                GetOrFillBoxes(true);
                

            }

            //resize btnClose icon 
            btnClose.Image = Utilites.ResizeImage(btnClose.Image, 20, 20);

            

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
                lblPersonID2.Text = _Person.PersonID.ToString();
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

        private void CopyImage(string OriginalLocation, string SaveLocation)
        {
            if (!string.IsNullOrEmpty(OriginalLocation))
            {

                //copy the image for DVLV FOLDER
                if (!Directory.Exists(imageDirPath))
                {
                    Directory.CreateDirectory(imageDirPath);
                }
                else
                {
                    if (_ctrlMode == ctrlMode.Update && !string.IsNullOrEmpty(OldImagePath) && OldImagePath.Contains(imageDirPath))
                    {
                        //if updated picture remove old one that in that dir
                            File.Delete(OldImagePath);
                    }

                    File.Copy(OriginalLocation, SaveLocation, overwrite: true);

                }

            }
            else if(!string.IsNullOrEmpty(OldImagePath))
            {
                //if removed the picture from pictureBox then delete it in the path too
                File.Delete(OldImagePath);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //if (!uctrlAddPerson1.isEveryRequiredFieldFilled())
            //{
            //    return;
            //}


            ////getting new Location for the imagePath
            ////string OldLocation = uctrlAddPerson1.pbPath;
            //var newGuid = string.Empty;
            //var NewLocation = string.Empty;
            //var OriginalLocation = string.Empty;

            //if (!string.IsNullOrEmpty(uctrlAddPerson1.pbPath))
            //{
            //newGuid = Guid.NewGuid().ToString();
            //NewLocation = imageDirPath + newGuid + ".png";
            //OriginalLocation = uctrlAddPerson1.pbPath;
            //uctrlAddPerson1.pbPath = NewLocation;    
            //}
                
            ////get Informations ToThe Person
            //    GetOrFillBoxes(false);


            
                


            //    if (_Person.Save())
            //    {
            //        CopyImage(OriginalLocation,NewLocation);

            //        if (_ctrlMode == ctrlMode.Add)
            //        {
            //            _ctrlMode = ctrlMode.Update;
            //        }

            //        //update old image path
            //        OldImagePath = NewLocation;

            //    MessageBox.Show("Person Saved Succesfully.");
            //    }
            //    else
            //    {
            //    MessageBox.Show("Failed To Save Person Information!");  
            //    }
            


            //UpdateForm();
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
                uctrlAddPerson1.NationalNo = _Person.NationalNo;
                uctrlAddPerson1.Address = _Person.Address;
                uctrlAddPerson1.Email = _Person.Email;
                uctrlAddPerson1.CountryID =_Person.CountryID;
                //fill both pictureBox and oldImagePath
                uctrlAddPerson1.pbPath = OldImagePath =  _Person.ImagePath;

                
            }
            else
            {
                
            }
        }

    }
}
