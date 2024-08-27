using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataAccessLayer
{
    public static class clsApplicationDataAccess
    {
        public static int AddNewApplication(int ApplicantPersonID, DateTime ApplicationDate, int ApplicationTypeID, byte ApplicationStatus, DateTime LastStatusDate, double PaidFees, int CreatedByUserID)
        {
            int NewApplicationID = -1;

            using (var sqlConnection = new SqlConnection(DataAccessLayerSetting.connectionString))
            {
                var query = @"INSERT INTO Applications
           (ApplicantPersonID
           ,ApplicationDate
           ,ApplicationTypeID
           ,ApplicationStatus
           ,LastStatusDate
           ,PaidFees
           ,CreatedByUserID)
     VALUES
            (@ApplicantPersonID,
            @ApplicationDate,
            @ApplicationTypeID,
            @ApplicationStatus,
            @LastStatusDate,
            @PaidFees,
            @CreatedByUserID)

SELECT Scope_Identity();";

                using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@ApplicantPersonID",ApplicantPersonID);
                    sqlCommand.Parameters.AddWithValue("@ApplicationDate", ApplicationDate);
                    sqlCommand.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
                    sqlCommand.Parameters.AddWithValue("@ApplicationStatus", ApplicationStatus);
                    sqlCommand.Parameters.AddWithValue("@LastStatusDate", LastStatusDate);
                    sqlCommand.Parameters.AddWithValue("@PaidFees", (decimal)PaidFees);
                    sqlCommand.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);


                    try
                    {
                        sqlConnection.Open();

                        object result = sqlCommand.ExecuteScalar();

                        if (result != null)
                        {
                            NewApplicationID = Convert.ToInt32(result);
                        }
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message);
                    }


                }
            }
            return NewApplicationID;
        }
        public static bool UpdateApplication(int ApplicationID, int ApplicantPersonID, DateTime ApplicationDate, int ApplicationTypeID, byte ApplicationStatus, DateTime LastStatusDate, double PaidFees, int CreatedByUserID)
        {
            bool isUpdated = false;

            using (var sqlConnection = new SqlConnection(DataAccessLayerSetting.connectionString))
            {
                var query = @"Update Applications
                              Set 
                                ApplicantPersonID = @ApplicantPersonID 
                               ,ApplicationDate   = @ApplicationDate
                               ,ApplicationTypeID = @ApplicationTypeID
                               ,ApplicationStatus = @ApplicationStatus
                               ,LastStatusDate    = @LastStatusDate
                               ,PaidFees          = @PaidFees
                               ,CreatedByUserID   = @CreatedByUserID
                              Where ApplicationID = @ApplicationID;";

                using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                {


                    sqlCommand.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                    sqlCommand.Parameters.AddWithValue("@ApplicantPersonID", ApplicantPersonID);
                    sqlCommand.Parameters.AddWithValue("@ApplicationDate", ApplicationDate);
                    sqlCommand.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
                    sqlCommand.Parameters.AddWithValue("@ApplicationStatus", ApplicationStatus);
                    sqlCommand.Parameters.AddWithValue("@LastStatusDate", LastStatusDate);
                    sqlCommand.Parameters.AddWithValue("@PaidFees", (decimal)PaidFees);
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

        public static bool GetApplicationByPersonID(int ApplicantPersonID,ref int ApplicationID,ref DateTime ApplicationDate,ref int ApplicationTypeID,ref byte ApplicationStatus,ref DateTime LastStatusDate,ref double PaidFees,ref int CreatedByUserID)
        {
            bool isExist = false;

            using (var sqlConnection = new SqlConnection(DataAccessLayerSetting.connectionString))
            {
                var query = @"SELECT * FROM Applications Where ApplicantPersonID = @ApplicantPersonID;";

                using (var sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@ApplicantPersonID", ApplicantPersonID);
                    try
                    {
                        sqlConnection.Open();

                        using (SqlDataReader reader = sqlCommand.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                ApplicationID = (int)reader["ApplicationID"];
                                ApplicationDate = (DateTime)reader["ApplicationDate"];
                                ApplicationTypeID = (int)reader["ApplicationTypeID"];
                                ApplicationStatus = (byte)reader["ApplicationStatus"];
                                LastStatusDate = (DateTime)reader["LastStatusDate"];
                                PaidFees = Convert.ToDouble((decimal)reader["PaidFees"]);
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
