

namespace efetivo.repositorio
{

    using DataEngineer;
    using efetivo.entidades;
    using efetivo.model;
    using efetivo.model.converter;
    using System.Threading.Tasks;

    public class ResumoRepositorio : BaseRepositorio<ResumoEntidade, EfetivoContext>
    {

        public ResumoRepositorio() :
            base(null)
        {

        }

        public ResumoRepositorio(IUnitOfWork unitOfWork) :
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
