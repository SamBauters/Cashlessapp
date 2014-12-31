using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Security.Claims;
using nmct.ba.cashlessproject.model;

namespace nmct.ba.cashlessproject.api.Helper
{
    public class DAkassaMngmt
    {
        private const string CONNECTIONSTRING = "KlantCon";
        public static List<Registers> GetKassasManagement(IEnumerable<Claim> claims)
        {
            List<Registers> list = new List<Registers>();
            string sql = "SELECT * FROM Registers";
            DbDataReader reader = Database.GetData(Database.GetConnection("KlantDB"), sql);
            while (reader.Read())
            {
                Registers r = new Registers();
                r.ID = Convert.ToInt32(reader["ID"]);
                r.RegisterName = reader["RegisterName"].ToString();
                r.Device = reader["Device"].ToString();

                list.Add(r);
            }

            return list;

        }



        private static RegistersKlant Create(IDataRecord record)
        {
            return new RegistersKlant()
            {
                ID = Int32.Parse(record["RegisterID"].ToString()),
                Device = record["Device"].ToString(),
                RegisterName = record["RegisterName"].ToString(),
                From = Double.Parse(record["FromDate"].ToString()),
                Until = Double.Parse(record["UntilDate"].ToString()),
                EmployeeName = record["EmployeeName"].ToString(),
                EmployeeID = Int32.Parse(record["EmployeeID"].ToString())


            };
        }
        public static void UpdateAccount(Registers r, IEnumerable<Claim> claims)
        {
            string sql = "UPDATE Products SET RegisterName=@RegisterName, Device=@Device WHERE ID=@ID";
            DbParameter par1 = Database.AddParameter("AdminDB", "@RegisterName", r.RegisterName);
            DbParameter par2 = Database.AddParameter("AdminDB", "@Device", r.Device);
            DbParameter par3 = Database.AddParameter("AdminDB", "@ID", r.ID);
            Database.ModifyData(Database.GetConnection("KlantDB"), sql, par1, par2, par3);
        }

        public static Registers GetRegisterById(int id)
        {
            Registers r = new Registers();
            string sql = "SELECT * FROM Registers WHERE ID=@ID";
            DbParameter par1 = Database.AddParameter("AdminDB", "@ID", id);
            DbDataReader reader = Database.GetData(Database.GetConnection("KlantDB"), sql, par1);

            while (reader.Read())
            {
                r.ID = Convert.ToInt32(reader["ID"]);
                r.RegisterName = reader["RegisterName"].ToString();
                r.Device = reader["Device"].ToString();
            }

            return r;
        }
    }
}