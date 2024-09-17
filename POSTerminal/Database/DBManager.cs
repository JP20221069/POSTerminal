using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSTerminal.Database
{
    public class DBManager
    {
        private DBConnection conn;
        public DBManager()
        {
            conn = new DBConnection();
        }

        public void Commit()
        {
            conn.Commit();
        }

        public void Rollback()
        {
            conn.Rollback();
        }

        public void BeginTransaction()
        {
            conn.BeginTransaction();
        }
    }
}
