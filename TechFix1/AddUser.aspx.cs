using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TechFix1
{
    public partial class AddUser : System.Web.UI.Page
    {
        localhost.ManageUserService mus = new localhost.ManageUserService();

        protected void Page_Load(object sender, EventArgs e)
        {
            // Code to run on page load (if any)
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            // Validate if the required fields are not empty
            if (!string.IsNullOrEmpty(txtfName.Text) && !string.IsNullOrEmpty(txtuName.Text) && ddlRole.SelectedIndex != 0 && !string.IsNullOrEmpty(txtPassword.Text))
            {
                string fName = txtfName.Text.Trim();
                string uName = txtuName.Text.Trim();
                string uRole = ddlRole.SelectedValue;
                string password = txtPassword.Text.Trim();

                // Hash the password before sending it to the service
                string hashedPassword = HashPassword(password);

                try
                {
                    // Call the AddUser method of ManageUserService
                    mus.InsertUser(fName, uName, uRole, hashedPassword);

                    // Redirect to UserManagement.aspx upon successful addition of the user
                    Response.Redirect("UserManagement.aspx");
                }
                catch (Exception ex)
                {
                    // Display error message in case of failure
                    lblError.Text = "An error occurred while adding the user: " + ex.Message;
                    lblError.Visible = true;
                }
            }
            else
            {
                // Display error message if validation fails
                lblError.Text = "Please fill in all fields and select a role.";
                lblError.Visible = true;
            }
        }

        // Method to hash the password using SHA-256
        private string HashPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // Compute hash
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

                // Convert byte array to string
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }

                return builder.ToString();
            }
        }
    }
}