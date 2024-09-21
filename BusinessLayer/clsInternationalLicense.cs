using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class clsInternationalLicense
    {
        public static DataTable GetInternationalLicenseHistoryByPersonID(int PersonID)
        {
            return clsInternationalLicense_DataAccess.GetInternationalLicenseHistoryByPersonID(PersonID);
        }
    }
}
