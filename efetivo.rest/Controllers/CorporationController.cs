
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



        [AllowAnonymous]
        [HttpPost("autenticar")]
        [ProducesResponseType(typeof(LoginModel), StatusCodes.Status200OK)]        
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Login([FromBody]LoginModel usuario)
        {
            var retorno = SecurityDomain.Instance.Autenticar(usuario);
            
            var ResultAuntentication =  await SecurityDomain.Instance.Autenticar(usuario);


            switch (ResultAuntentication)
            {

                case ReturnActionAutentication.Valid:

                    return Ok(EnvironmentDomain.Instance.User);

                case ReturnActionAutentication.Invalid:

                    return Unauthorized();

                case ReturnActionAutentication.ErrorDB:

                    return Forbid();

                default:

                    return Unauthorized();

            }
            

            


            
        }

        

        [HttpGet("usuario")]
        public IActionResult Getclaim() 
        {

            SecurityDomain.Instance.InicializeEnvironment(User);
            return Ok(EnvironmentDomain.Instance.User);            
        }


    }
}

