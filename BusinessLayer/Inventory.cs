using DataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class Inventory
    {
        // Properties for Inventory fields
        public int ID { get; set; }
        public int UserID { get; set; }
        public string ItemName { get; set; }
        public string BrandNO { get; set; }
        public string SerialNO { get; set; }
        public int Quantity { get; set; }
        public decimal ItemPrice { get; set; }
        public DateTime AddDate { get; set; }

        // Method to add a new inventory item
        public bool AddInventoryItem()
        {
            string sql = $"INSERT INTO Inventory (UserID, ItemName, BrandNO, SerialNO, Quantity, ItemPrice) " +
                         $"VALUES ({UserID}, '{ItemName}', '{BrandNO}', '{SerialNO}', {Quantity}, {ItemPrice})";
            return DatabaseOperations.ExecuteQuery(sql) > 0;
        }

        // Method to update an existing inventory item
        public bool UpdateInventoryItem()
        {
            string sql = $"UPDATE Inventory SET UserID = {UserID}, ItemName = '{ItemName}', BrandNO = '{BrandNO}', " +
                         $"SerialNO = '{SerialNO}', Quantity = {Quantity}, ItemPrice = {ItemPrice} " +
                         $"WHERE ID = {ID}";
            return DatabaseOperations.ExecuteQuery(sql) > 0;
        }

        // Method to delete an inventory item by its ID
        public bool DeleteInventoryItem()
        {
            string sql = $"DELETE FROM Inventory WHERE ID = {ID}";
            return DatabaseOperations.ExecuteQuery(sql) > 0;
        }

        // Static method to get all inventory items
        public static DataSet GetAllInventoryItems()
        {
            string sql = "SELECT * FROM Inventory";
            return DatabaseOperations.SelectQuery(sql);
        }

        // Static method to get an inventory item by its ID
        public static DataSet GetInventoryItemById(int id)
        {
            string sql = $"SELECT * FROM Inventory WHERE ID = {id}";
            return DatabaseOperations.SelectQuery(sql);
        }

        // Method to get inventory items by user ID
        public static DataSet GetInventoryItemsByUserId(int userId)
        {
            string sql = $"SELECT * FROM Inventory WHERE UserID = {userId}";
            return DatabaseOperations.SelectQuery(sql);
        }
    }
}
