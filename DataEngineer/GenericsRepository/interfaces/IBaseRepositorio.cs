

namespace DataEngineer
{

    using System;
    using System.Data;    
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;


    /// <typeparam name="TContext">DbContext do projeto.</typeparam>
    public interface IBaseRepositorio<TEntity> : IDisposable
        where TEntity : class
    {
        #region Propriedades
        /// <summary>
        /// Unidade de trabalho.
        /// </summary>
        IUnitOfWork UnitOfWork { get; }
        #endregion Propriedades

        #region Result Genéricos

        /// <summary>
        /// Retornar o objeto apartir da cheve.
        /// </summary>
        /// <param name="_primaryKey">A chave primário do registro.</param>
        /// <returns>T</returns>
        TEntity Find(object _primaryKey, bool _enabledPocoProxy = true);

        /// <summary>
        /// Verifica se o objeto existe.
        /// </summary>
        /// <param name="_primaryKey">Chave primária do objeto.</param>
        /// <returns>Se o objeto existe</returns>
        bool Exists(object _primaryKey);
        #endregion Result Genéricos

        #region Persistencia de dados

        /// <summary>
        /// Adicionar uma entidade na base.
        /// </summary>
        /// <param name="_entity">A entidade para inserir.</param>
        void Add(TEntity _entity);

        void AddAll(TEntity _entity);

        /// <summary>
        /// Editar uma entidade da base.
        /// </summary>
        /// <param name="_entity">A ser editada.</param>
        void Edit(TEntity _entity);

        void EditAll(TEntity _entity);

        void Edit(TEntity entity, Func<TEntity, bool> predicate);
        /// <summary>
        /// Remove uma entidade da base.
        /// </summary>
        /// <param name="_entity">A ser removida.</param>
        void Remove(TEntity _entity);

        /// <summary>
        /// Atualiza o objeto conforme base de dados.
        /// </summary>
        /// <param name="_entity">Entidade a ser atualizada.</param>
        void Reload(TEntity _entity);
        #endregion Persistencia de dados

        #region Listagem Genéricas

        /// <summary>
        /// Retornar a listagem de TEntity.
        /// </summary>
        /// <returns>Lista TEntity.</returns>
        IQueryable<TEntity> List();

        //IQueryable<TEntity> List(bool _enabledPocoProxy, params Expression<Func<TEntity, object>>[] _includeProperties);

        ///// <summary>
        ///// Retornar a listagem de TEntity.
        ///// </summary>
        ///// <param name="_where">where na lista.</param>
        ///// <returns>Lista TEntity.</returns>
        //IQueryable<TEntity> List(Expression<Func<TEntity, bool>> _where);

        //IQueryable<TEntity> List(Expression<Func<TEntity, bool>> _where, bool _enabledPocoProxy);

        ///// <summary>
        ///// Retornar a listagem de TEntity.
        ///// </summary>
        ///// <param name="_where">where na lista.</param>
        ///// <param name="includeProperties">Propriedades ou classes a serem adicionadas na classe.</param>
        ///// <returns>Lista TEntity.</returns>
        //IQueryable<TEntity> List(Expression<Func<TEntity, bool>> _where, params Expression<Func<TEntity, object>>[] _includeProperties);

        //IQueryable<TEntity> List(Expression<Func<TEntity, bool>> _where, bool _enabledPocoProxy = true, params Expression<Func<TEntity, object>>[] _includeProperties);

        IQueryable<TEntity> OrderAndSort(IQueryable<TEntity> _list, ref int count, Func<TEntity, object> _orderby = null, SortDirection _sort = SortDirection.Ascending, int? _skip = null, int? _take = null);

        IQueryable<TEntity> OrderAndSort(IQueryable<TEntity> _list, Func<TEntity, object> _orderby = null, SortDirection _sort = SortDirection.Ascending, int? _skip = null, int? _take = null);
        #endregion Listagem Genéricas
    }
}
