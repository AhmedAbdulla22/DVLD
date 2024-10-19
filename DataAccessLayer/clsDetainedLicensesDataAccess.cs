using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataAccessLayer
{
    public static class clsDetainedLicensesDataAccess
    {
        public static int AddNewDetainedLicense(int LicenseID, DateTime DetainDate, decimal FineFees, bool IsReleased,DateTime ReleaseDate, int ReleasedByUserID,int ReleaseApplicationID, int CreatedByUserID)
        {
            int NewLicenseID = -1;

            using (var sqlConnection = new SqlConnection(DataAccessLayerSetting.connectionString))
            {
                var query = @"INSERT INTO DetainedLicenses
           (LicenseID
            ,DetainDate
            ,FineFees
            ,IsReleased
            ,ReleaseDate
            ,ReleasedByUserID
            ,ReleaseApplicationID
            ,CreatedByUserID)
     VALUES
            (@LicenseID
            ,@DetainDate
            ,@FineFees
            ,@IsReleased
            ,@ReleaseDate
            ,@ReleasedByUserID
            ,@ReleaseApplicationID
            ,@CreatedByUserID)

SELECT Scope_Identity();";

                using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@LicenseID", LicenseID);
                    sqlCommand.Parameters.AddWithValue("@DetainDate", DetainDate);
                    sqlCommand.Parameters.AddWithValue("@FineFees", FineFees);
                    sqlCommand.Parameters.AddWithValue("@IsReleased", IsReleased);
                    DataAccessLayerSetting.safeParameterAdding<DateTime>(sqlCommand, "@ReleaseDate", ReleaseDate);
                    DataAccessLayerSetting.safeParameterAdding<int>(sqlCommand, "@ReleasedByUserID", ReleasedByUserID);
                    DataAccessLayerSetting.safeParameterAdding<int>(sqlCommand, "@ReleaseApplicationID", ReleaseApplicationID);
                    sqlCommand.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);


                    try
                    {
                        sqlConnection.Open();

                        object result = sqlCommand.ExecuteScalar();

                        if (result != null)
                        {
                            NewLicenseID = Convert.ToInt32(result);
                        }
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message);
                    }


                }
            }
            return NewLicenseID;
        }
        public static bool UpdateDetainedLicense(int DetainID, int LicenseID, DateTime DetainDate, decimal FineFees, bool IsReleased, DateTime ReleaseDate, int ReleasedByUserID, int ReleaseApplicationID, int CreatedByUserID)
        {
            bool isUpdated = false;

            using (var sqlConnection = new SqlConnection(DataAccessLayerSetting.connectionString))
            {
                var query = @"Update DetainedLicenses
                              Set 
                                LicenseID            = @LicenseID
                               ,DetainDate           = @DetainDate
                               ,FineFees             = @FineFees
                               ,IsReleased           = @IsReleased
                               ,ReleaseDate          = @ReleaseDate
                               ,ReleasedByUserID     = @ReleasedByUserID
                               ,ReleaseApplicationID = @ReleaseApplicationID
                               ,CreatedByUserID      = @CreatedByUserID
                              Where DetainID = @DetainID;";

                using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                {


                    sqlCommand.Parameters.AddWithValue("@DetainID", DetainID);
                    sqlCommand.Parameters.AddWithValue("@LicenseID", LicenseID);
                    sqlCommand.Parameters.AddWithValue("@DetainDate", DetainDate);
                    sqlCommand.Parameters.AddWithValue("@FineFees", FineFees);
                    sqlCommand.Parameters.AddWithValue("@IsReleased", IsReleased);
                    DataAccessLayerSetting.safeParameterAdding<DateTime>(sqlCommand, "@ReleaseDate", ReleaseDate);
                    DataAccessLayerSetting.safeParameterAdding<int>(sqlCommand, "@ReleasedByUserID", ReleasedByUserID);
                    DataAccessLayerSetting.safeParameterAdding<int>(sqlCommand, "@ReleaseApplicationID", ReleaseApplicationID);
                    sqlCommand.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);


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
        //public static bool GetDetainedLicenseByDetainID(int DetainID,ref int LicenseID,ref DateTime DetainDate,ref decimal FineFees,ref bool IsReleased,ref DateTime ReleaseDate,ref int ReleasedByUserID,ref int ReleaseApplicationID,ref int CreatedByUserID)
        //{
        //    bool isExist = false;

        //    using (var sqlConnection = new SqlConnection(DataAccessLayerSetting.connectionString))
        //    {
        //        var query = @"SELECT * FROM DetainedLicenses Where LicenseID = @LicenseID;";

        //        using (var sqlCommand = new SqlCommand(query, sqlConnection))
        //        {
        //            sqlCommand.Parameters.AddWithValue("@LicenseID", LicenseID);
        //            try
        //            {
        //                sqlConnection.Open();

        //                using (SqlDataReader reader = sqlCommand.ExecuteReader())
        //                {
        //                    if (reader.Read())
        //                    {
        //                        ApplicationID = (int)reader["ApplicationID"];
        //                        DriverID = (int)reader["DriverID"];
        //                        LicenseClass = (int)reader["LicenseClass"];
        //                        ApplicationID = (int)reader["ApplicationID"];
        //                        ApplicationID = (int)reader["ApplicationID"];
        //                        IssueDate = (DateTime)reader["IssueDate"];
        //                        ExpirationDate = (DateTime)reader["ExpirationDate"];

        //                        Notes = (reader["Notes"] != DBNull.Value) ? (string)reader["Notes"] : "";

        //                        IsActive = (bool)reader["IsActive"];
        //                        IssueReason = (byte)reader["IssueReason"];
        //                        PaidFees = (decimal)reader["PaidFees"];
        //                        CreatedByUserID = (int)reader["CreatedByUserID"];
        //                        isExist = true;
        //                    }

        //                }

        //            }
        //            catch (Exception ex)
        //            {
        //                MessageBox.Show(ex.Message);
        //            }

        //        }

        //    }

        //    return isExist;
        //}
        public static bool GetDetainedLicenseByLicenseID(int LicenseID,ref int DetainID, ref DateTime DetainDate,ref decimal FineFees,ref bool IsReleased,ref DateTime ReleaseDate,ref int ReleasedByUserID,ref int ReleaseApplicationID,ref int CreatedByUserID)
        {
            bool isExist = false;

            using (var sqlConnection = new SqlConnection(DataAccessLayerSetting.connectionString))
            {
                var query = @"SELECT * FROM DetainedLicenses 
                              Where DetainedLicenses.LicenseID = @LicenseID AND DetainedLicenses.IsReleased = 0;";

                using (var sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@LicenseID", LicenseID);
                    try
                    {
                        sqlConnection.Open();

                        using (SqlDataReader reader = sqlCommand.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                DetainID = (int)reader["DetainID"];
                                DetainDate = (DateTime)reader["DetainDate"];
                                FineFees = (decimal)reader["FineFees"];
                                IsReleased = (bool)reader["IsReleased"];
                                ReleaseDate = (reader["ReleaseDate"] != DBNull.Value) ? (DateTime)reader["ReleaseDate"] : DateTime.MinValue;
                                ReleaseApplicationID = (reader["ReleaseApplicationID"] != DBNull.Value) ? (int)reader["ReleaseApplicationID"] : -1;
                                ReleasedByUserID = (reader["ReleasedByUserID"] != DBNull.Value) ? (int)reader["ReleasedByUserID"] : -1;
                                CreatedByUserID = (int)reader["CreatedByUserID"];
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
        public static bool GetDetainedLicenseByDetainID(int DetainID, ref int LicenseID, ref DateTime DetainDate, ref decimal FineFees, ref bool IsReleased, ref DateTime ReleaseDate, ref int ReleasedByUserID, ref int ReleaseApplicationID, ref int CreatedByUserID)
        {
            bool isExist = false;

            using (var sqlConnection = new SqlConnection(DataAccessLayerSetting.connectionString))
            {
                var query = @"SELECT * FROM DetainedLicenses Where DetainID = @DetainID;";

                using (var sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@DetainID", DetainID);
                    try
                    {
                        sqlConnection.Open();

                        using (SqlDataReader reader = sqlCommand.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                LicenseID = (int)reader["LicenseID"];
                                DetainDate = (DateTime)reader["DetainDate"];
                                FineFees = (decimal)reader["FineFees"];
                                IsReleased = (bool)reader["IsReleased"];
                                ReleaseDate = (reader["ReleaseDate"] != DBNull.Value) ? (DateTime)reader["ReleaseDate"] : DateTime.MinValue;
                                ReleaseApplicationID = (reader["ReleaseApplicationID"] != DBNull.Value) ? (int)reader["ReleaseApplicationID"] : -1;
                                ReleasedByUserID = (reader["ReleasedByUserID"] != DBNull.Value) ? (int)reader["ReleasedByUserID"] : -1;
                                CreatedByUserID = (int)reader["CreatedByUserID"];
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
        public static DataTable getAllDetainedLicense()
        {

            DataTable dt = new DataTable();

            using (SqlConnection sqlConnection = new SqlConnection(DataAccessLayerSetting.connectionString))
            {
                var query = @"SELECT    'D.ID' = DL.DetainID           
                               ,'L.ID' = DL.LicenseID    
                               ,'D.Date' = DL.DetainDate
                               ,'Is Released' = DL.IsReleased          
                               ,'Fine Fees' = DL.FineFees            
                               ,'Release Date' = DL.ReleaseDate  
                               ,'N.No' = People.NationalNo
                               ,'Full Name' = People.FirstName + ' ' + People.SecondName + ' ' + People.ThirdName + ' ' + People.LastName    
                               ,'Release App ID' = ReleaseApplicationID
                                  FROM DetainedLicenses DL
								  INNER JOIN Licenses ON Licenses.LicenseID = DL.LicenseID
								  INNER JOIN Drivers ON Drivers.DriverID = Licenses.DriverID
								  INNER JOIN People ON People.PersonID = Drivers.PersonID;";
                using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                {

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
        public static DataTable getAllDetainedLicenseByIsReleased(bool IsReleased)
        {
            DataTable dt = new DataTable();

            using (SqlConnection sqlConnection = new SqlConnection(DataAccessLayerSetting.connectionString))
            {
                var query = @"SELECT    
                                'D.ID' = DL.DetainID           
                               ,'L.ID' = DL.LicenseID    
                               ,'D.Date' = DL.DetainDate
                               ,'Is Released' = DL.IsReleased          
                               ,'Fine Fees' = DL.FineFees            
                               ,'Release Date' = DL.ReleaseDate  
                               ,'N.No' = People.NationalNo
                               ,'Full Name' = People.FirstName + ' ' + People.SecondName + ' ' + People.ThirdName + ' ' + People.LastName    
                               ,'Release App ID' = ReleaseApplicationID
                                  FROM DetainedLicenses DL
								  INNER JOIN Licenses ON Licenses.LicenseID = DL.LicenseID
								  INNER JOIN Drivers ON Drivers.DriverID = Licenses.DriverID
								  INNER JOIN People ON People.PersonID = Drivers.PersonID
                          Where DL.IsReleased = @IsReleased;";
                using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@IsReleased", IsReleased);

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
        public static DataTable getAllDetainedLicenseByFullName(string FullName)
        {
            DataTable dt = new DataTable();

            using (SqlConnection sqlConnection = new SqlConnection(DataAccessLayerSetting.connectionString))
            {
                var query = @"SELECT    
                                'D.ID' = DL.DetainID           
                               ,'L.ID' = DL.LicenseID    
                               ,'D.Date' = DL.DetainDate
                               ,'Is Released' = DL.IsReleased          
                               ,'Fine Fees' = DL.FineFees            
                               ,'Release Date' = DL.ReleaseDate  
                               ,'N.No' = People.NationalNo
                               ,'Full Name' = People.FirstName + ' ' + People.SecondName + ' ' + People.ThirdName + ' ' + People.LastName    
                               ,'Release App ID' = ReleaseApplicationID
                                  FROM DetainedLicenses DL
								  INNER JOIN Licenses ON Licenses.LicenseID = DL.LicenseID
								  INNER JOIN Drivers ON Drivers.DriverID = Licenses.DriverID
								  INNER JOIN People ON People.PersonID = Drivers.PersonID
                           Where (People.FirstName + ' ' + People.SecondName + ' ' + People.ThirdName + ' ' + People.LastName) LIKE @FullName + '%';";
                using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@FullName", FullName);

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
        public static DataTable getAllDetainedLicenseByNationalNo(string NationalNo)
        {
            DataTable dt = new DataTable();

            using (SqlConnection sqlConnection = new SqlConnection(DataAccessLayerSetting.connectionString))
            {
                var query = @"SELECT    
                                'D.ID' = DL.DetainID           
                               ,'L.ID' = DL.LicenseID    
                               ,'D.Date' = DL.DetainDate
                               ,'Is Released' = DL.IsReleased          
                               ,'Fine Fees' = DL.FineFees            
                               ,'Release Date' = DL.ReleaseDate  
                               ,'N.No' = People.NationalNo
                               ,'Full Name' = People.FirstName + ' ' + People.SecondName + ' ' + People.ThirdName + ' ' + People.LastName    
                               ,'Release App ID' = ReleaseApplicationID
                                  FROM DetainedLicenses DL
								  INNER JOIN Licenses ON Licenses.LicenseID = DL.LicenseID
								  INNER JOIN Drivers ON Drivers.DriverID = Licenses.DriverID
								  INNER JOIN People ON People.PersonID = Drivers.PersonID
                          Where People.NationalNo = @NationalNo;";
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
        public static DataTable getAllDetainedLicenseByLicenseID(int LicenseID)
        {
            DataTable dt = new DataTable();

            using (SqlConnection sqlConnection = new SqlConnection(DataAccessLayerSetting.connectionString))
            {
                var query = @"SELECT    
                                'D.ID' = DL.DetainID           
                               ,'L.ID' = DL.LicenseID    
                               ,'D.Date' = DL.DetainDate
                               ,'Is Released' = DL.IsReleased          
                               ,'Fine Fees' = DL.FineFees            
                               ,'Release Date' = DL.ReleaseDate  
                               ,'N.No' = People.NationalNo
                               ,'Full Name' = People.FirstName + ' ' + People.SecondName + ' ' + People.ThirdName + ' ' + People.LastName    
                               ,'Release App ID' = ReleaseApplicationID
                                  FROM DetainedLicenses DL
								  INNER JOIN Licenses ON Licenses.LicenseID = DL.LicenseID
								  INNER JOIN Drivers ON Drivers.DriverID = Licenses.DriverID
								  INNER JOIN People ON People.PersonID = Drivers.PersonID
                          Where DL.LicenseID = @LicenseID;";
                using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@LicenseID", LicenseID);

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
