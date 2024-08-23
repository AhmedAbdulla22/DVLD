using DataAccessLayer;
using System.Data;

namespace BusinessLayer
{
    public class clsApplicationType
    {
        public int ApplicationID { get; set; }
        public string Title { get; set; }
        public int Fees { get; set; }
        public enum mode { Add, Update };
        mode enMode;

        public clsApplicationType()
        {
            ApplicationID = -1;
            Title = "";
            Fees = 0;

            enMode = mode.Add;
        }

        public clsApplicationType(int ApplicationID, string Title, int Fees)
        {
            this.ApplicationID = ApplicationID;
            this.Title = Title;
            this.Fees = Fees;

            enMode = mode.Update;
        }

        public static DataTable getAllApplicationTypes()
        {
            return ClsApplicationTypeDataAccess.GetAllApplicationTypes();
        }
    }
}
