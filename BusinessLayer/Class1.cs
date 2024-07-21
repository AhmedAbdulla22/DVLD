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
    }

    public static class CountryBusinessLayer
    {
        public static List<string> GetAllCountries()
        {
            return CountryDataAccessLayer.GetCountryList();
        }
    }
}
