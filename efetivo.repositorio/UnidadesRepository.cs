

namespace efetivo.repository
{

    using infra.generics.repository;
    using efetivo.entidades;
    using efetivo.model;
    using efetivo.model.converter;
    using System.Threading.Tasks;
    using System.Linq;
    using System.Collections.Generic;
    using efetivo.entity;

    public class UnidadeRepository : BaseRepositorio<UnidadeEntity, EfetivoContext>
    {

        public UnidadeRepository() :
            base(null)
        {

        }

        public UnidadeRepository(IUnitOfWork unitOfWork) :
            base(unitOfWork)
        {

        }



        public async Task<UnidadeModel> AddUnit(UnidadeModel model)
        {
            var entity = new UnidadeConverter().ParseAwait(model);
            try
            {
                var objeto = await this.AddAsync(entity);
                this.Save();


            }
            catch (System.Exception w)
            {

                throw;
            }
            

            return await Task.Run(() => { return model; });

        }

        public async Task<UnidadeModel> GetUnit(decimal id)
        {

            var model = new UnidadeConverter().ParseAwait(this.Find(id));

            

            return await Task.Run(() => { return model; });

        }

        public async Task<List<UnidadeModel>> GetAllUnits()
        {
            return await new UnidadeConverter().ParseList(
               this.List()
               );
        }




    }
}
