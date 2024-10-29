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
    /// Summary description for ManageInventoryService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class ManageInventoryService : System.Web.Services.WebService
    {

        // Web method to add a new inventory item
        [WebMethod]
        public bool AddInventoryItem(int userID, string itemName, string brandNO, string serialNO, int quantity, decimal itemPrice)
        {
            Inventory inventory = new Inventory
            {
                UserID = userID,
                ItemName = itemName,
                BrandNO = brandNO,
                SerialNO = serialNO,
                Quantity = quantity,
                ItemPrice = itemPrice
            };
            return inventory.AddInventoryItem();
        }

        // Web method to update an existing inventory item
        [WebMethod]
        public bool UpdateInventoryItem(int id, int userID, string itemName, string brandNO, string serialNO, int quantity, decimal itemPrice)
        {
            Inventory inventory = new Inventory
            {
                ID = id,
                UserID = userID,
                ItemName = itemName,
                BrandNO = brandNO,
                SerialNO = serialNO,
                Quantity = quantity,
                ItemPrice = itemPrice
            };
            return inventory.UpdateInventoryItem();
        }

        // Web method to delete an inventory item by its ID
        [WebMethod]
        public bool DeleteInventoryItem(int id)
        {
            Inventory inventory = new Inventory
            {
                ID = id
            };
            return inventory.DeleteInventoryItem();
        }

        // Web method to get all inventory items (returns a DataSet)
        [WebMethod]
        public DataSet GetAllInventoryItems()
        {
            return Inventory.GetAllInventoryItems();
        }

        // Web method to get a specific inventory item by ID
        [WebMethod]
        public DataSet GetInventoryItemById(int id)
        {
            return Inventory.GetInventoryItemById(id);
        }

        // Web method to find inventory items by a specific user ID
        [WebMethod]
        public DataSet GetInventoryItemsByUserId(int userId)
        {
            string sql = $"SELECT * FROM Inventory WHERE UserID = {userId}";
            return DatabaseOperations.SelectQuery(sql);
        }

        // Web method to get all accountant users
        [WebMethod]
        public DataSet GetAccountantUsers()
        {
            string sql = "SELECT ID, uName FROM Users WHERE uRole = 'accountant'";
            return DatabaseOperations.SelectQuery(sql);
        }

        [WebMethod]
        public bool CreateQuotationRequest(string itemName, int quantity, string brandNo, string serialNo, int userId, int inventoryId)
        {
            // Manually concatenate the parameters into the SQL query
            string query = $@"INSERT INTO RequestQuotation 
                      (ItemName, BrandNO, SerialNO, Quantity, RequestDate, UserID, InventoryID, qStatus) 
                      VALUES ('{itemName}', '{brandNo}', '{serialNo}', {quantity}, GETDATE(), {userId}, {inventoryId}, 'Pending')";

            // Call ExecuteQuery with just the SQL string
            int result = DatabaseOperations.ExecuteQuery(query);

            // Return true if rows were affected (successful insertion)
            return result > 0;
        }

        [WebMethod]
        public DataSet GetQuotationRequestsByInventoryID(int inventoryID)
        {
            // Manually inserting the inventoryID into the SQL query string
            string query = $"SELECT ItemName, Quantity, RequestDate, qStatus FROM RequestQuotation WHERE InventoryID = {inventoryID}";

            // Call the method with just the SQL string
            return DatabaseOperations.SelectQuery(query);  // Using SelectQuery instead of ExecuteQuery since you're fetching data
        }
    }
}
