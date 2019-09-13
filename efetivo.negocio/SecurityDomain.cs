using efetivo.model;
using efetivo.model.converter;
using efetivo.repository;

using infra.security;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace efetivo.domain
{
    public enum ReturnActionAutentication
    {
        Valid,
        Invalid,
        ErrorDB

    };

    public class SecurityDomain : IUsuarioDomain
    {
        
        
        
        #region Singleton

        private UsuarioRepository repository = new UsuarioRepository();
            
        private static volatile SecurityDomain instance;
        private static object syncRoot = new Object();

        public static SecurityDomain Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new SecurityDomain();
                    }
                }

                return instance;
            }
        }

        #endregion Singleton

        //, String secretJWT = "UmaChave@FortePrecisadeNumeros2020"
        public async Task<ReturnActionAutentication> Autenticar(LoginModel Usuario)
        {
            LoginModel local_usuario;
            try
            {


                if (Usuario.Senha== "simulation_error_conenection_db")
                {
                    throw new System.ArgumentException("Problemas com conexão de dados");
                }


                local_usuario = await repository.Auntenticar(Usuario.Email, Usuario.Senha);
                

                if (local_usuario.IdUsuario  == 0)
                {
                    return ReturnActionAutentication.Invalid;
                }
                else
                {
                    local_usuario.Token = Security.CreateToken(
                            new Claim[] {
                                                       new Claim(ClaimTypes.Name, local_usuario.Nome),
                                                       new Claim(ClaimTypesCustom.Iduser, local_usuario.IdUsuario.ToString()),
                                        }

                            , EnvironmentDomain.Instance.SecretKeyToken
                        );


                    local_usuario.Senha = null;

                    EnvironmentDomain.Instance.AddUser(local_usuario);

                    

                    return ReturnActionAutentication.Valid;


                }
                
            }
            catch (Exception)
            {
                return ReturnActionAutentication.ErrorDB;
            };

                
                
            

        }

        public async Task<LoginModel> getUser(decimal IdUser)
        {
            return await new LoginConverter().Parse(repository.Find(IdUser)); 

        }

        public LoginModel UserTest(String login, String Senha)
        {
            return new LoginModel { Email = login, Senha = Senha };
        }


        public void InicializeEnvironment(ClaimsPrincipal user)
        {


            var identity = ((ClaimsIdentity)user.Identity);

            if (identity != null)
            {
                IEnumerable<Claim> claims = identity.Claims;

                var a = identity.FindFirst(ClaimTypes.Name).Value;
                
                var IdUser = Convert.ToDecimal( identity.FindFirst(ClaimTypesCustom.Iduser).Value);

                EnvironmentDomain.Instance.Inicialize(IdUser);
            }

            


        }

        public string getClaim(ClaimsPrincipal User)
        {

            var identity = ((ClaimsIdentity)User.Identity);

            if (identity != null)
            {
                IEnumerable<Claim> claims = identity.Claims;
                
                return identity.FindFirst(ClaimTypes.Name).Value;

            }

            return "-1";

        }


    }

    public class ClaimTypesCustom
    {
        public static string Iduser = "IdUser";
        public static string IdGroup = "IdGroup";

    }
}
