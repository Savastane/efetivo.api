namespace DataEngineer
{

    using System.Collections.Generic;
    using Microsoft.EntityFrameworkCore;
    using System.Data;
    using Microsoft.EntityFrameworkCore.ChangeTracking;

    public interface IDbContext
    {

        


        /// <summary>
        /// Configuração da base de dados
        /// </summary>
        //  DbContextConfiguration Configuration { get; }

        /// <summary>
        /// Retorna uma instância não genérica System.Data.Entity.DbSet para acesso a entidades
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>Um ​​conjunto para o tipo de entidade dado.</returns>
        /// 


        DbSet<T> Set<T>() where T : class;

        /// <summary>
        /// Obtém um objeto System.Data.Entity.Infrastructure.DbEntityEntry para a entidade dada
        /// fornecendo acesso a informações sobre a entidade e a capacidade de realizar ações
        /// na entidade.
        /// </summary>
        /// <typeparam name="T">Entity Type</typeparam>
        /// <param name="entity">Entity</param>
        /// <returns></returns>
        EntityEntry<T> Entry<T>(T entity) where T : class;

        /// <summary>
        /// Salva todas as alterações feitas nesse contexto ao banco de dados subjacente.
        /// </summary>
        /// <returns>Numeros de entidades alteradas.</returns>
        int SaveChanges();

        /// <summary>
        /// Salva todas as alterações feitas nesse contexto ao banco de dados subjacente (método async).
        /// </summary>
        /// <returns>Numeros de entidades alteradas.</returns>
        //Task<int> SaveChangesAsync();

        #region Métodos que retornam dados

        /// <summary>
        /// retorna um objeto a partir de um sql.
        /// </summary>
        /// <param name="_sql">consulta na base.</param>
        /// <param name="_param">lista de parametros da base</param>
        /// <param name="_cmdType">commandType</param>
        /// <returns>DataSet</returns>
        object ExecuteScalar(string _sql, List<object> _param = null);

        object ExecuteScalarADO(string _sql, List<object> _param = null, CommandType _cmdType = CommandType.Text);

        void ExecuteNonQueryADO(string _sql, List<object> _param, CommandType _cmdType = CommandType.Text);

        /// <summary>
        /// retorna um objeto a partir de um sql (método async).
        /// </summary>
        /// <param name="_sql">consulta na base.</param>
        /// <param name="_param">lista de parametros da base</param>
        /// <param name="_cmdType">commandType</param>
        /// <returns>DataSet</returns>
        //Task<object> ExecuteScalarAsync(string _sql, List<object> _param = null);

        //Task<object> ExecuteScalarAsyncADO(string _sql, List<object> _param = null, CommandType _cmdType = CommandType.Text);


        /// <summary>
        /// retorna um data set a partir de um sql.
        /// </summary>
        /// <param name="_sql">consulta na base.</param>
        /// <param name="_param">lista de parametros da base</param>
        /// <param name="_cmdType">commandType</param>
        /// <returns>DataSet</returns>
        DataSet GetDataSet(string _sql, List<object> _param = null, CommandType _cmdType = CommandType.Text);

        /// <summary>
        /// retorna um data table a partir de um sql (método async).
        /// </summary>
        /// <param name="_sql">consulta na base.</param>
        /// <param name="_param">lista de parametros da base</param>
        /// <param name="_cmdType">commandType</param>
        /// <returns>DataTable</returns>
        //Task<DataTable> GetDataTableAsync(string _sql, List<object> _param = null, CommandType _cmdType = CommandType.Text);

        /// <summary>
        /// retorna um data table a partir de um sql.
        /// </summary>
        /// <param name="_sql">consulta na base.</param>
        /// <param name="_param">lista de parametros da base</param>
        /// <param name="_cmdType">commandType</param>
        /// <returns>DataTable</returns>
        DataTable GetDataTable(string _sql, List<object> _param = null, CommandType _cmdType = CommandType.Text);

        /// <summary>
        /// retorna um data set a partir de um sql (método async).
        /// </summary>
        /// <param name="_sql">consulta na base.</param>
        /// <param name="_param">lista de parametros da base</param>
        /// <param name="_cmdType">commandType</param>
        /// <returns>DataSet</returns>
        //Task<DataSet> GetDataSetAsync(string _sql, List<object> _param = null, CommandType _cmdType = CommandType.Text);

        /// <summary>
        /// Executa consult e retorna uma lista a partir de um Sql.
        /// </summary>
        /// <typeparam name="T">Entidade de retorno da Lista</typeparam>
        /// <param name="_sql">Consulta Sql</param>
        /// <param name="_param">Parametros</param>
        /// <returns>Lista de T</returns>
        List<T> SqlQuery<T>(string _sql, List<object> _param = null);

        /// <summary>
        /// Executa consult e retorna uma lista a partir de um Sql (método async).
        /// </summary>
        /// <typeparam name="T">Entidade de retorno da Lista</typeparam>
        /// <param name="_sql">Consulta Sql</param>
        /// <param name="_param">Parametros</param>
        /// <returns>Lista de T</returns>
        //Task<List<T>> SqlQueryAsync<T>(string _sql, List<object> _param = null);

        /// <summary>
        /// Retorna uma lista de model apartir de uma consulta sql.
        /// </summary>
        /// <typeparam name="TModel">Tipo da lista.</typeparam>
        /// <param name="_sql">Consulta sql.</param>
        /// <param name="_param">Lista de parametros.</param>
        /// <param name="_cmdType">commandType</param>
        /// <returns>Lista do tipo.</returns>
        List<TModel> GetListModel<TModel>(string _sql, List<object> _param = null, CommandType _cmdType = CommandType.Text);

        /// <summary>
        /// Retorna uma lista de model apartir de uma consulta sql.
        /// </summary>
        /// <typeparam name="TModel">Tipo da lista.</typeparam>
        /// <param name="_sql">Consulta sql.</param>
        /// <param name="_param">Lista de parametros.</param>
        /// <param name="_cmdType">commandType</param>
        /// <returns>Lista do tipo.</returns>
        //Task<List<TModel>> GetListModelAsync<TModel>(string _sql, List<object> _param = null, CommandType _cmdType = CommandType.Text);
        #endregion Métodos que retornam dados

        void Dispose();
    }
}
