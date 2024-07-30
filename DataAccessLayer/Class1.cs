﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;


namespace DataAccessLayer
{
    
    
    public static class DataAccessPeopleLayer
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
                var query = @"SELECT NationalNo, FirstName, SecondName, ThirdName, LastName, DateOfBirth,
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
        
        public static bool UpdatePerson(int PersonID,string fname, string Sname, string Tname, string Lname, string NationalNo, DateTime DateOfBirth, short gender, string Phone, string Email, int CountryID, string Address, string ImagePath)
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
                    safeParameterAdding<string>(sqlCommand,"@FirstName", fname);
                    safeParameterAdding<string>(sqlCommand,"@SecondName", Sname);
                    safeParameterAdding<string>(sqlCommand,"@ThirdName", Tname);
                    safeParameterAdding<string>(sqlCommand,"@LastName", Lname);
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
    }

    
    public static class CountryDataAccessLayer
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
