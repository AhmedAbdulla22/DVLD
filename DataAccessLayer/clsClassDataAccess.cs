using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataAccessLayer
{
    public static class clsClassDataAccess
    {
        public static Dictionary<string, int> GetClassList()
        {
            var DictMap = new Dictionary<string, int>();

            using (SqlConnection sqlConnection = new SqlConnection(DataAccessLayerSetting.connectionString))
            {


                var query = "Select ClassName,LicenseClassID From LicenseClasses;";

                using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    try
                    {
                        sqlConnection.Open();

                        using (SqlDataReader reader = sqlCommand.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                DictMap.Add((string)reader["ClassName"], (int)reader["LicenseClassID"]);
                            }
                        }


                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                }

            }
            return DictMap;
        }

        public static Dictionary<int, decimal> GetClassFees()
        {
            var DictMap = new Dictionary<int, decimal>();

            using (SqlConnection sqlConnection = new SqlConnection(DataAccessLayerSetting.connectionString))
            {


                var query = "Select LicenseClassID,ClassFees From LicenseClasses;";

                using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    try
                    {
                        sqlConnection.Open();

                        using (SqlDataReader reader = sqlCommand.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                DictMap.Add((int)reader["LicenseClassID"], (decimal)reader["ClassFees"]);
                            }
                        }


                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                }

            }
            return DictMap;
        }
    }
}
