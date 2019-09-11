using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using efetivo.entity;
using infra.valueobject;


namespace efetivo.model.converter
{
    public class ResumoConverter : IParserAsync<ResumoModel, ResumoEntity>, IParserAsync<ResumoEntity, ResumoModel>
    {
        public Task<ResumoModel> Parse(ResumoEntity origin)
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

        public Task<ResumoEntity> Parse(ResumoModel origin)
        {
            if (origin == null)
            {
                return Task.Run(() => { return new ResumoEntity(); });  
            }
            else
            {

                return Task.Run(() => {
                    return new ResumoEntity
                    {
                                Id = origin.Id
                            };
                });
            }
        }

        public ResumoModel ParseAwait(ResumoEntity origin)
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

        public ResumoEntity ParseAwait (ResumoModel origin)
        {
            if (origin == null)
            {
                return new ResumoEntity(); 
            }
            else
            {                
                    return new ResumoEntity
                    {
                        Id = origin.Id
                    };                
            }
        }

        public Task<List<ResumoModel>> ParseList(IQueryable<ResumoEntity> origin)
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

        public Task<List<ResumoEntity>> ParseList(IQueryable<ResumoModel> origin)
        {
            if (origin == null)
            {
                return  Task.Run(() => {
                    return new List<ResumoEntity>();
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
