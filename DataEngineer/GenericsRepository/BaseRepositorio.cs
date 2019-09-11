
namespace infra.generics.repository
{
    using System;
    using System.Data;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    
    using Microsoft.EntityFrameworkCore;
    using System.Threading.Tasks;

    public class BaseRepositorio<TEntity, TContext> : IBaseRepositorio<TEntity>
        where TEntity : class
        where TContext : IDbContext
    {
        #region Variáveis

        /// <summary>
        /// Trabalho da persistência.
        /// </summary>
        private readonly IUnitOfWork unitOfWork;

        /// <summary>
        /// DbSet da entidade
        /// </summary>
        internal DbSet<TEntity> dbSet;

        #endregion Variáveis

        #region Propriedades

        /// <summary>
        /// Get a instancia do trabalho atual da classe.
        /// </summary>
        public IUnitOfWork UnitOfWork
        {
            get { return unitOfWork; }
        }

        #endregion Propriedades

        #region Construtor

        /// <summary>
        /// Contrutor da classe.
        /// </summary>
        /// <param name="_unitOfWork">instacia da unidade de trablalho.</param>
        public BaseRepositorio(IUnitOfWork _unitOfWork)
        {
            if (_unitOfWork == null)
            {
                _unitOfWork = new UnitOfWork<TContext>();
            }

            this.unitOfWork = _unitOfWork;
            this.dbSet = _unitOfWork.Db.Set<TEntity>();
        }

        #endregion Construtor

        #region Result Genéricos

        /// <summary>
        /// Retornar o objeto apartir da cheve.
        /// </summary>
        /// <param name="_primaryKey">A chave primário do registro.</param>
        /// <returns>T</returns>
        public TEntity Find(object _primaryKey, bool _enabledPocoProxy = true)
        {
         //   this.unitOfWork.Db.Configuration.ProxyCreationEnabled = _enabledPocoProxy;
          //  this.unitOfWork.Db.Configuration.LazyLoadingEnabled = _enabledPocoProxy;

            var dbResult = dbSet.Find(_primaryKey);
            return dbResult;
        }

        /// <summary>
        /// Verifica se o objeto existe.
        /// </summary>
        /// <param name="_primaryKey">Chave primária do objeto.</param>
        /// <returns>Se o objeto existe</returns>
        public bool Exists(object _primaryKey)
        {
            return dbSet.Find(_primaryKey) == null ? false : true;
        }

        #endregion Result Genéricos

        #region Persistencia de dados

        /// <summary>
        /// Adicionar uma entidade na base.
        /// </summary>
        /// <param name="_entity">A entidade para inserir.</param>
        public virtual void Add(TEntity _entity)
        {
            
            dbSet.Add(_entity);
        }

        public virtual async Task<TEntity> AddAsync(TEntity _entity)
        {
            
            await dbSet.AddAsync(_entity);

            return _entity;
        }

        public virtual void AddAll(TEntity _entity)
        {
            

            dbSet.Add(_entity);
        }

        /// <summary>
        /// Editar uma entidade da base.
        /// </summary>
        /// <param name="_entity">A ser editada.</param>
        public virtual void Edit(TEntity _entity)
        {
            dbSet.Attach(_entity);
            unitOfWork.Db.Entry(_entity).State = EntityState.Modified;
        }

        /// <summary>
        /// Editar uma entidade da base.
        /// </summary>
        /// <param name="_entity">A ser editada.</param>
        public virtual void EditAll(TEntity _entity)
        {
            

            dbSet.Attach(_entity);
            unitOfWork.Db.Entry(_entity).State = EntityState.Modified;
        }

        public virtual void Edit(TEntity entity, Func<TEntity, bool> predicate = null)
        {
            var entry = unitOfWork.Db.Entry<TEntity>(entity);
            if (entry.State == EntityState.Detached)
            {
                TEntity attachedEntity = dbSet.Local.SingleOrDefault(predicate);
                if (attachedEntity != null)
                {
                    var attachedEntry = unitOfWork.Db.Entry(attachedEntity);
                    attachedEntry.CurrentValues.SetValues(entity);
                }
                else
                {
                    entry.State = EntityState.Modified; // This should attach entity
                }
            }
        }

        /// <summary>
        /// Remove uma entidade da base.
        /// </summary>
        /// <param name="_entity">A ser removida.</param>
        public virtual void Remove(TEntity _entity)
        {
            if (unitOfWork.Db.Entry(_entity).State == EntityState.Detached)
            {
                dbSet.Attach(_entity);
            }
            dbSet.Remove(_entity);
        }

        /// <summary>
        /// Atualiza o objeto conforme base de dados.
        /// </summary>
        /// <param name="_entity">Entidade a ser atualizada.</param>
        public void Reload(TEntity _entity)
        {
            this.UnitOfWork.Db.Entry<TEntity>(_entity).Reload();
        }
        #endregion Persistencia de dados

        #region Listagem Genéricas

        /// <summary>
        /// Retornar a listagem de TEntity.
        /// </summary>
        /// <returns>Lista TEntity.</returns>
        public IQueryable<TEntity> List()
        {
            return this.dbSet;
        }

        //public IQueryable<TEntity> List(bool _enabledPocoProxy, params Expression<Func<TEntity, object>>[] _includeProperties)
        //{
        //    return List(null, true, _includeProperties);
        //}

        //public IQueryable<TEntity> List(Expression<Func<TEntity, bool>> _where)
        //{
        //    return List(_where, true, null);
        //}

        //public IQueryable<TEntity> List(Expression<Func<TEntity, bool>> _where, bool _enabledPocoProxy)
        //{
        //    return List(_where, _enabledPocoProxy, null);
        //}

        //public IQueryable<TEntity> List(Expression<Func<TEntity, bool>> _where, params Expression<Func<TEntity, object>>[] _includeProperties)
        //{
        //    return List(_where, true, _includeProperties);
        //}

        //public IQueryable<TEntity> List(Expression<Func<TEntity, bool>> _where, bool _enabledPocoProxy, params Expression<Func<TEntity, object>>[] _includeProperties)
        //{
        //    IQueryable<TEntity> result = null;

        //    DbQuery<TEntity> currentQuery = null;

        //    //this.unitOfWork.Db.Configuration.ProxyCreationEnabled = _enabledPocoProxy;
        //    //this.unitOfWork.Db.Configuration.LazyLoadingEnabled = _enabledPocoProxy;

        //    if (_includeProperties != null && _includeProperties.Count() > 0)
        //    {
        //        foreach (string propertyInclude in this.GetIncludeProperties(_includeProperties))
        //        {
        //            if (currentQuery == null)
        //                currentQuery = this.dbSet.Include(propertyInclude);
        //            else
        //                currentQuery.Include(propertyInclude);
        //        }
        //    }

        //    // Executando a query query
        //    if (currentQuery == null)
        //    {
        //        result = (_where == null) ? dbSet : dbSet.Where(_where);
        //    }
        //    else
        //    {
        //        result = (_where == null) ? ((currentQuery == null) ? dbSet : currentQuery) : currentQuery.Where(_where);
        //    }

        //    return result;
        //}

        public IQueryable<TEntity> OrderAndSort(IQueryable<TEntity> _list, ref int _count, Func<TEntity, object> _orderby = null, SortDirection _sort = SortDirection.Ascending, int? _skip = null, int? _take = null)
        {
            _count = _list.Count();

            return this.OrderAndSort(_list, _orderby, _sort, _skip, _take);
        }

        public IQueryable<TEntity> OrderAndSort(IQueryable<TEntity> _list, Func<TEntity, object> _orderby = null, SortDirection _sort = SortDirection.Ascending, int? _skip = null, int? _take = null)
        {
            if (_orderby != null)
            {
                if (_sort == SortDirection.Ascending)
                {
                    _list = _list.OrderBy(_orderby).AsQueryable();
                }
                else
                {
                    _list = _list.OrderByDescending(_orderby).AsQueryable();
                }
            }

            if (_skip.HasValue)
            {
                _list = _list.Skip(_skip.Value);
            }

            if (_take.HasValue)
            {
                _list = _list.Take(_take.Value);
            }

            return _list;
        }
        #endregion Listagem Genéricas

        #region Métodos da interface

        /// <summary>
        /// Método disposable.
        /// </summary>
        public virtual void Dispose()
        {
            unitOfWork.Dispose();
        }
        #endregion Métodos da interface

        private string[] GetIncludeProperties(Expression<Func<TEntity, object>>[] _includeProperties)
        {
            List<string> result = new List<string>();

            foreach (Expression<Func<TEntity, object>> expression in _includeProperties)
            {
                result.Add(GetPropertyName<TEntity>(expression));

                //// separando o lambda pelos objetos
                //var split = expression.Body.ToString().Split('.').ToList();

                //// removendo a declaração da lista
                //split.RemoveAt(0);

                //result.Add(split.Aggregate((atual, next) => atual + '.' + next));
            }

            return result.ToArray();
        }

        public static string GetPropertyName<TModel>(Expression<Func<TModel, object>> expression)
        {
            // separando o lambda pelos objetos
            var split = expression.Body.ToString().Split('.').ToList();

            // removendo a declaração da lista
            split.RemoveAt(0);

            return split.Aggregate((atual, next) => atual + '.' + next);
        }

        public void Save()
        {
            this.UnitOfWork.Save();
        }
        





    }
}
