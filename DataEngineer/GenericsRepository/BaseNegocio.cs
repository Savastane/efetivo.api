

namespace DataEngineer
{
    
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    
    using Microsoft.EntityFrameworkCore;
    

    public class BaseNegocio<TEntity> : IBaseNegocio<TEntity> where TEntity : class
    {
        
        #region Variáveis

        /// <summary>
        /// Armazena se foi a classe atual que criou o trabalho.
        /// </summary>
        private bool _isCreateUnitOfWork = false;

        /// <summary>
        /// Armazena se pode ou não salvar a instacia da base de dados.
        /// </summary>
        private bool _isSaveUnitOfWork = true;

        /// <summary>
        /// Unidade de trabalho da classe.
        /// </summary>
        //private IUnitOfWork _unitOfWork = null;

        #endregion Variáveis

        #region Propriedades

        /// <summary>
        /// Instacia do repositório da classe.
        /// </summary>
        protected IBaseRepositorio<TEntity> repository; //{ get; set; }

        /// <summary>
        /// Trabalho da persistência.
        /// </summary>
        public IUnitOfWork UnitOfWork
        {
            get
            {
                _isSaveUnitOfWork = false;
                return this.repository.UnitOfWork;
            }
        }

        #endregion Propriedades

        #region Contrutor

        /// <summary>
        /// Contrutor.
        /// </summary>
        /// <param name="_unitOfWork">Unidade de trabalho</param>
        public BaseNegocio(IUnitOfWork _unitOfWork = null)
        {
            if (_unitOfWork == null)
            {
                this._isCreateUnitOfWork = true;
            }
            else
            {
                this._isCreateUnitOfWork = false;
            }
        }

        #endregion Contrutor

        #region Result Genéricos
        /// <summary>
        /// Retornar o objeto apartir da cheve.
        /// </summary>
        /// <param name="primaryKey">A chave primário do registro.</param>
        /// <returns>T</returns>
        public virtual TEntity Find(object _primaryKey, bool _enabledPocoProxy = true)
        {
            return this.repository.Find(_primaryKey, _enabledPocoProxy);
        }

        /// <summary>
        /// Verifica se o objeto existe.
        /// </summary>
        /// <param name="_primaryKey">Chave primária do objeto.</param>
        /// <returns>Se o objeto existe</returns>
        public virtual bool Exists(object _primaryKey)
        {
            return this.repository.Exists(_primaryKey);
        }
        #endregion Result Genéricos

        #region Persistencia de dados

        /// <summary>
        /// Adicionar uma entidade na base.
        /// </summary>
        /// <param name="_entity">A entidade para inserir.</param>
        public virtual void Add(TEntity _entity)
        {
            this.repository.Add(_entity);
            this.saveUnitOfWork();
        }

        public virtual void AddAll(TEntity _entity)
        {
            this.repository.AddAll(_entity);
            this.saveUnitOfWork();
        }

        /// <summary>
        /// Editar uma entidade da base.
        /// </summary>
        /// <param name="_entity">A ser editada.</param>
        public virtual void Edit(TEntity _entity)
        {
            try
            {
                this.repository.Edit(_entity);
                this.saveUnitOfWork();
            }
                   
            catch (DbUpdateConcurrencyException ex)
            {
                this.repository.Reload(_entity);
                this.saveUnitOfWork();
            }
        }

        public virtual void EditAll(TEntity _entity)
        {
            this.repository.EditAll(_entity);
            this.saveUnitOfWork();
        }

        public virtual void Edit(TEntity entity, Func<TEntity, bool> predicate)
        {
            try
            {
                this.repository.Edit(entity, predicate);
                this.saveUnitOfWork();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                this.repository.Reload(entity);
                this.saveUnitOfWork();
            }
        }

        /// <summary>
        /// Remove uma entidade da base.
        /// </summary>
        /// <param name="_entity">A ser removida.</param>
        public virtual void Remove(TEntity _entity)
        {
            try
            {
                this.repository.Remove(_entity);
                this.saveUnitOfWork();
            }

            //Microsoft.EntityFrameworkCore.DbUpdateException

            catch (DbUpdateException ex)
            {
                this.repository.Reload(_entity);
                this.saveUnitOfWork();
            }
        }

        public virtual void Remove(object primaryKey)
        {
            this.Remove(this.Find(primaryKey));
        }

        #endregion Persistencia de dados

        #region Listagem Genéricas
        /// <summary>
        /// Retornar a listagem de TEntity.
        /// </summary>
        /// <returns>Lista TEntity.</returns>
        public virtual IQueryable<TEntity> List()
        {
            return this.repository.List();
        }

        //public virtual IQueryable<TEntity> List(bool _enabledPocoProxy, params Expression<Func<TEntity, object>>[] _includeProperties)
        //{
        //    return this.repository.List(_enabledPocoProxy, _includeProperties);
        //}

        /// <summary>
        /// Retornar a listagem de TEntity.
        /// </summary>
        /// <param name="_where">where na lista.</param>
        /// <returns>Lista TEntity.</returns>
        //public virtual IQueryable<TEntity> List(Expression<Func<TEntity, bool>> _where)
        //{
        //    return this.repository.List(_where);
        //}

        //public virtual IQueryable<TEntity> List(Expression<Func<TEntity, bool>> _where, bool _enabledPocoProxy)
        //{
        //    return this.repository.List(_where, _enabledPocoProxy);
        //}

        /// <summary>
        /// Retornar a listagem de TEntity.
        /// </summary>
        /// <param name="_where">where na lista.</param>
        /// <param name="_includeProperties">Propriedades ou classes a serem adicionadas na classe.</param>
        /// <returns>Lista TEntity.</returns>
        //public virtual IQueryable<TEntity> List(Expression<Func<TEntity, bool>> _where, params Expression<Func<TEntity, object>>[] _includeProperties)
        //{
        //    return this.repository.List(_where, true, _includeProperties);
        //}

        /// <summary>
        /// Retornar a listagem de TEntity.
        /// </summary>
        /// <param name="_where">where na lista.</param>
        /// <param name="_includeProperties">Propriedades ou classes a serem adicionadas na classe.</param>
        /// <returns>Lista TEntity.</returns>
        //public virtual IQueryable<TEntity> List(Expression<Func<TEntity, bool>> _where, bool _enabledPocoProxy, params Expression<Func<TEntity, object>>[] _includeProperties)
        //{
        //    return this.repository.List(_where, _enabledPocoProxy, _includeProperties);
        //}

        #endregion Listagem Genéricas

        #region Métodos para salvar

        /// <summary>
        /// Salva a unidade de trabalho.
        /// </summary>
        protected void Save()
        {
            if (_isCreateUnitOfWork)
            {
                this._isSaveUnitOfWork = true;
                this.saveUnitOfWork();
            }
        }

        /// <summary>
        /// Salva a unidade de trabalho.
        /// </summary>
        private void saveUnitOfWork()
        {
            if (_isCreateUnitOfWork && _isSaveUnitOfWork)
            {
                this.repository.UnitOfWork.Save();
            }
        }
        #endregion Métodos para salvar

        #region Interface Disposable

        /// <summary>
        /// Disposable.
        /// </summary>
        public virtual void Dispose()
        {
            repository.Dispose();
        }
        #endregion Interface Disposable
    }
}
