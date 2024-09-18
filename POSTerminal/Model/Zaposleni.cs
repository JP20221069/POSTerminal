using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSTerminal.Model
{
    class Zaposleni : IModelObject
    {
        public string TableName => throw new NotImplementedException();

        public string ProcedureName => "GetZaposleniBy";

        public string[] ColumnNames => new string[]{"JMBG","Ime","Prezime","Status","SefID"};

        string jmbg;
        string ime;
        string prezime;
        StatusZaposlenog status;
        long sefID;

        public string JMBG { get => jmbg; set => jmbg = value; }
        public string Ime { get => ime; set => ime = value; }
        public string Prezime { get => prezime; set => prezime = value; }
        internal StatusZaposlenog Status { get => status; set => status = value; }
        public long SefID { get => sefID; set => sefID = value; }

        public Zaposleni()
        {
            
        }
        public Zaposleni(string jmbg, string ime, string prezime, StatusZaposlenog status, long sefID)
        {
            JMBG = jmbg;
            Ime = ime;
            Prezime = prezime;
            Status = status;
            SefID = sefID;
        }


    }
}
