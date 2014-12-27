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
        public static List<Employee> GetEmployee(IEnumerable<Claim> claims)
        {
            List<Employee> list = new List<Employee>();
            string sql = "SELECT [ID],[EmployeeName],[EmployeeLastname],[Address],[Email],[Phone] FROM [CashlessClient].[dbo].[Employee]";
            DbDataReader reader = Database.GetData(Database.GetConnection("AdminDB"), sql);
            while (reader.Read())
            {
                list.Add(Create(reader));
            }
            reader.Close();
            return list;

        }
        public static Employee GetEmployee(int id, IEnumerable<Claim> claims)
        {
            Employee emp = new Employee();
            string sql = "SELECT [ID],[EmployeeName],[EmployeeLastname],[Address],[Email],[Phone] FROM [CashlessClient].[dbo].[Employee] where ID=@id";
            DbParameter par1 = Database.AddParameter("AdminDB", "@id", id);
            DbDataReader reader = Database.GetData(Database.GetConnection("AdminDB"), sql, par1);
            while (reader.Read())
            {
                emp = Create(reader);
            }
            reader.Close();
            return emp;

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

        public static List<Employee> GetEmployeesByRegister(int rId, IEnumerable<Claim> claims)
        {
            List<Employee> list = new List<Employee>();
            List<int> employeeIDs = new List<int>();

            string sql = "SELECT EmployeeID FROM Register_Employee WHERE RegisterID=@RegisterID";
            DbParameter par1 = Database.AddParameter("AdminDB", "@RegisterID", rId);
            DbDataReader reader = Database.GetData(Database.GetConnection("KlantDB"), sql, par1);
            while (reader.Read())
            {
                int employeeID = Convert.ToInt32(reader["EmployeeID"]);

                employeeIDs.Add(employeeID);
            }

            if (employeeIDs.Count > 0)
            {
                sql = "SELECT * FROM Employee WHERE ID=@ID";

                foreach (int id in employeeIDs)
                {
                    par1 = Database.AddParameter("AdminDB", "@ID", id);
                    reader = Database.GetData(Database.GetConnection("KlantDB"), sql, par1);

                    while (reader.Read())
                    {
                        Employee e = new Employee();
                        e.ID = Convert.ToInt32(reader["ID"]);
                        e.EmployeeName = reader["EmployeeName"].ToString();
                        e.Address = reader["Address"].ToString();
                        e.Email = reader["Email"].ToString();
                        e.Phone = reader["Phone"].ToString();

                        list.Add(e);
                    }
                }
            }

            return list;
        }

        public static int UpdateEmployee(Employee emp, IEnumerable<Claim> claims)
        {
            int rowsaffected = 0;
            string address = emp.Address;
            string email = emp.Email;
            string name = emp.EmployeeName;
            string lastname = emp.EmployeeLastname;
            int id = emp.ID;
            string phone = emp.Phone;


            string sql = "UPDATE [CashlessClient].[dbo].[Employee] SET EmployeeName=@Name, EmployeeLastname=@Lastname, Email=@Email, Address=@Address, Phone=@Phone WHERE ID=@ID";
            DbParameter par1 = Database.AddParameter(CONNECTIONSTRING, "@Name", name);
            DbParameter par2 = Database.AddParameter(CONNECTIONSTRING, "@Lastname", lastname);
            DbParameter par3 = Database.AddParameter(CONNECTIONSTRING, "@Email", email);
            DbParameter par4 = Database.AddParameter(CONNECTIONSTRING, "@Phone", phone);
            DbParameter par5 = Database.AddParameter(CONNECTIONSTRING, "@Address", address);
            DbParameter par6 = Database.AddParameter(CONNECTIONSTRING, "@ID", id);

            rowsaffected += Database.ModifyData(Database.GetConnection("AdminDB"), sql, par1, par2, par3, par4, par5, par6);

            return rowsaffected;
        }

        public static void AddNewEmployee(Employee emp, IEnumerable<Claim> claims)
        {
            string address = emp.Address;
            string email = emp.Email;
            string name = emp.EmployeeName;
            string lastname = emp.EmployeeLastname;
            int id = emp.ID;
            string phone = emp.Phone;

            string sql = "INSERT INTO [CashlessClient].[dbo].[Employee] VALUES(@EmployeeName, @EmployeeLastname, @Address, @Email, @Phone)";

            DbParameter par1 = Database.AddParameter(CONNECTIONSTRING, "@EmployeeName", name);
            DbParameter par2 = Database.AddParameter(CONNECTIONSTRING, "@EmployeeLastname", lastname);
            DbParameter par3 = Database.AddParameter(CONNECTIONSTRING, "@Email", email);
            DbParameter par4 = Database.AddParameter(CONNECTIONSTRING, "@Phone", phone);
            DbParameter par5 = Database.AddParameter(CONNECTIONSTRING, "@Address", address);
            // DbParameter par5 = Database.AddParameter(CONNECTIONSTRING, "@ID", id);
            Database.InsertData(Database.GetConnection("AdminDB"), sql, par1, par2, par3, par4, par5);
        }

        public static void DeleteEmployee(int idMedewerker, IEnumerable<Claim> claims)
        {
            string sql2 = "DELETE FROM [CashlessClient].[dbo].[Employee] WHERE ID=@ID";
            DbParameter par21 = Database.AddParameter(CONNECTIONSTRING, "@ID", idMedewerker);
            Database.InsertData(Database.GetConnection("AdminDB"), sql2, par21);
        }
    }
}