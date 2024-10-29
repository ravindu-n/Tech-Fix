using DataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class ManageQuotation
    {
        // Properties representing fields from the Quotation table
        public int ID { get; set; }
        public int InventoryID { get; set; }
        public int UserID { get; set; }
        public string ItemName { get; set; }
        public string BrandNO { get; set; }
        public string SerialNO { get; set; }
        public int Quantity { get; set; }
        public decimal ItemPrice { get; set; }
        public decimal Discount { get; set; }
        public string qStatus { get; set; }
        public DateTime AddDate { get; set; }

        // Method for Manager to approve a quotation
        public bool ApproveQuotation(int quotationId)
        {
            string sql = $"UPDATE Quotation SET qStatus = 'Approved' WHERE ID = {quotationId}";
            return DatabaseOperations.ExecuteQuery(sql) > 0;
        }

        // Method for Manager to reject a quotation
        public bool RejectQuotation(int quotationId)
        {
            string sql = $"UPDATE Quotation SET qStatus = 'Rejected' WHERE ID = {quotationId}";
            return DatabaseOperations.ExecuteQuery(sql) > 0;
        }

        // Method for Supplier to add Item Price and Discount to a quotation
        public bool AddQuotationDetails(int requestQuotationId, decimal itemPrice, decimal discount)
        {
            // Retrieve additional details using the requestQuotationId
            var requestQuotation = GetRequestQuotationDetails(requestQuotationId);

            if (requestQuotation != null)
            {
                string query = "INSERT INTO Quotation (InventoryID, UserID, ItemName, BrandNO, SerialNO, Quantity, ItemPrice, Discount, RequestQuotationId) " +
                               "VALUES (@InventoryID, @UserID, @ItemName, @BrandNO, @SerialNO, @Quantity, @ItemPrice, @Discount, @RequestQuotationId)";

                var parameters = new List<SqlParameter>
                {
                    new SqlParameter("@InventoryID", requestQuotation.InventoryID),
                    new SqlParameter("@UserID", requestQuotation.UserID),
                    new SqlParameter("@ItemName", requestQuotation.ItemName),
                    new SqlParameter("@BrandNO", requestQuotation.BrandNO),
                    new SqlParameter("@SerialNO", requestQuotation.SerialNO),
                    new SqlParameter("@Quantity", requestQuotation.Quantity),
                    new SqlParameter("@ItemPrice", itemPrice),
                    new SqlParameter("@Discount", discount),
                    new SqlParameter("@RequestQuotationId", requestQuotationId)
                };

                int rowsAffected = DatabaseOperations.ExecuteQuery(query, parameters);
                return rowsAffected > 0;
            }
            return false;
        }

        // Method to get all pending quotations (for Manager approval)
        public static DataSet GetPendingQuotations()
        {
            string sql = "SELECT * FROM Quotation WHERE qStatus = 'Pending'";
            return DatabaseOperations.SelectQuery(sql);
        }

        // Method to get all approved quotations
        public static DataSet GetApprovedQuotations()
        {
            string sql = "SELECT * FROM Quotation WHERE qStatus = 'Approved'";
            return DatabaseOperations.SelectQuery(sql);
        }

        // Method for Manager to add approved quotations to inventory
        public bool AddQuotationToInventory()
        {
            string sql = $"INSERT INTO Inventory (UserID, ItemName, BrandNO, SerialNO, Quantity, ItemPrice, AddDate) " +
                         $"VALUES ({UserID}, '{ItemName}', '{BrandNO}', '{SerialNO}', {Quantity}, {ItemPrice}, GETDATE())";
            return DatabaseOperations.ExecuteQuery(sql) > 0;
        }

        // Method to get all Request Quotations (for Manager to approve/reject)
        public static DataSet GetRequestQuotations()
        {
            string sql = "SELECT * FROM RequestQuotation WHERE qStatus = 'Pending'";
            return DatabaseOperations.SelectQuery(sql);
        }

        // Method to get all pending Supplier Quotations (for Manager approval)
        public static DataSet GetQuotations()
        {
            string sql = "SELECT * FROM Quotation WHERE qStatus = 'Pending' OR qStatus = 'Submitted'";
            return DatabaseOperations.SelectQuery(sql);
        }

        // Method for Manager to approve a Request Quotation
        public bool ApproveRequestQuotation(int requestQuotationId)
        {
            string sql = $"UPDATE RequestQuotation SET qStatus = 'Approved' WHERE ID = {requestQuotationId}";
            return DatabaseOperations.ExecuteQuery(sql) > 0;
        }

        // Method for Manager to reject a Request Quotation
        public bool RejectRequestQuotation(int requestQuotationId)
        {
            string sql = $"UPDATE RequestQuotation SET qStatus = 'Rejected' WHERE ID = {requestQuotationId}";
            return DatabaseOperations.ExecuteQuery(sql) > 0;
        }

        // Additional method to mark quotation ItemPrice and Discount as pending until the supplier submits
        public static string MarkPriceDiscountPending()
        {
            return "Pending";
        }

        public bool AddOrUpdateQuotationDetails(int QuotationID, decimal itemPrice, decimal discount)
        {
            try
            {
                // Check if a record already exists in the Quotation table for the given QuotationID
                string checkSql = "SELECT ID FROM Quotation WHERE ID = @QuotationID";
                var checkParameters = new List<SqlParameter>
                {
                    new SqlParameter("@QuotationID", QuotationID)
                };

                object existingQuotationId = DatabaseOperations.ExecuteScalar(checkSql, checkParameters);

                if (existingQuotationId != null)
                {
                    // If it exists, update the record
                    string updateSql = "UPDATE Quotation SET ItemPrice = @ItemPrice, Discount = @Discount, qStatus = 'Submitted' WHERE ID = @QuotationID";
                    Console.WriteLine($"Executing SQL: {updateSql}, ItemPrice: {itemPrice}, Discount: {discount}, QuotationID: {QuotationID}");
                    var updateParameters = new List<SqlParameter>
                    {
                        new SqlParameter("@ItemPrice", itemPrice),
                        new SqlParameter("@Discount", discount),
                        new SqlParameter("@QuotationID", QuotationID)
                    };

                    int rowsAffected = DatabaseOperations.ExecuteQuery(updateSql, updateParameters);
                    return rowsAffected > 0;  // Return true if at least one row is updated
                }
                else
                {
                    // Log and return false if the QuotationID does not exist in the database
                    Console.WriteLine($"QuotationID {QuotationID} does not exist in the Quotation table.");
                    return false;
                }
            }
            catch (SqlException sqlEx)
            {
                // Log SQL errors for better debugging
                Console.WriteLine($"SQL Error: {sqlEx.Message}, Error Number: {sqlEx.Number}");
                return false;
            }
            catch (Exception ex)
            {
                // Log general errors
                Console.WriteLine($"Error: {ex.Message}");
                return false;
            }
        }

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

        public ManageQuotation GetQuotationById(int id)
        {
            string query = "SELECT * FROM Quotation WHERE ID = @ID";
            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@ID", id)
            };

            DataSet ds = DatabaseOperations.SelectQuery(query, parameters);

            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                // Create and return a Quotation object based on the retrieved data
                DataRow row = ds.Tables[0].Rows[0];
                return new ManageQuotation
                {
                    ID = Convert.ToInt32(row["ID"]),
                    InventoryID = Convert.ToInt32(row["InventoryID"]),
                    UserID = Convert.ToInt32(row["UserID"]),
                    ItemName = row["ItemName"].ToString(),
                    BrandNO = row["BrandNO"].ToString(),
                    SerialNO = row["SerialNO"].ToString(),
                    Quantity = Convert.ToInt32(row["Quantity"]),
                    ItemPrice = Convert.ToDecimal(row["ItemPrice"]),
                    Discount = Convert.ToDecimal(row["Discount"]),
                    qStatus = row["qStatus"].ToString()
                };
            }

            return null; // or throw an exception if needed
        }

        public bool AddToInventory(ManageQuotation quotation)
        {
            string query = "INSERT INTO Inventory (UserID, ItemName, BrandNO, SerialNO, Quantity, ItemPrice, AddDate) " +
                           "VALUES (@UserID, @ItemName, @BrandNO, @SerialNO, @Quantity, @ItemPrice, GETDATE())";

            List<SqlParameter> parameters = new List<SqlParameter>
    {
        new SqlParameter("@UserID", quotation.UserID),
        new SqlParameter("@ItemName", quotation.ItemName),
        new SqlParameter("@BrandNO", quotation.BrandNO),
        new SqlParameter("@SerialNO", quotation.SerialNO),
        new SqlParameter("@Quantity", quotation.Quantity),
        new SqlParameter("@ItemPrice", quotation.ItemPrice)
    };

            int result = DatabaseOperations.ExecuteQuery(query, parameters);
            return result > 0; // Returns true if the insert was successful
        }
    }
}
