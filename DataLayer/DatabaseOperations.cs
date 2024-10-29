using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class DatabaseOperations
    {
        public static string ConString = "Server=(localdb)\\Local;Database=TechFix1;Trusted_Connection=True;TrustServerCertificate=True";
        public static int ExecuteQuery(string query, List<SqlParameter> parameters = null)
        {
            using (SqlConnection conn = new SqlConnection(ConString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters.ToArray());
                    }
                    conn.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        public static DataSet SelectQuery(string sql, List<SqlParameter> parameters = null)
        {
            using (SqlConnection con = new SqlConnection(ConString))
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                if (parameters != null)
                {
                    cmd.Parameters.AddRange(parameters.ToArray());
                }

                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    return ds;
                }
            }
        }

        public static object ExecuteScalar(string query, List<SqlParameter> parameters = null)
        {
            using (SqlConnection conn = new SqlConnection(ConString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters.ToArray());
                    }
                    conn.Open();
                    return cmd.ExecuteScalar();
                }
            }
        }

    }
}
