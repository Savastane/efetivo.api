using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using efetivo.entidades;
using reusecode.ValueObjct;


namespace efetivo.model.converter
{
    public class ResumoConverter : IParserAsync<ResumoModel, ResumoEntidade>, IParserAsync<ResumoEntidade, ResumoModel>
    {
        public Task<ResumoModel> Parse(ResumoEntidade origin)
        {
            if (origin == null)
            {
                return Task.Run(() => { return new ResumoModel(); }) ;
            }
            else {

                return Task.Run(() => {

                    return new ResumoModel
                                        {
                                            Id = origin.Id                 
                                        };
                });
            }
            
            
        }

        public Task<ResumoEntidade> Parse(ResumoModel origin)
        {
            if (origin == null)
            {
                return Task.Run(() => { return new ResumoEntidade(); });  
            }
            else
            {

                return Task.Run(() => {
                    return new ResumoEntidade
                            {
                                Id = origin.Id
                            };
                });
            }
        }

        public ResumoModel ParseAwait(ResumoEntidade origin)
        {
            if (origin == null)
            {
                return new ResumoModel();
            }
            else
            {

                
                    return new ResumoModel
                    {
                        Id = origin.Id
                    };
                
            }


        }

        public ResumoEntidade ParseAwait (ResumoModel origin)
        {
            if (origin == null)
            {
                return new ResumoEntidade(); 
            }
            else
            {                
                    return new ResumoEntidade
                    {
                        Id = origin.Id
                    };                
            }
        }

        public Task<List<ResumoModel>> ParseList(IQueryable<ResumoEntidade> origin)
        {
            if (origin == null)
            {
                return Task.Run(() => {
                    return new List<ResumoModel>();
                });
            }
            else
            {
                return Task.Run(() => {

                    return  origin.Select(item => ParseAwait(item)).ToList();
                });
            }
        }

        public Task<List<ResumoEntidade>> ParseList(IQueryable<ResumoModel> origin)
        {
            if (origin == null)
            {
                return  Task.Run(() => {
                    return new List<ResumoEntidade>();
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
