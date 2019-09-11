
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
    [Route("api/v1")]
    [ApiController]
    public class SegurancaController : ControllerBase
    {

        //private IUsuarioDomain _UsuarioNegocio;

        //public SegurancaController(IUsuarioNegocio UsuarioNegocio)
        //{
        //    _UsuarioNegocio = UsuarioNegocio;
        //}


        [AllowAnonymous]
        [HttpPost("seguranca/autenticar")]
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

        [HttpGet("seguranca/usuario")]        
        public IActionResult GetUser()
        {
            //var claims (System.Security.Claims.ClaimsIdentity)User.Identity;

            
            return Ok(EnvironmentDomain.Instance.User);
            
        }

        [HttpGet("seguranca/claim")]
        public IActionResult Getclaim()
        {
            var a = User;

            return Ok(SecurityDomain.Instance.getClaim((ClaimsIdentity)User.Identity));            
        }


    }
}
