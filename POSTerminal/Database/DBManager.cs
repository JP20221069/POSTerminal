using POSTerminal.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace POSTerminal.Database
{
    public class DBManager
    {
        private DBConnection conn;
        public DBManager()
        {
            conn = new DBConnection();
        }

        public void Commit()
        {
            conn.Commit();
        }

        public void Rollback()
        {
            conn.Rollback();
        }

        public void BeginTransaction()
        {
            conn.BeginTransaction();
        }

        public DALObject GetList(IModelObject obj,List<SqlParameter> parameters = null)
        {
            DALObject retDalOb = new DALObject(DALObjectType.List, "", obj);
            conn.OpenConnection();
            BeginTransaction();
            try
            {
                SqlCommand comm = conn.CreateCommand("EXEC "+obj.ProcedureName);
                if(parameters!=null)
                {
                    string temp = " ";
                    for(int i=0;i<parameters.Count;i++)
                    {
                        if (i < parameters.Count - 1)
                        {
                            temp += "@" + parameters[i].ParameterName + ",";
                        }
                        else
                        {
                            temp += "@" + parameters[i].ParameterName + ";";
                        }
                    }
                    comm.CommandText += temp;
                    comm.Parameters.AddRange(parameters.ToArray());
                }
                retDalOb.GetValueList(comm.ExecuteReader());
            }
            catch (Exception ex)
            {
                Rollback();
                throw ex;
            }
            finally
            {
                Commit();
                conn.CloseConnection();
            }
            return retDalOb;
        }


        public DALObject GetSingle(IModelObject obj, List<SqlParameter> parameters = null)
        {
            try
            {
                DALObject dalobj = GetList(obj, parameters);
                object x = ((List<object>)dalobj.Values)[0];
                DALObject retdalobj = new DALObject(DALObjectType.Single, "", obj);
                retdalobj.Values = x;
                return retdalobj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Prijava(string JMBG)
        {
            conn.OpenConnection();
            BeginTransaction();
            try
            {
                SqlCommand comm = conn.CreateCommand("SELECT dbo.PRIJAVA_KASIRA('" + JMBG + "') AS x;");
                int x = Convert.ToInt32(comm.ExecuteScalar());
                if(x==1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch(Exception ex)
            {
                Rollback();
                throw ex;
            }
            finally
            {
                Commit();
                conn.CloseConnection();
            }
        }

        public void Add(IModelObject obj)
        {
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = $"INSERT INTO {obj.TableName}({obj.ColumnNames}) VALUES({obj.Values} )";
            cmd.ExecuteNonQuery();
            cmd.Dispose();
        }


    }
}
