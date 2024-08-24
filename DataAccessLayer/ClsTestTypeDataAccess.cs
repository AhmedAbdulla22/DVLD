using System.Data.SqlClient;
using System.Windows.Forms;
using System;
using System.Data;

namespace DataAccessLayer
{
    public static class ClsTestTypeDataAccess
    {
        public static DataTable GetAllTestTypes()
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection sqlConnection = new SqlConnection(DataAccessLayerSetting.connectionString))
            {
                var query = @"SELECT TestTypeID
                              ,TestTypeTitle
                              ,TestTypeDescription
                              ,TestTypeFees
                          FROM TestTypes;";
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

        private static void safeParameterAdding<T>(SqlCommand sqlCommand, string parameterName, T value)
        {
            if (value == null || (value is string str && string.IsNullOrEmpty(str)))
            {
                sqlCommand.Parameters.AddWithValue(parameterName, DBNull.Value);
            }
            else
            {
                sqlCommand.Parameters.AddWithValue(parameterName, value);
            }
        }

        public static bool UpdateTestType(int TypeID, string Title,string Description, double Fees)
        {
            bool isUpdated = false;

            using (var sqlConnection = new SqlConnection(DataAccessLayerSetting.connectionString))
            {
                var query = @"Update TestTypes
                              Set TestTypeTitle = @Title,TestTypeFees = @Fees,TestTypeDescription = @Description
                                Where TestTypeID = @TypeID;";

                using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                {

                    safeParameterAdding<int>(sqlCommand, "@TypeID", TypeID);
                    safeParameterAdding<string>(sqlCommand, "@Title", Title);
                    safeParameterAdding<string>(sqlCommand, "@Description", Description);
                    safeParameterAdding<double>(sqlCommand, "@Fees", Fees);



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

        public static bool GetTestTypeByID(int TypeID, ref string Title,ref string Description, ref double Fees)
        {
            bool isExist = false;

            using (var sqlConnection = new SqlConnection(DataAccessLayerSetting.connectionString))
            {
                var query = @"SELECT * FROM TestTypes Where TestTypeID = @TypeID;";

                using (var sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@TypeID", TypeID);
                    try
                    {
                        sqlConnection.Open();

                        using (SqlDataReader reader = sqlCommand.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                Title = (string)reader["TestTypeTitle"];
                                Description = (string)reader["TestTypeDescription"];
                                Fees = Convert.ToDouble((decimal)reader["TestTypeFees"]);
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
    }
}
