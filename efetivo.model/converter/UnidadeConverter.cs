using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using efetivo.entity;
using infra.valueobject;

namespace efetivo.model
{
    public class UnidadeConverter : IParserAsync<UnidadeModel, UnidadeEntity>, IParserAsync<UnidadeEntity, UnidadeModel>
    {
        public Task<UnidadeModel> Parse(UnidadeEntity origin)
        {
            if (origin == null)
            {
                return Task.Run(() => { return new UnidadeModel(); });
            }
            else
            {

                return Task.Run(() => {

                    return new UnidadeModel
                    {
                        IdUnidade = origin.IdUnidade,                    
                        Sigla = origin.Sigla,
                        Bairro = origin.Bairro,
                        Cidade = origin.Cidade,
                        UF = origin.UF,
                        Numero = origin.Numero,
                        Longitude = origin.Longitude,
                        Latitude = origin.Latitude,
                        Estado = origin.Estado,
                        Endereco = origin.Endereco,
                        CEP = origin.CEP,
                        Nome = origin.Nome


                    };
                });
            }


        }

        public Task<UnidadeEntity> Parse(UnidadeModel origin)
        {
            if (origin == null)
            {
                return Task.Run(() => { return new UnidadeEntity(); });
            }
            else
            {

                return Task.Run(() => {
                    return new UnidadeEntity
                    {
                        IdUnidade = origin.IdUnidade,
                        Sigla = origin.Sigla,
                        Bairro = origin.Bairro,
                        Cidade = origin.Cidade,
                        UF = origin.UF,
                        Numero = origin.Numero,
                        Longitude = origin.Longitude,
                        Latitude = origin.Latitude,
                        Estado = origin.Estado,
                        Endereco = origin.Endereco,
                        CEP = origin.CEP,
                        Nome = origin.Nome
                    };
                });
            }
        }

        public UnidadeModel ParseAwait(UnidadeEntity origin)
        {
            if (origin == null)
            {
                return new UnidadeModel();
            }
            else
            {
                
                
                return new UnidadeModel
                {
                    IdUnidade = origin.IdUnidade,
                    Sigla = origin.Sigla,
                    Bairro = origin.Bairro,
                    Cidade = origin.Cidade,
                    UF = origin.UF,
                    Numero = origin.Numero,
                    Longitude = origin.Longitude,
                    Latitude = origin.Latitude,
                    Estado = origin.Estado,
                    Endereco = origin.Endereco,
                    CEP = origin.CEP,
                    Nome = origin.Nome
                };

            }


        }

        public UnidadeEntity ParseAwait(UnidadeModel origin)
        {
            if (origin == null)
            {
                return new UnidadeEntity();
            }
            else
            {
                return new UnidadeEntity
                {
                    IdUnidade = origin.IdUnidade,
                    Sigla = origin.Sigla,
                    Bairro = origin.Bairro,
                    Cidade = origin.Cidade,
                    UF = origin.UF,
                    Numero = origin.Numero,
                    Longitude = origin.Longitude,
                    Latitude = origin.Latitude,
                    Estado = origin.Estado,
                    Endereco = origin.Endereco,
                    CEP = origin.CEP,
                    Nome = origin.Nome
                };
            }
        }

        public Task<List<UnidadeModel>> ParseList(IQueryable<UnidadeEntity> origin)
        {
            if (origin == null)
            {
                return Task.Run(() => {
                    return new List<UnidadeModel>();
                });
            }
            else
            {
                return Task.Run(() => {

                    

                    return origin.Select(item => ParseAwait(item)).ToList();
                });
            }
        }

        public Task<List<UnidadeEntity>> ParseList(IQueryable<UnidadeModel> origin)
        {
            if (origin == null)
            {
                return Task.Run(() => {
                    return new List<UnidadeEntity>();
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
