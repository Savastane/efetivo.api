


namespace efetivo.test
{

    using System;
    using Xunit;
    using System.Threading.Tasks;
    using efetivo.domain;
    using efetivo.model;

    public class SecurityTest
    {

        
        /// <summary>
        /// testar autenticação positiva
        /// </summary>
        [Fact]
        public async void AutenticationValidLogin()
        {

            var resultado = await SecurityDomain.Instance.Autenticar(SecurityDomain.Instance.UserTest("sava@gmail.com", "33344343"));

            Assert.Equal(ReturnActionAutentication.Valid, resultado);

        }


        [Fact]
        public async void AutenticationInvalidLogin()
        {

            var user = SecurityDomain.Instance.UserTest("sava@gmail.com", "senha-errada");
            var resultado = await SecurityDomain.Instance.Autenticar(user);

            Assert.Equal(ReturnActionAutentication.Invalid, resultado);

        }


        [Fact]
        public async void AutenticationErrorConectionDB()
        {

            var user = SecurityDomain.Instance.UserTest("sava@gmail.com", "simulation_error_conenection_db");
            var resultado = await SecurityDomain.Instance.Autenticar(user);

            Assert.Equal(ReturnActionAutentication.ErrorDB, resultado);

        }

       

    }
}
