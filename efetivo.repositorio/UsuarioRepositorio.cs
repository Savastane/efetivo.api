
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


        

        
               

        public UsuarioEntidade Auntenticar(string username, string password, string secretJWT)
        {
            var usuario = this.Find(1);

            // return null if user not found
            if (usuario == null)
                return null;

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secretJWT);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, usuario.IdUsuario.ToString())
                }),

                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            usuario.Token = tokenHandler.WriteToken(token);

            // remove password before returning
            usuario.Senha = null;

            return usuario;
        }



    }
}
