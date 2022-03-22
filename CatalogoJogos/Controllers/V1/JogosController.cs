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
        public async Task<ActionResult<List<object>>> GetGame()
        {
            return Ok();
        }

        [HttpGet("{idGame:guid}")]
        public async Task<ActionResult<object>> GetGameId(Guid idGame)
        {
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult<object>> InsertGame([FromBody])
        {
            return Ok();
        }

        [HttpPut("{idGame:guid}")]
        public async ActionResult<object> UpdateGame(Guid idGame, object game)
        {
            return Ok();
        }
        
    }
}
