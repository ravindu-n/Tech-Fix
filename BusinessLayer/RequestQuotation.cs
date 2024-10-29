using DataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class RequestQuotation
    {
        // Properties representing fields from the RequestQuotation table
        public int ID { get; set; }
        public int InventoryID { get; set; }
        public int UserID { get; set; }
        public string ItemName { get; set; }
        public string BrandNO { get; set; }
        public string SerialNO { get; set; }
        public int Quantity { get; set; }
        public string qStatus { get; set; }
        public DateTime RequestDate { get; set; }

        // Method to create a new Quotation Request (Accounter)
        public bool CreateRequestQuotation()
        {
            string sql = $"INSERT INTO RequestQuotation (InventoryID, UserID, ItemName, BrandNO, SerialNO, Quantity, qStatus, RequestDate) " +
                         $"VALUES ({InventoryID}, {UserID}, '{ItemName}', '{BrandNO}', '{SerialNO}', {Quantity}, 'Pending', GETDATE())";
            return DatabaseOperations.ExecuteQuery(sql) > 0;
        }

        // Method for Manager to get all pending Quotation Requests
        public static DataSet GetPendingRequests()
        {
            string sql = "SELECT * FROM RequestQuotation WHERE qStatus = 'Pending'";
            return DatabaseOperations.SelectQuery(sql);
        }

        // Method to update a Quotation Request (Accounter can edit their requests)
        public bool UpdateRequestQuotation(int requestId)
        {
            string sql = $"UPDATE RequestQuotation SET InventoryID = {InventoryID}, ItemName = '{ItemName}', BrandNO = '{BrandNO}', SerialNO = '{SerialNO}', Quantity = {Quantity} " +
                         $"WHERE ID = {requestId} AND qStatus = 'Pending'";
            return DatabaseOperations.ExecuteQuery(sql) > 0;
        }

        // Method to delete a Quotation Request (Accounter can delete before approval)
        public bool DeleteRequestQuotation(int requestId)
        {
            string sql = $"DELETE FROM RequestQuotation WHERE ID = {requestId} AND qStatus = 'Pending'";
            return DatabaseOperations.ExecuteQuery(sql) > 0;
        }

        // Method to approve a Quotation Request (Manager)
        public bool ApproveRequestQuotation(int requestId)
        {
            string sql = $"UPDATE RequestQuotation SET qStatus = 'Approved' WHERE ID = {requestId}";
            return DatabaseOperations.ExecuteQuery(sql) > 0;
        }

        // Method to reject a Quotation Request (Manager)
        public bool RejectRequestQuotation(int requestId)
        {
            string sql = $"UPDATE RequestQuotation SET qStatus = 'Rejected' WHERE ID = {requestId}";
            return DatabaseOperations.ExecuteQuery(sql) > 0;
        }

        // Method to retrieve approved Quotation Requests
        public static DataSet GetApprovedRequests()
        {
            string sql = "SELECT * FROM RequestQuotation WHERE qStatus = 'Approved'";
            return DatabaseOperations.SelectQuery(sql);
        }

        // Method to find a specific request by ID
        public static DataSet FindRequestQuotation(int requestId)
        {
            string sql = $"SELECT * FROM RequestQuotation WHERE ID = {requestId}";
            return DatabaseOperations.SelectQuery(sql);
        }
    }
}
