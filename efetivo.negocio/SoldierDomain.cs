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


    public class SoldierDomain
    {
        #region Singleton

        private SoldierRepository repositorio = new SoldierRepository();

        private static volatile SoldierDomain instance;
        private static object syncRoot = new Object();

        public static SoldierDomain Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new SoldierDomain();
                    }
                }

                return instance;
            }
        }

        #endregion Singleton


        public Task<EfetivoModel> AddSoldier(EfetivoModel model)
        {
            return repositorio.AddSoldier(model);
        }


        public Task<List<EfetivoModel>> GetAllSoldierForGenre(decimal idUnit, decimal IdGenre)
        {
            return repositorio.GetAllSoldierForGradation(idUnit, IdGenre);
        }

        public Task<List<EfetivoModel>> GetAllSoldierForGradation(decimal idUnit, decimal IdGradation)
        {
            return repositorio.GetAllSoldierForGradation(idUnit, IdGradation);
        }

        public Task<EfetivoModel> GetSoldier(decimal id)
        {
            return repositorio.GetSoldier(id);
        }




    }

   

}