using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace DataAccessLayer
{
    public static class DataAccessPeopleLayer
    {
        public static DataTable getAllPeople()
        {
            SqlConnection sqlConnection = new SqlConnection(DataAccessLayerSetting.connectionString);
            var query = "SELECT*FROM People;";
            SqlCommand sqlCommand = new SqlCommand(query,sqlConnection);

            DataTable dataTable = new DataTable();

            try
            {
                sqlConnection.Open();
                
                SqlDataReader reader = sqlCommand.ExecuteReader();

                dataTable.Load(reader);
            }
            catch (Exception ex) 
            {
                //
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }

            return dataTable;
        }
    }
}
