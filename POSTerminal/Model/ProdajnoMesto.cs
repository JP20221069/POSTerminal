using POSTerminal.Database;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSTerminal.Model
{
    class ProdajnoMesto : IModelObject
    {
        int id;
        string pib;
        Mesto mesto;
        string ulica;
        string broj;
        string naziv;

        public ProdajnoMesto(int id, string pib, Mesto mesto, string ulica, string broj, string naziv)
        {
            this.id = id;
            this.pib = pib;
            this.mesto = mesto;
            this.ulica = ulica;
            this.broj = broj;
            this.naziv = naziv;
        }

        public int ID { get => id; set => id = value; }
        public string PIB { get => pib; set => pib = value; }
        public string Ulica { get => ulica; set => ulica = value; }
        public string Broj { get => broj; set => broj = value; }
        public string Naziv { get => naziv; set => naziv = value; }

        public string TableName => throw new NotImplementedException();

        public string ProcedureName => "GetProdajnoMestoBy";

        public string[] ColumnNames => throw new NotImplementedException();

        public Dictionary<string, string> FieldColumnMap => new Dictionary<string, string>()
        {
            {"Mesto","MestoID" }
        };

        public Dictionary<string, Func<object, object>> ConversionMap => new Dictionary<string, Func<object, object>>()
        {
            ["Mesto"] = (mestoid) => {
                DBManager db = new DBManager();
                List<SqlParameter> sqop = new List<SqlParameter>();
                sqop.Add(new SqlParameter("ID", mestoid.ToString()));
                DALObject da = db.GetSingle(new Mesto(), sqop);
                return (Mesto)da.Values;
            }
        };

        public string Values => throw new NotImplementedException();

        internal Mesto Mesto { get => mesto; set => mesto = value; }
    }
}
