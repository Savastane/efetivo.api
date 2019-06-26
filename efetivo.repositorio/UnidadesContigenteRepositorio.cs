

namespace efetivo.repositorio
{

    using DataEngineer;
    using efetivo.entidades;
    using efetivo.model;
    using efetivo.model.converter;
    using System.Threading.Tasks;
    using System.Linq;
    using System.Collections.Generic;

    public class UnidadesContigenteRepositorio : BaseRepositorio<UnidadesContigenteEntidade, EfetivoContext>
    {

        public UnidadesContigenteRepositorio() :
            base(null)
        {

        }

        public UnidadesContigenteRepositorio(IUnitOfWork unitOfWork) :
            base(unitOfWork)
        {

        }



        public async Task<List<UnidadesContigenteModel>> GetUnidadesContigente()
        {
            return await new UnidadesContigenteConverter().ParseList(
               this.List()
               );  
        }


    }
}
