using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSTerminal.Model
{
    class Preduzece : IModelObject
    {
        public string TableName => throw new NotImplementedException();

        public string ProcedureName => "GetPreduzećeBy";

        public string[] ColumnNames => throw new NotImplementedException();

        public Dictionary<string, string> FieldColumnMap => new Dictionary<string, string>();

        public Dictionary<string, Func<object, object>> ConversionMap => new Dictionary<string, Func<object, object>>();

        public string PIB { get => pib; set => pib = value; }
        public string Naziv { get => naziv; set => naziv = value; }

        public string Values => throw new NotImplementedException();

        string pib;
        string naziv;

        public Preduzece()
        {
            
        }

        public Preduzece(string pIB, string naziv)
        {
            pib = pIB;
            this.Naziv = naziv;
        }
    }
}
