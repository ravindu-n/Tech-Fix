using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace TechFix1
{
    /// <summary>
    /// Summary description for ManageQuotationService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class ManageQuotationService : System.Web.Services.WebService
    {

        // Web method for Manager to approve a quotation
        [WebMethod]
        public bool ApproveQuotation(int quotationId)
        {
            ManageQuotation quotation = new ManageQuotation();
            return quotation.ApproveQuotation(quotationId);
        }

        // Web method for Manager to reject a quotation
        [WebMethod]
        public bool RejectQuotation(int quotationId)
        {
            ManageQuotation quotation = new ManageQuotation();
            return quotation.RejectQuotation(quotationId);
        }

        // Web method for Supplier to add Item Price and Discount
        [WebMethod]
        public bool AddQuotationDetails(int quotationId, decimal itemPrice, decimal discount)
        {
            ManageQuotation quotation = new ManageQuotation();
            return quotation.AddQuotationDetails(quotationId, itemPrice, discount);
        }

        // Web method for Manager to get pending quotations
        [WebMethod]
        public DataSet GetPendingQuotations()
        {
            return ManageQuotation.GetPendingQuotations();
        }

        // Web method for Manager to get approved quotations
        [WebMethod]
        public DataSet GetApprovedQuotations()
        {
            return ManageQuotation.GetApprovedQuotations();
        }

        // Web method for Manager to add an approved quotation to inventory
        [WebMethod]
        public bool AddQuotationToInventory(int quotationId)
        {
            // Assuming we fetch the details of the quotation to be added to the inventory
            DataSet ds = ManageQuotation.GetApprovedQuotations();
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow row = ds.Tables[0].Rows[0]; // Taking the first row as an example
                ManageQuotation quotation = new ManageQuotation
                {
                    UserID = Convert.ToInt32(row["UserID"]),
                    ItemName = row["ItemName"].ToString(),
                    BrandNO = row["BrandNO"].ToString(),
                    SerialNO = row["SerialNO"].ToString(),
                    Quantity = Convert.ToInt32(row["Quantity"]),
                    ItemPrice = Convert.ToDecimal(row["ItemPrice"])
                };
                return quotation.AddQuotationToInventory();
            }
            return false;
        }

        // Web method to get approved request quotations
        [WebMethod]
        public DataSet GetApprovedRequestQuotations()
        {
            return RequestQuotation.GetApprovedRequests();
        }
    }
}
