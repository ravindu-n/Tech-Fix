using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TechFix1
{
    public partial class ViewQuotationRequests : System.Web.UI.Page
    {
        ManageQuotationService quotationService = new ManageQuotationService();
        RequestQuotationService requestQuotationService = new RequestQuotationService();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadApprovedRequestQuotations();
            }
        }

        private void LoadApprovedRequestQuotations()
        {
            ManageQuotationService service = new ManageQuotationService();
            DataSet approvedRequests = service.GetApprovedRequestQuotations();

            if (approvedRequests != null && approvedRequests.Tables.Count > 0)
            {
                // Filter out 'Completed' status requests from the grid
                DataView dv = approvedRequests.Tables[0].DefaultView;
                dv.RowFilter = "qStatus <> 'Completed'"; 

                GridViewApprovedRequests.DataSource = dv;

                GridViewApprovedRequests.DataSource = approvedRequests.Tables[0];
                GridViewApprovedRequests.DataBind();
            }
        }

        protected void SubmitQuotation(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string requestQuotationId = btn.CommandArgument; // This should be the RequestQuotation ID
            Response.Redirect($"EnterQuotationDetails.aspx?RequestQuotationID={requestQuotationId}");
        }
    }
}