
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

    [Authorize]
    [Route("api/v1")]
    [ApiController]
    
    public class UnidadeController : ControllerBase
    {


        [HttpGet("unidades")]
        [ProducesResponseType(typeof(UnidadesContigenteModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<List<UnidadesContigenteModel>> Unidades()
        {


            return await UnidadesNegocio.Instance.GetUnidades();

        }



        [HttpGet("unidade/{id}")]
        [ProducesResponseType(typeof(UnidadesContigenteModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<UnidadesContigenteModel> Unidades(int id)
        {
            return await UnidadesNegocio.Instance.GetUnidade(2);

        }
    }

    


    
}



