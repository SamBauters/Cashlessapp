using nmct.ba.cashlessproject.model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace nmct.ba.cashlessproject.api.Helper
{
    public class DAproduct
    {
        //private const string CONNECTIONSTRING = "KlantCon";
        public static List<Products> GetProducts(IEnumerable<Claim> claims)
        {
            List<Products> list = new List<Products>();
            string sql = "SELECT Products.[ID] ,[ProductName],[Price] FROM [CashlessClient].[dbo].[Products]";
            DbDataReader reader = Database.GetData(Database.GetConnection("AdminDB"), sql);
            while (reader.Read())
            {
                list.Add(Create(reader));
            }
            reader.Close();
            return list;

        }
        public static Products GetProducts(int id, IEnumerable<Claim> claims)
        {
            Products pr = new Products();
            string sql = "SELECT [Id],[ProductName],[Price] FROM [CashlessClient].[dbo].[Products] where ID=@id";
            DbParameter par1 = Database.AddParameter("AdminDB", "@id", id);

            DbDataReader reader = Database.GetData(Database.GetConnection("AdminDB"), sql, par1);
            while (reader.Read())
            {
                pr = Create(reader);
            }
            reader.Close();
            return pr;
        }
        public static void DeleteProduct(int id, IEnumerable<Claim> claims)
        {
            string sql = "DELETE FROM [CashlessClient].[dbo].[Products] WHERE ID =@ID";
            DbParameter par1 = Database.AddParameter("AdminDB", "@ID", id);
            Database.InsertData(Database.GetConnection("AdminDB"), sql, par1);

            /*string sql2 = "DELETE FROM [CashlessClient].[dbo].[Product_Category] WHERE [ProductId] =@ID";
            DbParameter par21 = Database.AddParameter(CONNECTIONSTRING, "@ID", id);
            Database.InsertData(CONNECTIONSTRING, sql2, par21);*/

        }
        private static Products Create(IDataRecord record)
        {
            return new Products()
            {
                ID = Int32.Parse(record["ID"].ToString()),
                ProductName = record["ProductName"].ToString(),
                Price = Convert.ToDouble(record["Price"].ToString())

            };
        }
        public static int UpdateProduct(Products product, IEnumerable<Claim> claims)
        {
            int rowsaffected = 0;

            int id = product.ID;
            string naam = product.ProductName;
            double price = product.Price;


            string sql = "UPDATE [CashlessClient].[dbo].[Products] SET Price = @Price, ProductName = @ProductName WHERE Id=@Id";
            DbParameter par1 = Database.AddParameter("AdminDB", "@Price", price);
            DbParameter par2 = Database.AddParameter("AdminDB", "@ProductName", naam);
            DbParameter par3 = Database.AddParameter("AdminDB", "@Id", id);

            return rowsaffected += Database.ModifyData(Database.GetConnection("AdminDB"), sql, par1, par2, par3);
        }
        public static void AddNewProduct(Products product, IEnumerable<Claim> claims)
        {
            int id = product.ID;
            string naam = product.ProductName;
            //string category = product.Category;
            double price = product.Price;
            //int stock = product.Stock;


            string sql = "INSERT INTO [CashlessClient].[dbo].[Products] VALUES(@ProductName, @Price)";

            DbParameter par1 = Database.AddParameter("AdminDB", "@Price", price);
            DbParameter par2 = Database.AddParameter("AdminDB", "@ProductName", naam);
            Database.InsertData(Database.GetConnection("AdminDB"), sql, par1, par2);

            /*string sql2 = "insert into Klant.dbo.Product_Category values(@Category);";
            DbParameter par21 = Database.AddParameter(CONNECTIONSTRING, "@Id", id);
            DbParameter par23;
            if (category == "Drank")
            {
                par23 = Database.AddParameter(CONNECTIONSTRING, "@Category", 1);
            }
            else
            {
                par23 = Database.AddParameter(CONNECTIONSTRING, "@Category", 2);
            }

            Database.InsertData(CONNECTIONSTRING, sql2, par23);*/


        }

        /*public static List<string> GetCategorie()
        {
            List<string> List = new List<string>();
            string sql = "SELECT distinct [Category] FROM [CashlessClient].[dbo].[Products]";
            DbDataReader reader = Database.GetData(CONNECTIONSTRING, sql);
            while (reader.Read())
            {
                List.Add(reader["Category"].ToString());
            }
            reader.Close();
            return List;
        }*/
    }
}