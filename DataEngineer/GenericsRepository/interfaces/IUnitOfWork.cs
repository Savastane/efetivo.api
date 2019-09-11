using System;
using System.Data;
using System.Collections.Generic;
using System.Text;

namespace infra.generics.repository
{
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Context de trabalho
        /// </summary>
        IDbContext Db { get; }

        /// <summary>
        /// Retorna um objeto via SQL
        /// </summary>
        /// <param name="_sql">código sql para retorno</param>
        /// <param name="_param">lista de parametros</param>
        /// <param name="_cmdType">commandType</param>
        /// <returns>objeto.</returns>
        object ExecuteScalar(string _sql, List<object> _param = null, CommandType _cmdType = CommandType.Text);

        /// <summary>
        /// Salva as alterações realizadas na base.
        /// </summary>
        void Save();

        /// <summary>
        /// Retorna um objeto via SQL
        /// </summary>
        /// <param name="_sql">código sql para retorno</param>
        /// <param name="_param">lista de parametros</param>
        /// <param name="_cmdType">commandType</param>
        void ExecuteNonQuery(string _sql, ref List<object> _param, CommandType _cmdType = CommandType.Text);

        /// <summary>
        /// retorna um data table apartir de um sql.
        /// </summary>
        /// <param name="_sql">consulta na base.</param>
        /// <param name="_param">lista de parametros da base</param>
        /// <param name="_cmdType">commandType</param>
        /// <returns>DataTable</returns>
        DataTable GetDataTable(string _sql, List<object> _param = null, CommandType _cmdType = CommandType.Text);

        /// <summary>
        /// retorna um data table apartir de um sql.
        /// </summary>
        /// <param name="_sql">consulta na base.</param>
        /// <param name="_param">lista de parametros da base</param>
        /// <param name="_cmdType">commandType</param>
        /// <returns>DataTable</returns>
        [Obsolete("Correção na nomenclatura do método. Utilizar o GetDataTable", false)]
        DataTable GetDataTale(string _sql, List<object> _param = null, CommandType _cmdType = CommandType.Text);

        /// <summary>
        /// retorna um data set apartir de um sql.
        /// </summary>
        /// <param name="_sql">consulta na base.</param>
        /// <param name="_param">lista de parametros da base</param>
        /// <param name="_cmdType">commandType</param>
        /// <returns>DataSet</returns>
        DataSet GetDataSet(string _sql, List<object> _param = null, CommandType _cmdType = CommandType.Text);

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
        /// Retorna uma mapeamento apartir da tabela passada via parametro.
        /// </summary>
        /// <typeparam name="dt">tabela para montar a lista.</typeparam>
        /// <returns>Lista do tipo.</returns>
        List<TModel> GetMapModel<TModel>(DataTable _data);
    }
}
