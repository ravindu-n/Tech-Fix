using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;

namespace TechFix1
{
    public partial class ManageInventory : System.Web.UI.Page
    {
        // Service proxy instance for managing inventory
        ManageInventoryService inventoryService = new ManageInventoryService();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadInventoryGrid();
                LoadAccountantUserIDs();
            }
        }

        // Method to load accountant UserIDs into the DropDownList
        private void LoadAccountantUserIDs()
        {
            DataSet ds = inventoryService.GetAccountantUsers();
            ddlUserID.DataSource = ds;
            ddlUserID.DataTextField = "ID"; 
            ddlUserID.DataValueField = "ID"; // Value
            ddlUserID.DataBind();
        }

        // Method to load the inventory items into the GridView
        private void LoadInventoryGrid()
        {
            DataSet ds = inventoryService.GetAllInventoryItems();
            gvInventory.DataSource = ds;
            gvInventory.DataBind();
        }

        // Method to clear the form fields
        protected void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        // Clears all the input fields on the form
        private void ClearFields()
        {
            hfID.Value = string.Empty;
            ddlUserID.SelectedIndex = -1; // Reset dropdown
            txtItemName.Text = string.Empty;
            txtBrandNO.Text = string.Empty;
            txtSerialNO.Text = string.Empty;
            txtQuantity.Text = string.Empty;
            txtItemPrice.Text = string.Empty;
            btnAddOrUpdate.Text = "Add";
            ddlUserID.Enabled = true; // Enable dropdown for new entry
            lblValidationMessage.Text = string.Empty;
        }

        // Add or Update button click event
        protected void btnAddOrUpdate_Click(object sender, EventArgs e)
        {
            if (ValidateForm()) // Add validation logic here
            {
                int userID = int.Parse(ddlUserID.SelectedValue);
                string itemName = txtItemName.Text;
                string brandNO = txtBrandNO.Text;
                string serialNO = txtSerialNO.Text;
                int quantity = int.Parse(txtQuantity.Text);
                decimal itemPrice = decimal.Parse(txtItemPrice.Text);

                if (string.IsNullOrEmpty(hfID.Value))
                {
                    // Add new inventory item
                    bool isAdded = inventoryService.AddInventoryItem(userID, itemName, brandNO, serialNO, quantity, itemPrice);
                    if (isAdded)
                    {
                        lblID.Text = "Item added successfully!";
                    }
                }
                else
                {
                    // Update existing inventory item
                    int id = int.Parse(hfID.Value);
                    bool isUpdated = inventoryService.UpdateInventoryItem(id, userID, itemName, brandNO, serialNO, quantity, itemPrice);
                    if (isUpdated)
                    {
                        lblID.Text = "Item updated successfully!";
                    }
                }

                // Reload the GridView after adding or updating
                LoadInventoryGrid();
                ClearFields();
            }
        }

        // GridView Row Editing event
        protected void gvInventory_RowEditing(object sender, GridViewEditEventArgs e)
        {
            int id = Convert.ToInt32(gvInventory.DataKeys[e.NewEditIndex].Value);
            Response.Redirect($"EditInventory.aspx?id={id}");
        }

        // GridView Row Deleting event
        protected void gvInventory_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // This method will only be reached if the confirmation was successful
            int id = Convert.ToInt32(gvInventory.DataKeys[e.RowIndex].Value);
            bool isDeleted = inventoryService.DeleteInventoryItem(id);
            if (isDeleted)
            {
                lblID.Text = "Item deleted successfully!";
                LoadInventoryGrid();
            }
        }

        private bool ConfirmDelete()
        {
            // Return true or false based on user confirmation
            // This will require some modification, as confirmation
            // should ideally be done on the client-side.
            // Here, we just simulate confirmation.
            return true; // Change this to actual confirmation logic
        }

        protected void gvInventory_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Request")
            {
                // Get the selected inventory item ID
                int inventoryID = Convert.ToInt32(e.CommandArgument);

                // Log the inventoryID to debug output
                System.Diagnostics.Debug.WriteLine(inventoryID);

                // Check if the ID is retrieved correctly
                if (inventoryID > 0)
                {
                    // Log the redirect event
                    System.Diagnostics.Debug.WriteLine("Redirecting to HandleQuotationRequests.aspx");

                    // Redirect to HandleQuotationRequests.aspx with the selected inventory ID
                    Response.Redirect($"HandleQuotationRequests.aspx?InventoryID={inventoryID}");
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("Invalid Inventory ID");
                }
            }

            if (e.CommandName == "Delete")
            {
                // Inject JavaScript confirmation
                string script = "if (confirm('Are you sure you want to delete this item?')) { " +
                                $"__doPostBack('{gvInventory.UniqueID}', '{{ {e.CommandArgument} }}'); ";
                ClientScript.RegisterStartupScript(this.GetType(), "confirmDelete", script, true);
            }
        }

        private bool ValidateForm()
        {
            bool isValid = true;
            lblValidationMessage.Text = "";  // Clear any previous messages

            // Check if item name is provided
            if (string.IsNullOrWhiteSpace(txtItemName.Text))
            {
                lblValidationMessage.Text += "Item Name is required.<br/>";
                isValid = false;
            }

            // Check if brand number is provided
            if (string.IsNullOrWhiteSpace(txtBrandNO.Text))
            {
                lblValidationMessage.Text += "Brand NO is required.<br/>";
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(txtSerialNO.Text))
            {
                lblValidationMessage.Text += "Serial NO is required.<br/>";
                isValid = false;
            }

            // Check if quantity is a valid integer
            if (!int.TryParse(txtQuantity.Text, out int quantity) || quantity <= 0)
            {
                lblValidationMessage.Text += "Please enter a valid quantity.<br/>";
                isValid = false;
            }

            // Check if item price is a valid decimal
            if (!decimal.TryParse(txtItemPrice.Text, out decimal itemPrice) || itemPrice <= 0)
            {
                lblValidationMessage.Text += "Please enter a valid price.<br/>";
                isValid = false;
            }

            return isValid;
        }
    }
}