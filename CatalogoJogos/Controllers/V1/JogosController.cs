using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CatalogoJogos.ViewModel;
using CatalogoJogos.InputModel;
using CatalogoJogos.Services;
using System.ComponentModel.DataAnnotations;
using CatalogoJogos.Exceptions;

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
        public async Task<ActionResult<IEnumerable<GameViewModel>>> GetGame(
            [FromQuery, Range(1, int.MaxValue)] int page = 1,
            [FromQuery, Range(1, 50)] int amount = 5)
        {
            var games = await _jogoService.GetGames(Convert.ToInt32(page), Convert.ToInt32(amount));

            if (games.Count() == 0) return NoContent();

            return Ok(games);
        }

        [HttpGet("{idGame:guid}")]
        public async Task<ActionResult<GameViewModel>> GetGameId(Guid idGame)
        {
            var game = await _jogoService.GetGame(idGame);

            if (game == null) return NoContent();

            return Ok(game);
        }

        [HttpPost]
        public async Task<ActionResult<GameViewModel>> InsertGame([FromBody] GameInputModel game)
        {
            try
            {
                var result = await _jogoService.InsertGame(game);
                return Ok(result);

            }
            catch (RegisteredGameException e)
            {
                return UnprocessableEntity(e.Message);
            }
        }

        [HttpPut("{idGame:guid}")]
        public async Task<ActionResult> UpdateGame(
            [FromRoute] Guid idGame,
            [FromBody] GameInputModel game)
        {
            try
            {
                await _jogoService.UpdateGame(idGame, game);
                return Ok();
            }
            catch (RegisteredNotGameException e)
            {
                return NotFound(e.Message);   
            }
        }

        [HttpPatch("{idGame:guid}/price/{price:double}")]
        public async Task<ActionResult> UpdatePriceGame(
            [FromRoute] Guid idGame,
            [FromRoute] double price)
        {
            try
            {
                await _jogoService.UpdatePriceGame(idGame, Convert.ToDouble(price));
                return Ok();   
            }
            catch (RegisteredNotGameException e)
            {
                return NotFound(e.Message);   
            }

        }

        [HttpDelete("{idGame:guid}")]
        public async Task<ActionResult> DeleteGame([FromRoute] Guid idGame)
        {
            try
            {
                await _jogoService.Remove(idGame);
                return Ok();   
            }
            catch (RegisteredNotGameException e)
            {
                return NotFound(e.Message);   
            }
        }
    }
}
