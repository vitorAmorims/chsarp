using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CatalogoJogos.Controllers.V1
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class JogosController: ControllerBase
    {
        [HttpGet]
        public ActionResult<List<object>> GetGame()
        {
            
            return NoContent();
        }
        // [HttpGet]
        // public async Task<ActionResult<List<object>>> GetGame()
        // {
            
        //     return Ok();
        // }
        
        
    }
}
