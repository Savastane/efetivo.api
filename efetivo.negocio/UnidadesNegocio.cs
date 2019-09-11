


namespace efetivo.domain
{

    using efetivo.repository;
    using System;    
    using System.Threading.Tasks;
    using System.Linq;    
    using efetivo.model;
    using System.Collections.Generic;

    public class UnidadesNegocio:  IResumoDomain
    {
        #region Singleton

        private UnidadesContigenteRepository repositorio = new UnidadesContigenteRepository();
            
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

        /*
        public async Task<UnidadesContigenteModel> GetUnidade(int id_unidade)
        {
            return null;

        }
        

        public async Task<List<UnidadesContigenteModel>> GetUnidades()
        {
            return  repositorio.GetUnidadesContigente();

        }
        */
    }
}
