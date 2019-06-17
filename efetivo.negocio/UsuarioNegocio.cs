using efetivo.model;
using efetivo.model.converter;
using efetivo.repositorio;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace efetivo.negocio
{

    public class UsuarioNegocio: IUsuarioNegocio
    {
        #region Singleton

        private UsuarioRepositorio repositorio = new UsuarioRepositorio();
            
        private static volatile UsuarioNegocio instance;
        private static object syncRoot = new Object();

        public static UsuarioNegocio Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new UsuarioNegocio();
                    }
                }

                return instance;
            }
        }

        #endregion Singleton

        public LoginModel Autenticar(LoginModel Usuario, String secretJWT = "UmaChave @FortePrecisadeNumeros2020")
        {
            // obter dados 
            var usuario = repositorio.Auntenticar(Usuario.Email, Usuario.Senha);
            
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

        public LoginModel getUsuario()
        {
            
            
            return new LoginConverter().Parse(repositorio.Find(1)); 

        }


    }
}
