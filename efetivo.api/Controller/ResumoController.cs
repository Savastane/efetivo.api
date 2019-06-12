using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace efetivo.api.Controller
{
    [Route("api/v1")]
    [ApiController]
    public class ResumoController : ControllerBase
    {
        [HttpGet("Resumo")]

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Resumo()
        {
            return Ok("Api Funcionando");
        }
    }
}



