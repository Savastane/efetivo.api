using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using efetivo.entity;
using infra.valueobject;

namespace efetivo.model.converter
{
    public class LoginConverter : IParserAsync<LoginModel, UsuarioEntity>, IParserAsync<UsuarioEntity, LoginModel>
    {
        public async Task<LoginModel> Parse(UsuarioEntity origin)
        {
            if (origin == null)
            {

                return await Task.Run(() => { return new LoginModel(); });
             
            }
            else {

                return await Task.Run(() => {
                                            return new LoginModel
                                        {
                                            IdUsuario = origin.IdUsuario,
                                            Email = origin.Email,
                                            Senha = origin.Senha,
                                            Nome = origin.Nome,
                                            Matricula = origin.Matricula,
                                            Token = origin.Token
                                        };
                });
            }
            
            
        }

        public async Task<UsuarioEntity> Parse(LoginModel origin)
        {
            if (origin == null)
            {

                return await Task.Run(() => { return new UsuarioEntity(); });
                                
            }
            else
            {
                return await Task.Run(() =>
                {
                    return new UsuarioEntity
                    {
                        IdUsuario = origin.IdUsuario,
                        Email = origin.Email,
                        Senha = origin.Senha,
                        Nome = origin.Nome,
                        Matricula = origin.Matricula,
                        Token = origin.Token
                    };
                });
            }
        }

      

        public Task<List<LoginModel>> ParseList(IQueryable<UsuarioEntity> origin)
        {
            if (origin == null)
            {
                return Task.Run(() => {
                    return new List<LoginModel>();
                });
            }
            else
            {
                return Task.Run(() => {

                    return origin.Select(item => ParseAwait(item)).ToList();
                });
            }
        }

        public Task<List<UsuarioEntity>> ParseList(IQueryable<LoginModel> origin)
        {
            if (origin == null)
            {
                return Task.Run(() => {
                    return new List<UsuarioEntity>();
                });
            }
            else
            {
                return Task.Run(() => {
                    return origin.Select(item => ParseAwait(item)).ToList();
                });


            }
        }


        public LoginModel ParseAwait(UsuarioEntity origin)
        {
            if (origin == null)
            {
                return new LoginModel();
            }
            else
            {


                return new LoginModel
                {
                    IdUsuario = origin.IdUsuario
                };

            }


        }

        public UsuarioEntity ParseAwait(LoginModel origin)
        {
            if (origin == null)
            {
                return new UsuarioEntity();
            }
            else
            {
                return new UsuarioEntity
                {
                    IdUsuario = origin.IdUsuario
                };
            }
        }



    }
}
