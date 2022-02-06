using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using cinemaAPI.Data.Dtos.Gerente;
using cinemaAPI.Models;
using cinemaAPI.Services;
using FilmesApi.Data;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace cinemaAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GerenteController : ControllerBase
    {
        private GerenteService _service;
        public GerenteController(GerenteService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult Adicionargerente(CreateGerenteDto gerenteDto)
        {
            ReadGerenteDto readDto = _service.Adicionargerente(gerenteDto);
            
            return CreatedAtAction(nameof(RecuperaGerentePorId), new { Id = readDto.Id }, readDto);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaGerentePorId(int id)
        {
            ReadGerenteDto readDto = _service.RecuperaGerentePorId(id);
            if(readDto != null) return Ok(readDto);
            return NotFound();
        }

        [HttpGet]
        public IActionResult ExibirGerentes([FromQuery] string nomeDogerente)
        {
            List<ReadGerenteDto> lista = _service.ExibirGerentes(nomeDogerente);
            if(lista != null) return Ok(lista);
            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaGerente(int id)
        {
            Result resultado = _service.DeletaGerente(id);
            if(resultado.IsFailed) return NotFound();
            return NoContent();
        }
        [HttpPut("{id}")]
        public IActionResult AtualizarGerente(int id, [FromBody] UpdateGerenteDto gerenteDto)
        {
            Result resultado = _service.AtualizarGerente(id, gerenteDto);
            if(resultado.IsFailed) return NotFound();
            return NoContent();

        }
    }
}
