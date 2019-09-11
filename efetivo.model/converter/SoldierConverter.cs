using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using efetivo.entity;
using infra.valueobject;


namespace efetivo.model.converter
{
    public class SoldierConverter : IParserAsync<EfetivoModel, EfetivoEntity>, IParserAsync<EfetivoEntity, EfetivoModel>
    {
        public Task<EfetivoModel> Parse(EfetivoEntity origin)
        {
            if (origin == null)
            {
                return Task.Run(() => { return new EfetivoModel(); });
            }
            else {

                return Task.Run(() => {

                    return new EfetivoModel
                    {

                        IdEfetivo = origin.IdEfetivo,
                        Nome = origin.Nome,
                        Genero = origin.Genero,
                        DDD_Celular = origin.DDD_Celular,
                        Celular = origin.Celular,
                        CPF = origin.CPF,
                        Email = origin.Email,
                        Senha = origin.Senha,
                        Matricula = origin.Matricula,
                        idPosto = origin.idPosto,
                        idUnidade = origin.IdEfetivo,
                        flag_situacao = origin.flag_situacao,
                        flag_perfil = origin.flag_perfil


                   
                    };
            });

        }
            
        }

        public Task<EfetivoEntity> Parse(EfetivoModel origin)
        {
            if (origin == null)
            {
                return Task.Run(() => { return new EfetivoEntity(); });  
            }
            else
            {

                return Task.Run(() => {
                    return new EfetivoEntity
                    {
                        IdEfetivo = origin.IdEfetivo,
                        Nome = origin.Nome,
                        Genero = origin.Genero,
                        DDD_Celular = origin.DDD_Celular,
                        Celular = origin.Celular,
                        CPF = origin.CPF,
                        Email = origin.Email,
                        Senha = origin.Senha,
                        Matricula = origin.Matricula,
                        idPosto = origin.idPosto,
                        idUnidade = origin.IdEfetivo,
                        flag_situacao = origin.flag_situacao,
                        flag_perfil = origin.flag_perfil
                    };
                });
            }
        }

        public EfetivoModel ParseAwait(EfetivoEntity origin)
        {
            if (origin == null)
            {
                return new EfetivoModel();
            }
            else
            {   
                    return new EfetivoModel
                    {
                        IdEfetivo = origin.IdEfetivo,
                        Nome = origin.Nome,
                        Genero = origin.Genero,
                        DDD_Celular = origin.DDD_Celular,
                        Celular = origin.Celular,
                        CPF = origin.CPF,
                        Email = origin.Email,
                        Senha = origin.Senha,
                        Matricula = origin.Matricula,
                        idPosto = origin.idPosto,
                        idUnidade = origin.IdEfetivo,
                        flag_situacao = origin.flag_situacao,
                        flag_perfil = origin.flag_perfil
                    };
                
            }


        }

        public EfetivoEntity ParseAwait (EfetivoModel origin)
        {
            if (origin == null)
            {
                return new EfetivoEntity(); 
            }
            else
            {                
                    return new EfetivoEntity
                    {
                        IdEfetivo = origin.IdEfetivo,
                        Nome = origin.Nome,
                        Genero = origin.Genero,
                        DDD_Celular = origin.DDD_Celular,
                        Celular = origin.Celular,
                        CPF = origin.CPF,
                        Email = origin.Email,
                        Senha = origin.Senha,
                        Matricula = origin.Matricula,
                        idPosto = origin.idPosto,
                        idUnidade = origin.IdEfetivo,
                        flag_situacao = origin.flag_situacao,
                        flag_perfil = origin.flag_perfil
                    };                
            }
        }

        public Task<List<EfetivoModel>> ParseList(IQueryable<EfetivoEntity> origin)
        {
            if (origin == null)
            {
                return Task.Run(() => {
                    return new List<EfetivoModel>();
                });
            }
            else
            {
                return Task.Run(() => {

                    return  origin.Select(item => ParseAwait(item)).ToList();
                });
            }
        }

        public Task<List<EfetivoEntity>> ParseList(IQueryable<EfetivoModel> origin)
        {
            if (origin == null)
            {
                return  Task.Run(() => {
                    return new List<EfetivoEntity>();
                });
            }
            else
            {
                return Task.Run(() => {
                    return origin.Select(item => ParseAwait(item)).ToList();
                });


            }
        }
    }

}
