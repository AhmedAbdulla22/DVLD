using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Data.SqlClient;
using System.Net;
using System.Windows.Forms;
using System;

namespace DataAccessLayer
{
    public static class ClsUserDataAccess
    {
        public static bool GetUserByUserNameAndPassword(string UserName,string Password,ref bool isActive)
        {
            bool isExist = false;

            using (var sqlConnection = new SqlConnection(DataAccessLayerSetting.connectionString))
            {
                var query = @"SELECT * FROM Users Where UserName = @UserName AND Password = @Password;";

                using (var sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@UserName", UserName);
                    sqlCommand.Parameters.AddWithValue("@Password", Password);

                    try
                    {
                        sqlConnection.Open();

                        using (SqlDataReader reader = sqlCommand.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                UserName = (string)reader["UserName"];
                                Password = (string)reader["Password"];
                                isActive = (bool)reader["isActive"];
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
