using efetivo.entity;
using efetivo.model;
using efetivo.model.converter;
using efetivo.repository;

using infra.security;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace efetivo.domain
{


    public class CorporationDomain 
    {
        #region Singleton

        private UsuarioRepository repositorio = new UsuarioRepository();
            
        private static volatile CorporationDomain instance;
        private static object syncRoot = new Object();

        public static CorporationDomain Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new CorporationDomain();
                    }
                }

                return instance;
            }
        }

        #endregion Singleton
        

        #region Unit

        public Task<List<UnidadesContigenteModel>> GetAllViewUnits()
        {                        
            return new UnidadesContigenteRepository().GetAllUnits();
        }


        public Task<List<UnidadeModel>> GetAllUnits()
        {
            return new UnidadeRepository().GetAllUnits();
        }


        public async Task<UnidadeModel> GetUnit(decimal id)
        {
            return  await new UnidadeRepository().GetUnit(id);
        }


        public Task<UnidadeModel> AddUnit(UnidadeModel unidade)
        {
            return new UnidadeRepository().AddUnit(unidade);
        }

        public void DeleteUnit(decimal id)
        {
           // return new UnidadeRepository().DeleteUnit(id);
        }

        public UnidadeModel UpdateUnit(decimal id)
        {

         //   return new UnidadeRepository().UpdateUnit(id);

            return null;
        }


        #endregion Unit

    }
}
