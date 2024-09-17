using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSTerminal.Database
{
    public class DBConnection
    {
        private SqlConnection conn;
        private SqlTransaction tran;

        public DBConnection()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["cs_main"].ConnectionString);
        }

        public void OpenConnection()
        {
            conn?.Open();
        }

        public void CloseConnection()
        {
            conn?.Close();
        }

        public void BeginTransaction()
        {
            tran = conn.BeginTransaction();
        }
        public void Commit()
        {
            tran?.Commit();
        }
        public void Rollback()
        {
            tran?.Rollback();
        }
        public SqlCommand CreateCommand()
        {
            return new SqlCommand("", conn, tran);
        }
    }
}
