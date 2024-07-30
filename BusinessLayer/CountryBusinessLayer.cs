using System.Collections.Generic;
using DataAccessLayer;

namespace BusinessLayer
{
    public static class CountryBusinessLayer
    {
        public static Dictionary<string, int> GetAllCountries()
        {
            return CountryDataAccessLayer.GetCountryList();
        }
    }
}
