using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using DataLayer;

namespace BusinessLayer
{
    public class User
    {
        // Properties
        public int Id { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string UserRole { get; set; }
        public string Pasword { get; set; }

        // Method to hash the password using SHA256
        private string HashPassword(string Pasword)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(Pasword));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }

        // Method to insert a new user into the database
        public int InsertUser()
        {
            string hashedPassword = HashPassword(Pasword);
            using (SqlConnection con = new SqlConnection(DatabaseOperations.ConString))
            {
                string sql = "INSERT INTO Users (uName, Pasword, uRole, fName) VALUES (@uName, @Pasword, @uRole, @fName)";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@fName", FullName);
                    cmd.Parameters.AddWithValue("@uName", UserName);
                    cmd.Parameters.AddWithValue("@uRole", UserRole);
                    cmd.Parameters.AddWithValue("@Pasword", hashedPassword);

                    con.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }
 
        // Method to update an existing user's information
        public int UpdateUser(int id, string uName, string uRole)
        {
            using (SqlConnection con = new SqlConnection(DatabaseOperations.ConString))
            {
                string sql = "UPDATE Users SET uName = @uName, uRole = @uRole WHERE ID = @Id";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@uName", uName);
                    cmd.Parameters.AddWithValue("@uRole", uRole);
                    cmd.Parameters.AddWithValue("@Id", id);

                    con.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        // Method to delete a user from the database
        public int DeleteUser(int id)
        {
            using (SqlConnection con = new SqlConnection(DatabaseOperations.ConString))
            {
                string sql = "DELETE FROM Users WHERE ID = @ID";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);

                    con.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        // Method to validate a user by username and password
        public string IsValidUser(string username, string Pasword)
        {
            string hashedPassword = HashPassword(Pasword);
            using (SqlConnection con = new SqlConnection(DatabaseOperations.ConString))
            {
                con.Open();
                string query = "SELECT uRole FROM Users WHERE uName = @uName AND Pasword = @Pasword";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@uName", username);
                    cmd.Parameters.AddWithValue("@Pasword", hashedPassword);
                    object result = cmd.ExecuteScalar();
                    return result?.ToString();  // Return the user role if found, or null if not
                }
            }
        }

        // Method to get a user's role based on the username
        public string GetUserRole(string username)
        {
            using (SqlConnection con = new SqlConnection(DatabaseOperations.ConString))
            {
                string sql = "SELECT uRole FROM Users WHERE uName = @uName";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@uName", username);

                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        return reader["uRole"].ToString();
                    }
                    return null;  // Return null if no role found
                }
            }
        }

        // Method to retrieve all users
        public DataSet GetAllUsers()
        {
            using (SqlConnection con = new SqlConnection(DatabaseOperations.ConString))
            {
                string sql = "SELECT * FROM Users";
                using (SqlDataAdapter da = new SqlDataAdapter(sql, con))
                {
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    return ds;
                }
            }
        }

        public int GetUserID(string uName, string Pasword)
        {
            string hashedPassword = HashPassword(Pasword);
            using (SqlConnection con = new SqlConnection(DatabaseOperations.ConString))
            {
                con.Open();
                string query = "SELECT ID FROM tblUser WHERE uName = @uName AND Pasword = @Pasword";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@uName", uName);
                    cmd.Parameters.AddWithValue("@Pasword", hashedPassword);
                    object result = cmd.ExecuteScalar();

                    // Check if the result is null before casting
                    if (result != null && int.TryParse(result.ToString(), out int userID))
                    {
                        return userID;
                    }
                    else
                    {
                        // Handle cases where user is not found
                        return -1; // Or any other value that indicates the user was not found
                    }
                }
            }
        }

        // Method to find a specific user by ID
        public DataSet FindUser(int id)
        {
            using (SqlConnection con = new SqlConnection(DatabaseOperations.ConString))
            {
                string sql = "SELECT * FROM Users WHERE ID = @ID";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    return ds;
                }
            }
        }
    }
}
