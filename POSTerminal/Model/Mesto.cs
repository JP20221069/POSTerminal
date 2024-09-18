using POSTerminal.Database;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSTerminal.Model
{
    class Mesto : IModelObject
    {

        public string TableName => throw new NotImplementedException();

        public string ProcedureName => "GetMestoBy";

        public string[] ColumnNames => throw new NotImplementedException();

        public Dictionary<string, string> FieldColumnMap => new Dictionary<string, string>()
        {
            {"PostanskiBroj","PoštanskiBroj" },
            {"Opstina","OpštinaID" }
        };

        public Dictionary<string, Func<object, object>> ConversionMap => new Dictionary<string, Func<object, object>>()
        {
            ["Opstina"] = (opstinaid) => {
                DBManager db = new DBManager();
                List<SqlParameter> sqop = new List<SqlParameter>();
                sqop.Add(new SqlParameter("ID", opstinaid.ToString()));
                DALObject da = db.GetSingle(new Opstina(), sqop);
                return (Opstina)da.Values;
            }
        };

        public int ID { get => id; set => id = value; }
        public string Naziv { get => naziv; set => naziv = value; }
        public string PostanskiBroj { get => postanskibroj; set => postanskibroj = value; }

        public string Values => throw new NotImplementedException();

        int id;
        string naziv;
        string postanskibroj;

        public Mesto()
        {
            
        }

        public Mesto(int id, string naziv, string postanskibroj)
        {
            this.id = id;
            this.naziv = naziv;
            this.postanskibroj = postanskibroj;
        }
    }
}
