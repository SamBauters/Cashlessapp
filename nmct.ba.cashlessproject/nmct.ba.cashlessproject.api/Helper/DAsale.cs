using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using nmct.ba.cashlessproject.model;

namespace nmct.ba.cashlessproject.api.Helper
{
    public class DAsale
    {
        public static List<Sales> GetSales()
        {
            List<Sales> list = new List<Sales>();

            string sql = "SELECT ID, Timestamp, CustomerID, RegisterID, RegisterName, ProductID, ProductName, Amount, Price, TotalPrice FROM Sales";
            DbDataReader reader = Database.GetData(Database.GetConnection("KlantDB"), sql);

            while (reader.Read())
            {
                list.Add(Create(reader));
            }

            reader.Close();
            return list;
        }

        public static int InsertSale(Sales s)
        {
            string sql = "INSERT INTO Sales VALUES(@Timestamp, @CustomerID, @RegisterID, @RegisterName, @ProductID, @ProductName, @Amount, @Price, @TotalPrice)";
            DbParameter par1 = Database.AddParameter("KlantDB", "@Timestamp", DateTimeToUnixTimeStamp(s.Timestamp));
            DbParameter par2 = Database.AddParameter("KlantDB", "@CustomerID", s.CustomerID);
            DbParameter par3 = Database.AddParameter("KlantDB", "@RegisterID", s.RegisterID);
            DbParameter par4 = Database.AddParameter("KlantDB", "@RegisterName", s.RegisterName);
            DbParameter par5 = Database.AddParameter("KlantDB", "@ProductID", s.ProductID);
            DbParameter par6 = Database.AddParameter("KlantDB", "@ProductName", s.ProductName);
            DbParameter par7 = Database.AddParameter("KlantDB", "@Amount", s.Amount);
            DbParameter par8 = Database.AddParameter("KlantDB", "@Price", s.Price);
            DbParameter par9 = Database.AddParameter("KlantDB", "@TotalPrice", s.TotalPrice);

            return Database.InsertData(Database.GetConnection("KlantDB"), sql, par1, par2, par3, par4, par5 ,par6 ,par7 ,par8 ,par9);
        }

        //create sale
        private static Sales Create(IDataRecord record)
        {
            return new Sales()
            {
                ID = Int32.Parse(record["ID"].ToString()),
                Timestamp = UnixTimeStampToDateTime(Int32.Parse(record["Timestamp"].ToString())),
                CustomerID = Int32.Parse(record["CustomerID"].ToString()),
                RegisterID = Int32.Parse(record["RegisterID"].ToString()),
                RegisterName = record["RegisterName"].ToString(),
                ProductID = Int32.Parse(record["ProductID"].ToString()),
                ProductName = record["ProductName"].ToString(),
                Amount = Int32.Parse(record["Amount"].ToString()),
                Price = Double.Parse(record["Price"].ToString()),
                TotalPrice = Double.Parse(record["TotalPrice"].ToString())
            };
        }

        //UnixTimeStamp convert to DateTime
        public static DateTime UnixTimeStampToDateTime(int unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dtDateTime;
        }

        //DateTime convert to UnixTimeStamp
        private static int DateTimeToUnixTimeStamp(DateTime t)
        {
            var date = new DateTime(1970, 1, 1, 0, 0, 0, t.Kind);
            var unixTimestamp = Convert.ToInt32((t - date).TotalSeconds);

            return unixTimestamp;
        }
    }
}