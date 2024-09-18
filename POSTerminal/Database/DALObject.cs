using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
        object model_object;

        

        public DALObject(DALObjectType t, string name, object model_object)
        {
            this.type = t;
            fields = new List<string>();
            this.model_object = model_object;
            switch (t)
            {
                case DALObjectType.View:
                    this.Values = new DataTable(name);
                    break;
                case DALObjectType.List:
                    this.Values = new List<object>();
                    break;
                case DALObjectType.Single:
                case DALObjectType.Scalar:
                    Values = model_object;
                    break;

            }
            PropertyInfo[] pi = model_object.GetType().GetProperties();
            foreach (PropertyInfo p in pi)
            {
                Fields.Add(p.Name);
            }
        }

        public string Name { get => name; set => name = value; }
        public List<string> Fields { get => fields; set => fields = value; }
        public object Values { get => values; set => values = value; }
        public DALObjectType Type { get => type; set => type = value; }

        public void GetValueList(SqlDataReader reader, List<string> avoid_fields=null)
        {
            string[] avoid = new string[] { "TableName", "ProcedureName", "ColumnNames" };
            if(avoid_fields!=null)
            {
                avoid = avoid.Concat(avoid_fields.ToArray()).ToArray();
            }
            if (Type == DALObjectType.View)
            {
                throw new DALObjectException("Cannot populate view with reader.");
            }
            try
            {
                while (reader.Read())
                {
                    Object obj = Activator.CreateInstance(model_object.GetType());
                    if (Type == DALObjectType.Scalar)
                    {
                        Values = reader[0];
                    }
                    else
                    {
                        foreach (string name in Fields)
                        {
                            if (!avoid.Contains(name))
                            {
                                obj.GetType().GetProperty(name).SetValue(obj, Convert.ChangeType(reader[name], obj.GetType().GetProperty(name).PropertyType));
                            }
                        }
                    }
                    if (Type == DALObjectType.Single || Type == DALObjectType.Scalar)
                    {
                        Values = obj;
                        break;
                    }
                    else
                    {
                        ((List<object>)Values).Add(obj);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                reader.Close();
            }
        }

        public void GetValueTable(SqlDataAdapter adapter)
        {
            if (Type == DALObjectType.View)
            {
                try
                {
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    Values = ds.Tables[0];
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                throw new DALObjectException("Cannot populate anything other than view with adapter.");
            }
        }
    }
}
