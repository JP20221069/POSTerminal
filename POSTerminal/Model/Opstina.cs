using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSTerminal.Model
{
    class Opstina : IModelObject
    {
        int id;
        string naziv;
        string grad;

        public int ID { get => id; set => id = value; }
        public string Naziv { get => naziv; set => naziv = value; }
        public string Grad { get => grad; set => grad = value; }

        public Opstina()
        {
            
        }

        public Opstina(int id, string naziv, string grad)
        {
            this.ID = id;
            this.Naziv = naziv;
            this.Grad = grad;
        }

        public string TableName => throw new NotImplementedException();

        public string ProcedureName => "GetOpštinaBy";

        public string[] ColumnNames => throw new NotImplementedException();

        public Dictionary<string, string> FieldColumnMap => new Dictionary<string, string>();

        public Dictionary<string, Func<object, object>> ConversionMap => new Dictionary<string, Func<object, object>>();

        public string Values => throw new NotImplementedException();
    }
}
