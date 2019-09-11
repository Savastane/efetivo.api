using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using efetivo.entity;
using infra.valueobject;

namespace efetivo.model.converter
{
    public class UnidadesContigenteConverter : IParserAsync<UnidadesContigenteModel, UnidadesContigenteEntity>, IParserAsync<UnidadesContigenteEntity, UnidadesContigenteModel>
    {
        public Task<UnidadesContigenteModel> Parse(UnidadesContigenteEntity origin)
        {
            if (origin == null)
            {
                return Task.Run(() => { return new UnidadesContigenteModel(); });
            }
            else
            {

                return Task.Run(() => {

                    return new UnidadesContigenteModel
                    {
                        IdUnidade = origin.IdUnidade,
                        NomeUnidade = origin.NomeUnidade,
                        Regiao = origin.Regiao,
                        Sigla = origin.Sigla,
                        Bairro = origin.Bairro,
                        Cidade = origin.Cidade,
                        UnidadeFederativa = origin.UnidadeFederativa,
                        ImagemUnidade = origin.ImagemUnidade,
                        Contigente = origin.Contigente
                    };
                });
            }


        }

        public Task<UnidadesContigenteEntity> Parse(UnidadesContigenteModel origin)
        {
            if (origin == null)
            {
                return Task.Run(() => { return new UnidadesContigenteEntity(); });
            }
            else
            {

                return Task.Run(() => {
                    return new UnidadesContigenteEntity
                    {
                        IdUnidade = origin.IdUnidade,
                        NomeUnidade = origin.NomeUnidade,
                        Regiao = origin.Regiao,
                        Sigla = origin.Sigla,
                        Bairro = origin.Bairro,
                        Cidade = origin.Cidade,
                        UnidadeFederativa = origin.UnidadeFederativa,
                        ImagemUnidade = origin.ImagemUnidade,
                        Contigente = origin.Contigente
                    };
                });
            }
        }

        public UnidadesContigenteModel ParseAwait(UnidadesContigenteEntity origin)
        {
            if (origin == null)
            {
                return new UnidadesContigenteModel();
            }
            else
            {
                
                
                return new UnidadesContigenteModel
                {
                    IdUnidade = origin.IdUnidade,
                    NomeUnidade = origin.NomeUnidade,
                    Regiao = origin.Regiao,
                    Sigla = origin.Sigla,
                    Bairro = origin.Bairro,
                    Cidade = origin.Cidade,
                    UnidadeFederativa = origin.UnidadeFederativa,
                    ImagemUnidade = origin.ImagemUnidade,
                    Contigente = origin.Contigente
                };

            }


        }

        public UnidadesContigenteEntity ParseAwait(UnidadesContigenteModel origin)
        {
            if (origin == null)
            {
                return new UnidadesContigenteEntity();
            }
            else
            {
                return new UnidadesContigenteEntity
                {
                    IdUnidade = origin.IdUnidade,                                    
                    NomeUnidade = origin.NomeUnidade,
                    Regiao = origin.Regiao,
                    Sigla = origin.Sigla,
                    Bairro = origin.Bairro,
                    Cidade = origin.Cidade,
                    UnidadeFederativa = origin.UnidadeFederativa,
                    ImagemUnidade = origin.ImagemUnidade,
                    Contigente = origin.Contigente
                };
            }
        }

        public Task<List<UnidadesContigenteModel>> ParseList(IQueryable<UnidadesContigenteEntity> origin)
        {
            if (origin == null)
            {
                return Task.Run(() => {
                    return new List<UnidadesContigenteModel>();
                });
            }
            else
            {
                return Task.Run(() => {

                    

                    return origin.Select(item => ParseAwait(item)).ToList();
                });
            }
        }

        public Task<List<UnidadesContigenteEntity>> ParseList(IQueryable<UnidadesContigenteModel> origin)
        {
            if (origin == null)
            {
                return Task.Run(() => {
                    return new List<UnidadesContigenteEntity>();
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
