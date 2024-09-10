using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class clsTests
    {
      public int TestID { get; set; }
      public int TestAppointmentID { get; set; }
        public bool TestResult { get; set; }
        public string Notes { get; set; }
        public int CreatedByUserID { get; set; }
        public enum mode { Add, Update };
        mode enMode;

        public clsTests()
        {
            TestID = TestAppointmentID = CreatedByUserID = -1;
            Notes = string.Empty;
            TestResult = false;
            this.enMode = mode.Add;
        }

        public clsTests(int TestID, int TestAppointmentID,bool TestResult,string Notes,int CreatedByUserID)
        {
            this.TestID = TestID;
            this.TestAppointmentID = TestAppointmentID;
            this.TestResult = TestResult;
            this.Notes = Notes;
            this.CreatedByUserID = CreatedByUserID;
            this.enMode = mode.Update;
        }

        public static bool GetTestResult(int TestAppointmentID)
        {
            return clsTests_DataAccess.GetTestResult(TestAppointmentID);
        }

        private bool _AddNewTest()
        {
            this.TestID = clsTests_DataAccess.AddNewTest(this.TestAppointmentID,this.TestResult,this.Notes,this.CreatedByUserID);

            return (this.TestID != -1);
        }
        private bool _Update()
        {
            //Update User
            return clsTests_DataAccess.UpdateTest(this.TestID,this.TestAppointmentID, this.TestResult, this.Notes, this.CreatedByUserID);

        }
        public bool Save()
        {
            switch (enMode)
            {
                case mode.Update:
                    {
                        return _Update();

                    }
                case mode.Add:
                    {
                        if (_AddNewTest())
                        {
                            enMode = mode.Update;
                            return true;
                        }
                        else
                        {
                            return false;
                        }

                    }
            }
            return false;
        }
        public bool Delete()
        {
            return clsTests_DataAccess.DeleteTest(this.TestID);
        }

        public static bool Delete(int TestID)
        {
            return clsTests_DataAccess.DeleteTest(TestID);
        }
        public static clsTests GetTestByTestID(int TestID)
        {
            int TestAppointmentID = -1, CreatedByUserID = -1;
            bool TestResult = false;
            string Notes = string.Empty;

            if (clsTests_DataAccess.GetTestByTestID(TestID,ref TestAppointmentID,ref TestResult,ref Notes, ref CreatedByUserID))
            {
                return new clsTests(TestID,TestAppointmentID,TestResult,Notes,CreatedByUserID);
            }
            else
            {
                return null;
            }
        }
        public static clsTests GetTestByTestAppointmentID(int TestAppointmentID)
        {
            int TestID = -1, CreatedByUserID = -1;
            bool TestResult = false;
            string Notes = string.Empty;

            if (clsTests_DataAccess.GetTestByTestAppointmentID(TestAppointmentID, ref TestID, ref TestResult, ref Notes, ref CreatedByUserID))
            {
                return new clsTests(TestID, TestAppointmentID, TestResult, Notes, CreatedByUserID);
            }
            else
            {
                return null;
            }
        }

    }
}
