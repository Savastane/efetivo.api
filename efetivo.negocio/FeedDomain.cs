using efetivo.model;
using efetivo.model.converter;
using efetivo.repository;

using infra.security;
using System;
using System.Collections.Generic;
using System.Security.Claims;


namespace efetivo.domain
{


    public class FeedDomain 
    {
        #region Singleton

        private UsuarioRepository repositorio = new UsuarioRepository();
            
        private static volatile FeedDomain instance;
        private static object syncRoot = new Object();

        public static FeedDomain Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new FeedDomain();
                    }
                }

                return instance;
            }
        }

        #endregion Singleton

        public void InsertPost()
        {
        }

        
        public void DeletePost(decimal id)
        {
        }

        public void UpdatePost()
        {
        }

        public void GetPost(decimal IdFeed)
        {
        }

        public void GetFeed(decimal idUnit, decimal IdGenre)
        {
        }

        public void QualifyPost(decimal IdFeed)
        {
        }
        

    }
}
