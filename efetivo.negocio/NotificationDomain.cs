using efetivo.model;
using efetivo.model.converter;
using efetivo.repository;

using infra.security;
using System;
using System.Collections.Generic;
using System.Security.Claims;


namespace efetivo.domain
{


    public class NotificationDomain 
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
        
        public void Register()
        {
        }
        
        public void UnRegister(decimal id)
        {
        }


    }
}
