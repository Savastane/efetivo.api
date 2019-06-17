
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
    using efetivo.model;

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

       

        public LoginModel Auntenticar(string email, string senha)
        {

            

            return new LoginConverter().Parse(

                this.List().Where(u => u.Email == email && u.Senha == senha).FirstOrDefault()

                );


        }



    }
}
