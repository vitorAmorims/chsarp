using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CatalogoJogos.ViewModel;
using CatalogoJogos.InputModel;

namespace CatalogoJogos.Controllers.V1
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class JogosController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<GameViewModel>>> GetGame()
        {
            return Ok();
        }

        [HttpGet("{idGame:guid}")]
        public async Task<ActionResult<GameViewModel>> GetGameId(Guid idGame)
        {
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult<GameViewModel>> InsertGame(GameInputModel game)
        {
            return Ok();
        }

        [HttpPut("{idGame:guid}")]
        public async Task<ActionResult> UpdateGame(Guid idGame, GameInputModel game)
        {
            return Ok();
        }

        [HttpPatch("{idGame:guid}/preco/{price: double}")]
        public async Task<ActionResult> UpdateGame(Guid idGame, double price)
        {
            return Ok();
        }

        [HttpDelete("{idGame:guid}")]
        public async Task<ActionResult> DeleteGame(Guid idGame)
        {
            return Ok();
        }
    }
}
