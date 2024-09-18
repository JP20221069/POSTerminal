using POSTerminal.Database;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSTerminal.Model
{
    class StavkaRacuna : IModelObject
    {
        int id;
        string brojracuna;
        Proizvod proizvod;
        float kolicina;
        bool storno;
        Zaposleni odobravastorno;

        public string TableName => throw new NotImplementedException();

        public string ProcedureName => throw new NotImplementedException();

        public string[] ColumnNames => throw new NotImplementedException();

        public Dictionary<string, string> FieldColumnMap => new Dictionary<string, string>()
        {
            {"BrojRacuna","BrojRačuna" },
            {"Kolicina","Količina" }
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
            }
        };

        public int ID { get => id; set => id = value; }
        public string BrojRacuna { get => brojracuna; set => brojracuna = value; }
        public Proizvod Proizvod { get => proizvod; set => proizvod = value; }
        public float Kolicina { get => kolicina; set => kolicina = value; }
        public bool Storno { get => storno; set => storno = value; }
        internal Zaposleni OdobravaStorno { get => odobravastorno; set => odobravastorno = value; }

        public string Values => throw new NotImplementedException();

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
    }
}
