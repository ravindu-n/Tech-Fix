using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using BusinessLayer;

namespace TechFix1
{
    /// <summary>
    /// Summary description for ManageUserService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class ManageUserService : System.Web.Services.WebService
    {

        [WebMethod]
        public int InsertUser(string fName, string uName, string uRole, string Pasword)
        {
            User user = new User
            {
                FullName = fName,
                UserName = uName,
                UserRole = uRole,
                Pasword = Pasword
            };
            return user.InsertUser();
        }

        // Web method to update an existing user
        [WebMethod]
        public int UpdateUser(int ID, string uName, string uRole)
        {
            User user = new User
            {
                Id = ID,
                UserName = uName,
                UserRole = uRole
            };
            return user.UpdateUser(ID, uName, uRole);
        }

        // Web method to delete a user by ID
        [WebMethod]
        public int DeleteUser(int id)
        {
            User user = new User();
            return user.DeleteUser(id);
        }

        // Web method to validate user login (checks if the user exists and returns their role)
        [WebMethod]
        public string IsValidUser(string uName, string Pasword)
        {
            User user = new User();
            return user.IsValidUser(uName, Pasword);
        }

        // Web method to get a user’s role based on their username
        [WebMethod]
        public string GetUserRole(string uName)
        {
            User user = new User();
            return user.GetUserRole(uName);
        }

        // Web method to get all users (returns a DataSet)
        [WebMethod]
        public DataSet GetAllUsers()
        {
            User user = new User();
            return user.GetAllUsers();
        }

        // Web method to find a specific user by ID
        [WebMethod]
        public DataSet FindUser(int id)
        {
            User user = new User();
            return user.FindUser(id);
        }

        // Web method to get a user's ID based on username and password
        [WebMethod]
        public int GetUserID(string uName, string Pasword)
        {
            User user = new User();
            return user.GetUserID(uName, Pasword);
        }

    }
}
