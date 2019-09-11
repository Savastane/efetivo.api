using System;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;


namespace infra.generics.repository
{
    
    using System.Reflection;
    using Microsoft.EntityFrameworkCore;
    using System.Data;


    public class DbContextRepositorio : DbContext, IDbContext
    {
        #region Métodos internos e privados

        private IDbConnection dbConnection;

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


        public void setConection(IDbConnection dbConnection)
        {
            this.dbConnection = dbConnection;
        }

        private DataSet FillData(string _sql, List<object> _param = null, CommandType _cmdType = CommandType.Text)
        {



            IDbConnection con = dbConnection; //new Oracle.ManagedDataAccess.Client.OracleConnection("DATA SOURCE=DBLAB;PASSWORD=123@academico;USER ID=academico");
            IDbCommand cmd = con.CreateCommand();

            cmd.CommandText = _sql;
            cmd.CommandTimeout = 0;
            cmd.CommandType = _cmdType;

            addParam(cmd, _param);

            try
            {
                DataSet dt = new DataSet();

                DbProviderFactory factory = DbProviderFactories.GetFactory((DbConnection)con);
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
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

                cmd.Dispose();
                con.Dispose();
            }
        }

        /// <summary>
        /// Retorna uma mapeamento apartir da tabela passada via parametro.
        /// </summary>
        /// <typeparam name="dt">tabela para montar a lista.</typeparam>
        /// <returns>Lista do tipo.</returns>
        private List<TModel> getMapModel<TModel>(DataTable dt)
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
                        bool extColumn = false;
                        string columnName = "";
                        for (int i = 0; i < dt.Columns.Count; i++)
                        {
                            extColumn = info.Name.Equals(dt.Columns[i].ColumnName, StringComparison.InvariantCultureIgnoreCase);
                            if (extColumn)
                            {
                                columnName = dt.Columns[i].ColumnName;
                                break;
                            }
                        }

                        if (extColumn && dr[columnName] != System.DBNull.Value)
                        {
                            info.SetValue(tview, dr[columnName], null);
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
        #endregion Métodos internos e privados

        #region Override do DbContext

        /*
        public DbContextRepositorio(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
         //   this.Configuration.ProxyCreationEnabled = false;
          //  this.Configuration.LazyLoadingEnabled = false;
        }
        */
        /// <summary>
        /// Salva todas as alterações feitas nesse contexto ao banco de dados subjacente.
        /// </summary>
        /// <returns>Numeros de entidades alteradas.</returns>
        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();
                       
            return base.SaveChanges();
        }

        ///// <summary>
        ///// Salva todas as alterações feitas nesse contexto ao banco de dados subjacente (método async).
        ///// </summary>
        ///// <returns>Numeros de entidades alteradas.</returns>
        //public override async Task<int> SaveChangesAsync()
        //{
        //    return await base.SaveChangesAsync();
        //}

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    //Aqui vamos remover a pluralização padrão do Etity Framework que é em inglês
        //    modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

        //    //Desabilitamos o delete em cascata em relacionamentos 1:N evitando
        //    //ter registros filhos     sem registros pai
        //    modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

        //    //Basicamente a mesma configuração, porém em relacionamenos N:N
        //    modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();


        //    //Definimos usando reflexão que toda propriedade que contenha
        //    //ID_ + "Nome da classe" como "ID_CURSO" por exemplo, seja dada como
        //    //chave primária, caso não tenha sido especificado
        //    //modelBuilder.Properties()
        //    //   .Where(p => p.Name.Equals("ID_" + p.ReflectedType.Name, StringComparison.InvariantCultureIgnoreCase))
        //    //   .Configure(p => p.IsKey());

        //    base.OnModelCreating(modelBuilder);
        //}

        #endregion Override do DbContext

        #region Métodos que retornam dados

        /// <summary>
        /// retorna um objeto a partir de um sql.
        /// </summary>
        /// <param name="_sql">consulta na base.</param>
        /// <param name="_param">lista de parametros da base</param>
        /// <param name="_cmdType">commandType</param>
        /// <returns>DataSet</returns>
        public object ExecuteScalar(string _sql, List<object> _param = null)
        {
            return this.Database.ExecuteSqlCommand(_sql, _param.ToArray());
        }

        public object ExecuteScalarADO(string _sql, List<object> _param = null, CommandType _cmdType = CommandType.Text)
        {
            DbConnection con = this.Database.GetDbConnection(); //new Oracle.ManagedDataAccess.Client.OracleConnection("DATA SOURCE=DBLAB;PASSWORD=123@academico;USER ID=academico");
            IDbCommand cmd = con.CreateCommand();

            cmd.CommandText = _sql;
            cmd.CommandTimeout = 0;
            cmd.CommandType = _cmdType;

            addParam(cmd, _param);

            try
            {
                con.Open();

                return cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                cmd.Dispose();
                con.Dispose();

                throw new Exception("Erro ao executar o comando. Classe: UnitOfWork; Método: GetDataTale;  Erro: " + ex.Message);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

                cmd.Dispose();
                con.Dispose();
            }
        }

        public void ExecuteNonQueryADO(string _sql, List<object> _param, CommandType _cmdType = CommandType.Text)
        {
            DbConnection con = this.Database.GetDbConnection(); //new Oracle.ManagedDataAccess.Client.OracleConnection("DATA SOURCE=DBLAB;PASSWORD=123@academico;USER ID=academico");
            IDbCommand cmd = con.CreateCommand();

            cmd.CommandText = _sql;
            cmd.CommandTimeout = 0;
            cmd.CommandType = _cmdType;

            addParam(cmd, _param);

            try
            {
                con.Open();

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                cmd.Dispose();
                con.Dispose();

                throw new Exception("Erro ao executar o comando. Classe: UnitOfWork; Método: GetDataTale;  Erro: " + ex.Message);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

                cmd.Dispose();
                con.Dispose();
            }
        }

        ///// <summary>
        ///// retorna um objeto a partir de um sql (método async).
        ///// </summary>
        ///// <param name="_sql">consulta na base.</param>
        ///// <param name="_param">lista de parametros da base</param>
        ///// <param name="_cmdType">commandType</param>
        ///// <returns>DataSet</returns>
        //public async Task<object> ExecuteScalarAsync(string _sql, List<object> _param = null)
        //{
        //    return await this.Database.ExecuteSqlCommandAsync(_sql, _param.ToArray());
        //}

        //public async Task<object> ExecuteScalarAsyncADO(string _sql, List<object> _param = null, CommandType _cmdType = CommandType.Text)
        //{
        //    return await Task.Run(() => { return ExecuteScalarADO(_sql, _param, _cmdType); });
        //}

        /// <summary>
        /// retorna um data table a partir de um sql.
        /// </summary>
        /// <param name="_sql">consulta na base.</param>
        /// <param name="_param">lista de parametros da base</param>
        /// <param name="_cmdType">commandType</param>
        /// <returns>DataTable</returns>
        public DataTable GetDataTable(string _sql, List<object> _param = null, CommandType _cmdType = CommandType.Text)
        {
            return FillData(_sql, _param, _cmdType).Tables[0];
        }

        ///// <summary>
        ///// retorna um data table a partir de um sql (método async).
        ///// </summary>
        ///// <param name="_sql">consulta na base.</param>
        ///// <param name="_param">lista de parametros da base</param>
        ///// <param name="_cmdType">commandType</param>
        ///// <returns>DataTable</returns>        
        //public async Task<DataTable> GetDataTableAsync(string _sql, List<object> _param = null, CommandType _cmdType = CommandType.Text)
        //{
        //    return await Task.Run(() => { return FillData(_sql, _param, _cmdType).Tables[0]; });
        //}

        /// <summary>
        /// retorna um data set a partir de um sql.
        /// </summary>
        /// <param name="_sql">consulta na base.</param>
        /// <param name="_param">lista de parametros da base</param>
        /// <param name="_cmdType">commandType</param>
        /// <returns>DataSet</returns>
        public DataSet GetDataSet(string _sql, List<object> _param = null, CommandType _cmdType = CommandType.Text)
        {
            return FillData(_sql, _param, _cmdType);
        }

        

        ///// <summary>
        ///// retorna um data set a partir de um sql (método async).
        ///// </summary>
        ///// <param name="_sql">consulta na base.</param>
        ///// <param name="_param">lista de parametros da base</param>
        ///// <param name="_cmdType">commandType</param>
        ///// <returns>DataSet</returns>
        //public async Task<DataSet> GetDataSetAsync(string _sql, List<object> _param = null, CommandType _cmdType = CommandType.Text)
        //{
        //    return await Task.Run(() => { return FillData(_sql, _param, _cmdType); });
        //}

        /// <summary>
        /// Executa consult e retorna uma lista a partir de um Sql.
        /// </summary>
        /// <typeparam name="T">Entidade de retorno da Lista</typeparam>
        /// <param name="_sql">Consulta Sql</param>
        /// <param name="_param">Parametros</param>
        /// <returns>Lista de T</returns>
        public List<T> SqlQuery<T>(string _sql, List<object> _param = null)
        {



            return null; // this.Database.SqlQuery<T>(_sql, _param.ToArray()).ToList();
        }

        ///// <summary>
        ///// Executa consult e retorna uma lista a partir de um Sql (método async).
        ///// </summary>
        ///// <typeparam name="T">Entidade de retorno da Lista</typeparam>
        ///// <param name="_sql">Consulta Sql</param>
        ///// <param name="_param">Parametros</param>
        ///// <returns>Lista de T</returns>
        //public async Task<List<T>> SqlQueryAsync<T>(string _sql, List<object> _param = null)
        //{
        //    return await this.Database.SqlQuery<T>(_sql, _param.ToArray()).ToListAsync();
        //}

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

            return this.getMapModel<TModel>(dt);
        }

        ///// <summary>
        ///// Retorna uma lista de model apartir de uma consulta sql (método async).
        ///// </summary>
        ///// <typeparam name="TModel">Tipo da lista.</typeparam>
        ///// <param name="_sql">Consulta sql.</param>
        ///// <param name="_param">Lista de parametros.</param>
        ///// <param name="_cmdType">commandType</param>
        ///// <returns>Lista do tipo.</returns>
        //public async Task<List<TModel>> GetListModelAsync<TModel>(string _sql, List<object> _param = null, CommandType _cmdType = CommandType.Text)
        //{
        //    List<TModel> result = new List<TModel>();

        //    DataTable dt = await this.GetDataTableAsync(_sql, _param, _cmdType);

        //    return await Task.Run( () => { return this.getMapModel<TModel>(dt); });
        //}
        #endregion Métodos que retornam dados
    }


    

}
