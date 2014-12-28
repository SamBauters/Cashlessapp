using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using nmct.ba.cashlessproject.model;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Security.Claims;

namespace nmct.ba.cashlessproject.api.Helper
{
    public class DAklant
    {
        private const string CONNECTIONSTRING = "KlantCon";

        private static ConnectionStringSettings CreateConnectionString(IEnumerable<Claim> claims)
        {
            string dblogin = claims.FirstOrDefault(c => c.Type == "dblogin").Value;
            string dbpass = claims.FirstOrDefault(c => c.Type == "dbpass").Value;
            string dbname = claims.FirstOrDefault(c => c.Type == "dbname").Value;

            return Database.CreateConnectionString("System.Data.SqlClient", @"SAMBAUTERS", Cryptography.Decrypt(dbname), Cryptography.Decrypt(dblogin), Cryptography.Decrypt(dbpass));
        }
        public static List<Customers> GetKlanten()
        {
            List<Customers> list = new List<Customers>();
            string sql = "SELECT [ID],[CustomerName],[Address],[Balance],[Picture] FROM [CashlessClient].[dbo].[Customers]";
            DbDataReader reader = Database.GetData(Database.GetConnection("AdminDB"), sql);
            while (reader.Read())
            {
                list.Add(Create(reader));
            }
            reader.Close();
            return list;

        }

        private static Customers Create(IDataRecord record)
        {
            Customers c = new Customers();
            c.ID = Convert.ToInt32(record["ID"]);
            c.CustomerName = record["CustomerName"].ToString();
            c.Address = record["Address"].ToString();
            if (!DBNull.Value.Equals(record["Picture"]))
                c.Picture = (byte[])record["Picture"];
            else
                c.Picture = new byte[0];
            c.Balance = Double.Parse(record["Balance"].ToString());

            return c;
        }

        public static void UpdateAccount(Customers kl)
        {
            string sql = "UPDATE Customers SET CustomerName=@CustomerName, Address=@Address, Balance=@Balance WHERE ID=@ID";
            DbParameter par1 = Database.AddParameter("AdminDB", "@CustomerName", kl.CustomerName);
            DbParameter par2 = Database.AddParameter("AdminDB", "@Address", kl.Address);
            DbParameter par3 = Database.AddParameter("AdminDB", "@Balance", kl.Balance);
            DbParameter par4 = Database.AddParameter("AdminDB", "@ID", kl.ID);
            Database.ModifyData(Database.GetConnection("KlantDB"), sql, par1, par2, par3, par4);
        }

        public static int AddNewCustomer(Customers kl)
        {
            string sql = "INSERT INTO Customers (CustomerName, Address, Picture) VALUES(@CustomerName,@Address,@Picture)";
            DbParameter par1 = Database.AddParameter("AdminDB", "@CustomerName", kl.CustomerName);
            DbParameter par2 = Database.AddParameter("AdminDB", "@Address", kl.Address);
            DbParameter par3 = Database.AddParameter("AdminDB", "@Picture", kl.Picture);
            return Database.InsertData(Database.GetConnection("KlantDB"), sql, par1, par2, par3);
        }
    }
}