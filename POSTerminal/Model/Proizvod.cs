using POSTerminal.Database;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSTerminal.Model
{
    public class Proizvod : IModelObject
    {
        public string TableName => "PROIZVOD";

        public string ProcedureName => "GetProizvodBy";

        public string[] ColumnNames => throw new NotImplementedException();

        public int ID { get { return this.id; } set { this.id = value; } }
        public string Naziv { get { return this.naziv; } set { this.naziv = value; } }
        public float Cena { get { return this.cena; } set { this.cena = value; } }
        public PoreskaGrupa PoreskaGrupa { get { return this.poreskagrupa; } set { this.poreskagrupa = value; } }

        public Dictionary<string, string> FieldColumnMap => new Dictionary<string, string>()
        {
            { "PoreskaGrupa","Poreska_Grupa" }
        };

        public Dictionary<string, Func<object, object>> ConversionMap => new Dictionary<string, Func<object, object>>()
        {
            ["PoreskaGrupa"] = (poreskagrupaid)=>{
                DBManager db = new DBManager();
                List<SqlParameter> sqop = new List<SqlParameter>();
                sqop.Add(new SqlParameter("ID", poreskagrupaid.ToString()));
                DALObject da = db.GetSingle(new PoreskaGrupa(), sqop);
                return (PoreskaGrupa)da.Values;
            }
        };

        public string Values => throw new NotImplementedException();

        int id;
        string naziv;
        float cena;
        PoreskaGrupa poreskagrupa;
        public Proizvod()
        {
            
        }
        public Proizvod(int id, string naziv, float cena, PoreskaGrupa poreskaGrupa)
        {
            ID = id;
            Naziv = naziv;
            Cena = cena;
            this.poreskagrupa = poreskaGrupa;
        }
    }
}
