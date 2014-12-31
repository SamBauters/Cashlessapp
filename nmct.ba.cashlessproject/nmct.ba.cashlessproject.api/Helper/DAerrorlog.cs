using System.Data.Common;
using nmct.ba.cashlessproject.model;

namespace nmct.ba.cashlessproject.api.Helper
{
    public class DAerrorlog
    {
        public static void InsertErrorlog(Errorlog e)
        {
            string sql = "INSERT INTO Errorlog VALUES(@RegisterID, @Timestamp, @Message, @StackTrace)";
            DbParameter par1 = Database.AddParameter("KlantDB", "@RegisterID", e.RegisterID);
            DbParameter par2 = Database.AddParameter("KlantDB", "@Timestamp", e.TimeStamp);
            DbParameter par3 = Database.AddParameter("KlantDB", "@Message", e.Message);
            DbParameter par4 = Database.AddParameter("KlantDB", "@StackTrace", e.StackTrace);

            Database.InsertData(Database.GetConnection("KlantDB"),sql, par1, par2, par3, par4);
        }
    }
}