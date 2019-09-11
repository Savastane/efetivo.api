using efetivo.model;
using efetivo.model.converter;
using efetivo.repository;

using infra.security;
using System;
using System.Collections.Generic;
using System.Security.Claims;


namespace efetivo.domain
{

    public class EnvironmentDomain : IUsuarioDomain
    {
        #region Singleton

        private UsuarioRepository repositorio = new UsuarioRepository();
            
        private static volatile EnvironmentDomain instance;
        private static object syncRoot = new Object();

        public static EnvironmentDomain Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new EnvironmentDomain();
                    }
                }

                return instance;
            }
        }

        #endregion Singleton
        

        public String SecretKeyToken = "UmaChave@FortePrecisadeNumeros2020";
        public LoginModel User;
        private LoginModel Group;
        private LoginModel Systems;
        private LoginModel Requeriments;
        

        #region Adds

        public void AddUser(LoginModel user)
        {
            this.User = user;
        }

        public void AddGroup(LoginModel user)
        {
            this.Group = user;
        }

        public void AddSystem(LoginModel user)
        {
            this.Systems = user;
        }

        public void AddRequeriments(LoginModel user)
        {
            this.Requeriments = user;
        }

        #endregion Adds


    }
}
