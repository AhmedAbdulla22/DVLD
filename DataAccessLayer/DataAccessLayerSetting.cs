using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    internal class DataAccessLayerSetting
    {
        public static string connectionString = "Server=.\\MSSQLSERVER22;Database=DVLD;User Id=sa;Password=sa123456;";

        public static void safeParameterAdding<T>(SqlCommand sqlCommand, string parameterName, T value)
        {
            if (value is int num)
            {
                if (num == -1)
                {
                    sqlCommand.Parameters.AddWithValue(parameterName, DBNull.Value);
                }
                else
                {
                    sqlCommand.Parameters.AddWithValue(parameterName, value);
                }
            }
            else if (value == null || (value is string str && string.IsNullOrEmpty(str)))
            {
                sqlCommand.Parameters.AddWithValue(parameterName, DBNull.Value);
            }
            else if(value is DateTime date)
            {
                if (date == DateTime.MinValue)
                {
                    sqlCommand.Parameters.AddWithValue(parameterName, DBNull.Value);
                }
                else
                {
                    sqlCommand.Parameters.AddWithValue(parameterName, value);
                }
            }
            else
            {
                sqlCommand.Parameters.AddWithValue(parameterName, value);
            }

        }
    }
}
