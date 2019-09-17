
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
    [Route("api/v1/[controller]")]
    [ApiController]
    public class SegurancaController : ControllerBase
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

            string nome = "<h1><B>v.alpha.1.0.0.0</B></h1>";
            return Ok(nome);

        }


        /// <summary>
        /// Creates a TodoItem.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Todo
        ///     {
        ///        "id": 1,
        ///        "name": "Item1",
        ///        "isComplete": true
        ///     }
        ///
        /// </remarks>
        /// <param name="LoginModel"></param>
        /// <returns>A newly created TodoItem</returns>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If the item is null</response>            
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


        /// <summary>
        /// Deletes a specific TodoItem.
        /// </summary>
        /// <param name="id"></param>     
        [HttpGet("usuarioTest")]        
        public IActionResult GetUserTest()
        {
            
            return Ok(EnvironmentDomain.Instance.User);
            
        }

        [HttpGet("usuario")]
        public IActionResult GetUser()
        {

            // carrega Environment
            SecurityDomain.Instance.InicializeEnvironment(User);

            //Ok - SecurityDomain.Instance.getClaim(User)

            return Ok(EnvironmentDomain.Instance.User);            
        }


    }
}

