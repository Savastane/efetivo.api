

namespace efetivo.api.Controller
{

    
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;
    using efetivo.model;
    using efetivo.negocio;
    using System.Security.Claims;

    [Authorize]
    [Route("api/v1")]
    [ApiController]
    public class SegurancaController : ControllerBase
    {

        private IUsuarioNegocio _UsuarioNegocio;

        //public SegurancaController(IUsuarioNegocio UsuarioNegocio)
        //{
        //    _UsuarioNegocio = UsuarioNegocio;
        //}


        [AllowAnonymous]
        [HttpPost("seguranca/autenticar")]
        [ProducesResponseType(typeof(LoginModel), StatusCodes.Status200OK)]        
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Autenticar([FromBody]LoginModel usuario)
        {

            var usuarioretorno = UsuarioNegocio.Instance.Autenticar(usuario);

             if (usuarioretorno.IdUsuario == 0)
             {
                return Unauthorized();
             }
             else
             {
                return Ok(usuarioretorno);
             }
            


            
        }

        [HttpGet("seguranca/usuario")]        
        public IActionResult GetAll()
        {

            //var claims (System.Security.Claims.ClaimsIdentity)User.Identity;
            return Ok(UsuarioNegocio.Instance.getUsuario());
            //return NotFound(null);
        }

        [HttpGet("seguranca/claim")]
        public IActionResult Getclaim()
        {   
            return Ok(UsuarioNegocio.Instance.getClaim((ClaimsIdentity)User.Identity));            
        }


    }
}
