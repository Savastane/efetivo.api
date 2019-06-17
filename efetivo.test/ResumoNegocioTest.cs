using System;
using Xunit;
using efetivo.negocio;
using efetivo.entidades;
using System.Threading.Tasks;
using efetivo.model;

namespace efetivo.test
{
    public class ResumoNegocioTest
    {
        [Fact]
        public async void Consultar()
        {
            ResumoModel entidade = await ResumoNegocio.Instance.GetResumo(1);

            Assert.Equal(1, entidade.Id);

        }
    }
}
