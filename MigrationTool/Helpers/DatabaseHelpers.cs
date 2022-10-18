using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MigrationTool.Helpers
{
    public static class DatabaseHelpers
    {
        public static bool ValidateConnectionString(string connectionString)
        {
            if (String.IsNullOrWhiteSpace(connectionString))
            {
                return false;
            }
            try
            {
                using SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                if(connection.State == System.Data.ConnectionState.Open)
                {
                    return true;
                }
            }
            catch {}
            return false;
        }
    }
}
