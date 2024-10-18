using System;
using System.Collections.Generic;
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

    }
}
