
namespace efetivo.repository
{

    using infra.generics.repository;
    using efetivo.entity;
    using System.Linq;
    using efetivo.model.converter;
    using efetivo.model;
    using System.Threading.Tasks;

    public class UsuarioRepository : BaseRepositorio<UsuarioEntity, EfetivoContext> 
    {

        


        public UsuarioRepository() :
           base(null)
        {

        }

        public UsuarioRepository(string secretJWT) :
           base(null)
        {
            
        }

        public UsuarioRepository(IUnitOfWork unitOfWork) :
            base(unitOfWork)
        {

        }

       

        public async Task<LoginModel> Auntenticar(string email, string senha)
        {

            

            return await new LoginConverter().Parse(

                this.List().Where(u => u.Email == email && u.Senha == senha).FirstOrDefault()

                );


        }



    }
}
