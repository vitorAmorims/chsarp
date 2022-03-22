using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CatalogoJogos.ViewModel;
using CatalogoJogos.InputModel;
using CatalogoJogos.Services;
using System.ComponentModel.DataAnnotations;

namespace CatalogoJogos.Controllers.V1
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class JogosController : ControllerBase
    {
        private readonly IJogoService _jogoService;
        public JogosController(IJogoService jogoService)
        {
            _jogoService = jogoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GameViewModel>>> GetGame([FromQuery,
            Range(1, int.MaxValue)] int page = 1,
            [FromQuery, Range(1, 50)] int amount = 5)
        {
            var result = await _jogoService.GetGames(page, amount);

            if(result.Count() == 0) return NoContent();

            return Ok(result);
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
