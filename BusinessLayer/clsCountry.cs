using System.Collections.Generic;
using DataAccessLayer;

namespace BusinessLayer
{
    public static class clsCountry
    {
        public static Dictionary<string, int> GetAllCountries()
        {
            return ClsCountryDataAccess.GetCountryList();
        }
    }
}
