using System;
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
        clsPerson()
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

        clsPerson(int CountryID,string FirstName,string SecondName,string ThirdName,string LastName,short Gender,DateTime DateOfBirth,string Phone,string Email,string Address,string ImagePath)
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
            this.PersonID = DataAccessPeopleLayer.AddNewPerson(this.FirstName, this.SecondName, this.ThirdName, this.LastName, this.NationalNo, this.DateOfBirth, this.Gender, this.Phone, this.Email, this.CountryID, this.Address, this.ImagePath);

            return (this.PersonID != -1);
        }

        private bool _Update()
        {
            //Update Person
            //this.PersonID = DataAccessPeopleLayer.AddNewPerson(this.FirstName, this.SecondName, this.ThirdName, this.LastName, this.NationalNo, this.DateOfBirth, this.Gender, this.Phone, this.Email, this.CountryID, this.Address, this.ImagePath);


            return (this.PersonID != -1);
        }


        public bool Save()
        {
            switch(mode)
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

            return DataAccessPeopleLayer.getAllPeople();
        }

        public static bool isNationalNumberExist(string nationalNumber) 
        {
            return DataAccessPeopleLayer.isNationalNumberExist(nationalNumber);
        }

    }
}
