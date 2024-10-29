using BusinessLayer;
using DataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace TechFix1
{
    /// <summary>
    /// Summary description for RequestQuotationService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class RequestQuotationService : System.Web.Services.WebService
    {

        [WebMethod]
        public bool CreateRequestQuotation(int inventoryID, int userID, string itemName, string brandNO, string serialNO, int quantity)
        {
            RequestQuotation request = new RequestQuotation
            {
                InventoryID = inventoryID,
                UserID = userID,
                ItemName = itemName,
                BrandNO = brandNO,
                SerialNO = serialNO,
                Quantity = quantity,
                qStatus = "Pending",
                RequestDate = DateTime.Now
            };
            return request.CreateRequestQuotation();
        }

        // Web method to update a Quotation Request (Accounter can edit their requests)
        [WebMethod]
        public bool UpdateRequestQuotation(int requestId, int inventoryID, string itemName, string brandNO, string serialNO, int quantity)
        {
            RequestQuotation request = new RequestQuotation
            {
                InventoryID = inventoryID,
                ItemName = itemName,
                BrandNO = brandNO,
                SerialNO = serialNO,
                Quantity = quantity
            };
            return request.UpdateRequestQuotation(requestId);
        }

        // Web method to delete a Quotation Request (Accounter can delete before approval)
        [WebMethod]
        public bool DeleteRequestQuotation(int requestId)
        {
            RequestQuotation request = new RequestQuotation();
            return request.DeleteRequestQuotation(requestId);
        }

        // Web method to get all pending requests (for Manager approval)
        [WebMethod]
        public DataSet GetPendingRequests()
        {
            return RequestQuotation.GetPendingRequests();
        }

        // Web method for Manager to approve a request
        [WebMethod]
        public bool ApproveRequestQuotation(int requestId)
        {
            RequestQuotation request = new RequestQuotation();
            return request.ApproveRequestQuotation(requestId);
        }

        // Web method for Manager to reject a request
        [WebMethod]
        public bool RejectRequestQuotation(int requestId)
        {
            RequestQuotation request = new RequestQuotation();
            return request.RejectRequestQuotation(requestId);
        }

        // Web method to retrieve approved requests
        [WebMethod]
        public DataSet GetApprovedRequests()
        {
            return RequestQuotation.GetApprovedRequests();
        }

        // Web method to find a specific request by ID
        [WebMethod]
        public DataSet FindRequestQuotation(int requestId)
        {
            return RequestQuotation.FindRequestQuotation(requestId);
        }

        [WebMethod]
        public RequestQuotation GetRequestQuotationDetails(int requestQuotationId)
        {
            string query = "SELECT InventoryID, UserID, ItemName, BrandNO, SerialNO, Quantity FROM RequestQuotation WHERE ID = @RequestQuotationId";
            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@RequestQuotationId", requestQuotationId)
            };

            DataSet ds = DatabaseOperations.SelectQuery(query, parameters);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                var row = ds.Tables[0].Rows[0];
                return new RequestQuotation
                {
                    InventoryID = (int)row["InventoryID"],
                    UserID = (int)row["UserID"],
                    ItemName = (string)row["ItemName"],
                    BrandNO = row["BrandNO"] as string,
                    SerialNO = row["SerialNO"] as string,
                    Quantity = (int)row["Quantity"]
                };
            }
            return null;
        }

        [WebMethod]
        public bool UpdateRequestQuotationStatus(int requestQuotationId, string newStatus)
        {
            string query = "UPDATE RequestQuotation SET qStatus = @qStatus WHERE ID = @ID";
            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@qStatus", newStatus),
                new SqlParameter("@ID", requestQuotationId)
            };

            return DatabaseOperations.ExecuteQuery(query, parameters) > 0;
        }

        [WebMethod]
        public DataSet GetApprovedRequestQuotations()
        {
            string query = "SELECT * FROM RequestQuotation WHERE qStatus = 'Approved'";
            return DatabaseOperations.SelectQuery(query);
        }

    }
}
