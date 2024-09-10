using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class clsTestAppointments
    {
        public enum TestType : int { VisionTest = 1, WrittenTest = 2, PracticalTest = 3, All = 4}
        public TestType enTestType;
        public enum mode { Add, Update };
        mode enMode;

        public int TestAppointmentID {  get; set; }
        public int TestTypeID { get { return (int)enTestType; } set {  enTestType = (TestType)value; } }
        public int LocalDrivingLicenseApplicationID { get; set; }
        public DateTime AppointmentDate { get; set; }
        public decimal PaidFees { get; set; }
        public int CreatedByUserID {  get; set; }
        public bool IsLocked { get; set; }
        public int RetakeTestApplicationID { get; set; }

        public clsTestAppointments()
        {
            this.TestTypeID = this.TestAppointmentID = this.RetakeTestApplicationID = this.CreatedByUserID = this.LocalDrivingLicenseApplicationID = -1;
            this.AppointmentDate = DateTime.Now;
            this.IsLocked = false;
            this.PaidFees = 0;
            this.enMode = mode.Add;

        }

        public clsTestAppointments(int TestAppointmentID, int TestTypeID, DateTime AppointmentDate, int LocalDrivingLicenseApplicationID, decimal paidFees, int createdByUserID, int RetakeTestApplicationID = -1, bool IsLocked = false)
        {
            this.TestAppointmentID = TestAppointmentID;
            this.TestTypeID = TestTypeID;
            this.AppointmentDate = AppointmentDate;
            this.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            this.RetakeTestApplicationID = RetakeTestApplicationID;
            this.PaidFees = paidFees;
            this.IsLocked = IsLocked;
            this.enMode = mode.Update;

            this.CreatedByUserID = createdByUserID;
        }


        public static DataTable GetTestAppointments(TestType enTestType = TestType.All)
        {
            DataTable dt = new DataTable();

            switch(enTestType)
            {
                case TestType.VisionTest:
                    {
                        dt = clsTestAppointments_DataAccess.GetVisionAppointments();
                        break;
                    }
                case TestType.WrittenTest:
                    {
                        dt = clsTestAppointments_DataAccess.GetWrittenAppointments();

                        break;
                    }
                case TestType.PracticalTest:
                    {
                        dt = clsTestAppointments_DataAccess.GetPracticalAppointments();

                        break;
                    }
                default:
                    {
                        dt = clsTestAppointments_DataAccess.GetPracticalAppointments();

                        break;
                    }

            }

            return dt;
        }

        public static DataTable GetTestAppointments(int LocalDLAppID,TestType enTestType = TestType.All)
        {
            DataTable dt = new DataTable();

            switch (enTestType)
            {
                case TestType.VisionTest:
                    {
                        dt = clsTestAppointments_DataAccess.GetVisionAppointments(LocalDLAppID);
                        break;
                    }
                case TestType.WrittenTest:
                    {
                        dt = clsTestAppointments_DataAccess.GetWrittenAppointments(LocalDLAppID);

                        break;
                    }
                case TestType.PracticalTest:
                    {
                        dt = clsTestAppointments_DataAccess.GetPracticalAppointments(LocalDLAppID);

                        break;
                    }
                default:
                    {
                        dt = clsTestAppointments_DataAccess.GetPracticalAppointments(LocalDLAppID);

                        break;
                    }

            }

            return dt;
        }
        public static clsTestAppointments FindTestAppointment(int TestAppointmentID)
        {
            int TestTypeID = -1, LocalDrivingLicenseApplicationID = -1, CreatedByUserID = -1, RetakeTestApplicationID = -1;
            decimal PaidFees = 0;
            bool IsLocked = false;
            DateTime AppointmentDate = DateTime.Now;


            
            if (clsTestAppointments_DataAccess.GetTestAppointmentByTestAppointmentID(TestAppointmentID,ref TestTypeID,ref LocalDrivingLicenseApplicationID, ref AppointmentDate, ref PaidFees, ref CreatedByUserID, ref IsLocked, ref RetakeTestApplicationID))
            {
                return new clsTestAppointments(TestAppointmentID,TestTypeID,AppointmentDate,LocalDrivingLicenseApplicationID,PaidFees,CreatedByUserID,RetakeTestApplicationID,IsLocked);
            }
            else
            {
                return null;
            }
        }
        public static int GetTrails(int LocalDLAppID, TestType enTestType)
        {
            int Trails = 0;

            Trails = clsTestAppointments_DataAccess.GetTrails(LocalDLAppID,(int)enTestType);

            return Trails;
        }

        public bool Delete()
        {
            return clsTestAppointments_DataAccess.DeleteTestAppointment(this.TestAppointmentID);
        }

        public static bool Delete(int TestAppointmentID)
        {
            return clsTestAppointments_DataAccess.DeleteTestAppointment(TestAppointmentID);
        }

        private bool _AddNewTestAppointment()
        {
            this.TestAppointmentID = clsTestAppointments_DataAccess.AddTestAppointment(this.TestTypeID, this.LocalDrivingLicenseApplicationID, this.AppointmentDate, this.PaidFees,this.CreatedByUserID,this.IsLocked,this.RetakeTestApplicationID);

            return (this.TestAppointmentID != -1);
        }
        private bool _Update()
        {
            //Update User
            return clsTestAppointments_DataAccess.UpdateTestAppointment(this.TestAppointmentID, this.TestTypeID, this.LocalDrivingLicenseApplicationID, this.AppointmentDate, this.PaidFees, this.CreatedByUserID, this.IsLocked, this.RetakeTestApplicationID);

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
                        if (_AddNewTestAppointment())
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

        public bool TestResult()
        {
            return clsTests_DataAccess.GetTestResult(this.TestAppointmentID);
        }
    }


}
