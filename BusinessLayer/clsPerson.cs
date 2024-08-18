using System;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
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

        public clsPerson(int PersonID,string FirstName,string SecondName,string ThirdName,string LastName,string NationalNo,short Gender,DateTime DateOfBirth, int CountryID, string Phone,string Email,string Address,string ImagePath)
        {
            this.PersonID = PersonID;
            this.FirstName = FirstName;
            this.SecondName = SecondName;
            this.ThirdName = ThirdName;
            this.LastName = LastName;
            this.NationalNo = NationalNo;
            this.Gender = Gender;
            this.DateOfBirth = DateOfBirth;
            this.Phone = Phone;
            this.Email = Email;
            this.Address = Address;
            this.ImagePath = ImagePath; 
            this.CountryID = CountryID;
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

        public bool Delete()
        {
            return ClsPersonDataAccess.DeletePerson(this.PersonID);
        }

        public static bool Delete(int PersonID)
        {
            return ClsPersonDataAccess.DeletePerson(PersonID);
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

        public static DataTable getPeopleByPersonID(int PersonID = -1) 
        {
            return ClsPersonDataAccess.GetPersonByPersonID(PersonID);
        }

        public static DataTable getPeopleByNationalNo(string NationalNo)
        {
            return ClsPersonDataAccess.GetPersonByNationalNo(NationalNo);
        }

        public static DataTable getPeopleByFirstName(string FirstName)
        {
            return ClsPersonDataAccess.GetPersonByFirstName(FirstName);
        }

        public static DataTable getPeopleBySecondName(string SecondName)
        {
            return ClsPersonDataAccess.GetPersonBySecondName(SecondName);
        }

        public static DataTable getPeopleByThirdName(string ThirdName)
        {
            return ClsPersonDataAccess.GetPersonByThirdName(ThirdName);
        }
        public static DataTable getPeopleByLastName(string LastName)
        {
            return ClsPersonDataAccess.GetPersonByLastName(LastName);
        }
        public static DataTable getPeopleByPhone(string Phone)
        {
            return ClsPersonDataAccess.GetPersonByPhone(Phone);
        }
        public static DataTable getPeopleByNationality(string Nationality)
        {
            return ClsPersonDataAccess.GetPersonByNationality(Nationality);
        }
        public static DataTable getPeopleByEmail(string Email)
        {
            return ClsPersonDataAccess.GetPersonByEmail(Email);
        }
        public static DataTable getPeopleByGender(string Gender)
        {
            return ClsPersonDataAccess.GetPersonByGender(Gender);
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
                return new clsPerson(PersonID,firstName,secondName,thirdName,lastName,nationalNo,gender,dateOfBirth,countryID,Phone,email,address,imagePath);
            }
            else
            {
                return null;
            }
        }

        public static clsPerson Find(string NationalNo)
        {
            string firstName = "", secondName = "", thirdName = "", lastName = "", address = "", imagePath = "", email = "", nationalNo = "", Phone = "";
            DateTime dateOfBirth = DateTime.UtcNow;
            int countryID = -1,PersonID = -1;
            short gender = -1;

            //if 
            //get person by id 
            if (ClsPersonDataAccess.GetPersonInfoByNationalNo(ref PersonID, ref firstName, ref secondName, ref thirdName, ref lastName, NationalNo, ref dateOfBirth, ref gender, ref Phone, ref email, ref countryID, ref address, ref imagePath))
            {
                return new clsPerson(PersonID, firstName, secondName, thirdName, lastName, nationalNo, gender, dateOfBirth, countryID, Phone, email, address, imagePath);
            }
            else
            {
                return null;
            }
        }


    }
}
