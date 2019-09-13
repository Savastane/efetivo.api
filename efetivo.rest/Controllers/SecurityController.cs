
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
    [Route("api/v1/seguranca")]
    [ApiController]
    public class SecurityController : ControllerBase
    {

        //private IUsuarioDomain _UsuarioNegocio;

        //public SegurancaController(IUsuarioNegocio UsuarioNegocio)
        //{
        //    _UsuarioNegocio = UsuarioNegocio;
        //}
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Get()
        {

            //var claims (System.Security.Claims.ClaimsIdentity)User.Identity;
            var content = "<html><head><meta charset = \"UTF-8\"></head><body><br><h> API. Versão.Alpha.1.0.0.0</h><p></p></body></html>";

            return new ContentResult()
            {
                Content = content,
                ContentType = "text/html",
            };

            //string nome = "";
            //return Ok(nome);

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

        [HttpGet("claim")]        
        public IActionResult GetUser()
        {
            //var claims (System.Security.Claims.ClaimsIdentity)User.Identity;

            
            return Ok(EnvironmentDomain.Instance.User);
            
        }

        [HttpGet("usuario")]
        public IActionResult Getclaim() 
        {

            SecurityDomain.Instance.InicializeEnvironment(User);
            return Ok(EnvironmentDomain.Instance.User);            
        }


    }
}

