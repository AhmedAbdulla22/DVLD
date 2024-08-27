using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class clsLocalDLA
    {

        public static DataTable getAllLocalDLA()
        {

            return clsLocalDLA_DataAccess.getAllLocalDLA();
        }

        public static DataTable getLocalDLA_ByStatus(byte ApplicationStatus)
        {
            return clsLocalDLA_DataAccess.GetLDLA_ByStatus(ApplicationStatus);
        }

        public static DataTable getLocalDLA_ByLDLAppID(int LDLAppID)
        {
            return clsLocalDLA_DataAccess.GetLDLA_ByLDLAppID(LDLAppID);
        }
        public static DataTable getLocalDLA_ByNationalNo(int NationalNo)
        {
            return clsLocalDLA_DataAccess.GetLDLA_ByNationalNo(NationalNo);
        }
        public static DataTable getLocalDLA_ByFullName(string FullName)
        {
            return clsLocalDLA_DataAccess.GetLDLA_ByFullName(FullName);
        }
    }
}
