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
    }
}
