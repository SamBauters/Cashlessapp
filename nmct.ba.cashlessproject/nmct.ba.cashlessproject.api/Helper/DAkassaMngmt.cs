using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using nmct.ba.cashlessproject.model;
using System.Data.Common;
using System.Data;
using System.Security.Claims;

namespace nmct.ba.cashlessproject.api.Helper
{
    public class DAkassaMngmt
    {
        private const string CONNECTIONSTRING = "KlantCon";
        public static List<RegistersKlant> GetKassasManagement(IEnumerable<Claim> claims)
        {
            List<RegistersKlant> list = new List<RegistersKlant>();
            string sql = "SELECT RegisterID,EmployeeID, EmployeeName, FromDate, UntilDate, RegisterName, Device FROM [CashlessClient].[dbo].Register_Employee Inner join [CashlessClient].[dbo].[Employee] on Employee.ID = Register_Employee.EmployeeID INNER JOIN CashlessClient.dbo.Registers ON Registers.ID = Register_Employee.RegisterID";
            DbDataReader reader = Database.GetData(Database.GetConnection("AdminDB"), sql);
            while (reader.Read())
            {
                list.Add(Create(reader));
            }
            reader.Close();
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
        public static int UpdateAccount(RegistersKlant kassa, IEnumerable<Claim> claims)
        {
            int rowsaffected = 0;

            int id = kassa.ID;
            string medewerkerName = kassa.EmployeeName;
            string device = kassa.Device;
            Double from = kassa.From;
            string kassaName = kassa.RegisterName;
            Double until = kassa.Until;
            int medewerkerid = kassa.EmployeeID;


            string sql = "UPDATE Registers SET CustomerName = @Name, Balance = @Balance, Address = @Address, Picture = @Picture WHERE ID=@ID";
            DbParameter par1 = Database.AddParameter(CONNECTIONSTRING, "@RegisterName", kassaName);
            DbParameter par2 = Database.AddParameter(CONNECTIONSTRING, "@Device", device);
            DbParameter par3 = Database.AddParameter(CONNECTIONSTRING, "@ID", id);

            rowsaffected += Database.ModifyData(Database.GetConnection("AdminDB"), sql, par1, par2, par3);

            string sql1 = "UPDATE [Klant].[dbo].[Register_Employee] SET EmployeeID = @EmployeeID, FromDate = @FromDate, UntilDate = @UntilDate WHERE RegisterID=@RegisterID";
            DbParameter par11 = Database.AddParameter(CONNECTIONSTRING, "@RegisterID", id);
            DbParameter par12 = Database.AddParameter(CONNECTIONSTRING, "@EmployeeID", medewerkerid);
            DbParameter par13 = Database.AddParameter(CONNECTIONSTRING, "@FromDate", from);
            DbParameter par14 = Database.AddParameter(CONNECTIONSTRING, "@UntilDate", until);



            rowsaffected += Database.ModifyData(Database.GetConnection("AdminDB"), sql1, par1, par2, par3);

            return rowsaffected;
        }
    }
}