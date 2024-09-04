using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataAccessLayer
{
    public class clsTestAppointments_DataAccess
    {
        public static int GetTrails(int LocalDrivingLicenseApplicationID,int TestTypeID)
        {
            int Trails = 0;

            using (SqlConnection sqlConnection = new SqlConnection(DataAccessLayerSetting.connectionString))
            {
                var query = @"SELECT count(*)
                             FROM TestAppointments
                            Where TestAppointments.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID AND TestTypeID = @TestTypeID;";
                using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
                    sqlCommand.Parameters.AddWithValue("@TestTypeID", TestTypeID);

                    try
                    {
                        sqlConnection.Open();

                        object result = sqlCommand.ExecuteScalar();

                        if (result != null && result != DBNull.Value)
                        {
                            Trails = Convert.ToInt32(result);
                        }

                    }
                    catch (Exception ex)
                    {
                        //
                        MessageBox.Show(ex.Message);
                    }
                }


            }


            return Trails;
        }
        public static DataTable GetAllAppointments()
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection sqlConnection = new SqlConnection(DataAccessLayerSetting.connectionString))
            {
                var query = @"SELECT 'Appointment ID' = TestAppointmentID
                              ,'Appointment Date' = AppointmentDate
                              ,'Paid Fees' = PaidFees
                              ,IsLocked
                             FROM TestAppointments;";
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

        public static DataTable GetVisionAppointments()
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection sqlConnection = new SqlConnection(DataAccessLayerSetting.connectionString))
            {
                var query = @"SELECT 'Appointment ID' = TestAppointmentID
                              ,'Appointment Date' = AppointmentDate
                              ,'Paid Fees' = PaidFees
                              ,IsLocked
                             FROM TestAppointments
                             Where TestTypeID = 1;";
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

        public static DataTable GetWrittenAppointments()
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection sqlConnection = new SqlConnection(DataAccessLayerSetting.connectionString))
            {
                var query = @"SELECT 'Appointment ID' = TestAppointmentID
                              ,'Appointment Date' = AppointmentDate
                              ,'Paid Fees' = PaidFees
                              ,IsLocked
                             FROM TestAppointments
                             Where TestTypeID = 2;";
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
        public static DataTable GetPracticalAppointments()
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection sqlConnection = new SqlConnection(DataAccessLayerSetting.connectionString))
            {
                var query = @"SELECT 'Appointment ID' = TestAppointmentID
                              ,'Appointment Date' = AppointmentDate
                              ,'Paid Fees' = PaidFees
                              ,IsLocked
                             FROM TestAppointments
                             Where TestTypeID = 3;";
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
        public static DataTable GetAllAppointments(int LocalDrivingLicenseApplicationID)
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection sqlConnection = new SqlConnection(DataAccessLayerSetting.connectionString))
            {
                var query = @"SELECT 
                               'Appointment ID' = TestAppointmentID
                              ,'Appointment Date' = AppointmentDate
                              ,'Paid Fees' = PaidFees
                              ,IsLocked
                             FROM TestAppointments
                              Where TestAppointments.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID ;";
                using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
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

        public static DataTable GetVisionAppointments(int LocalDrivingLicenseApplicationID)
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection sqlConnection = new SqlConnection(DataAccessLayerSetting.connectionString))
            {
                var query = @"SELECT 
                               'Appointment ID' = TestAppointmentID
                              ,'Appointment Date' = AppointmentDate
                              ,'Paid Fees' = PaidFees
                              ,IsLocked
                             FROM TestAppointments
                              Where TestAppointments.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID AND TestTypeID = 1;";
                using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
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

        public static DataTable GetWrittenAppointments(int LocalDrivingLicenseApplicationID)
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection sqlConnection = new SqlConnection(DataAccessLayerSetting.connectionString))
            {
                var query = @"SELECT 
                               'Appointment ID' = TestAppointmentID
                              ,'Appointment Date' = AppointmentDate
                              ,'Paid Fees' = PaidFees
                              ,IsLocked
                             FROM TestAppointments
                              Where TestAppointments.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID AND TestTypeID = 2;";
                using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
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
        public static DataTable GetPracticalAppointments(int LocalDrivingLicenseApplicationID)
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection sqlConnection = new SqlConnection(DataAccessLayerSetting.connectionString))
            {
                var query = @"SELECT 
                               'Appointment ID' = TestAppointmentID
                              ,'Appointment Date' = AppointmentDate
                              ,'Paid Fees' = PaidFees
                              ,IsLocked
                             FROM TestAppointments
                              Where TestAppointments.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID AND TestTypeID = 3;";
                using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
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
