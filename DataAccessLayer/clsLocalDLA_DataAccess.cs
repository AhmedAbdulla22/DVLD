﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataAccessLayer
{
    public static class clsLocalDLA_DataAccess
    {
        public static DataTable getAllLocalDLA()
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection sqlConnection = new SqlConnection(DataAccessLayerSetting.connectionString))
            {
                var query = @"SELECT
                            'L.D.L.AppID' = LDLApp.LocalDrivingLicenseApplicationID,
                            'Driving Class' = LicenseClasses.ClassName,
                            'National No.' = People.NationalNo,
                            'Full Name' = People.FirstName + ' ' + People.SecondName + ' ' + People.ThirdName + ' ' + People.LastName,
                            'Application Date' = Applications.ApplicationDate,  
                            'Passed Tests' = 
                                (SELECT COUNT(*)
                                 FROM TestAppointments
                                 JOIN Tests ON TestAppointments.TestAppointmentID = Tests.TestAppointmentID 
                                 WHERE TestAppointments.LocalDrivingLicenseApplicationID = LDLApp.LocalDrivingLicenseApplicationID 
                                 AND Tests.TestResult = 1),
                            'Status' = 
							CASE 
							WHEN Applications.ApplicationStatus = 1 THEN 'New'
							WHEN Applications.ApplicationStatus = 2 THEN 'Canceled'
							ELSE 'Completed'
							END
                        FROM 
                            LocalDrivingLicenseApplications LDLApp
                        INNER JOIN 
                            Applications  ON Applications.ApplicationID = LDLApp.ApplicationID 
                        INNER JOIN 
                            People ON Applications.ApplicantPersonID = People.PersonID 
                        INNER JOIN 
                            LicenseClasses ON LDLApp.LicenseClassID = LicenseClasses.LicenseClassID;";
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

        public static DataTable GetLDLA_ByLDLAppID(int LocalDrivingLicenseApplicationID)
        {
            DataTable dt = new DataTable();

            using (SqlConnection sqlConnection = new SqlConnection(DataAccessLayerSetting.connectionString))
            {
                var query = @"SELECT
                            'L.D.L.AppID' = LDLApp.LocalDrivingLicenseApplicationID,
                            'Driving Class' = LicenseClasses.ClassName,
                            'Full Name' = People.FirstName + ' ' + People.SecondName + ' ' + People.ThirdName + ' ' + People.LastName,
                            'Application Date' = Applications.ApplicationDate, 
                            People.NationalNo, 
                            'Passed Tests' = 
                                (SELECT COUNT(*)
                                 FROM TestAppointments
                                 JOIN Tests ON TestAppointments.TestAppointmentID = Tests.TestAppointmentID 
                                 WHERE TestAppointments.LocalDrivingLicenseApplicationID = LDLApp.LocalDrivingLicenseApplicationID 
                                 AND Tests.TestResult = 1),
                            'Status' = 
							CASE 
							WHEN Applications.ApplicationStatus = 1 THEN 'New'
							WHEN Applications.ApplicationStatus = 2 THEN 'Canceled'
							ELSE 'Completed'
							END
                        FROM 
                            LocalDrivingLicenseApplications LDLApp
                        INNER JOIN 
                            Applications  ON Applications.ApplicationID = LDLApp.ApplicationID 
                        INNER JOIN 
                            People ON Applications.ApplicantPersonID = People.PersonID 
                        INNER JOIN 
                            LicenseClasses ON LDLApp.LicenseClassID = LicenseClasses.LicenseClassID
                                Where LDLApp.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID;";
                using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);


                    try
                    {
                        sqlConnection.Open();

                        using (SqlDataReader reader = sqlCommand.ExecuteReader())
                        {
                            dt.Load(reader);
                        }

                    }
                    catch (Exception ex)
                    {
                        //
                        MessageBox.Show(ex.Message);
                    }
                }


            }



            return dt;
        }
        public static DataTable GetLDLA_ByNationalNo(int NationalNo)
        {
            DataTable dt = new DataTable();

            using (SqlConnection sqlConnection = new SqlConnection(DataAccessLayerSetting.connectionString))
            {
                var query = @"SELECT
                            'L.D.L.AppID' = LDLApp.LocalDrivingLicenseApplicationID,
                            'Driving Class' = LicenseClasses.ClassName,
                            'Full Name' = People.FirstName + ' ' + People.SecondName + ' ' + People.ThirdName + ' ' + People.LastName,
                            'Application Date' = Applications.ApplicationDate, 
                            People.NationalNo, 
                            'Passed Tests' = 
                                (SELECT COUNT(*)
                                 FROM TestAppointments
                                 JOIN Tests ON TestAppointments.TestAppointmentID = Tests.TestAppointmentID 
                                 WHERE TestAppointments.LocalDrivingLicenseApplicationID = LDLApp.LocalDrivingLicenseApplicationID 
                                 AND Tests.TestResult = 1),
                            'Status' = 
							CASE 
							WHEN Applications.ApplicationStatus = 1 THEN 'New'
							WHEN Applications.ApplicationStatus = 2 THEN 'Canceled'
							ELSE 'Completed'
							END
                        FROM 
                            LocalDrivingLicenseApplications LDLApp
                        INNER JOIN 
                            Applications  ON Applications.ApplicationID = LDLApp.ApplicationID 
                        INNER JOIN 
                            People ON Applications.ApplicantPersonID = People.PersonID 
                        INNER JOIN 
                            LicenseClasses ON LDLApp.LicenseClassID = LicenseClasses.LicenseClassID
                                Where People.NationalNo = @NationalNo;";
                using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@NationalNo", NationalNo);


                    try
                    {
                        sqlConnection.Open();

                        using (SqlDataReader reader = sqlCommand.ExecuteReader())
                        {
                            dt.Load(reader);
                        }

                    }
                    catch (Exception ex)
                    {
                        //
                        MessageBox.Show(ex.Message);
                    }
                }


            }



            return dt;
        }

        public static DataTable GetLDLA_ByFullName(string FullName)
        {
            DataTable dt = new DataTable();

            using (SqlConnection sqlConnection = new SqlConnection(DataAccessLayerSetting.connectionString))
            {
                var query = @"SELECT
                            'L.D.L.AppID' = LDLApp.LocalDrivingLicenseApplicationID,
                            'Driving Class' = LicenseClasses.ClassName,
                            'Full Name' = People.FirstName + ' ' + People.SecondName + ' ' + People.ThirdName + ' ' + People.LastName,
                            'Application Date' = Applications.ApplicationDate, 
                            People.NationalNo, 
                            'Passed Tests' = 
                                (SELECT COUNT(*)
                                 FROM TestAppointments
                                 JOIN Tests ON TestAppointments.TestAppointmentID = Tests.TestAppointmentID 
                                 WHERE TestAppointments.LocalDrivingLicenseApplicationID = LDLApp.LocalDrivingLicenseApplicationID 
                                 AND Tests.TestResult = 1),
                            'Status' = 
							CASE 
							WHEN Applications.ApplicationStatus = 1 THEN 'New'
							WHEN Applications.ApplicationStatus = 2 THEN 'Canceled'
							ELSE 'Completed'
							END
                        FROM 
                            LocalDrivingLicenseApplications LDLApp
                        INNER JOIN 
                            Applications  ON Applications.ApplicationID = LDLApp.ApplicationID 
                        INNER JOIN 
                            People ON Applications.ApplicantPersonID = People.PersonID 
                        INNER JOIN 
                            LicenseClasses ON LDLApp.LicenseClassID = LicenseClasses.LicenseClassID
                                Where (People.FirstName + ' ' + People.SecondName + ' ' + People.ThirdName + ' ' + People.LastName) LIKE @FullName + '%';";
                using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@FullName", FullName);


                    try
                    {
                        sqlConnection.Open();

                        using (SqlDataReader reader = sqlCommand.ExecuteReader())
                        {
                            dt.Load(reader);
                        }

                    }
                    catch (Exception ex)
                    {
                        //
                        MessageBox.Show(ex.Message);
                    }
                }


            }



            return dt;
        }

        public static DataTable GetLDLA_ByStatus(byte ApplicationStatus)
        {
            DataTable dt = new DataTable();

            using (SqlConnection sqlConnection = new SqlConnection(DataAccessLayerSetting.connectionString))
            {
                var query = @"SELECT
                            'L.D.L.AppID' = LDLApp.LocalDrivingLicenseApplicationID,
                            'Driving Class' = LicenseClasses.ClassName,
                            'Full Name' = People.FirstName + ' ' + People.SecondName + ' ' + People.ThirdName + ' ' + People.LastName,
                            'Application Date' = Applications.ApplicationDate, 
                            People.NationalNo, 
                            'Passed Tests' = 
                                (SELECT COUNT(*)
                                 FROM TestAppointments
                                 JOIN Tests ON TestAppointments.TestAppointmentID = Tests.TestAppointmentID 
                                 WHERE TestAppointments.LocalDrivingLicenseApplicationID = LDLApp.LocalDrivingLicenseApplicationID 
                                 AND Tests.TestResult = 1),
                            'Status' = 
							CASE 
							WHEN Applications.ApplicationStatus = 1 THEN 'New'
							WHEN Applications.ApplicationStatus = 2 THEN 'Canceled'
							ELSE 'Completed'
							END
                        FROM 
                            LocalDrivingLicenseApplications LDLApp
                        INNER JOIN 
                            Applications  ON Applications.ApplicationID = LDLApp.ApplicationID 
                        INNER JOIN 
                            People ON Applications.ApplicantPersonID = People.PersonID 
                        INNER JOIN 
                            LicenseClasses ON LDLApp.LicenseClassID = LicenseClasses.LicenseClassID
                                Where Applications.ApplicationStatus = @ApplicationStatus;";
                using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@ApplicationStatus", ApplicationStatus);


                    try
                    {
                        sqlConnection.Open();

                        using (SqlDataReader reader = sqlCommand.ExecuteReader())
                        {
                            dt.Load(reader);
                        }

                    }
                    catch (Exception ex)
                    {
                        //
                        MessageBox.Show(ex.Message);
                    }
                }


            }



            return dt;
        }
    }
}
