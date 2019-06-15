using efetivo.entidades;
using efetivo.repositorio;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace efetivo.negocio
{

    public class UsuarioNegocio: IUsuarioNegocio
    {
        #region Singleton

        private UsuarioRepositorio repositorio = new UsuarioRepositorio();
            
        private static volatile UsuarioNegocio instance;
        private static object syncRoot = new Object();

        public static UsuarioNegocio Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new UsuarioNegocio();
                    }
                }

                return instance;
            }
        }

        #endregion Singleton

        public  UsuarioEntidade Autenticar(UsuarioEntidade usuario)
        {
            
            return repositorio.Auntenticar(usuario.Nome, usuario.Senha, "UmaChave@FortePrecisadeNumeros2020");

        }

        public UsuarioEntidade getUsuario()
        {

            return repositorio.Find(1);

        }


    }
}
