

namespace efetivo.repository
{

    using infra.generics.repository;
    using efetivo.entity;
    using efetivo.model;
    using efetivo.model.converter;
    using System.Threading.Tasks;

    public class ResumoRepository : BaseRepositorio<ResumoEntity, EfetivoContext>
    {

        public ResumoRepository() :
            base(null)
        {

        }

        public ResumoRepository(IUnitOfWork unitOfWork) :
            base(unitOfWork)
        {

        }

        public async Task<ResumoModel> GetResumo(int id_unidade)
        {
            Task<ResumoModel> resumo = new ResumoConverter().Parse(this.Find(id_unidade));     
            
            return await resumo;
            
        }




    }
}
