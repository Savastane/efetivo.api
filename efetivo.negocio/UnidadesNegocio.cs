


namespace efetivo.negocio
{

    using efetivo.repositorio;
    using System;    
    using System.Threading.Tasks;
    using System.Linq;    
    using efetivo.model;
    using System.Collections.Generic;

    public class UnidadesNegocio:  IResumoNegocio
    {
        #region Singleton

        private UnidadesContigenteRepositorio repositorio = new UnidadesContigenteRepositorio();
            
        private static volatile UnidadesNegocio instance;
        private static object syncRoot = new Object();

        public static UnidadesNegocio Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new UnidadesNegocio();
                    }
                }

                return instance;
            }
        }

        #endregion Singleton

        public async Task<UnidadesContigenteModel> GetUnidade(int id_unidade)
        {
            return null;

        }


        public async Task<List<UnidadesContigenteModel>> GetUnidades()
        {
            return await repositorio.GetUnidadesContigente();

        }

    }
}
