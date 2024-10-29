using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TechFix1
{
    public partial class EditInventory : System.Web.UI.Page
    {
        ManageInventoryService inventoryService = new ManageInventoryService();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadAccountantUserIDs();
                LoadInventoryItem();
            }
        }

        private void LoadAccountantUserIDs()
        {
            DataSet ds = inventoryService.GetAccountantUsers();
            ddlUserID.DataSource = ds;
            ddlUserID.DataTextField = "ID";
            ddlUserID.DataValueField = "ID";
            ddlUserID.DataBind();
        }

        private void LoadInventoryItem()
        {
            int id = Convert.ToInt32(Request.QueryString["id"]);
            DataSet ds = inventoryService.GetInventoryItemById(id);
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                hfID.Value = ds.Tables[0].Rows[0]["ID"].ToString();
                ddlUserID.SelectedValue = ds.Tables[0].Rows[0]["UserID"].ToString();
                txtItemName.Text = ds.Tables[0].Rows[0]["ItemName"].ToString();
                txtBrandNO.Text = ds.Tables[0].Rows[0]["BrandNO"].ToString();
                txtSerialNO.Text = ds.Tables[0].Rows[0]["SerialNO"].ToString();
                txtQuantity.Text = ds.Tables[0].Rows[0]["Quantity"].ToString();
                txtItemPrice.Text = ds.Tables[0].Rows[0]["ItemPrice"].ToString();
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                int userID = int.Parse(ddlUserID.SelectedValue);
                string itemName = txtItemName.Text;
                string brandNO = txtBrandNO.Text;
                string serialNO = txtSerialNO.Text;
                int quantity = int.Parse(txtQuantity.Text);
                decimal itemPrice = decimal.Parse(txtItemPrice.Text);
                int id = int.Parse(hfID.Value);

                bool isUpdated = inventoryService.UpdateInventoryItem(id, userID, itemName, brandNO, serialNO, quantity, itemPrice);
                if (isUpdated)
                {
                    Response.Redirect("ManageInventory.aspx");
                }
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("ManageInventory.aspx");
        }

        private bool ValidateForm()
        {
            bool isValid = true;
            lblValidationMessage.Text = ""; // Clear previous messages

            // Check if Item Name is provided
            if (string.IsNullOrWhiteSpace(txtItemName.Text))
            {
                lblValidationMessage.Text += "Item Name is required.<br/>";
                isValid = false;
            }

            // Check if Quantity is a valid integer and greater than 0
            if (!int.TryParse(txtQuantity.Text, out int quantity) || quantity <= 0)
            {
                lblValidationMessage.Text += "Please enter a valid quantity greater than zero.<br/>";
                isValid = false;
            }

            // Check if Item Price is a valid decimal and greater than 0
            if (!decimal.TryParse(txtItemPrice.Text, out decimal itemPrice) || itemPrice <= 0)
            {
                lblValidationMessage.Text += "Please enter a valid item price greater than zero.<br/>";
                isValid = false;
            }

            // Check if Brand NO is provided
            if (string.IsNullOrWhiteSpace(txtBrandNO.Text))
            {
                lblValidationMessage.Text += "Brand NO is required.<br/>";
                isValid = false;
            }

            // Check if Serial NO is provided
            if (string.IsNullOrWhiteSpace(txtSerialNO.Text))
            {
                lblValidationMessage.Text += "Serial NO is required.<br/>";
                isValid = false;
            }

            return isValid;
        }
    }
}