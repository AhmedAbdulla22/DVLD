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
    }
}
