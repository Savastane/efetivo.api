
namespace efetivo.api.Controller
{

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using efetivo.model;
    using efetivo.domain;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    [Route("api/v1")]
    [ApiController]
    
    public class EfetivoController : ControllerBase
    {
        /*

        [HttpGet("Efetivo")]
        [ProducesResponseType(typeof(ResumoModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ResumoModel>  Efetivo(int id_efetivo)
        {   
            return await  ResumoDomain.Instance.GetResumo(1);
        }


        [HttpGet("Efetivo/Unidade")]
        [ProducesResponseType(typeof(ResumoModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ResumoModel> EfetivoUnidade(int id_unidade)
        {
            return await ResumoDomain.Instance.GetResumo(1);
        }
        */

    }
}



