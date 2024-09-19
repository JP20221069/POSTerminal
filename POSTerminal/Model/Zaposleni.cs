using POSTerminal.Database;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSTerminal.Model
{
    public class Zaposleni : IModelObject
    {
        public string TableName => throw new NotImplementedException();

        public string ProcedureName => "GetZaposleniBy";

        public string ColumnNames => "JMBG,Ime,Prezime,Status,SefID";

        public Dictionary<string, string> FieldColumnMap => new Dictionary<string, string>()
        {
            {"Sef","ŠefID" }
        };

        public Dictionary<string, Func<object,object>> ConversionMap => new Dictionary<string, Func<object,object>>()
        {
            ["SefID"] = (jmbgx) =>
            {
                if (jmbgx.ToString()=="") return null;
                DBManager db = new DBManager();
                List<SqlParameter> sqop = new List<SqlParameter>();
                sqop.Add(new SqlParameter("JMBG", (string)jmbgx));
                DALObject da = db.GetSingle(new Zaposleni(), sqop);
                return (Zaposleni)da.Values;
            }
        };

        string jmbg;
        string ime;
        string prezime;
        StatusZaposlenog status;

        Zaposleni sef;

        public string JMBG { get => jmbg; set => jmbg = value; }
        public string Ime { get => ime; set => ime = value; }
        public string Prezime { get => prezime; set => prezime = value; }
        internal StatusZaposlenog Status { get => status; set => status = value; }
        internal Zaposleni Sef { get => sef; set => sef = value; }

        public string Values => throw new NotImplementedException();

        public Zaposleni()
        {
            
        }
        public Zaposleni(string jmbg, string ime, string prezime, StatusZaposlenog status)
        {
            JMBG = jmbg;
            Ime = ime;
            Prezime = prezime;
            Status = status;
        }


    }
}
