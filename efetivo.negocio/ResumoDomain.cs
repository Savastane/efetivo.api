


namespace efetivo.domain
{

    using efetivo.repository;
    using System;    
    using System.Threading.Tasks;
    using System.Linq;    
    using efetivo.model;

    public class ResumoDomain :  IResumoDomain
    {
        #region Singleton

        private ResumoRepository repositorio = new ResumoRepository();
            
        private static volatile ResumoDomain instance;
        private static object syncRoot = new Object();

        public static ResumoDomain Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new ResumoDomain();
                    }
                }

                return instance;
            }
        }

        #endregion Singleton

        public async Task<ResumoModel> GetResumo(int id_unidade)
        {
            return await repositorio.GetResumo(id_unidade);

        }


    }
}
