using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace DataAccessLayer
{
    public static class clsLicense_DataAccess
    {
        public static bool isDetained(int LicenseID)
        {
            bool isExist = false;

            using (var sqlConnection = new SqlConnection(DataAccessLayerSetting.connectionString))
            {
                var query = @"SELECT 'A' FROM DetainedLicenses
                              Where LicenseID = @LicenseID AND IsReleased = 0;";

                using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                {


                    sqlCommand.Parameters.AddWithValue("@LicenseID", LicenseID);


                    try
                    {
                        sqlConnection.Open();

                        if(sqlCommand.ExecuteScalar() != null)
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
        public static int AddNewLicense(int ApplicationID, int DriverID, int LicenseClass, DateTime IssueDate, DateTime ExpirationDate, string Notes, decimal PaidFees, bool IsActive, byte IssueReason, int CreatedByUserID)
        {
            int NewLicenseID = -1;

            using (var sqlConnection = new SqlConnection(DataAccessLayerSetting.connectionString))
            {
                var query = @"INSERT INTO Licenses
           (ApplicationID
            ,DriverID
            ,LicenseClass
            ,IssueDate
            ,ExpirationDate
            ,Notes
            ,PaidFees
            ,IsActive
            ,IssueReason
            ,CreatedByUserID)
     VALUES
            (@ApplicationID
            ,@DriverID
            ,@LicenseClass
            ,@IssueDate
            ,@ExpirationDate
            ,@Notes
            ,@PaidFees
            ,@IsActive
            ,@IssueReason
            ,@CreatedByUserID)

SELECT Scope_Identity();";

                using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                    sqlCommand.Parameters.AddWithValue("@DriverID", DriverID);
                    sqlCommand.Parameters.AddWithValue("@LicenseClass", LicenseClass);
                    sqlCommand.Parameters.AddWithValue("@IssueDate", IssueDate);
                    sqlCommand.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
                    DataAccessLayerSetting.safeParameterAdding<string>(sqlCommand,"@Notes", Notes);
                    sqlCommand.Parameters.AddWithValue("@PaidFees", PaidFees);
                    sqlCommand.Parameters.AddWithValue("@IsActive", IsActive);
                    sqlCommand.Parameters.AddWithValue("@IssueReason", IssueReason);
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
        public static bool UpdateLicense(int LicenseID, int ApplicationID, int DriverID, int LicenseClass, DateTime IssueDate, DateTime ExpirationDate, string Notes, decimal PaidFees, bool IsActive, byte IssueReason, int CreatedByUserID)
        {
            bool isUpdated = false;

            using (var sqlConnection = new SqlConnection(DataAccessLayerSetting.connectionString))
            {
                var query = @"Update Licenses
                              Set 
                                ApplicationID = @ApplicationID 
                               ,DriverID   = @DriverID
                               ,LicenseClass = @LicenseClass
                               ,IssueDate = @IssueDate
                               ,ExpirationDate    = @ExpirationDate
                               ,Notes          = @Notes
                               ,PaidFees = @PaidFees
                               ,IsActive = @IsActive
                               ,IssueReason = @IssueReason
                               ,CreatedByUserID   = @CreatedByUserID
                              Where LicenseID = @LicenseID;";

                using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                {


                    sqlCommand.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                    sqlCommand.Parameters.AddWithValue("@DriverID", DriverID);
                    sqlCommand.Parameters.AddWithValue("@LicenseClass", LicenseClass);
                    sqlCommand.Parameters.AddWithValue("@IssueDate", IssueDate);
                    sqlCommand.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
                    DataAccessLayerSetting.safeParameterAdding<string>(sqlCommand, "@Notes", Notes);
                    sqlCommand.Parameters.AddWithValue("@PaidFees", PaidFees);
                    sqlCommand.Parameters.AddWithValue("@IsActive", IsActive);
                    sqlCommand.Parameters.AddWithValue("@IssueReason", IssueReason);
                    sqlCommand.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
                    sqlCommand.Parameters.AddWithValue("@LicenseID", LicenseID);


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
        public static bool GetLicenseByLicenseID(int LicenseID,ref int ApplicationID,ref int DriverID,ref int LicenseClass,ref DateTime IssueDate,ref DateTime ExpirationDate,ref string Notes,ref decimal PaidFees,ref bool IsActive,ref byte IssueReason,ref int CreatedByUserID)
        {
            bool isExist = false;

            using (var sqlConnection = new SqlConnection(DataAccessLayerSetting.connectionString))
            {
                var query = @"SELECT * FROM Licenses Where LicenseID = @LicenseID;";

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
                                ApplicationID = (int)reader["ApplicationID"];
                                DriverID = (int)reader["DriverID"];
                                LicenseClass = (int)reader["LicenseClass"];
                                ApplicationID = (int)reader["ApplicationID"];
                                ApplicationID = (int)reader["ApplicationID"];
                                IssueDate = (DateTime)reader["IssueDate"];
                                ExpirationDate = (DateTime)reader["ExpirationDate"];
                                
                                    Notes = (reader["Notes"] != DBNull.Value) ? (string)reader["Notes"]:"";
                                
                                IsActive = (bool)reader["IsActive"];
                                IssueReason = (byte)reader["IssueReason"];
                                PaidFees = (decimal)reader["PaidFees"];
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
        public static bool GetLicenseByClassIDandPersonID(int PersonID,int LicenseClassID,ref int LicenseID, ref int ApplicationID, ref int DriverID, ref DateTime IssueDate, ref DateTime ExpirationDate, ref string Notes, ref decimal PaidFees, ref bool IsActive, ref byte IssueReason, ref int CreatedByUserID)
        {
            bool isExist = false;

            using (var sqlConnection = new SqlConnection(DataAccessLayerSetting.connectionString))
            {
                var query = @"SELECT Licenses.LicenseID
                              ,Licenses.ApplicationID
                              ,Licenses.DriverID
                              ,Licenses.LicenseClass
                              ,Licenses.IssueDate
                              ,Licenses.ExpirationDate
                              ,Licenses.Notes
                              ,Licenses.PaidFees
                              ,Licenses.IsActive
                              ,Licenses.IssueReason
                              ,Licenses.CreatedByUserID
                          FROM Licenses
                          INNER JOIN Applications ON Applications.ApplicationID = Licenses.ApplicationID
                          INNER JOIN People ON Applications.ApplicantPersonID = People.PersonID
                          Where Licenses.LicenseClass = @LicenseClassID AND People.PersonID = @PersonID;";

                using (var sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
                    sqlCommand.Parameters.AddWithValue("@PersonID", PersonID);

                    try
                    {
                        sqlConnection.Open();

                        using (SqlDataReader reader = sqlCommand.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                LicenseID = (int)reader["LicenseID"];
                                ApplicationID = (int)reader["ApplicationID"];
                                DriverID = (int)reader["DriverID"];
                                ApplicationID = (int)reader["ApplicationID"];
                                ApplicationID = (int)reader["ApplicationID"];
                                IssueDate = (DateTime)reader["IssueDate"];
                                ExpirationDate = (DateTime)reader["ExpirationDate"];

                                Notes = (reader["Notes"] != DBNull.Value) ? (string)reader["Notes"] : "";

                                IsActive = (bool)reader["IsActive"];
                                IssueReason = (byte)reader["IssueReason"];
                                PaidFees = (decimal)reader["PaidFees"];
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
        public static bool GetLicenseByApplicationID(int ApplicationID,ref int LicenseID, ref int DriverID, ref int LicenseClass, ref DateTime IssueDate, ref DateTime ExpirationDate, ref string Notes, ref decimal PaidFees, ref bool IsActive, ref byte IssueReason, ref int CreatedByUserID)
        {
            bool isExist = false;

            using (var sqlConnection = new SqlConnection(DataAccessLayerSetting.connectionString))
            {
                var query = @"SELECT * FROM Licenses 
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
                                LicenseID = (int)reader["LicenseID"];
                                DriverID = (int)reader["DriverID"];
                                LicenseClass = (int)reader["LicenseClass"];
                                ApplicationID = (int)reader["ApplicationID"];
                                ApplicationID = (int)reader["ApplicationID"];
                                IssueDate = (DateTime)reader["IssueDate"];
                                ExpirationDate = (DateTime)reader["ExpirationDate"];

                                Notes = (reader["Notes"] != DBNull.Value) ? (string)reader["Notes"] : "";

                                IsActive = (bool)reader["IsActive"];
                                IssueReason = (byte)reader["IssueReason"];
                                PaidFees = (decimal)reader["PaidFees"];
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
        public static DataTable GetLocalLicenseHistoryByPersonID(int PersonID)
        {
            DataTable dt = new DataTable();

            using (SqlConnection sqlConnection = new SqlConnection(DataAccessLayerSetting.connectionString))
            {
                var query = @"SELECT 'Lic.ID' = LicenseID
                              ,'App.ID' =ApplicationID
                              ,'Class Name' = LicenseClasses.ClassName
                              ,'Issue Date' =IssueDate
                              ,'Expiration Date' =ExpirationDate
                              ,'Is Active'=IsActive
                          FROM Licenses
                            INNER JOIN LicenseClasses On LicenseClasses.LicenseClassID = Licenses.LicenseClass
                            Inner JOIN Drivers On Drivers.DriverID = Licenses.DriverID 
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
        public static int TotalLicense(bool OnlyActive = false)
        {
            int total = 0;

            using (var sqlConnection = new SqlConnection(DataAccessLayerSetting.connectionString))
            {
                var query = (OnlyActive) ? @"Select count(*) FROM Licenses Where IsActive = 1;" : @"Select count(*) FROM Licenses;";

                using (var sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    try
                    {
                        sqlConnection.Open();

                        object result = sqlCommand.ExecuteScalar();

                        if (result != null && result != DBNull.Value)
                        {
                            total = Convert.ToInt32(result);
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                }

            }

            return total;
        }
    }
}
