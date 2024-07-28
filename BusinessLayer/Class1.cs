using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace BusinessLayer
{
    public static class PeopleBusinessLayer
    {
        public static DataTable getAllPeople()
        {

            return DataAccessPeopleLayer.getAllPeople();
        }

        public static bool isNationalNumberExist(string nationalNumber) 
        {
            return DataAccessPeopleLayer.isNationalNumberExist(nationalNumber);
        }

        public static int SavePerson(string fname,string Sname,string Tname,string Lname,string NationalNo,DateTime DateOfBirth,short gender,string Phone,string Email,int CountryID, string Address,string ImagePath)
        {
            
            //save & send arguments
            return DataAccessPeopleLayer.SavePerson(ref fname,ref Sname,ref Tname,ref Lname,ref NationalNo,ref DateOfBirth,ref gender,ref Phone,ref Email,ref CountryID, ref Address,ref ImagePath);
        }
    }

    public static class CountryBusinessLayer
    {
        public static Dictionary<string, int> GetAllCountries()
        {
            return CountryDataAccessLayer.GetCountryList();
        }
    }
}
