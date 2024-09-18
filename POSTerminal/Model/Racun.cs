using System;
using System.Collections.Generic;
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
        DateTime pfrbroj;
        NacinPlacanja nacinPlacanja;
        int prodajnomesto;
        int brojkasira;

        public string BrojRacuna { get => brojracuna; set => brojracuna = value; }
        public string ESIRbroj { get => esirbroj; set => esirbroj = value; }
        public DateTime Datum { get => datum; set => datum = value; }
        public DateTime Vreme { get => vreme; set => vreme = value; }
        public DateTime PFRVreme { get => pfrvreme; set => pfrvreme = value; }
        public DateTime PFRBroj { get => pfrbroj; set => pfrbroj = value; }
        public NacinPlacanja NacinPlacanja { get => nacinPlacanja; set => nacinPlacanja = value; }
        public int ProdajnoMesto { get => prodajnomesto; set => prodajnomesto = value; }
        public int BrojKasira { get => brojkasira; set => brojkasira = value; }

        public string TableName => "RAČUN";

        public string ProcedureName => "GetRačunBy";

        public string[] ColumnNames => throw new NotImplementedException();

        public Dictionary<string, string> FieldColumnMap => new Dictionary<string, string>()
        {
            { "BrojRačuna","BrojRacuna" },
            { "ESIRBroj","ESIRBroj" },
            { "Datum","Datum" },
            { "Vreme","Vreme" },
            { "PFRVreme","PFRVreme" },
            { "PFRBroj","PFRBroj" },
            { "NačinPlacanja","NacinPlacanja" },
            //{ "ProdajnoMesto"}
        };

        public Dictionary<string, Func<object, object>> ConversionMap => throw new NotImplementedException();

        public string Values => throw new NotImplementedException();

        public Racun()
        {
            
        }

        public Racun(string brojRacuna, string eSIRbroj, DateTime datum, DateTime vreme, DateTime pFRVreme, DateTime pFRBroj, NacinPlacanja nacinPlacanja, int prodajnoMesto, int brojKasira)
        {
            BrojRacuna = brojRacuna;
            ESIRbroj = eSIRbroj;
            Datum = datum;
            Vreme = vreme;
            PFRVreme = pFRVreme;
            PFRBroj = pFRBroj;
            NacinPlacanja = nacinPlacanja;
            ProdajnoMesto = prodajnoMesto;
            BrojKasira = brojKasira;
        }
    }
}
