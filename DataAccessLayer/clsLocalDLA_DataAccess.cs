using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataAccessLayer
{
    internal class clsLocalDLA_DataAccess
    {
        public static DataTable getAllLocalDLA()
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection sqlConnection = new SqlConnection(DataAccessLayerSetting.connectionString))
            {
                var query = @"SELECT 
                            'L.D.L.AppID' = LDLApp.LocalDrivingLicenseApplicationID,
                            'Driving Class' = LicenseClasses.ClassName,
                            'Full Name' = People.FirstName + ' ' + People.SecondName + ' ' + People.ThirdName + ' ' + People.LastName,
                            'Application Date' = Applications.ApplicationDate, 
                            Applications.ApplicationStatus, 
                            People.NationalNo, 
                            'Passed Tests' = 
                                (SELECT COUNT(*)
                                 FROM TestAppointments
                                 JOIN Tests ON TestAppointments.TestAppointmentID = Tests.TestAppointmentID 
                                 WHERE TestAppointments.LocalDrivingLicenseApplicationID = LDLApp.LocalDrivingLicenseApplicationID 
                                 AND Tests.TestResult = 1)
                        FROM 
                            Applications 
                        INNER JOIN 
                            LocalDrivingLicenseApplications LDLApp ON Applications.ApplicationID = LDLApp.ApplicationID 
                        INNER JOIN 
                            People ON Applications.ApplicantPersonID = People.PersonID 
                        INNER JOIN 
                            LicenseClasses ON LDLApp.LicenseClassID = LicenseClasses.LicenseClassID 
                        INNER JOIN 
                            TestAppointments ON LDLApp.LocalDrivingLicenseApplicationID = TestAppointments.LocalDrivingLicenseApplicationID;";
                using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                {

                    try
                    {
                        sqlConnection.Open();

                        using (SqlDataReader reader = sqlCommand.ExecuteReader())
                        {
                            dataTable.Load(reader);
                        }

                    }
                    catch (Exception ex)
                    {
                        //
                        MessageBox.Show(ex.Message);
                    }
                }


            }


            return dataTable;
        }
    }
}
