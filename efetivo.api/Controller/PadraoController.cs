

namespace efetivo.api.Controller
{

    using efetivo.domain;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;
    using efetivo.model;
    using System.Security.Claims;


    [Route("api/v1")]
    [ApiController]
    public class PadraoController : ControllerBase
    {

        

        //public SegurancaController(IUsuarioNegocio UsuarioNegocio)
        //{
        //    _UsuarioNegocio = UsuarioNegocio;
        //}


        [AllowAnonymous]
        [HttpGet("padrao")]
        
        public IActionResult padrao()
        {
            HomeModel  obj  = new HomeModel();
            obj.Application = "Efetivo";
            obj.Version = "1.00";
            obj.Message = "Controle de Versão";
            obj.CopyRight = "sava 2020";
            obj.Email = "suporte@sava.com.br";
            return Ok(obj);
            
        }


    }

    public partial class HomeModel
    {

        public string Application { get; set; }

        public string Version { get; set; }
        public string Message { get; set; }

        public string CopyRight { get; set; }

        public string Email { get; set; }

        

    }
}
