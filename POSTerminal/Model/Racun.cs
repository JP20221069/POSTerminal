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
    public class Racun : IModelObject
    {
        string brojracuna;
        string esirbroj;
        DateTime datum;
        DateTime vreme;
        DateTime pfrvreme;
        string pfrbroj;
        NacinPlacanja nacinPlacanja;
        ProdajnoMesto prodajnomesto;
        int kasir;

        public string BrojRacuna { get => brojracuna; set => brojracuna = value; }
        public string ESIRbroj { get => esirbroj; set => esirbroj = value; }
        public DateTime Datum { get => datum; set => datum = value; }
        public DateTime Vreme { get => vreme; set => vreme = value; }
        public DateTime PFRVreme { get => pfrvreme; set => pfrvreme = value; }
        public string PFRBroj { get => pfrbroj; set => pfrbroj = value; }
        public NacinPlacanja NacinPlacanja { get => nacinPlacanja; set => nacinPlacanja = value; }
        public ProdajnoMesto ProdajnoMesto { get => prodajnomesto; set => prodajnomesto = value; }
        public int Kasir { get => kasir; set => kasir = value; }

        public string TableName => "RAČUN";

        public string Values => "''"+BrojRacuna+"'',''1121/2.0'',''"+DateTime.Now.ToString("yyyy-MM-dd") + "'',''"+DateTime.Now.ToShortTimeString() +"'',''"+DateTime.Now.ToString("yyyy-MM-dd") + "'',''"+PFRBroj+"'',"+(int)NacinPlacanja+","+ProdajnoMesto.ID+","+FrmGlavna.brojkasira;

        public string ProcedureName => "GetRačunBy";

        public string ColumnNames => "BrojRačuna, ESIRBroj, Datum, Vreme, PFRVreme, PFRBroj, NačinPlaćanja, ProdajnoMesto, BrojKasira";

        public Dictionary<string, string> FieldColumnMap => new Dictionary<string, string>()
        {
            { "BrojRacuna","BrojRačuna" },
            { "NacinPlacanja","NačinPlaćanja" },
            {"Kasir","BrojKasira" }
        };

        public Dictionary<string, Func<object, object>> ConversionMap => new Dictionary<string, Func<object, object>>()
        {
            ["ProdajnoMesto"] = (prodajnomestoid) => {
                DBManager db = new DBManager();
                List<SqlParameter> sqop = new List<SqlParameter>();
                sqop.Add(new SqlParameter("ID", prodajnomestoid.ToString()));
                DALObject da = db.GetSingle(new ProdajnoMesto(), sqop);
                return (ProdajnoMesto)da.Values;
            },
            ["NacinPlacanja"] = (nacinplacanja) =>
            {
                return (NacinPlacanja)nacinPlacanja;
            }
        };


        public Racun()
        {
            BrojRacuna = FiskalnaIntegracija.GenerisiBR();
            PFRBroj = FiskalnaIntegracija.GenerisiPFRBroj();
            ESIRbroj = "1121 / 2.0";
        }

        public Racun(string brojRacuna, string eSIRbroj, DateTime datum, DateTime vreme, DateTime pFRVreme, string pFRBroj, NacinPlacanja nacinPlacanja, ProdajnoMesto prodajnoMesto, Zaposleni brojKasira)
        {
            BrojRacuna = brojRacuna;
            ESIRbroj = eSIRbroj;
            Datum = datum;
            Vreme = vreme;
            PFRVreme = pFRVreme;
            PFRBroj = pFRBroj;
            NacinPlacanja = nacinPlacanja;
            ProdajnoMesto = prodajnoMesto;

        }
    }
}
