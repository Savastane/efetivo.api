
namespace efetivo.api.Controller
{

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using efetivo.model;
    using efetivo.negocio;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;


    [Route("api/v1")]
    [ApiController]
    
    public class ResumoController : ControllerBase
    {

        [Authorize]
        [HttpGet("resumo/{id}")]
        [ProducesResponseType(typeof(ResumoModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ResumoModel> Resumo(int id)
        {   
            return await  ResumoNegocio.Instance.GetResumo(id);

        }


        [Authorize]
        [HttpGet("resumo")]
        [ProducesResponseType(typeof(ResumoModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<List<UnidadesContigenteModel>> GetUnidadesContigente()
        {
            return null; // await ResumoNegocio.Instance.GetResumo(1);
        }

    }
}



