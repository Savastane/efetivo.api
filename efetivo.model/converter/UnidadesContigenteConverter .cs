using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using efetivo.entidades;
using reusecode.ValueObjct;

namespace efetivo.model.converter
{
    public class UnidadesContigenteConverter : IParserAsync<UnidadesContigenteModel, UnidadesContigenteEntidade>, IParserAsync<UnidadesContigenteEntidade, UnidadesContigenteModel>
    {
        public Task<UnidadesContigenteModel> Parse(UnidadesContigenteEntidade origin)
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

        public Task<UnidadesContigenteEntidade> Parse(UnidadesContigenteModel origin)
        {
            if (origin == null)
            {
                return Task.Run(() => { return new UnidadesContigenteEntidade(); });
            }
            else
            {

                return Task.Run(() => {
                    return new UnidadesContigenteEntidade
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

        public UnidadesContigenteModel ParseAwait(UnidadesContigenteEntidade origin)
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

        public UnidadesContigenteEntidade ParseAwait(UnidadesContigenteModel origin)
        {
            if (origin == null)
            {
                return new UnidadesContigenteEntidade();
            }
            else
            {
                return new UnidadesContigenteEntidade
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

        public Task<List<UnidadesContigenteModel>> ParseList(IQueryable<UnidadesContigenteEntidade> origin)
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

        public Task<List<UnidadesContigenteEntidade>> ParseList(IQueryable<UnidadesContigenteModel> origin)
        {
            if (origin == null)
            {
                return Task.Run(() => {
                    return new List<UnidadesContigenteEntidade>();
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
