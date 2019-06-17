
namespace efetivo.repositorio
{

    using DataEngineer;
    using efetivo.entidades;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using System.Text;
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using Microsoft.IdentityModel.Tokens;
    using System;
    using System.Linq;
    using efetivo.model.converter;

    public class UsuarioRepositorio  : BaseRepositorio<UsuarioEntidade, EfetivoContext> 
    {

        


        public UsuarioRepositorio() :
           base(null)
        {

        }

        public UsuarioRepositorio(string secretJWT) :
           base(null)
        {
            
        }

        public UsuarioRepositorio(IUnitOfWork unitOfWork) :
            base(unitOfWork)
        {

        }

       

        public LoginModlel Auntenticar(string email, string senha)
        {

            //var usuario = new LoginConverter().Parse(repositorio.Auntenticar(Usuario.Email, Usuario.Senha));

            return new LoginConverter().Parse(
                this.List().Where(u => u.Email == email && u.Senha == senha).FirstOrDefault()
                );


        }



    }
}
