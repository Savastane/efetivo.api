namespace infra.generics.repository
{

    using System;
    
    using infra.generics.repository.exceptions;
    using System.Data;
    using System.Data.Common;
    using Microsoft.EntityFrameworkCore;
    
    using System.Collections.Generic;
    using System.Reflection;

    public class UnitOfWork<TContext> : IUnitOfWork where TContext : IDbContext
    {
        #region Variáveis
        private bool isCloseConnection = true;

        /// <summary>
        /// Context.
        /// </summary>
        private readonly IDbContext db;
        #endregion Variáveis

        #region Propriedades

        /// <summary>
        /// Context de trabalho
        /// </summary>
        public IDbContext Db
        {
            get { return db; }
        }
        #endregion Propriedades

        #region Contrutor

        /// <summary>
        /// Contrutor.
        /// </summary>
        public UnitOfWork()
        {
            try
            {
                Type type = typeof(TContext);
                db = (TContext)type.Assembly.CreateInstance(type.ToString());
            }
            catch (Exception ex)
            {
                throw new RepositorioException("Erro ao executar o comando. Classe: UnitOfWork; Método: UnitOfWork;  Erro: " + (ex.InnerException.InnerException).Message);
            }
        }
        #endregion Contrutor

        #region Métodos internos e privados

        /// <summary>
        /// Adiciona um parametro na base de dados.
        /// </summary>
        /// <param name="_cmd">DbCommand que será adicionado os parametros.</param>
        /// <param name="_param">Lista de parametros</param>
        private void addParam(IDbCommand _cmd, List<object> _param)
        {
            if (_param != null)
            {
                _param.ForEach(delegate (object p)
                {
                    _cmd.Parameters.Add(p);
                });
            }
        }

        private DbConnection GetConnection()
        {
            this.isCloseConnection = false;
            return (db as DbContext).Database.GetDbConnection();

            /*
            string connStr = (db as DbContext).Database.GetDbConnection().ConnectionString;

            string providerName = null;
            var csb = new DbConnectionStringBuilder { ConnectionString = connStr };

            if (csb.ContainsKey("provider"))
            {
                providerName = csb["provider"].ToString();
            }
            else
            {
                var css = ConfigurationManager
                                  .ConnectionStrings
                                  .Cast<ConnectionStringSettings>()
                                  .FirstOrDefault(x => x.ConnectionString == connStr);
                if (css != null) providerName = css.ProviderName;
            }

            if (providerName != null)
            {
                var providerExists = DbProviderFactories
                                            .GetFactoryClasses()
                                            .Rows.Cast<DataRow>()
                                            .Any(r => r[2].Equals(providerName));
                if (providerExists)
                {
                    var factory = DbProviderFactories.GetFactory(providerName);
                    var dbConnection = factory.CreateConnection();

                    dbConnection.ConnectionString = connStr;
                    return dbConnection;
                }
            }

            this.isCloseConnection = false;
            return (db as DbContext).Database.GetDbConnection();
            */
            //return null;
        }

        //private Exception TrataErro(Exception ex, string mensagem = "")
        //{
        //    //if (HttpContext.Current == null && HttpContext.Current.IsDebuggingEnabled)
        //    //{
        //    //    return ex;
        //    //}
        //    //else
        //    //{
        //        return new RepositorioException(mensagem);
        //    //}
        //}
        #endregion Métodos internos e privados

        #region Métodos executáveis

        /// <summary>
        /// Retorna um objeto via SQL
        /// </summary>
        /// <param name="_sql">código sql para retorno</param>
        /// <param name="_param">lista de parametros</param>
        /// <param name="_cmdType">commandType</param>
        public void ExecuteNonQuery(string _sql, ref List<object> _param, CommandType _cmdType = CommandType.Text)
        {
            DbConnection con = this.GetConnection();
            IDbCommand cmd = con.CreateCommand();

            cmd.CommandText = _sql;
            cmd.CommandTimeout = 0;
            cmd.CommandType = _cmdType;

            addParam(cmd, _param);

            try
            {
                if (con.State == ConnectionState.Closed) con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                cmd.Dispose();
                con.Dispose();

                throw new Exception("Erro ao executar o comando. Classe: UnitOfWork; Método: ExecuteScalar;  Erro: " + ex.Message);
            }
            finally
            {
                if (isCloseConnection)
                {
                    con.Open();
                }
            }
        }

        /// <summary>
        /// Salva as alterações realizadas na base.
        /// </summary>
        public void Save()
        {
            try
            {
                db.SaveChanges();
            }
            //catch (DbEntityValidationException ex)
            //{
            //    string mensagem = "";
            //    IEnumerator<DbEntityValidationResult> validResult = ex.EntityValidationErrors.GetEnumerator();
            //    while (validResult.MoveNext())
            //    {
            //        IEnumerator<DbValidationError> validError = validResult.Current.ValidationErrors.GetEnumerator();
            //        while (validError.MoveNext())
            //        {
            //            mensagem += validError.Current.PropertyName + ": " + validError.Current.ErrorMessage + "; ";
            //        }
            //    }

            //    throw new RepositorioException("Inconsistência de dados. Exception:" + ex.Message + "  | Detalhes: " + mensagem);
            //}
            catch (DbUpdateException ex)
            {
                string mensagem = (ex.InnerException == null) ? ex.Message : (ex.InnerException.InnerException != null) ? ex.InnerException.InnerException.Message : ex.InnerException.Message;
                throw new RepositorioException("Inconsistência de dados. Exception: " + mensagem);
            }
            catch (Exception ex)
            {
                //string mensagem = (ex.InnerException == null) ? ex.Message : (ex.InnerException.InnerException != null) ? ex.InnerException.InnerException.Message : ex.InnerException.Message;
                //throw TrataErro(ex, "Falha ao executar o comando. Exception: " + mensagem);
                throw ex;
            }
        }

        //public async void SaveAsync()
        //{
        //    try
        //    {
        //        await db.SaveChangesAsync();
        //    }
        //    catch (DbEntityValidationException ex)
        //    {
        //        string mensagem = "";
        //        IEnumerator<DbEntityValidationResult> validResult = ex.EntityValidationErrors.GetEnumerator();
        //        while (validResult.MoveNext())
        //        {
        //            IEnumerator<DbValidationError> validError = validResult.Current.ValidationErrors.GetEnumerator();
        //            while (validError.MoveNext())
        //            {
        //                mensagem += validError.Current.PropertyName + ": " + validError.Current.ErrorMessage + "; ";
        //            }
        //        }

        //        throw new RepositorioException("Inconsistência de dados. Exception:" + ex.Message + "  | Detalhes: " + mensagem);
        //    }
        //    catch (DbUpdateException ex)
        //    {
        //        string mensagem = (ex.InnerException == null) ? ex.Message : (ex.InnerException.InnerException != null) ? ex.InnerException.InnerException.Message : ex.InnerException.Message;
        //        throw new RepositorioException("Inconsistência de dados. Exception: " + mensagem);
        //    }
        //    catch (Exception ex)
        //    {
        //        //string mensagem = (ex.InnerException == null) ? ex.Message : (ex.InnerException.InnerException != null) ? ex.InnerException.InnerException.Message : ex.InnerException.Message;
        //        //throw TrataErro(ex, "Falha ao executar o comando. Exception: " + mensagem);
        //        throw ex;
        //    }
        //}
        #endregion Métodos executáveis

        #region Métodos que retornam dados

        /// <summary>
        /// retorna um data table apartir de um sql.
        /// </summary>
        /// <param name="_sql">consulta na base.</param>
        /// <param name="_param">lista de parametros da base</param>
        /// <param name="_cmdType">commandType</param>
        /// <returns>DataTable</returns>
        public DataTable GetDataTable(string _sql, List<object> _param = null, CommandType _cmdType = CommandType.Text)
        {
            DbConnection con = this.GetConnection();
            DbCommand cmd = con.CreateCommand();

            cmd.CommandText = _sql;
            cmd.CommandTimeout = 0;
            cmd.CommandType = _cmdType;            

            addParam(cmd, _param);

            try
            {
                DataSet dt = new DataSet();

                DbProviderFactory factory = DbProviderFactories.GetFactory(con);
                DbDataAdapter da = factory.CreateDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(dt);

                return dt.Tables[0];
            }
            catch (Exception ex)
            {
                cmd.Dispose();
                con.Dispose();

                throw new Exception("Erro ao executar o comando. Classe: UnitOfWork; Método: GetDataTale;  Erro: " + ex.Message);
            }
            finally
            {
                if (isCloseConnection)
                {
                    con.Open();
                }
            }
        }

        /// <summary>
        /// retorna um data table apartir de um sql.
        /// </summary>
        /// <param name="_sql">consulta na base.</param>
        /// <param name="_param">lista de parametros da base</param>
        /// <param name="_cmdType">commandType</param>
        /// <returns>DataTable</returns>
        [Obsolete("Correção na nomenclatura do método. Utilizar o GetDataTable", false)]
        public DataTable GetDataTale(string _sql, List<object> _param = null, CommandType _cmdType = CommandType.Text)
        {
            return this.GetDataTable(_sql, _param, _cmdType);
        }

        /// <summary>
        /// retorna um data set apartir de um sql.
        /// </summary>
        /// <param name="_sql">consulta na base.</param>
        /// <param name="_param">lista de parametros da base</param>
        /// <param name="_cmdType">commandType</param>
        /// <returns>DataSet</returns>
        public DataSet GetDataSet(string _sql, List<object> _param = null, CommandType _cmdType = CommandType.Text)
        {
            DbConnection con = this.GetConnection();
            IDbCommand cmd = con.CreateCommand();

            cmd.CommandText = _sql;
            cmd.CommandTimeout = 0;
            cmd.CommandType = _cmdType;

            //if (cmd.GetType() == typeof(Oracle.DataAccess.Client.OracleCommand))
            //{
            //    (cmd as Oracle.DataAccess.Client.OracleCommand).BindByName = true;
            //}
            //else if (cmd.GetType() == typeof(Oracle.ManagedDataAccess.Client.OracleCommand))
            //{
            //    (cmd as Oracle.ManagedDataAccess.Client.OracleCommand).BindByName = true;
            //}

            addParam(cmd, _param);

            try
            {
                DataSet dt = new DataSet();

                DbProviderFactory factory = DbProviderFactories.GetFactory(con);
                IDbDataAdapter da = factory.CreateDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(dt);

                return dt;
            }
            catch (Exception ex)
            {
                cmd.Dispose();
                con.Dispose();

                throw new Exception("Erro ao executar o comando. Classe: UnitOfWork; Método: GetDataTale;  Erro: " + ex.Message);
            }
            finally
            {
                if (isCloseConnection)
                {
                    con.Open();
                }
            }

        }

        /// <summary>
        /// Retorna uma lista de model apartir de uma consulta sql.
        /// </summary>
        /// <typeparam name="TModel">Tipo da lista.</typeparam>
        /// <param name="_sql">Consulta sql.</param>
        /// <param name="_param">Lista de parametros.</param>
        /// <param name="_cmdType">commandType</param>
        /// <returns>Lista do tipo.</returns>
        public List<TModel> GetListModel<TModel>(string _sql, List<object> _param = null, CommandType _cmdType = CommandType.Text)
        {
            List<TModel> result = new List<TModel>();

            DataTable dt = this.GetDataTable(_sql, _param, _cmdType);

            return this.GetMapModel<TModel>(dt);
        }

        /// <summary>
        /// Retorna uma mapeamento apartir da tabela passada via parametro.
        /// </summary>
        /// <typeparam name="dt">tabela para montar a lista.</typeparam>
        /// <returns>Lista do tipo.</returns>
        public List<TModel> GetMapModel<TModel>(DataTable dt)
        {
            List<TModel> result = new List<TModel>();

            try
            {
                // montando a lista de  objetos com os dados da tabela.
                foreach (DataRow dr in dt.Rows)
                {
                    Type type = typeof(TModel);
                    TModel tview = (TModel)type.Assembly.CreateInstance(type.ToString());

                    foreach (PropertyInfo info in type.GetProperties())
                    {
                        if (dt.Columns.Contains(info.Name) && dr[info.Name] != System.DBNull.Value)
                        {
                            info.SetValue(tview, dr[info.Name], null);
                        }
                    }
                    result.Add(tview);
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao executar o comando. Classe: UnitOfWork; Método: GetListModel;  Erro: " + (ex.InnerException.InnerException).Message);
            }
        }

        /// <summary>
        /// Retorna um objeto via SQL
        /// </summary>
        /// <param name="_sql">código sql para retorno</param>
        /// <param name="_param">lista de parametros</param>
        /// <param name="_cmdType">commandType</param>
        /// <returns>objeto.</returns>
        public object ExecuteScalar(string _sql, List<object> _param = null, CommandType _cmdType = CommandType.Text)
        {
            DbConnection con = this.GetConnection();
            IDbCommand cmd = con.CreateCommand();

            cmd.CommandText = _sql;
            cmd.CommandTimeout = 0;
            cmd.CommandType = _cmdType;

            addParam(cmd, _param);

            try
            {
                if (con.State == ConnectionState.Closed) con.Open();
                return cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                cmd.Dispose();
                con.Dispose();

                throw new Exception("Erro ao executar o comando. Classe: UnitOfWork; Método: ExecuteScalar;  Erro: " + ex.Message);
            }
            finally
            {
                if (isCloseConnection)
                {
                    con.Open();
                }
                else
                {
                    this.isCloseConnection = true;
                }
            }
        }
        #endregion Métodos que retornam dados

        #region Disposable

        /// <summary>
        /// Método da interface IDisposable
        /// </summary>
        public virtual void Dispose()
        {
            db.Dispose();
        }
        #endregion Disposable
    }
}
