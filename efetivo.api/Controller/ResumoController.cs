
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


    [Route("api/v1")]
    [ApiController]
    
    public class ResumoController : ControllerBase
    {


        [HttpGet("Resumo")]
        [ProducesResponseType(typeof(ResumoEntidade), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ResumoEntidade>  Resumo()
        {   
            return await ResumoNegocio.Instance.GetResumo(1);

        }
    }
}



