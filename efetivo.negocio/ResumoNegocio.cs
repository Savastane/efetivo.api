using efetivo.entidades;
using efetivo.repositorio;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace efetivo.negocio
{

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

        public async Task<ResumoEntidade> GetResumo(int id_unidade)
        {   
            return await repositorio.GetResumo(id_unidade);

        }

    }
}
