using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TechFix1
{
    public partial class HandleQuotationRequests : System.Web.UI.Page
    {
        ManageInventoryService inventoryService = new ManageInventoryService();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Get InventoryID from query string
                int inventoryID = Convert.ToInt32(Request.QueryString["InventoryID"]);

                // Log the inventoryID for debugging purposes
                System.Diagnostics.Debug.WriteLine($"InventoryID from query string: {inventoryID}");

                if (inventoryID > 0)
                {
                    LoadInventoryDetails(inventoryID);
                    LoadQuotationRequests(inventoryID);
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("Invalid or missing InventoryID in query string");
                }
            }
        }

        // Load the inventory details based on InventoryID
        private void LoadInventoryDetails(int inventoryID)
        {
            DataSet ds = inventoryService.GetInventoryItemById(inventoryID);
            if (ds.Tables[0].Rows.Count > 0)
            {
                txtUserID.Text = ds.Tables[0].Rows[0]["UserID"].ToString();
                txtInventoryID.Text = ds.Tables[0].Rows[0]["ID"].ToString();
                txtItemName.Text = ds.Tables[0].Rows[0]["ItemName"].ToString();
                txtBrandNO.Text = ds.Tables[0].Rows[0]["BrandNO"].ToString();
                txtSerialNO.Text = ds.Tables[0].Rows[0]["SerialNO"].ToString();
                txtQuantity.Text = ds.Tables[0].Rows[0]["Quantity"].ToString();
            }
        }

        // Send the quotation request to the manager
        protected void btnSendRequest_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                string itemName = txtItemName.Text;
                int quantity = int.Parse(txtQuantity.Text);
                string brandNo = txtBrandNO.Text;
                string serialNo = txtSerialNO.Text;
                int userId = int.Parse(txtUserID.Text);
                int inventoryId = int.Parse(txtInventoryID.Text);

                // Call the method to create a new quotation request and send it to the Manager
                bool isRequested = inventoryService.CreateQuotationRequest(itemName, quantity, brandNo, serialNo, userId, inventoryId);

                if (isRequested)
                {
                    Response.Write("<script>alert('Quotation request sent successfully.');</script>");
                    txtQuantity.Text = "";
                    LoadQuotationRequests(inventoryId);
                }
            }
        }

        // Load existing quotation requests based on InventoryID
        private void LoadQuotationRequests(int inventoryID)
        {
            DataSet ds = inventoryService.GetQuotationRequestsByInventoryID(inventoryID);
            if (ds.Tables[0].Rows.Count > 0)
            {
                gvQuotationRequests.DataSource = ds;
                gvQuotationRequests.DataBind();
            }
            else
            {
                gvQuotationRequests.DataSource = null;
                gvQuotationRequests.DataBind();
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("ManageInventory.aspx");
        }

        private bool ValidateForm()
        {
            bool isValid = true;
            lblValidationMessage.Text = ""; // Clear any previous messages

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

            // Check if User ID is provided and is a valid integer
            if (!int.TryParse(txtUserID.Text, out int userId) || userId <= 0)
            {
                lblValidationMessage.Text += "Please enter a valid User ID greater than zero.<br/>";
                isValid = false;
            }

            return isValid;
        }
    }
}