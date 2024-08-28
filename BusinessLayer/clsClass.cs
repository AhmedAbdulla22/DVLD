using DataAccessLayer;
using System.Collections.Generic;

namespace BusinessLayer
{
    public class clsClass
    {
        public static Dictionary<string, int> GetAllClasses()
        {
            return clsClassDataAccess.GetClassList();
        }
        public static Dictionary<int, decimal> GetAllClassFees()
        {
            return clsClassDataAccess.GetClassFees();
        }
    }
}
