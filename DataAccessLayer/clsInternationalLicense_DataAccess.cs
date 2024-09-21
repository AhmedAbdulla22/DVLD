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
    }
}
