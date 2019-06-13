using System;
using System.Collections.Generic;
using System.Text;
using DataEngineer;

namespace efetivo.negocio
{
    public class BaseEfetivoNegocio<TEntity> : BaseNegocio<TEntity> where TEntity : class
    {
        public BaseEfetivoNegocio(IUnitOfWork _unitOfWork = null)
            : base(_unitOfWork)
        {
          //  this.repository = new NotasFaltasRepositorio<TEntity>(_unitOfWork);
        }

    }
}
