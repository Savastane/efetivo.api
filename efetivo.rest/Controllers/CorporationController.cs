
namespace efetivo.api.Controller
{

    using efetivo.domain;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;
    using efetivo.model;
    using System.Security.Claims;
    using System.Threading.Tasks;

    [Authorize]
    [Route("api/v1/corporacao")]
    [ApiController]
    public class CorporationController : ControllerBase
    {

        //private IUsuarioDomain _UsuarioNegocio;

        //public SegurancaController(IUsuarioNegocio UsuarioNegocio)
        //{
        //    _UsuarioNegocio = UsuarioNegocio;
        //}
        [AllowAnonymous]
        [HttpGet("unidades")]
        public async Task<IActionResult> Get()
        {

            var lista = await CorporationDomain.Instance.GetAllViewUnits();

            return Ok(lista);            

        }



        [HttpGet("usuario")]
        public IActionResult Getclaim() 
        {

            SecurityDomain.Instance.InicializeEnvironment(User);
            return Ok(EnvironmentDomain.Instance.User);            
        }


    }
}

