using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataAccessLayer
{
    public static class clsLicense_DataAccess
    {
        
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
                var query = @"SELECT * FROM License Where LicenseID = @LicenseID;";

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

    }
}
