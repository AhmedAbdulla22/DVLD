using System.Data.SqlClient;
using System.Windows.Forms;
using System;
using System.Data;

namespace DataAccessLayer
{
    public static class ClsApplicationTypeDataAccess
    {
        public static DataTable GetAllApplicationTypes()
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection sqlConnection = new SqlConnection(DataAccessLayerSetting.connectionString))
            {
                var query = @"SELECT ApplicationTypeID,ApplicationTypeTitle,ApplicationFees FROM ApplicationTypes;";
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

        public static bool UpdateApplicationType(int ApplicationID, string Title, decimal Fees)
        {
            bool isUpdated = false;

            using (var sqlConnection = new SqlConnection(DataAccessLayerSetting.connectionString))
            {
                var query = @"Update ApplicationTypes
                              Set ApplicationTypeTitle = @Title,ApplicationFees = @Fees
                                Where ApplicationTypeID = @ApplicationID;";

                using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                {

                    safeParameterAdding<int>(sqlCommand,"@ApplicationID",ApplicationID);
                    safeParameterAdding<string>(sqlCommand, "@Title", Title);
                    safeParameterAdding<decimal>(sqlCommand, "@Fees", Fees);



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

        public static bool GetApplicationTypeByID(int TypeID, ref string Title, ref decimal Fees)
        {
            bool isExist = false;

            using (var sqlConnection = new SqlConnection(DataAccessLayerSetting.connectionString))
            {
                var query = @"SELECT * FROM ApplicationTypes Where ApplicationTypeID = @TypeID;";

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
                                Title = (string)reader["ApplicationTypeTitle"];
                                Fees = (decimal)reader["ApplicationFees"];
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
