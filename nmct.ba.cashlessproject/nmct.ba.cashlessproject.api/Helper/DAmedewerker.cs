using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Web;
using nmct.ba.cashlessproject.model;
using System.Data;
using System.Security.Claims;

namespace nmct.ba.cashlessproject.api.Helper
{
    public class DAmedewerker
    {
        private const string CONNECTIONSTRING = "KlantCon";
        public static List<Employee> GetEmployees(IEnumerable<Claim> claims)
        {
            List<Employee> list = new List<Employee>();
            string sql = "SELECT * FROM Employee";
            DbDataReader reader = Database.GetData(Database.GetConnection("KlantDB"), sql);
            while (reader.Read())
            {
                Employee e = new Employee();
                e.ID = Convert.ToInt32(reader["ID"]);
                e.EmployeeName = reader["EmployeeName"].ToString();
                e.EmployeeLastname = reader["EmployeeLastname"].ToString();
                e.Address = reader["Address"].ToString();
                e.Email = reader["Email"].ToString();
                e.Phone = reader["Phone"].ToString();

                list.Add(e);
            }

            return list;
        }

        private static Employee Create(IDataRecord record)
        {
            return new Employee()
            {
                ID = Int32.Parse(record["ID"].ToString()),
                EmployeeName = record["EmployeeName"].ToString(),
                EmployeeLastname = record["EmployeeLastname"].ToString(),
                Address = record["Address"].ToString(),
                Email = record["Email"].ToString(),
                Phone = record["Phone"].ToString()
            };
        }

        public static List<Register_Employee> GetEmployeesByRegister(int rId, IEnumerable<Claim> claims)
        {
            List<Register_Employee> list = new List<Register_Employee>();

            string sql = "SELECT * FROM Register_Employee WHERE RegisterID=@RegisterID";
            DbParameter par1 = Database.AddParameter("AdminDB", "@RegisterID", rId);
            DbDataReader reader = Database.GetData(Database.GetConnection("KlantDB"), sql, par1);
            while (reader.Read())
            {
                Register_Employee re = new Register_Employee();

                int employeeID = Convert.ToInt32(reader["EmployeeID"]);
                int from = Convert.ToInt32(reader["FromDate"]);
                int until = Convert.ToInt32(reader["UntilDate"]);

                Employee e = GetEmployeeById(employeeID);

                re.Register = DAkassaMngmt.GetRegisterById(rId);
                re.Employee = e;
                re.From = from;
                re.Until = until;

                list.Add(re);
            }
            return list;
        }

        public static Employee GetEmployeeById(int id)
        {
            Employee e = new Employee();

            string sql = "SELECT * FROM Employee WHERE ID=@ID";
            DbParameter par1 = Database.AddParameter("AdminDB", "@ID", id);
            DbDataReader reader = Database.GetData(Database.GetConnection("KlantDB"), sql, par1);

            while (reader.Read())
            {
                e.ID = Convert.ToInt32(reader["ID"]);
                e.EmployeeName = reader["EmployeeName"].ToString();
                e.EmployeeLastname = reader["EmployeeLastname"].ToString();
                e.Address = reader["Address"].ToString();
                e.Email = reader["Email"].ToString();
                e.Phone = reader["Phone"].ToString();
            }

            return e;
        }


        public static void UpdateEmployee(Employee e, IEnumerable<Claim> claims)
        {
            string sql = "UPDATE Employee SET EmployeeName=@EmployeeName, EmployeeLastname=@EmployeeLastname, Address=@Address, Email=@Email, Phone=@Phone WHERE ID=@ID";
            DbParameter par1 = Database.AddParameter("AdminDB", "@EmployeeName", e.EmployeeName);
            DbParameter par2 = Database.AddParameter("AdminDB", "@EmployeeLastname", e.EmployeeLastname);
            DbParameter par3 = Database.AddParameter("AdminDB", "@Address", e.Address);
            DbParameter par4 = Database.AddParameter("AdminDB", "@Email", e.Email);
            DbParameter par5 = Database.AddParameter("AdminDB", "@Phone", e.Phone);
            DbParameter par6 = Database.AddParameter("AdminDB", "@ID", e.ID);
            Database.ModifyData(Database.GetConnection("KlantDB"), sql, par1, par2, par3, par4, par5, par6);
        }

        public static int AddNewEmployee(Employee e, IEnumerable<Claim> claims)
        {
            string sql = "INSERT INTO Employee VALUES(@EmployeeName,@EmployeeLastname,@Address,@Email,@Phone)";
            DbParameter par1 = Database.AddParameter("AdminDB", "@EmployeeName", e.EmployeeName);
            DbParameter par2 = Database.AddParameter("AdminDB", "@EmployeeLastname", e.EmployeeLastname);
            DbParameter par3 = Database.AddParameter("AdminDB", "@Address", e.Address);
            DbParameter par4 = Database.AddParameter("AdminDB", "@Email", e.Email);
            DbParameter par5 = Database.AddParameter("AdminDB", "@Phone", e.Phone);
            return Database.InsertData(Database.GetConnection("KlantDB"), sql, par1, par2, par3, par4, par5);
        }

        /*public static void DeleteEmployee(int idMedewerker, IEnumerable<Claim> claims)
        {
            string sql2 = "DELETE FROM [CashlessClient].[dbo].[Employee] WHERE ID=@ID";
            DbParameter par21 = Database.AddParameter(CONNECTIONSTRING, "@ID", idMedewerker);
            Database.InsertData(Database.GetConnection("AdminDB"), sql2, par21);
        }*/

        public static void DeleteEmployee(int id, IEnumerable<Claim> claims)
        {
            string sql = "DELETE FROM Employee WHERE ID=@ID";
            DbParameter par1 = Database.AddParameter("AdminDB", "@ID", id);
            DbConnection con = Database.GetConnection("KlantDB");
            Database.ModifyData(con, sql, par1);
        }


    }
}