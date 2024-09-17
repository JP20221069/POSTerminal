using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace POSTerminal.Database
{
    public class DALObject
    {
        string name;
        List<string> fields;
        object values;
        DALObjectType type;

        public DALObject(DALObjectType t,string name,object model_object)
        {
            switch(t)
            {
                case DALObjectType.View:
                    this.values = new DataTable(name);
                    break;
                case DALObjectType.List:
                    this.values = new List<object>();
                    break;
                case DALObjectType.Single:
                case DALObjectType.Scalar:
                    values = model_object;
                    break;

            }
            PropertyInfo[] pi = model_object.GetType().GetProperties();
            foreach(PropertyInfo p in pi)
            {
                fields.Add(p.Name);
            }
        }
    }
}
