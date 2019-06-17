using efetivo.model;
using efetivo.model.converter;
using efetivo.repositorio;
using Microsoft.AspNetCore.Http;
using reusecode.Security;
using System;
using System.Collections.Generic;

using System.Security.Claims;
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

        public LoginModel Autenticar(LoginModel Usuario, String secretJWT = "UmaChave@FortePrecisadeNumeros2020")
        {
            // obter dados 
            var usuario = repositorio.Auntenticar(Usuario.Email, Usuario.Senha);
            
            // return null if user not found
            if (usuario == null)
                return null;

            usuario.Token = 
                Security.CreateToken(
                                        new Claim[] {
                                                       new Claim(ClaimTypes.Name, usuario.IdUsuario.ToString())
                                                    }
                                        , secretJWT
                                    );


            usuario.Senha = null;

            
            return usuario;

            

        }

        public LoginModel getUsuario()
        {
            
            
            return new LoginConverter().Parse(repositorio.Find(1)); 

        }

        public string getClaim(HttpContext httpContext)
        {
            var identity = httpContext.User.Identity as ClaimsIdentity;

            if (identity != null)
            {
                IEnumerable<Claim> claims = identity.Claims;
                
                return identity.FindFirst(ClaimTypes.Name).Value;

            }

            return "0";

        }


    }
}
