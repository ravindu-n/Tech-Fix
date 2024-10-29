using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TechFix1
{
    public partial class EnterQuotationDetails : System.Web.UI.Page
    {
        ManageQuotationService quotationService = new ManageQuotationService();
        RequestQuotationService requestQuotationService = new RequestQuotationService();
        ManageQuotation manageQuotation = new ManageQuotation();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["RequestQuotationID"] != null)
                {
                    int requestQuotationId = int.Parse(Request.QueryString["RequestQuotationID"]);
                    lblRequestQuotationIdValue.Text = requestQuotationId.ToString();

                    // Fetch the request quotation details
                    var requestQuotation = requestQuotationService.GetRequestQuotationDetails(requestQuotationId);

                    if (requestQuotation != null)
                    {
                        lblInventoryIDValue.Text = requestQuotation.InventoryID.ToString();
                        lblUserIDValue.Text = requestQuotation.UserID.ToString();
                        lblItemNameValue.Text = requestQuotation.ItemName;
                        lblBrandNOValue.Text = requestQuotation.BrandNO;
                        lblSerialNOValue.Text = requestQuotation.SerialNO;
                        lblQuantityValue.Text = requestQuotation.Quantity.ToString();
                    }
                    else
                    {
                        lblMessage.Text = "No details found for this Request Quotation ID.";
                    }
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (int.TryParse(lblRequestQuotationIdValue.Text, out int requestQuotationId) &&
                    decimal.TryParse(txtItemPrice.Text, out decimal itemPrice) &&
                    decimal.TryParse(txtDiscount.Text, out decimal discount))
                {
                    bool result = manageQuotation.AddQuotationDetails(requestQuotationId, itemPrice, discount);

                    if (result)
                    {
                        // Update RequestQuotation status to 'Completed'
                        bool updateStatus = requestQuotationService.UpdateRequestQuotationStatus(requestQuotationId, "Completed");

                        if (updateStatus)
                        {
                            lblMessage.Text = "Details submitted successfully!";
                            Response.Redirect("ViewQuotationRequests.aspx"); // Redirect back to the list after successful submission
                        }
                        else
                        {
                            lblMessage.Text = "Failed to update Request Quotation status.";
                        }
                    }
                    else
                    {
                        lblMessage.Text = "Failed to submit details. Check your inputs or database connection.";
                    }
                }
                else
                {
                    lblMessage.Text = "Invalid input for Request Quotation ID, Item Price, or Discount.";
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = $"An error occurred: {ex.Message}";
            }
        }
    }
}
