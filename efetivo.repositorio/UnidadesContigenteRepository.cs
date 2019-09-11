

namespace efetivo.repository
{

    using infra.generics.repository;
    using efetivo.entity;
    using efetivo.model;
    using efetivo.model.converter;
    using System.Threading.Tasks;
    using System.Linq;
    using System.Collections.Generic;

    public class UnidadesContigenteRepository : BaseRepositorio<UnidadesContigenteEntity, EfetivoContext>
    {

        public UnidadesContigenteRepository() :
            base(null)
        {

        }

        public UnidadesContigenteRepository(IUnitOfWork unitOfWork) :
            base(unitOfWork)
        {

        }



        public async Task<List<UnidadesContigenteModel>> GetAllUnits()
        {
            return await new UnidadesContigenteConverter().ParseList(
               this.List()
               );  
        }


    }
}
