﻿using System;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace BusinessLayer
{
    public class clsPerson
    {
        
            public int PersonID { get; set; }
            public int CountryID { get; set; }
            public string FirstName{ get; set; }
            public string SecondName{ get; set; }
            public string ThirdName{ get; set; }
            public string LastName{ get; set; }
            public string NationalNo{ get; set; }
            public short Gender{ get; set; }
            public DateTime DateOfBirth{ get; set; }
            public string Phone{ get; set; }
            public string Email{ get; set; }
            public string Address{ get; set; }
            public string ImagePath{ get; set; }

            public enum mode { Add , Update};
        mode enMode;    

        //constructors
        public clsPerson()
        {
            PersonID = -1;
            FirstName = "";
            SecondName = "";
            ThirdName = "";
            LastName = "";
            Gender = -1;
            DateOfBirth = DateTime.Now;
            Phone = "";
            Email = "";
            Address = "";
            ImagePath = "";

            enMode = mode.Add;
        }

        public clsPerson(int CountryID,string FirstName,string SecondName,string ThirdName,string LastName,short Gender,DateTime DateOfBirth,string Phone,string Email,string Address,string ImagePath)
        {
            this.PersonID = PersonID;
            this.FirstName = FirstName;
            this.SecondName = SecondName;
            this.ThirdName = ThirdName;
            this.LastName = LastName;
            this.Gender = Gender;
            this.DateOfBirth = DateOfBirth;
            this.Phone = Phone;
            this.Email = Email;
            this.Address = Address;
            this.ImagePath = ImagePath; 

            enMode = mode.Update;
        }

        private bool _AddNewPerson()
        {
            this.PersonID = ClsPersonDataAccess.AddNewPerson(this.FirstName, this.SecondName, this.ThirdName, this.LastName, this.NationalNo, this.DateOfBirth, this.Gender, this.Phone, this.Email, this.CountryID, this.Address, this.ImagePath);

            return (this.PersonID != -1);
        }

        private bool _Update()
        {
            //Update Person

            return ClsPersonDataAccess.UpdatePerson(this.PersonID,this.FirstName, this.SecondName, this.ThirdName, this.LastName, this.NationalNo, this.DateOfBirth, this.Gender, this.Phone, this.Email, this.CountryID, this.Address, this.ImagePath);
        }


        public bool Save()
        {
            switch(enMode)
            {
                case mode.Update:
                    {
                        return _Update();
                        
                    }
                case mode.Add:
                    {
                        if(_AddNewPerson())
                        {
                            enMode = mode.Update;
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                        
                    }
            }
            return false;
        }


        public static DataTable getAllPeople()
        {

            return ClsPersonDataAccess.getAllPeople();
        }

        public static bool isNationalNumberExist(string nationalNumber) 
        {
            return ClsPersonDataAccess.isNationalNumberExist(nationalNumber);
        }

        public static clsPerson Find(int PersonID)
        {
            string firstName = "", secondName = "", thirdName= "", lastName= "", address= "", imagePath= "", email= "", nationalNo= "", Phone = "";
            DateTime dateOfBirth = DateTime.UtcNow;
            int countryID = -1;
            short gender = -1;

            //if 
            //get person by id 
            if (ClsPersonDataAccess.GetPersonInfoByID(PersonID,ref firstName,ref secondName,ref thirdName,ref lastName,ref nationalNo,ref dateOfBirth,ref gender,ref Phone,ref email,ref countryID,ref address,ref imagePath))
            {
                return new clsPerson(PersonID,firstName,secondName,thirdName,lastName,gender,dateOfBirth,Phone,email,address,imagePath);
            }
            else
            {
                return null;
            }
        }

        
    }
}