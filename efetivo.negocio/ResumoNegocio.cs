using System;
using System.Collections.Generic;
using System.Text;
using DataEngineer;

namespace efetivo.negocio
{

    public class ResumoNegocio: BaseEfetivoNegocio<ACAO_RECURSO>, IResumoNegocio, IDisposable
    {

        public ResumoNegocio(): base()
        {

        }

        public ResumoNegocio(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }


    }
    public class ACAO_RECURSO
    {
        public long Id { get; set; }
    }
}
