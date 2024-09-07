using DataAccessLayer;
using System.Data;
using System.Xml.Linq;

namespace BusinessLayer
{
    public class clsApplicationType
    {
        public int ApplicationID { get; set; }
        public string Title { get; set; }
        public decimal Fees { get; set; }
        public enum ApplicationType { New_Local_Driving_License_Service = 1, Renew_Driving_License_Service , Replacement_for_a_Lost_Driving_License , Replacement_for_a_Damaged_Driving_License, Release_Detained_Driving_Licsense, New_International_License,Retake_Test }

        public clsApplicationType()
        {
            ApplicationID = -1;
            Title = "";
            Fees = 0;

        }

        public clsApplicationType(int ApplicationID, string Title, decimal Fees)
        {
            this.ApplicationID = ApplicationID;
            this.Title = Title;
            this.Fees = Fees;
        }
        public static clsApplicationType GetApplicationType(int TypeID)
        {
            string Title = string.Empty;
            decimal Fees = -1;


            if (ClsApplicationTypeDataAccess.GetApplicationTypeByID(TypeID,ref Title, ref Fees))
            {
                return new clsApplicationType(TypeID,Title,Fees);
            }
            else
            {
                return null;
            }
        }
        public static DataTable getAllApplicationTypes()
        {
            return ClsApplicationTypeDataAccess.GetAllApplicationTypes();
        }

        public bool Update()
        {
           return ClsApplicationTypeDataAccess.UpdateApplicationType(this.ApplicationID, this.Title, this.Fees);
        }


    }
}
