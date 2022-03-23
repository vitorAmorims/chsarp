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
        public async Task<ActionResult<IEnumerable<GameViewModel>>> GetGame([
            FromQuery,
            Range(1, int.MaxValue)] int page = 1,
            [FromQuery, Range(1, 50)] int amount = 5)
        {
            var games = await _jogoService.GetGames(page, amount);

            if(games.Count() == 0) return NoContent();

            return Ok(games);
        }

        [HttpGet("{idGame:guid}")]
        public async Task<ActionResult<GameViewModel>> GetGameId(Guid idGame)
        {
            var game = await _jogoService.GetGame(idGame);

            if(game == null) return NoContent();

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
            // catch (RegisteredGameException ex)
            catch(Exception e)
            {
                return UnprocessableEntity("Já existe um jogo com este nome para esta produtora.");
            }
        }

        [HttpPut("{idGame:guid}")]
        public async Task<ActionResult> UpdateGame(
            [FromRoute] Guid idGame,
            [FromBody]GameInputModel game)
        {
            try
            {
                await _jogoService.UpdateGame(idGame, game);
                return Ok();
            }
            // catch (RegisteredGameException ex)
            catch(Exception ex)
            {
                return NotFound("Não existe o jogo cadastrado");   
                
            }
        }

        [HttpPatch("{idGame:guid}/preco/{price: double}")]
        public async Task<ActionResult> UpdatePriceGame(Guid idGame, double price)
        {
            try
            {
                await _jogoService.UpdatePriceGame(idGame, price);
                return Ok();   
            }
            // catch (RegisteredGameException ex)
            catch (System.Exception ex)
            {
                return NotFound("Não existe o jogo cadastrado");   
            }
            
        }

        [HttpDelete("{idGame:guid}")]
        public async Task<ActionResult> DeleteGame(Guid idGame)
        {
            return Ok();
        }
    }
}
