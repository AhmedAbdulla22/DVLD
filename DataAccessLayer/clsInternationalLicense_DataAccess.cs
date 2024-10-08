using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataAccessLayer
{
    public class clsInternationalLicense_DataAccess
    {
        public static DataTable GetInternationalLicenseHistoryByPersonID(int PersonID)
        {
            DataTable dt = new DataTable();

            using (SqlConnection sqlConnection = new SqlConnection(DataAccessLayerSetting.connectionString))
            {
                var query = @"SELECT 'Int.License ID' = InternationalLicenseID
                              ,'Application ID' =ApplicationID
	                          ,'L.License ID' = IssuedUsingLocalLicenseID
                              ,'Issue Date' =IssueDate
                              ,'Expiration Date' =ExpirationDate
                              ,'Is Active'=IsActive
                          FROM InternationalLicenses
                          Inner JOIN Drivers On Drivers.DriverID = InternationalLicenses.DriverID 
                          Where Drivers.PersonID = @PersonID;";
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

        public static bool isDetained(int InternationalLicenseID)
        {
            bool isExist = false;

            using (var sqlConnection = new SqlConnection(DataAccessLayerSetting.connectionString))
            {
                var query = @"SELECT 'A' FROM DetainedLicenses
                              Where LicenseID = @InternationalLicenseID;";

                using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                {


                    sqlCommand.Parameters.AddWithValue("@InternationalLicenseID", InternationalLicenseID);


                    try
                    {
                        sqlConnection.Open();

                        if (sqlCommand.ExecuteNonQuery() > 0)
                        {
                            isExist = true;
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
        public static int AddNewInternationalLicense(int ApplicationID, int DriverID, int IssuedUsingLocalLicenseID, DateTime IssueDate, DateTime ExpirationDate, bool IsActive, int CreatedByUserID)
        {
            int NewInternationalLicenseID = -1;

            using (var sqlConnection = new SqlConnection(DataAccessLayerSetting.connectionString))
            {
                var query = @"INSERT INTO InternationalLicenses
           (ApplicationID
            ,DriverID
            ,IssuedUsingLocalLicenseID
            ,IssueDate
            ,ExpirationDate
            ,IsActive
            ,CreatedByUserID)
     VALUES
            (@ApplicationID
            ,@DriverID
            ,@IssuedUsingLocalLicenseID
            ,@IssueDate
            ,@ExpirationDate
            ,@IsActive
            ,@CreatedByUserID)

SELECT Scope_Identity();";

                using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                    sqlCommand.Parameters.AddWithValue("@DriverID", DriverID);
                    sqlCommand.Parameters.AddWithValue("@IssuedUsingLocalLicenseID", IssuedUsingLocalLicenseID);
                    sqlCommand.Parameters.AddWithValue("@IssueDate", IssueDate);
                    sqlCommand.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
                    sqlCommand.Parameters.AddWithValue("@IsActive", IsActive);
                    sqlCommand.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);


                    try
                    {
                        sqlConnection.Open();

                        object result = sqlCommand.ExecuteScalar();

                        if (result != null)
                        {
                            NewInternationalLicenseID = Convert.ToInt32(result);
                        }
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message);
                    }


                }
            }
            return NewInternationalLicenseID;
        }
        public static bool UpdateInternationalLicense(int InternationalLicenseID, int ApplicationID, int DriverID, int IssuedUsingLocalLicenseID, DateTime IssueDate, DateTime ExpirationDate,  bool IsActive, int CreatedByUserID)
        {
            bool isUpdated = false;

            using (var sqlConnection = new SqlConnection(DataAccessLayerSetting.connectionString))
            {
                var query = @"Update InternationalLicenses
                              Set 
                                ApplicationID = @ApplicationID 
                               ,DriverID   = @DriverID
                               ,IssuedUsingLocalLicenseID = @IssuedUsingLocalLicenseID
                               ,IssueDate = @IssueDate
                               ,ExpirationDate    = @ExpirationDate
                               ,IsActive = @IsActive
                               ,CreatedByUserID   = @CreatedByUserID
                              Where LicenseID = @InternationalLicenseID;";

                using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                {


                    sqlCommand.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                    sqlCommand.Parameters.AddWithValue("@DriverID", DriverID);
                    sqlCommand.Parameters.AddWithValue("@IssuedUsingLocalLicenseID", IssuedUsingLocalLicenseID);
                    sqlCommand.Parameters.AddWithValue("@IssueDate", IssueDate);
                    sqlCommand.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
                    sqlCommand.Parameters.AddWithValue("@IsActive", IsActive);
                    sqlCommand.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
                    sqlCommand.Parameters.AddWithValue("@InternationalLicenseID", InternationalLicenseID);


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
        public static bool GetInternationalLicenseByInternationalLicenseID(int InternationalLicenseID, ref int ApplicationID, ref int DriverID, ref int IssuedUsingLocalLicenseID, ref DateTime IssueDate, ref DateTime ExpirationDate, ref bool IsActive, ref int CreatedByUserID)
        {
            bool isExist = false;

            using (var sqlConnection = new SqlConnection(DataAccessLayerSetting.connectionString))
            {
                var query = @"SELECT * FROM InternationalLicense Where LicenseID = @InternationalLicenseID;";

                using (var sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@InternationalLicenseID", InternationalLicenseID);
                    try
                    {
                        sqlConnection.Open();

                        using (SqlDataReader reader = sqlCommand.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                ApplicationID = (int)reader["ApplicationID"];
                                DriverID = (int)reader["DriverID"];
                                IssuedUsingLocalLicenseID = (int)reader["IssuedUsingLocalLicenseID"];
                                ApplicationID = (int)reader["ApplicationID"];
                                ApplicationID = (int)reader["ApplicationID"];
                                IssueDate = (DateTime)reader["IssueDate"];
                                ExpirationDate = (DateTime)reader["ExpirationDate"];


                                IsActive = (bool)reader["IsActive"];
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
        public static bool GetInternationalLicenseByApplicationID(int ApplicationID, ref int InternationalLicenseID, ref int DriverID, ref int IssuedUsingLocalLicenseID, ref DateTime IssueDate, ref DateTime ExpirationDate, ref bool IsActive, ref int CreatedByUserID)
        {
            bool isExist = false;

            using (var sqlConnection = new SqlConnection(DataAccessLayerSetting.connectionString))
            {
                var query = @"SELECT * FROM InternationalLicenses 
                            Where ApplicationID = @ApplicationID;";

                using (var sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                    try
                    {
                        sqlConnection.Open();

                        using (SqlDataReader reader = sqlCommand.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                InternationalLicenseID = (int)reader["InternationalLicenseID"];
                                DriverID = (int)reader["DriverID"];
                                IssuedUsingLocalLicenseID = (int)reader["IssuedUsingLocalLicenseID"];
                                IssueDate = (DateTime)reader["IssueDate"];
                                ExpirationDate = (DateTime)reader["ExpirationDate"];


                                IsActive = (bool)reader["IsActive"];
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
        public static bool GetInternationalLicenseByLDLicenseID(int IssuedUsingLocalLicenseID, ref int InternationalLicenseID, ref int DriverID, ref int ApplicationID, ref DateTime IssueDate, ref DateTime ExpirationDate, ref bool IsActive, ref int CreatedByUserID)
        {
            bool isExist = false;

            using (var sqlConnection = new SqlConnection(DataAccessLayerSetting.connectionString))
            {
                var query = @"SELECT * FROM InternationalLicenses 
                            Where IssuedUsingLocalLicenseID = @IssuedUsingLocalLicenseID;";

                using (var sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@IssuedUsingLocalLicenseID", IssuedUsingLocalLicenseID);
                    try
                    {
                        sqlConnection.Open();

                        using (SqlDataReader reader = sqlCommand.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                InternationalLicenseID = (int)reader["InternationalLicenseID"];
                                DriverID = (int)reader["DriverID"];
                                ApplicationID = (int)reader["ApplicationID"];
                                IssueDate = (DateTime)reader["IssueDate"];
                                ExpirationDate = (DateTime)reader["ExpirationDate"];


                                IsActive = (bool)reader["IsActive"];
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

        public static DataTable getAllInternationalLicense()
        {

            DataTable dt = new DataTable();

            using (SqlConnection sqlConnection = new SqlConnection(DataAccessLayerSetting.connectionString))
            {
                var query = @"SELECT 'Int.License ID' = InternationalLicenseID
                              ,'Application ID' =ApplicationID
                              ,'Driver ID' = InternationalLicenses.DriverID
	                          ,'L.License ID' = IssuedUsingLocalLicenseID
                              ,'Issue Date' =IssueDate
                              ,'Expiration Date' =ExpirationDate
                              ,'Is Active'=IsActive
                          FROM InternationalLicenses;";
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

    }
}
