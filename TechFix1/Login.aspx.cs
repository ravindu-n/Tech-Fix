using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TechFix1
{
    public partial class Login : System.Web.UI.Page
    {
        localhost.ManageUserService mus = new localhost.ManageUserService();

        protected void Page_Load(object sender, EventArgs e)
        {
            // Clear any previous error messages on page load
            lblErrorMessage.Text = string.Empty;
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            // Create an instance of the ManageUserService
            ManageUserService manageUserService = new ManageUserService();

            // Get username and password from the text boxes
            string uName = txtUsername.Text.Trim();
            string Pasword = txtPassword.Text;

            // Validate the user
            string uRole = manageUserService.IsValidUser(uName, Pasword);

            if (!string.IsNullOrEmpty(uRole))
            {
                // If the user is valid, store their role in a session variable
                Session["UserRole"] = uRole;
                Session["Username"] = uName;

                // Redirect based on the user role
                if (uRole == "manager")
                {
                    Response.Redirect("~/ManagerPage.aspx");
                }
                else if (uRole == "accountant")
                {
                    Response.Redirect("~/AccountantPage.aspx");
                }
                else if (uRole == "supplier")
                {
                    Response.Redirect("~/SupplierPage.aspx");
                }
                else
                {
                    // If the role is not recognized, show an error
                    lblErrorMessage.Text = "User role is not recognized.";
                }
            }
            else
            {
                // If the user is not valid, display an error message
                lblErrorMessage.Text = "Invalid username or password.";
            }
        }
    }
}