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
    public partial class ViewQuotations : System.Web.UI.Page
    {
        ManageQuotationService quotationService = new ManageQuotationService();
        RequestQuotationService requestQuotationService = new RequestQuotationService();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadRequestQuotations();
                LoadQuotations();
            }
        }

        // Load the quotation requests from accountants
        private void LoadRequestQuotations()
        {
            try
            {
                var requestQuotations = RequestQuotation.GetPendingRequests(); // Adjust this method call if necessary
                GridViewRequestQuotations.DataSource = requestQuotations;
                GridViewRequestQuotations.DataBind();
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error loading request quotations: " + ex.Message;
            }
        }

        // Load the quotations from suppliers
        private void LoadQuotations()
        {
            try
            {
                var quotations = ManageQuotation.GetQuotations(); // Adjust this method call if necessary
                GridViewQuotations.DataSource = quotations;
                GridViewQuotations.DataBind();
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error loading quotations: " + ex.Message;
            }
        }

        // Handle row commands for Request Quotations (Approve/Reject)
        protected void GridViewRequestQuotations_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int requestQuotationID = Convert.ToInt32(e.CommandArgument);

                if (e.CommandName == "ApproveRequest")
                {
                    ApproveRequestQuotation(requestQuotationID);
                }
                else if (e.CommandName == "RejectRequest")
                {
                    RejectRequestQuotation(requestQuotationID);
                }

                // Reload the data after action
                LoadRequestQuotations();
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error handling request quotation action: " + ex.Message;
            }
        }

        // Approve request quotation
        private void ApproveRequestQuotation(int requestQuotationID)
        {
            try
            {
                ManageQuotation manageQuotation = new ManageQuotation(); // Create an instance
                bool isApproved = manageQuotation.ApproveRequestQuotation(requestQuotationID); // Call the method with the correct argument

                if (isApproved)
                {
                    lblMessage.Text = "Request Quotation Approved!";
                }
                else
                {
                    lblMessage.Text = "Error approving Request Quotation.";
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error approving Request Quotation: " + ex.Message;
            }
        }

        // Reject request quotation
        private void RejectRequestQuotation(int requestQuotationID)
        {
            try
            {
                ManageQuotation manageQuotation = new ManageQuotation(); // Assuming this class exists in your Business Layer
                bool isRejected = manageQuotation.RejectRequestQuotation(requestQuotationID);

                if (isRejected)
                {
                    lblMessage.Text = "Request Quotation Rejected!";
                }
                else
                {
                    lblMessage.Text = "Error rejecting Request Quotation.";
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error rejecting Request Quotation: " + ex.Message;
            }
        }

        // Handle row commands for Quotations (Approve/Reject)
        protected void GridViewQuotations_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int quotationID = Convert.ToInt32(e.CommandArgument);

                if (e.CommandName == "ApproveQuotation")
                {
                    ApproveQuotation(quotationID); // Correct method for approving quotations
                }
                else if (e.CommandName == "RejectQuotation")
                {
                    RejectQuotation(quotationID); // Handle rejection
                }

                // Reload the data after action
                LoadQuotations();
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error handling quotation action: " + ex.Message;
            }
        }

        // Approve quotation


        // Reject quotation
        private void RejectQuotation(int quotationID)
        {
            try
            {
                ManageQuotation manageQuotation = new ManageQuotation(); // Assuming this class exists in your Business Layer
                bool isRejected = manageQuotation.RejectQuotation(quotationID);

                if (isRejected)
                {
                    lblMessage.Text = "Quotation Rejected!";
                }
                else
                {
                    lblMessage.Text = "Error rejecting Quotation.";
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error rejecting Quotation: " + ex.Message;
            }
        }

        // Approve quotation
        private void ApproveQuotation(int quotationID)
        {
            try
            {
                ManageQuotation manageQuotation = new ManageQuotation(); // Create an instance of ManageQuotation
                bool isApproved = manageQuotation.ApproveQuotation(quotationID); // Call method to approve quotation

                if (isApproved)
                {
                    // After approving, move the quotation details to the Inventory
                    ManageQuotation approvedQuotation = manageQuotation.GetQuotationById(quotationID); // Get the approved quotation details
                    bool addedToInventory = manageQuotation.AddToInventory(approvedQuotation); // Add to Inventory

                    if (addedToInventory)
                    {
                        lblMessage.Text = "Quotation Approved and added to Inventory!";
                    }
                    else
                    {
                        lblMessage.Text = "Quotation approved but failed to add to Inventory.";
                    }
                }
                else
                {
                    lblMessage.Text = "Error approving Quotation.";
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error approving Quotation: " + ex.Message;
            }
        }

    }
}