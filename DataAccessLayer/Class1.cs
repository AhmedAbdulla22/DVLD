using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace DataAccessLayer
{
    public static class DataAccessPeopleLayer
    {
        public static DataTable getAllPeople()
        {
            DataTable dataTable = new DataTable();
            
            using (SqlConnection sqlConnection = new SqlConnection(DataAccessLayerSetting.connectionString))
            {
                var query = "SELECT*FROM People;";
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

        public static bool isNationalNumberExist(string NationalNumber)
        {
            bool isNationalNumberExist = false;

            using (SqlConnection sqlConnection = new SqlConnection(DataAccessLayerSetting.connectionString))
            {
                var query = @"SELECT 'A' FROM People
                                  Where NationalNo = @NationalNumber;";
                using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@NationalNumber", NationalNumber);

                    try
                    {
                        sqlConnection.Open();

                        if (sqlCommand.ExecuteScalar() != null)
                        {
                            isNationalNumberExist = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                
            }

                return isNationalNumberExist;
        }
    }

    public static class CountryDataAccessLayer
    {
        public static List<string> GetCountryList()
        {
            var list = new List<string>();

            using (SqlConnection sqlConnection = new SqlConnection(DataAccessLayerSetting.connectionString))
            {
                

                var query = "Select CountryName From Countries;";

                using ( SqlCommand sqlCommand = new SqlCommand( query, sqlConnection))
                {
                    try
                    {
                        sqlConnection.Open();

                        using (SqlDataReader reader = sqlCommand.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                list.Add(reader["CountryName"].ToString());
                            }
                        }

                        
                    }
                    catch(Exception ex) 
                    {
                            MessageBox.Show(ex.Message);
                    }
                    
                }

                return list;
            }
        }
    }
}
