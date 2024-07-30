using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace DataAccessLayer
{
    public static class ClsCountryDataAccess
    {
        public static Dictionary<string,int> GetCountryList()
        {
            var DictMap = new Dictionary<string,int>();

            using (SqlConnection sqlConnection = new SqlConnection(DataAccessLayerSetting.connectionString))
            {
                 

                var query = "Select CountryName,CountryID From Countries;";

                using ( SqlCommand sqlCommand = new SqlCommand( query, sqlConnection))
                {
                    try
                    {
                        sqlConnection.Open();

                        using (SqlDataReader reader = sqlCommand.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                DictMap.Add((string)reader["CountryName"], (int)reader["CountryID"]);
                            }
                        }

                        
                    }
                    catch(Exception ex) 
                    {
                            MessageBox.Show(ex.Message);
                    }
                    
                }

                return DictMap;
            }
        }
    }
}
