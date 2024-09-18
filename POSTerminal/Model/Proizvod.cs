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
        public int Naziv { get { return this.naziv; } set { this.naziv = value; } }
        public float Cena { get { return this.cena; } set { this.cena = value; } }
        public PoreskaGrupa PoreskaGrupaObj { get { return this.poreskagrupa; } set { this.poreskagrupa = value; } }

        public int Poreska_Grupa
        {
            get { return this.poreska_grupa; }
            set
            {
                this.poreska_grupa = value;
                DBManager db = new DBManager();
                List<SqlParameter> lista = new List<SqlParameter>();
                lista.Add(new SqlParameter("ID", this.poreska_grupa.ToString()));
                this.poreskagrupa = (PoreskaGrupa)db.GetSingle(PoreskaGrupaObj, lista).Values;
            }
        }

        int id;
        int naziv;
        float cena;
        int poreska_grupa;
        PoreskaGrupa poreskagrupa;
        public Proizvod()
        {
            
        }
        public Proizvod(int id, int naziv, float cena, PoreskaGrupa poreskaGrupa)
        {
            ID = id;
            Naziv = naziv;
            Cena = cena;
            PoreskaGrupaObj = poreskaGrupa;
        }
    }
}
