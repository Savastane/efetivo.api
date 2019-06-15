

namespace efetivo.api.Controller
{

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using efetivo.entidades;
    using efetivo.negocio;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;
    

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
        [ProducesResponseType(typeof(UsuarioEntidade), StatusCodes.Status200OK)]
        
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Autenticar([FromBody]UsuarioEntidade usuario)
        {

            var usuarioretorno = UsuarioNegocio.Instance.Autenticar(usuario);

             if (usuarioretorno == null)
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
            return Ok(UsuarioNegocio.Instance.getUsuario());
            //return NotFound(null);
        }
    }
}
