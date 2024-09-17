using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataAccessLayer
{
    public class clsDriver_DataAccess
    {
        public static int AddNewDriver(int PersonID, DateTime CreatedDate, int CreatedByUserID)
        {
            int NewDriverID = -1;

            using (var sqlConnection = new SqlConnection(DataAccessLayerSetting.connectionString))
            {
                var query = @"INSERT INTO Drivers
           (PersonID
            ,CreatedDate
            ,CreatedByUserID)
     VALUES
            (@PersonID
            ,@CreatedDate
            ,@CreatedByUserID)

SELECT Scope_Identity();";

                using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@PersonID", PersonID);
                    sqlCommand.Parameters.AddWithValue("@CreatedDate", CreatedDate);
                    sqlCommand.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);


                    try
                    {
                        sqlConnection.Open();

                        object result = sqlCommand.ExecuteScalar();

                        if (result != null)
                        {
                            NewDriverID = Convert.ToInt32(result);
                        }
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message);
                    }


                }
            }
            return NewDriverID;
        }
        //public static bool UpdateDriver(int DriverID, int PersonID, DateTime CreatedDate, int CreatedByUserID)
        //{
        //    bool isUpdated = false;

        //    using (var sqlConnection = new SqlConnection(DataAccessLayerSetting.connectionString))
        //    {
        //        var query = @"Update Drivers
        //                      Set 
        //                        PersonID = @PersonID 
        //                       ,CreatedDate = @CreatedDate
        //                       ,CreatedByUserID   = @CreatedByUserID
        //                      Where DriverID = @DriverID;";

        //        using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
        //        {


        //            sqlCommand.Parameters.AddWithValue("@PersonID", PersonID);
        //            sqlCommand.Parameters.AddWithValue("@DriverID", DriverID);
        //            sqlCommand.Parameters.AddWithValue("@CreatedDate", CreatedDate);
        //            sqlCommand.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);


        //            try
        //            {
        //                sqlConnection.Open();

        //                if (sqlCommand.ExecuteNonQuery() > 0)
        //                {
        //                    isUpdated = true;
        //                }

        //            }
        //            catch (Exception ex)
        //            {
        //                MessageBox.Show(ex.Message);
        //            }

        //        }

        //    }

        //    return isUpdated;
        //}
        public static bool GeDriverByDriverID(int DriverID,ref int PersonID, ref DateTime CreatedDate,ref int CreatedByUserID)
        {
            bool isExist = false;

            using (var sqlConnection = new SqlConnection(DataAccessLayerSetting.connectionString))
            {
                var query = @"SELECT * FROM Drivers Where DriverID = @DriverID;";

                using (var sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@DriverID", DriverID);
                    try
                    {
                        sqlConnection.Open();

                        using (SqlDataReader reader = sqlCommand.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                PersonID = (int)reader["PersonID"];
                                CreatedDate = (DateTime)reader["CreatedDate"];
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

        public static bool GeDriverByPersonID(int PersonID, ref int DriverID, ref DateTime CreatedDate, ref int CreatedByUserID)
        {
            bool isExist = false;

            using (var sqlConnection = new SqlConnection(DataAccessLayerSetting.connectionString))
            {
                var query = @"SELECT * FROM Drivers Where PersonID = @PersonID;";

                using (var sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@PersonID", PersonID);
                    try
                    {
                        sqlConnection.Open();

                        using (SqlDataReader reader = sqlCommand.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                DriverID = (int)reader["DriverID"];
                                CreatedDate = (DateTime)reader["CreatedDate"];
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
