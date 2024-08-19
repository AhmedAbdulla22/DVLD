using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Data.SqlClient;
using System.Net;
using System.Windows.Forms;
using System;
using System.Data;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace DataAccessLayer
{
    public static class ClsUserDataAccess
    {
        public static bool GetUserByUserNameAndPassword(string UserName,string Password,ref int UserID, ref int PersonID, ref bool isActive)
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
                                isActive = (bool)reader["isActive"];
                                UserID = (int)reader["UserID"];
                                PersonID = (int)reader["PersonID"];
                                

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

        public static bool GetUserByUserName(string UserName, ref int UserID, ref int PersonID,ref string Password, ref bool isActive)
        {
            bool isExist = false;

            using (var sqlConnection = new SqlConnection(DataAccessLayerSetting.connectionString))
            {
                var query = @"SELECT * FROM Users Where UserName = @UserName;";

                using (var sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@UserName", UserName);


                    try
                    {
                        sqlConnection.Open();

                        using (SqlDataReader reader = sqlCommand.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                Password = (string)reader["Password"];
                                isActive = (bool)reader["isActive"];
                                PersonID = (int)reader["PersonID"];
                                UserID = (int)reader["UserID"];

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

        public static bool GetUserByPersonID(int PersonID, ref int UserID, ref string UserName, ref string Password, ref bool isActive)
        {
            bool isExist = false;

            using (var sqlConnection = new SqlConnection(DataAccessLayerSetting.connectionString))
            {
                var query = @"SELECT * FROM Users Where PersonID = @PersonID;";

                using (var sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@PersonID", PersonID);
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
                                UserID = (int)reader["UserID"];
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

        public static bool GetUserByUserID(int UserID, ref string UserName, ref string Password, ref int PersonID, ref bool isActive)
        {
            bool isExist = false;

            using (var sqlConnection = new SqlConnection(DataAccessLayerSetting.connectionString))
            {
                var query = @"SELECT * FROM Users Where UserID = @UserID;";

                using (var sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@UserID", UserID);
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
                                UserID = (int)reader["UserID"];
                                PersonID = (int)reader["PersonID"];
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

        public static DataTable GetAllUsers()
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection sqlConnection = new SqlConnection(DataAccessLayerSetting.connectionString))
            {
                var query = @"SELECT Users.UserID, Users.PersonID, People.FirstName +' ' + People.SecondName + ' ' + People.ThirdName + ' ' + People.LastName as FullName,Users.UserName ,Users.IsActive
                                FROM     People INNER JOIN
                                Users ON People.PersonID = Users.PersonID;"; 
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

        public static int AddNewUser( int PersonID,string UserName,  string Password,  bool isActive)
        {
            int NewUserID = -1;

            using (var sqlConnection = new SqlConnection(DataAccessLayerSetting.connectionString))
            {
                var query = @"INSERT INTO Users
           (PersonID,UserName,Password,isActive)
             VALUES
           (@PersonID,@UserName,@Password,@isActive);

SELECT Scope_Identity();";

                using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@PersonID", PersonID);
                    sqlCommand.Parameters.AddWithValue("@UserName", UserName);
                    sqlCommand.Parameters.AddWithValue("@Password", Password);
                    sqlCommand.Parameters.AddWithValue("@isActive", isActive);

                    try
                    {
                        sqlConnection.Open();

                        object result = sqlCommand.ExecuteScalar();

                        if (result != null)
                        {
                            NewUserID = Convert.ToInt32(result);
                        }
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message);
                    }


                }
            }
            return NewUserID;
        }
    }
}
