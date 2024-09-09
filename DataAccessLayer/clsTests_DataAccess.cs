using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataAccessLayer
{
    public class clsTests_DataAccess
    {
        public static bool GetTestResult(int TestAppointmentID)
        {
            bool isPassed = false;

            using (var sqlConnection = new SqlConnection(DataAccessLayerSetting.connectionString))
            {
                var query = @"SELECT TestResult FROM Tests
                              Where TestAppointmentID = @TestAppointmentID;";
                using (var sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
                    try
                    {
                        sqlConnection.Open();

                        object result = sqlCommand.ExecuteScalar();

                        if (result != null && result != DBNull.Value)
                        {
                            isPassed = Convert.ToBoolean(result);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }

            }

            return isPassed;
        }
    }
}
