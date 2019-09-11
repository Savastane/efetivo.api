

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

    public class SoldierRepository : BaseRepositorio<EfetivoEntity,EfetivoContext>
    {

        SoldierConverter convert = new SoldierConverter();

        public SoldierRepository() :
            base(null)
        {

        }

        public SoldierRepository(IUnitOfWork unitOfWork) :
            base(unitOfWork)
        {

        }
               
        public async Task<EfetivoModel> AddSoldier(EfetivoModel model)
        {
            var entity = convert.ParseAwait(model);
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

        public async Task<EfetivoModel> GetSoldier(decimal id)
        {

            var model = convert.ParseAwait(this.Find(id));
            return await Task.Run(() => { return model; });

        }

        public async Task<List<EfetivoModel>> GetAllSoldier()
        {
            return await convert.ParseList( this.List() );
        }

        public async Task<List<EfetivoModel>> GetAllSoldierForGenre(decimal idUnit, decimal IdGenre)
        {
            var list = this.List().Where(s => s.idUnidade == idUnit).Where(s => s.Genero == IdGenre.ToString());

            return await convert.ParseList( list );
            
        }

        public async Task<List<EfetivoModel>> GetAllSoldierForGradation(decimal idUnit, decimal IdGradation)
        {


            var list = this.List().Where(s => s.idUnidade == idUnit).Where(s => s.idPosto == IdGradation);


            return await convert.ParseList(list);
        }
        



    }
}
