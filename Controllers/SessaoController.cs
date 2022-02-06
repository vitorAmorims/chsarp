using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using cinemaAPI.Data.Dtos.Sessao;
using cinemaAPI.Models;
using cinemaAPI.Services;
using FilmesApi.Data;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace cinemaAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SessaoController : ControllerBase
    {
        private SessaoService _service;

        public SessaoController(SessaoService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult CadastrarSessao([FromBody] CreateSessaoDto sessaoDto)
        {
            ReadSessaoDto readSessaoDto = _service.CadastrarSessao(sessaoDto);
            
            return CreatedAtAction(nameof(RecuperarSessaoPorId), new {Id = readSessaoDto.id}, readSessaoDto);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperarSessaoPorId(int id)
        {
            ReadSessaoDto readSessaoDto = _service.RecuperarSessaoPorId(id);
            if(readSessaoDto == null) return NotFound();
            return Ok(readSessaoDto);
        }

        [HttpGet]
        public IActionResult ExibirSessoes()
        {
            List<ReadSessaoDto> lista = _service.ExibirSessoes();
            if(lista == null) return NotFound();
            return Ok(lista);
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarSessao(int id)
        {
            Result resultado = _service.DeletarSessao(id);
            if(resultado.IsFailed) return NotFound();
            return Ok();

        }

    }
}
