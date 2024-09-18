using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSTerminal.Model
{
    public class PoreskaGrupa : IModelObject
    {
        public string TableName => "PORESKA_GRUPA";

        public string ProcedureName => "GetPoreskaGrupaBy";

        public string[] ColumnNames => throw new NotImplementedException();

        int id;
        char akronim;
        float stopa;

        public int ID { get { return this.id; } set{ this.id = value; } }
        public char Akronim { get { return this.akronim; } set { this.akronim = value; } }
        public float Stopa { get { return this.stopa; } set { this.stopa = value; } }

        public PoreskaGrupa()
        {
            
        }

        public PoreskaGrupa(int id, char akronim, float stopa)
        {
            this.ID = id;
            this.Akronim = akronim;
            this.Stopa = stopa;
        }
    }
}
