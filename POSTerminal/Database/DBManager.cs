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

        public int PrijavaMenadzera(string JMBG)
        {
            conn.OpenConnection();
            BeginTransaction();
            try
            {
                SqlCommand comm = conn.CreateCommand("SELECT dbo.PRIJAVA_MENADŽERA('" + JMBG + "') AS x;");
                object objx = comm.ExecuteScalar();
                int x;
                if (objx != null) x = Convert.ToInt32(objx);
                else x = -1;
                return x;
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
        }


        public int GetBrojKasira(string JMBG)
        {
            conn.OpenConnection();
            BeginTransaction();
            try
            {
                SqlCommand comm = conn.CreateCommand("SELECT dbo.FI_BROJ_KASIRA('" + JMBG + "') AS x;");
                int x = Convert.ToInt32(comm.ExecuteScalar());
                return x;
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
        }

        public string GetNajnovijiBrojacRacuna()
        {
            conn.OpenConnection();
            BeginTransaction();
            try
            {
                SqlCommand comm = conn.CreateCommand("EXEC FI_BROJAČ_RAČUNA;");
                object x = comm.ExecuteScalar();
                if(x==null)
                {
                    return null;
                }
                return x.ToString(); ;
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
        }

        public void Storniraj(Racun r, List<StavkaRacuna> sr,int sifraMenadzera)
        {
            conn.OpenConnection();
            BeginTransaction();
            try
            {
                foreach (StavkaRacuna s in sr)
                {
                    SqlCommand comm = conn.CreateCommand("EXEC STORNIRAJ_RAČUN @BrojRačuna='" + s.BrojRacuna + "', @IDStavke=" + s.ID + ",@ŠifraMenadžera=" + sifraMenadzera);
                    comm.ExecuteNonQuery();
                }
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
        }

        public void Add(IModelObject obj)
        {

            conn.OpenConnection();
            BeginTransaction();
            try
            {
                SqlCommand comm = conn.CreateCommand();
                comm.CommandText = $"EXEC ExecuteRawQuery N'INSERT INTO {obj.TableName}({obj.ColumnNames}) VALUES({obj.Values} )'";
                comm.ExecuteNonQuery();
                comm.Dispose();
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

        }


    }
}
