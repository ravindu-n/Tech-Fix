using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TechFix1
{
    public partial class UserManagement : System.Web.UI.Page
    {
        localhost.ManageUserService mus = new localhost.ManageUserService();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadUsers();
            }
        }

        // Method to load all users into the GridView
        private void LoadUsers()
        {
            DataSet ds = mus.GetAllUsers();
            gvUsers.DataSource = ds;
            gvUsers.DataBind();
        }

        // Handle the 'Add New User' button click event
        protected void btnAddUser_Click(object sender, EventArgs e)
        {
            // Redirect to AddUser.aspx page
            Response.Redirect("AddUser.aspx");
        }

        // Handle the 'Search' button click event
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string searchKeyword = txtSearch.Text.Trim();
            if (!string.IsNullOrEmpty(searchKeyword))
            {
                DataSet ds = mus.GetAllUsers(); // Assuming the service returns all users, filter them locally
                DataTable filteredTable = ds.Tables[0].Clone();

                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    if (row["fName"].ToString().Contains(searchKeyword) || row["uName"].ToString().Contains(searchKeyword))
                    {
                        filteredTable.ImportRow(row);
                    }
                }

                gvUsers.DataSource = filteredTable;
                gvUsers.DataBind();
            }
            else
            {
                LoadUsers();
            }
        }

        // Handle editing of GridView rows
        protected void gvUsers_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvUsers.EditIndex = e.NewEditIndex;
            LoadUsers();
        }

        // Handle updating of GridView rows
        protected void gvUsers_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int userId = Convert.ToInt32(gvUsers.DataKeys[e.RowIndex].Value);

            // Retrieve the updated values from the GridView controls
            string fName = (gvUsers.Rows[e.RowIndex].FindControl("txtfName") as TextBox).Text.Trim();
            string uName = (gvUsers.Rows[e.RowIndex].FindControl("txtuName") as TextBox).Text.Trim();
            string uRole = (gvUsers.Rows[e.RowIndex].FindControl("ddlRole") as DropDownList).SelectedValue;

            // Call the web service method to update the user
            mus.UpdateUser(userId, uName, uRole); // Adjust parameters as needed

            // Reset the edit index and reload the GridView
            gvUsers.EditIndex = -1;
            LoadUsers();
        }

        // Handle canceling of GridView row edit
        protected void gvUsers_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvUsers.EditIndex = -1;
            LoadUsers();
        }

        // Handle deletion of GridView rows
        protected void gvUsers_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int userId = Convert.ToInt32(gvUsers.DataKeys[e.RowIndex].Value);
            mus.DeleteUser(userId);
            LoadUsers();
        }

        // Handle commands in the GridView, such as editing or deleting users
        protected void gvUsers_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditUser")
            {
                int userId = Convert.ToInt32(e.CommandArgument);

                // Load the selected user's details to edit
                DataSet ds = mus.FindUser(userId);

                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    DataRow userRow = ds.Tables[0].Rows[0];
                    txtUserName.Text = userRow["fName"].ToString();
                    txtUserName.Text = userRow["uName"].ToString();
                    ddlRole.SelectedValue = userRow["uRole"].ToString();
                    editUserSection.Visible = true;  // Show the edit section
                }
            }

            if (e.CommandName == "DeleteUser")
            {
                int userId = Convert.ToInt32(e.CommandArgument);
                mus.DeleteUser(userId);
                LoadUsers(); // Refresh the grid after deletion
            }
        }
    }
}
