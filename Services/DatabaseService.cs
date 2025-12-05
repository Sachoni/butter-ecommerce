using System.Data.SQLite;
using POSApp.Models;

namespace POSApp.Services
{
    public class DatabaseService
    {
        private readonly string connectionString = "Data Source=pos.db";

        public Product GetProductByBarcode(string barcode)
        {
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM Products WHERE Barcode = @barcode";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@barcode", barcode);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Product
                            {
                                ID = Convert.ToInt32(reader["ID"]),
                                Barcode = reader["Barcode"].ToString(),
                                Name = reader["Name"].ToString(),
                                Price = Convert.ToDouble(reader["Price"]),
                                Stock = Convert.ToInt32(reader["Stock"])
                            };
                        }
                    }
                }
            }
            return null;
        }
    }
}
