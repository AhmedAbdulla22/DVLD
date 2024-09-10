using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataAccessLayer
{
    public class clsTests_DataAccess
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
        public static bool GetTestResult(int TestAppointmentID)
        {
            bool isPassed = false;

            using (var sqlConnection = new SqlConnection(DataAccessLayerSetting.connectionString))
            {
                var query = @"SELECT TestResult FROM Tests
                              Where TestAppointmentID = @TestAppointmentID;";
                using (var sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
                    try
                    {
                        sqlConnection.Open();

                        object result = sqlCommand.ExecuteScalar();

                        if (result != null && result != DBNull.Value)
                        {
                            isPassed = Convert.ToBoolean(result);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }

            }

            return isPassed;
        }
        public static int AddNewTest(int TestAppointmentID,bool TestResult,string Notes,int CreatedByUserID)
        {
            int NewTestID = -1;

            using (var sqlConnection = new SqlConnection(DataAccessLayerSetting.connectionString))
            {
                var query = @"INSERT INTO Tests
           (TestAppointmentID
           ,TestResult
           ,Notes
           ,CreatedByUserID)
     VALUES
            (@TestAppointmentID
           ,@TestResult
           ,@Notes
           ,@CreatedByUserID)

SELECT Scope_Identity();";

                using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
                    sqlCommand.Parameters.AddWithValue("@TestResult", TestResult);
                    safeParameterAdding<string>(sqlCommand, "@Notes", Notes);
                    sqlCommand.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
                    try
                    {
                        sqlConnection.Open();

                        object result = sqlCommand.ExecuteScalar();

                        if (result != null)
                        {
                            NewTestID = Convert.ToInt32(result);
                        }
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message);
                    }


                }
            }
            return NewTestID;
        }

        public static bool UpdateTest(int TestID, int TestAppointmentID, bool TestResult, string Notes, int CreatedByUserID)
        {
            bool isUpdated = false;

            using (var sqlConnection = new SqlConnection(DataAccessLayerSetting.connectionString))
            {
                var query = @"Update Tests
                              Set 
                               TestAppointmentID= @TestAppointmentID,
                               TestResult       = @TestResult,
                               Notes            = @Notes,
                               CreatedByUserID  = @CreatedByUserID 
                              Where TestID = @TestID;";

                using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                {


                    sqlCommand.Parameters.AddWithValue("@TestID", TestID);
                    sqlCommand.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
                    sqlCommand.Parameters.AddWithValue("@TestResult", TestResult);
                    safeParameterAdding<string>(sqlCommand, "@Notes", Notes);
                    sqlCommand.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

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


        public static bool GetTestByTestID(int TestID,ref int TestAppointmentID, ref bool TestResult, ref string Notes, ref int CreatedByUserID)
        {
            bool isExist = false;

            using (var sqlConnection = new SqlConnection(DataAccessLayerSetting.connectionString))
            {
                var query = @"SELECT * FROM Tests Where TestID = @TestID;";

                using (var sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@TestID", TestID);
                    try
                    {
                        sqlConnection.Open();

                        using (SqlDataReader reader = sqlCommand.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                TestAppointmentID = (int)reader["TestAppointmentID"];
                                TestResult = (bool)reader["TestResult"];
                                if (reader["Notes"] != DBNull.Value)
                                {
                                Notes = (string)reader["Notes"];
                                }
                                else
                                {
                                    Notes = "";
                                }
                                CreatedByUserID = (int)reader["CreatedByUserID"];
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
        public static bool GetTestByTestAppointmentID( int TestAppointmentID,ref int TestID, ref bool TestResult, ref string Notes, ref int CreatedByUserID)
        {
            bool isExist = false;

            using (var sqlConnection = new SqlConnection(DataAccessLayerSetting.connectionString))
            {
                var query = @"SELECT * FROM Tests Where TestAppointmentID = @TestAppointmentID;";

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
                                TestID = (int)reader["TestID"];
                                TestResult = (bool)reader["TestResult"];
                                if (reader["Notes"] != DBNull.Value)
                                {
                                    Notes = (string)reader["Notes"];
                                }
                                else
                                {
                                    Notes = "";
                                }
                                CreatedByUserID = (int)reader["CreatedByUserID"];
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


        public static bool DeleteTest(int TestID)
        {
            bool isDeleted = false;
            using (var sqlConnection = new SqlConnection(DataAccessLayerSetting.connectionString))
            {
                var query = @"DELETE FROM Tests
                              Where TestID = @TestID;";

                using (var sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@TestID", TestID);

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
