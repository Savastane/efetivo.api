


namespace efetivo.test
{

    using System;
    using Xunit;
    using System.Threading.Tasks;
    using efetivo.domain;
    using efetivo.model;

    public class SoldierTest 
    {

        
        [Fact]
        public async void GetAllSoldierForGenre()
        {
        

            var list = await SoldierDomain.Instance.GetAllSoldierForGenre(1, 1);
            
            Assert.NotEmpty(list);
            


        }

        [Fact]
        public async void GetAllSoldierForGradation()
        {
            var list = await SoldierDomain.Instance.GetAllSoldierForGradation(1, 1);
            Assert.NotEmpty(list);
        }

        [Fact]
        public async void GetSoldier()
        {
            SoldierMookup.Start();
            var unit = await SoldierDomain.Instance.GetSoldier(1);
            Assert.Equal(1, unit.IdEfetivo);

        }

        [Fact]
        public async void AddSoldier()
        {
            EfetivoModel model = await SoldierMookup.Add("Lauro de Freitas", -3);

            var resultado = await SoldierDomain.Instance.AddSoldier(model);

            Assert.Equal(model.IdEfetivo, resultado.IdEfetivo);

        }




    }

    public class SoldierMookup
    {
        public static async void Start()
        {
             await SoldierDomain.Instance.AddSoldier(await SoldierMookup.Add("Savastane", 1));
             await SoldierDomain.Instance.AddSoldier(await SoldierMookup.Add("Yoseph", 2));

        }
        public static  Task<EfetivoModel> Add(String Nome, decimal id)
        {
            EfetivoModel model = new EfetivoModel()
            {
                Nome = Nome,
                IdEfetivo = id,
                idPosto = 1,
                Genero = "1",
                idUnidade =1
            };

            return Task.Run(() => { return model; });

        }
    }
}
