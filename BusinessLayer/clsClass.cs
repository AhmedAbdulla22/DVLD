using DataAccessLayer;
using System;
using System.Collections.Generic;

namespace BusinessLayer
{
    public class clsClass
    {
        public int LicenseClassID { get; set; }
      public string className { get; set; }
      public string ClassDescription {get;set;}
      public byte MinimumAllowedAge {get;set;}
      public byte DefaultValidityLength {get;set;}
      public decimal ClassFees {get;set;}

        public clsClass()
        {
            LicenseClassID = -1;
            className = ClassDescription = string.Empty;
            MinimumAllowedAge = DefaultValidityLength = 0;
            ClassFees = 0;
        }

        public clsClass(int LicenseClassID, string className, string ClassDescription, byte MinimumAllowedAge, byte DefaultValidityLength, decimal ClassFees)
        {
            this.LicenseClassID = LicenseClassID;
            this.className = className;
            this.ClassDescription = ClassDescription;
            this.DefaultValidityLength = DefaultValidityLength;
            this.ClassFees = ClassFees;
            this.MinimumAllowedAge = MinimumAllowedAge;
        }




        public static clsClass GetClassByClassID(int LicenseClassID)
        {
            string className = string.Empty,ClassDescription = string.Empty;
            byte MinimumAllowedAge = 0 , DefaultValidityLength = 0;
            decimal ClassFees = 0;



            if (clsClassDataAccess.GetLicenseClassByLicenseClassID(LicenseClassID, ref className, ref ClassDescription, ref MinimumAllowedAge, ref DefaultValidityLength, ref ClassFees))
            {
                return new clsClass(LicenseClassID, className, ClassDescription, MinimumAllowedAge,DefaultValidityLength,ClassFees);
            }
            else
            {
                return null;
            }
        }

        public static Dictionary<string, int> GetAllClasses()
        {
            return clsClassDataAccess.GetClassList();
        }
        public static Dictionary<int, decimal> GetAllClassFees()
        {
            return clsClassDataAccess.GetClassFees();
        }

        public static string ClassName(int classID)
        {
            return clsClassDataAccess.GetClassName(classID);           
        }

        
    }
}
