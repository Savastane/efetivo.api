using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using efetivo.entidades;
using reusecode.ValueObjct;


namespace efetivo.model.converter
{
    public class LoginConverter : IParser<LoginModel, UsuarioEntidade>, IParser<UsuarioEntidade, LoginModel>
    {
        public LoginModel Parse(UsuarioEntidade origin)
        {
            if (origin == null)
            {
                return new LoginModel();
            }
            else {

                return new LoginModel
                {
                    IdUsuario = origin.IdUsuario,
                    Email = origin.Email,
                    Senha = origin.Senha,
                    Nome = origin.Nome,
                    Matricula = origin.Matricula,
                    Token = origin.Token
                };
            }
            
            
        }

        public UsuarioEntidade Parse(LoginModel origin)
        {
            if (origin == null)
            {
                return new UsuarioEntidade();
            }
            else
            {

                return new UsuarioEntidade
                {
                    IdUsuario = origin.IdUsuario,
                    Email = origin.Email,
                    Senha = origin.Senha,
                    Nome = origin.Nome,
                    Matricula = origin.Matricula,
                    Token = origin.Token
                };
            }
        }

        public List<LoginModel> ParseList(List<UsuarioEntidade> origin)
        {
            if (origin == null)
            {
                return new List<LoginModel>();
            }
            else
            {
                return origin.Select(item => Parse(item)).ToList();
            }
        }

        public List<UsuarioEntidade> ParseList(List<LoginModel> origin)
        {
            if (origin == null)
            {
                return new List<UsuarioEntidade>();
            }
            else
            {
                return origin.Select(item => Parse(item)).ToList();
            }
        }
    }
}
