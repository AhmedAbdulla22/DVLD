using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;


namespace DataAccessLayer
{


    public static class ClsPersonDataAccess
    {
        private static void safeParameterAdding<T>(SqlCommand sqlCommand,string parameterName, T value)
        {
            if (value == null || (value is string str && string.IsNullOrEmpty(str)) )
            {
                sqlCommand.Parameters.AddWithValue(parameterName, DBNull.Value);
            }
            else
            {
                sqlCommand.Parameters.AddWithValue(parameterName, value);
            }
        }

        public static DataTable getAllPeople()
        {
            DataTable dataTable = new DataTable();
            
            using (SqlConnection sqlConnection = new SqlConnection(DataAccessLayerSetting.connectionString))
            {
                var query = @"SELECT PersonID,NationalNo, FirstName, SecondName, ThirdName, LastName, DateOfBirth,
                            CASE
                             When People.Gendor = 0 then 'Male'
                             Else 'Female'
                             END as Gender,
                            Address,Phone,Email,Countries.CountryName as Nationality,ImagePath
                              FROM People INNER JOIN
                            Countries ON People.NationalityCountryID = Countries.CountryID;";
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

        public static bool GetPersonInfoByID(int PersonID,ref string FirstName,ref string SecondName,ref string ThirdName,ref string LastName, ref string NationalNo, ref DateTime DateOfBirth,ref short gender,ref string Phone,ref string Email,ref int CountryID,ref string Address,ref string ImagePath)
        {
            bool isExist = false;
            using (var sqlConnection = new SqlConnection(DataAccessLayerSetting.connectionString))
            {
                var query = @"SELECT * FROM People Where PersonID = @PersonID;";

                using (var sqlCommand = new SqlCommand(query,sqlConnection))
                {
                    safeParameterAdding<int>(sqlCommand,"@PersonID",PersonID);

                    try 
                    {
                        sqlConnection.Open();

                        using (SqlDataReader reader = sqlCommand.ExecuteReader())
                        {
                            if(reader.Read())
                            {
                                FirstName = (string)reader["FirstName"];
                                SecondName = (string)reader["SecondName"];
                                ThirdName = (string)reader["ThirdName"];
                                LastName = (string)reader["LastName"];
                                Phone = (string)reader["Phone"];
                                Address = (string)reader["LastName"];
                                NationalNo = (string)reader["NationalNo"];

                                DateOfBirth = (DateTime)reader["DateOfBirth"];
                                CountryID = (int)reader["NationalityCountryID"];
                                byte bytegender = (byte)reader["Gendor"];
                                gender = (short)bytegender;

                                if (reader["Email"] != DBNull.Value)
                                {
                                    Email = (string)reader["Email"];
                                }
                                else
                                {
                                    Email = "";
                                }

                                if (reader["ImagePath"] != DBNull.Value)
                                {
                                    ImagePath = (string)reader["ImagePath"];
                                }
                                else
                                {
                                    ImagePath = "";
                                }

                                isExist = true;
                            }

                        }

                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                }

            }
            return isExist;
        }

        public static bool GetPersonInfoByNationalNo(ref int PersonID, ref string FirstName, ref string SecondName, ref string ThirdName, ref string LastName, string NationalNo, ref DateTime DateOfBirth, ref short gender, ref string Phone, ref string Email, ref int CountryID, ref string Address, ref string ImagePath)
        {
            bool isExist = false;
            using (var sqlConnection = new SqlConnection(DataAccessLayerSetting.connectionString))
            {
                var query = @"SELECT * FROM People Where NationalNo = @NationalNo;";

                using (var sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    safeParameterAdding<string>(sqlCommand, "@NationalNo", NationalNo);

                    try
                    {
                        sqlConnection.Open();

                        using (SqlDataReader reader = sqlCommand.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                PersonID = (int)reader["PersonID"];
                                FirstName = (string)reader["FirstName"];
                                SecondName = (string)reader["SecondName"];
                                ThirdName = (string)reader["ThirdName"];
                                LastName = (string)reader["LastName"];
                                Phone = (string)reader["Phone"];
                                Address = (string)reader["LastName"];
                                DateOfBirth = (DateTime)reader["DateOfBirth"];
                                CountryID = (int)reader["NationalityCountryID"];
                                byte bytegender = (byte)reader["Gendor"];
                                gender = (short)bytegender;

                                if (reader["Email"] != DBNull.Value)
                                {
                                    Email = (string)reader["Email"];
                                }
                                else
                                {
                                    Email = "";
                                }

                                if (reader["ImagePath"] != DBNull.Value)
                                {
                                    ImagePath = (string)reader["ImagePath"];
                                }
                                else
                                {
                                    ImagePath = "";
                                }

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

        public static int AddNewPerson( string fname,  string Sname,  string Tname,  string Lname,  string NationalNo,  DateTime DateOfBirth,  short gender,  string Phone,  string Email,  int CountryID,  string Address, string ImagePath)
        {
            int newPersonID = -1;

            using (var sqlConnection = new SqlConnection(DataAccessLayerSetting.connectionString))
            {
                var query = @"INSERT INTO People
           (NationalNo
           ,FirstName
           ,SecondName
           ,ThirdName
           ,LastName
           ,DateOfBirth
           ,Gendor
           ,Address
           ,Phone
           ,Email
           ,NationalityCountryID
           ,ImagePath)
             VALUES
           (@NationalNo
           ,@FirstName
           ,@SecondName
           ,@ThirdName
           ,@LastName
           ,@DateOfBirth
           ,@Gendor
           ,@Address
           ,@Phone
           ,@Email
           ,@NationalityCountryID
           ,@ImagePath);

SELECT Scope_Identity();";

                using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    safeParameterAdding<string>(sqlCommand,"@NationalNo",NationalNo);
                    safeParameterAdding<string>(sqlCommand, "@FirstName",fname);
                    safeParameterAdding<string>(sqlCommand,"@SecondName",Sname);
                    safeParameterAdding<string>(sqlCommand,"@ThirdName",Tname);
                    safeParameterAdding<string>(sqlCommand,"@LastName",Lname);
                    safeParameterAdding<DateTime>(sqlCommand, "@DateOfBirth",DateOfBirth);
                    safeParameterAdding<short>(sqlCommand, "@Gendor",gender);
                    safeParameterAdding<string>(sqlCommand, "@Address",Address);
                    safeParameterAdding<string>(sqlCommand, "@Phone",Phone);
                    safeParameterAdding<int>(sqlCommand, "@NationalityCountryID",CountryID);
                    safeParameterAdding<string>(sqlCommand, "@Email",Email);
                    safeParameterAdding<string>(sqlCommand, "@ImagePath", ImagePath);


                    try
                    {
                        sqlConnection.Open();

                        object result = sqlCommand.ExecuteScalar();

                        if (result != null)
                        {
                            newPersonID = Convert.ToInt32(result);
                        }
                    }
                    catch(Exception e) 
                    {
                        MessageBox.Show(e.Message);
                    }


                }
            }
            return newPersonID;
        }
        
        public static bool UpdatePerson(int PersonID,string FirstName, string SecondName, string ThirdName, string LastName, string NationalNo, DateTime DateOfBirth, short gender, string Phone, string Email, int CountryID, string Address, string ImagePath)
        {
            bool isUpdated = false;

            using (var sqlConnection = new SqlConnection(DataAccessLayerSetting.connectionString))
            {
                var query = @"Update People
                              Set NationalNo = @NationalNo
                               ,FirstName = @FirstName
                               ,SecondName = @SecondName
                               ,ThirdName = @ThirdName
                               ,LastName = @LastName
                               ,DateOfBirth = @DateOfBirth
                               ,Gendor = @Gendor
                               ,Address = @Address
                               ,Phone = @Phone
                               ,Email = @Email
                               ,NationalityCountryID = @NationalityCountryID
                               ,ImagePath = @ImagePath
                                Where PersonID = @PersonID;";

                using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    
                    //Safe Paremeter Adding
                    safeParameterAdding<string>(sqlCommand, "@NationalNo", NationalNo);
                    safeParameterAdding<string>(sqlCommand,"@FirstName", FirstName);
                    safeParameterAdding<string>(sqlCommand,"@SecondName", SecondName);
                    safeParameterAdding<string>(sqlCommand,"@ThirdName", ThirdName);
                    safeParameterAdding<string>(sqlCommand,"@LastName", LastName);
                    safeParameterAdding<string>(sqlCommand,"@Phone", Phone);
                    safeParameterAdding<string>(sqlCommand,"@Address", Address);
                    safeParameterAdding<string>(sqlCommand,"@Email", Email);
                    safeParameterAdding<string>(sqlCommand,"@ImagePath", ImagePath);
                    safeParameterAdding<short>(sqlCommand,"@Gendor", gender);
                    safeParameterAdding<int>(sqlCommand,"@PersonID", PersonID);
                    safeParameterAdding<int>(sqlCommand, "@NationalityCountryID", CountryID);
                    safeParameterAdding<DateTime>(sqlCommand, "@DateOfBirth", DateOfBirth);

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

        public static bool DeletePerson(int PersonID)
        {
            bool isDeleted = false;
            using (var sqlConnection = new SqlConnection(DataAccessLayerSetting.connectionString))
            {
                var query = @"DELETE FROM People
                              Where PersonID = @PersonID;";

                using (var sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@PersonID", PersonID);

                    try
                    {
                        sqlConnection.Open();

                        if (sqlCommand.ExecuteNonQuery() > 0)
                        {
                            isDeleted = true;
                        }

                    }
                    catch(Exception ex) 
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            return isDeleted;
        }

        public static DataTable GetPersonByPersonID(int PersonID)
        {
            DataTable dt = new DataTable();

            using (SqlConnection sqlConnection = new SqlConnection(DataAccessLayerSetting.connectionString))
            {
                var query = @"SELECT PersonID,NationalNo, FirstName, SecondName, ThirdName, LastName, DateOfBirth,
                            CASE
                             When People.Gendor = 0 then 'Male'
                             Else 'Female'
                             END as Gender,
                            Address,Phone,Email,Countries.CountryName as Nationality,ImagePath
                              FROM People INNER JOIN
                            Countries ON People.NationalityCountryID = Countries.CountryID
                            Where PersonID = @PersonID;";
                using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@PersonID", PersonID);


                    try
                    {
                        sqlConnection.Open();

                        using (SqlDataReader reader = sqlCommand.ExecuteReader())
                        {
                            dt.Load(reader);
                        }

                    }
                    catch (Exception ex)
                    {
                        //
                        MessageBox.Show(ex.Message);
                    }
                }


            }



            return dt;
        }

        public static DataTable GetPersonByNationalNo(string NationalNo)
        {
            DataTable dt = new DataTable();

            using (SqlConnection sqlConnection = new SqlConnection(DataAccessLayerSetting.connectionString))
            {
                var query = @"SELECT PersonID,NationalNo, FirstName, SecondName, ThirdName, LastName, DateOfBirth,
                            CASE
                             When People.Gendor = 0 then 'Male'
                             Else 'Female'
                             END as Gender,
                            Address,Phone,Email,Countries.CountryName as Nationality,ImagePath
                              FROM People INNER JOIN
                            Countries ON People.NationalityCountryID = Countries.CountryID
                            Where NationalNo LIKE @NationalNo + '%';";
                using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@NationalNo", NationalNo);


                    try
                    {
                        sqlConnection.Open();

                        using (SqlDataReader reader = sqlCommand.ExecuteReader())
                        {
                            dt.Load(reader);
                        }

                    }
                    catch (Exception ex)
                    {
                        //
                        MessageBox.Show(ex.Message);
                    }
                }


            }



            return dt;
        }

        public static DataTable GetPersonByFirstName(string FirstName)
        {
            DataTable dt = new DataTable();

            using (SqlConnection sqlConnection = new SqlConnection(DataAccessLayerSetting.connectionString))
            {
                var query = @"SELECT PersonID,NationalNo, FirstName, SecondName, ThirdName, LastName, DateOfBirth,
                            CASE
                             When People.Gendor = 0 then 'Male'
                             Else 'Female'
                             END as Gender,
                            Address,Phone,Email,Countries.CountryName as Nationality,ImagePath
                              FROM People INNER JOIN
                            Countries ON People.NationalityCountryID = Countries.CountryID
                            Where FirstName LIKE @FirstName + '%';";
                using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@FirstName", FirstName);


                    try
                    {
                        sqlConnection.Open();

                        using (SqlDataReader reader = sqlCommand.ExecuteReader())
                        {
                            dt.Load(reader);
                        }

                    }
                    catch (Exception ex)
                    {
                        //
                        MessageBox.Show(ex.Message);
                    }
                }


            }



            return dt;
        }

        public static DataTable GetPersonBySecondName(string SecondName)
        {
            DataTable dt = new DataTable();

            using (SqlConnection sqlConnection = new SqlConnection(DataAccessLayerSetting.connectionString))
            {
                var query = @"SELECT PersonID,NationalNo, FirstName, SecondName, ThirdName, LastName, DateOfBirth,
                            CASE
                             When People.Gendor = 0 then 'Male'
                             Else 'Female'
                             END as Gender,
                            Address,Phone,Email,Countries.CountryName as Nationality,ImagePath
                              FROM People INNER JOIN
                            Countries ON People.NationalityCountryID = Countries.CountryID
                            Where SecondName LIKE @SecondName + '%';";
                using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@SecondName", SecondName);


                    try
                    {
                        sqlConnection.Open();

                        using (SqlDataReader reader = sqlCommand.ExecuteReader())
                        {
                            dt.Load(reader);
                        }

                    }
                    catch (Exception ex)
                    {
                        //
                        MessageBox.Show(ex.Message);
                    }
                }


            }



            return dt;
        }

        public static DataTable GetPersonByThirdName(string ThirdName)
        {
            DataTable dt = new DataTable();

            using (SqlConnection sqlConnection = new SqlConnection(DataAccessLayerSetting.connectionString))
            {
                var query = @"SELECT PersonID,NationalNo, FirstName, SecondName, ThirdName, LastName, DateOfBirth,
                            CASE
                             When People.Gendor = 0 then 'Male'
                             Else 'Female'
                             END as Gender,
                            Address,Phone,Email,Countries.CountryName as Nationality,ImagePath
                              FROM People INNER JOIN
                            Countries ON People.NationalityCountryID = Countries.CountryID
                            Where ThirdName LIKE @ThirdName + '%';";
                using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@ThirdName", ThirdName);


                    try
                    {
                        sqlConnection.Open();

                        using (SqlDataReader reader = sqlCommand.ExecuteReader())
                        {
                            dt.Load(reader);
                        }

                    }
                    catch (Exception ex)
                    {
                        //
                        MessageBox.Show(ex.Message);
                    }
                }


            }



            return dt;
        }

        public static DataTable GetPersonByLastName(string LastName)
        {
            DataTable dt = new DataTable();

            using (SqlConnection sqlConnection = new SqlConnection(DataAccessLayerSetting.connectionString))
            {
                var query = @"SELECT PersonID,NationalNo, FirstName, SecondName, ThirdName, LastName, DateOfBirth,
                            CASE
                             When People.Gendor = 0 then 'Male'
                             Else 'Female'
                             END as Gender,
                            Address,Phone,Email,Countries.CountryName as Nationality,ImagePath
                              FROM People INNER JOIN
                            Countries ON People.NationalityCountryID = Countries.CountryID
                            Where LastName LIKE @LastName + '%';";
                using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@LastName", LastName);


                    try
                    {
                        sqlConnection.Open();

                        using (SqlDataReader reader = sqlCommand.ExecuteReader())
                        {
                            dt.Load(reader);
                        }

                    }
                    catch (Exception ex)
                    {
                        //
                        MessageBox.Show(ex.Message);
                    }
                }


            }



            return dt;
        }

        public static DataTable GetPersonByNationality(string Nationality)
        {
            DataTable dt = new DataTable();

            using (SqlConnection sqlConnection = new SqlConnection(DataAccessLayerSetting.connectionString))
            {
                var query = @"SELECT PersonID,NationalNo, FirstName, SecondName, ThirdName, LastName, DateOfBirth,
                            CASE
                             When People.Gendor = 0 then 'Male'
                             Else 'Female'
                             END as Gender,
                            Address,Phone,Email,Countries.CountryName as Nationality,ImagePath
                              FROM People INNER JOIN
                            Countries ON People.NationalityCountryID = Countries.CountryID
                            Where Countries.CountryName LIKE @Nationality + '%';";
                using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@Nationality", Nationality);


                    try
                    {
                        sqlConnection.Open();

                        using (SqlDataReader reader = sqlCommand.ExecuteReader())
                        {
                            dt.Load(reader);
                        }

                    }
                    catch (Exception ex)
                    {
                        //
                        MessageBox.Show(ex.Message);
                    }
                }


            }



            return dt;
        }

        public static DataTable GetPersonByPhone(string Phone)
        {
            DataTable dt = new DataTable();

            using (SqlConnection sqlConnection = new SqlConnection(DataAccessLayerSetting.connectionString))
            {
                var query = @"SELECT PersonID,NationalNo, FirstName, SecondName, ThirdName, LastName, DateOfBirth,
                            CASE
                             When People.Gendor = 0 then 'Male'
                             Else 'Female'
                             END as Gender,
                            Address,Phone,Email,Countries.CountryName as Nationality,ImagePath
                              FROM People INNER JOIN
                            Countries ON People.NationalityCountryID = Countries.CountryID
                            Where Phone LIKE @Phone + '%';";
                using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@Phone", Phone);


                    try
                    {
                        sqlConnection.Open();

                        using (SqlDataReader reader = sqlCommand.ExecuteReader())
                        {
                            dt.Load(reader);
                        }

                    }
                    catch (Exception ex)
                    {
                        //
                        MessageBox.Show(ex.Message);
                    }
                }


            }



            return dt;
        }

        public static DataTable GetPersonByGender(string Gender)
        {
            DataTable dt = new DataTable();

            using (SqlConnection sqlConnection = new SqlConnection(DataAccessLayerSetting.connectionString))
            {
                var query = @"SELECT PersonID,NationalNo, FirstName, SecondName, ThirdName, LastName, DateOfBirth,
                            CASE
                             When People.Gendor = 0 then 'Male'
                             Else 'Female'
                             END as Gender,
                            Address,Phone,Email,Countries.CountryName as Nationality,ImagePath
                              FROM People INNER JOIN
                            Countries ON People.NationalityCountryID = Countries.CountryID
                            Where 
                                  CASE
                                  WHEN People.Gendor = 0 then 'Male'
                                  ELSE 'Female'
                                  END
                                  LIKE @Gender + '%';";
                using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@Gender", Gender);


                    try
                    {
                        sqlConnection.Open();

                        using (SqlDataReader reader = sqlCommand.ExecuteReader())
                        {
                            dt.Load(reader);
                        }

                    }
                    catch (Exception ex)
                    {
                        //
                        MessageBox.Show(ex.Message);
                    }
                }


            }



            return dt;
        }


        public static DataTable GetPersonByEmail(string Email)
        {
            DataTable dt = new DataTable();

            using (SqlConnection sqlConnection = new SqlConnection(DataAccessLayerSetting.connectionString))
            {
                var query = @"SELECT PersonID,NationalNo, FirstName, SecondName, ThirdName, LastName, DateOfBirth,
                            CASE
                             When People.Gendor = 0 then 'Male'
                             Else 'Female'
                             END as Gender,
                            Address,Phone,Email,Countries.CountryName as Nationality,ImagePath
                              FROM People INNER JOIN
                            Countries ON People.NationalityCountryID = Countries.CountryID
                            Where Email LIKE @Email + '%';";
                using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@Email", Email);


                    try
                    {
                        sqlConnection.Open();

                        using (SqlDataReader reader = sqlCommand.ExecuteReader())
                        {
                            dt.Load(reader);
                        }

                    }
                    catch (Exception ex)
                    {
                        //
                        MessageBox.Show(ex.Message);
                    }
                }


            }



            return dt;
        }


    }
}
