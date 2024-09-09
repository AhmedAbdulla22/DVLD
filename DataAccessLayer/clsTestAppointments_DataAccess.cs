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
        private static void safeParameterAdding<T>(SqlCommand sqlCommand, string parameterName, T value)
        {
            if (value is int num)
            {
                if (num == -1)
                {
                    sqlCommand.Parameters.AddWithValue(parameterName, DBNull.Value);
                }
                else
                {
                    sqlCommand.Parameters.AddWithValue(parameterName, value);
                }
            }
            else if (value == null || (value is string str && string.IsNullOrEmpty(str)))
            {
                sqlCommand.Parameters.AddWithValue(parameterName, DBNull.Value);
            }
            else
            {
                sqlCommand.Parameters.AddWithValue(parameterName, value);
            }
            
        }
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
                              ,'Is Locked' =IsLocked
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

        public static bool GetTestAppointmentByTestAppointmentID(int TestAppointmentID, ref int TestTypeID, ref int LocalDrivingLicenseApplicationID, ref DateTime AppointmentDate, ref decimal PaidFees, ref int CreatedByUserID, ref bool IsLocked, ref int RetakeTestApplicationID)
        {
            bool isExist = false;

            using (var sqlConnection = new SqlConnection(DataAccessLayerSetting.connectionString))
            {
                var query = @"SELECT * FROM TestAppointments Where TestAppointmentID = @TestAppointmentID;";

                using (var sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
                    try
                    {
                        sqlConnection.Open();

                        using (SqlDataReader reader = sqlCommand.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                TestTypeID = (int)reader["TestTypeID"];
                                LocalDrivingLicenseApplicationID = (int)reader["LocalDrivingLicenseApplicationID"];
                                AppointmentDate = (DateTime)reader["AppointmentDate"];
                                PaidFees = (decimal)reader["PaidFees"];
                                CreatedByUserID = (int)reader["CreatedByUserID"];
                                IsLocked = (bool)reader["IsLocked"];
                                RetakeTestApplicationID = (int)reader["RetakeTestApplicationID"];
                                isExist = true;
                            }

                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                }

            }

            return isExist;
        }
        public static bool GetTestAppointmentByLocalDrivingLicenseApplicationID(int LocalDrivingLicenseApplicationID, ref int TestAppointmentID, ref int TestTypeID, ref DateTime AppointmentDate, ref decimal PaidFees, ref int CreatedByUserID, ref bool IsLocked, ref int RetakeTestApplicationID)
        {
            bool isExist = false;

            using (var sqlConnection = new SqlConnection(DataAccessLayerSetting.connectionString))
            {
                var query = @"SELECT * FROM TestAppointments Where LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID;";

                using (var sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
                    try
                    {
                        sqlConnection.Open();

                        using (SqlDataReader reader = sqlCommand.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                TestAppointmentID = (int)reader["TestAppointmentID"];
                                TestTypeID = (int)reader["TestTypeID"];
                                AppointmentDate = (DateTime)reader["AppointmentDate"];
                                PaidFees = (decimal)reader["PaidFees"];
                                CreatedByUserID = (int)reader["CreatedByUserID"];
                                IsLocked = (bool)reader["IsLocked"];
                                RetakeTestApplicationID = (int)reader["RetakeTestApplicationID"];
                                isExist = true;
                            }

                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                }

            }

            return isExist;
        }

        public static int AddTestAppointment( int TestTypeID, int LocalDrivingLicenseApplicationID, DateTime AppointmentDate, decimal PaidFees, int CreatedByUserID, bool IsLocked, int RetakeTestApplicationID)
        {
            int TestAppointmentID = -1;

            using (var sqlConnection = new SqlConnection(DataAccessLayerSetting.connectionString))
            {
                var query = @"INSERT INTO TestAppointments
           (TestTypeID
           ,LocalDrivingLicenseApplicationID
           ,AppointmentDate
           ,PaidFees
           ,CreatedByUserID
           ,IsLocked
           ,RetakeTestApplicationID)
     VALUES
            (@TestTypeID,
            @LocalDrivingLicenseApplicationID,
            @AppointmentDate,
            @PaidFees,
            @CreatedByUserID,
            @IsLocked,
            @RetakeTestApplicationID)

SELECT Scope_Identity();";

                using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@TestTypeID", TestTypeID);
                    sqlCommand.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
                    sqlCommand.Parameters.AddWithValue("@AppointmentDate", AppointmentDate);
                    sqlCommand.Parameters.AddWithValue("@PaidFees", PaidFees);
                    sqlCommand.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
                    sqlCommand.Parameters.AddWithValue("@IsLocked", IsLocked);
                    safeParameterAdding<int>(sqlCommand, "@RetakeTestApplicationID", RetakeTestApplicationID);


                    try
                    {
                        sqlConnection.Open();

                        object result = sqlCommand.ExecuteScalar();

                        if (result != null)
                        {
                            TestAppointmentID = Convert.ToInt32(result);
                        }
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message);
                    }


                }
            }
            return TestAppointmentID;
        }
        public static bool UpdateTestAppointment(int TestAppointmentID, int TestTypeID, int LocalDrivingLicenseApplicationID, DateTime AppointmentDate, decimal PaidFees, int CreatedByUserID, bool IsLocked, int RetakeTestApplicationID)
        {
            bool isUpdated = false;

            using (var sqlConnection = new SqlConnection(DataAccessLayerSetting.connectionString))
            {
                var query = @"Update TestAppointments
                              Set 
                               TestTypeID   = @TestTypeID
                               ,LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID
                               ,AppointmentDate = @AppointmentDate
                               ,PaidFees          = @PaidFees
                               ,CreatedByUserID   = @CreatedByUserID
                               ,IsLocked    = @IsLocked
                               ,RetakeTestApplicationID = RetakeTestApplicationID;
                              Where TestAppointmentID = @TestAppointmentID;";

                using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                {


                    sqlCommand.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
                    sqlCommand.Parameters.AddWithValue("@TestTypeID", TestTypeID);
                    sqlCommand.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
                    sqlCommand.Parameters.AddWithValue("@AppointmentDate", AppointmentDate);
                    sqlCommand.Parameters.AddWithValue("@PaidFees", PaidFees);
                    sqlCommand.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
                    sqlCommand.Parameters.AddWithValue("@IsLocked", IsLocked);
                    safeParameterAdding<int>(sqlCommand, "@RetakeTestApplicationID", RetakeTestApplicationID);


                    try
                    {
                        sqlConnection.Open();

                        if (sqlCommand.ExecuteNonQuery() > 0)
                        {
                            isUpdated = true;
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                }

            }

            return isUpdated;
        }
        public static bool DeleteTestAppointment(int TestAppointmentID)
        {
            bool isDeleted = false;
            using (var sqlConnection = new SqlConnection(DataAccessLayerSetting.connectionString))
            {
                var query = @"DELETE FROM TestAppointments
                              Where TestAppointmentID = @TestAppointmentID;";

                using (var sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);

                    try
                    {
                        sqlConnection.Open();

                        if (sqlCommand.ExecuteNonQuery() > 0)
                        {
                            isDeleted = true;
                        }

                    }
                    catch (Exception ex)
                    {
                        //MessageBox.Show(ex.Message);
                    }
                }
            }
            return isDeleted;
        }

    }
}
