using DataAccessLayer;
using System.Data;

namespace BusinessLayer
{
    public class clsTestType
    {
        public int TestTypeID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double Fees { get; set; }

        public clsTestType()
        {
            TestTypeID = -1;
            Title = "";
            Description = "";
            Fees = 0;

        }

        public clsTestType(int TestTypeID, string Title,string Description, double Fees)
        {
            this.TestTypeID = TestTypeID;
            this.Title = Title;
            this.Description = Description;
            this.Fees = Fees;
        }
        public static clsTestType GetTestType(int TypeID)
        {
            string Title = string.Empty,Description = string.Empty;
            double Fees = -1;


            if (ClsTestTypeDataAccess.GetTestTypeByID(TypeID, ref Title,ref Description, ref Fees))
            {
                return new clsTestType(TypeID,Title,Description, Fees);
            }
            else
            {
                return null;
            }
        }
        public static DataTable getAllTestTypes()
        {
            return ClsTestTypeDataAccess.GetAllTestTypes();
        }

        public bool Update()
        {
            return ClsTestTypeDataAccess.UpdateTestType(this.TestTypeID, this.Title,this.Description, this.Fees);
        }


    }
}
