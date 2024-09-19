using POSTerminal.Database;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSTerminal.Model
{
    public class StavkaRacuna : IModelObject
    {
        int id;
        string brojracuna;
        Proizvod proizvod;
        float kolicina;
        bool storno;
        Zaposleni odobravastorno;

        public string TableName => "STAVKA_RAČUNA";

        public string ProcedureName => "GetStavkaRačunaBy";

        public string ColumnNames => "BrojRačuna, ProizvodID, Količina, Storno, OdobravaStorno";

        public string Values => "''" + brojracuna + "''," + proizvod.ID + "," + kolicina.ToString(CultureInfo.InvariantCulture) + ",0,NULL";

        public Dictionary<string, string> FieldColumnMap => new Dictionary<string, string>()
        {
            {"BrojRacuna","BrojRačuna" },
            {"Kolicina","Količina" },
            { "Proizvod","ProizvodID"}
        };

        public Dictionary<string, Func<object, object>> ConversionMap => new Dictionary<string, Func<object, object>>()
        {
            ["OdobravaStorno"] = (zaposleniid) =>
            {
                DBManager db = new DBManager();
                List<SqlParameter> sqop = new List<SqlParameter>();
                sqop.Add(new SqlParameter("JMBG", zaposleniid.ToString()));
                DALObject da = db.GetSingle(new Zaposleni(), sqop);
                return (Zaposleni)da.Values;
            },
            ["Proizvod"] = (proizvodid) =>
            {
                DBManager db = new DBManager();
                List<SqlParameter> sqop = new List<SqlParameter>();
                sqop.Add(new SqlParameter("ID", proizvodid.ToString()));
                DALObject da = db.GetSingle(new Proizvod(), sqop);
                return (Proizvod)da.Values;
            }
        };

        public int ID { get => id; set => id = value; }
        public string BrojRacuna { get => brojracuna; set => brojracuna = value; }
        public Proizvod Proizvod { get => proizvod; set => proizvod = value; }
        public float Kolicina { get => kolicina; set => kolicina = value; }
        public bool Storno { get => storno; set => storno = value; }
        internal Zaposleni OdobravaStorno { get => odobravastorno; set => odobravastorno = value; }



        public StavkaRacuna()
        {
            
        }
        public StavkaRacuna(int id, string brojracuna, Proizvod proizvod, float kolicina, bool storno, Zaposleni odobravastorno)
        {
            this.ID = id;
            this.BrojRacuna = brojracuna;
            this.Proizvod = proizvod;
            this.Kolicina = kolicina;
            this.Storno = storno;
            this.OdobravaStorno = odobravastorno;
        }

        public override string ToString()
        {
            return this.proizvod.Naziv + " | " + this.kolicina;
        }
    }
}
