


namespace efetivo.test
{

    using System;
    using Xunit;
    using System.Threading.Tasks;
    using efetivo.domain;
    using efetivo.model;
    using System.Linq;

    public class CorporationTest
    {


        [Fact]
        public async void GetAllUnits()
        {
            UnidadeModel model = await AddMockupUnit("Barreiras", -1);
            await CorporationDomain.Instance.AddUnit(model);

            model = await AddMockupUnit("Feira de Santana", -2);
            await CorporationDomain.Instance.AddUnit(model);

            
            var list = await CorporationDomain.Instance.GetAllUnits();

            Assert.NotEmpty(list);
            

        }

        [Fact]
        public async void AddUnit()
        {
            UnidadeModel model = await AddMockupUnit("Lauro de Freitas",-3);            

            var resultado = await CorporationDomain.Instance.AddUnit(model);

            Assert.Equal(model.IdUnidade, resultado.IdUnidade);


        }

        [Fact]
        public async void GetSpecificUnit()
        {

            UnidadeModel model = await AddMockupUnit("Salvador", -4);

            
            var resultado = await CorporationDomain.Instance.AddUnit(model);

            var unit = await CorporationDomain.Instance.GetUnit(model.IdUnidade);

            Assert.Equal(unit.IdUnidade, model.IdUnidade);

        }
                




        private async Task<UnidadeModel> AddMockupUnit(String Nome, decimal id)
        {
            UnidadeModel model = new UnidadeModel()
            {
                Nome = Nome,
                Bairro = Nome,
                IdUnidade = id,
                CEP = "",
                Cidade = "",
                Endereco = "",
                Estado = "",
                Latitude = 222,
                Longitude = 2121,
                Numero = "1",
                Sigla = "",
                UF = "BA"

            };

            return await Task.Run(() => { return model; });
            

            


        }


    }
}
