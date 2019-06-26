


namespace efetivo.negocio
{

    using efetivo.repositorio;
    using System;    
    using System.Threading.Tasks;
    using System.Linq;    
    using efetivo.model;

    public class ResumoNegocio:  IResumoNegocio
    {
        #region Singleton

        private ResumoRepositorio repositorio = new ResumoRepositorio();
            
        private static volatile ResumoNegocio instance;
        private static object syncRoot = new Object();

        public static ResumoNegocio Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new ResumoNegocio();
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
