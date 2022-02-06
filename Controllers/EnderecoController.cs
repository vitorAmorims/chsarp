using AutoMapper;
using cinemaAPI.Data.Dtos.Endereco;
using cinemaAPI.Models;
using cinemaAPI.Services;
using FilmesApi.Data;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EnderecoController : ControllerBase
    {
        private EnderecoService _service;
        public EnderecoController(EnderecoService service)
        {
           _service = service;
        }
  

        [HttpPost]
        public IActionResult AdicionaEndereco([FromBody] CreateEnderecoDto enderecoDto)
        {
            ReadEnderecoDto readDto = _service.AdicionaEndereco(enderecoDto);
            
            return CreatedAtAction(nameof(RecuperaEnderecosPorId), new { Id = readDto.Id }, readDto);
        }

        [HttpGet]
        public IActionResult RecuperaEnderecos([FromQuery] string logradouro)
        {
            List<ReadEnderecoDto> lista = _service.RecuperaEnderecos(logradouro);
            if(lista == null) return NotFound();
            return Ok(lista);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaEnderecosPorId(int id)
        {
            ReadEnderecoDto readDto = _service.RecuperaEnderecosPorId(id);
            if(readDto == null) return NotFound();
            return Ok(readDto);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaEndereco(int id, [FromBody] UpdateEnderecoDto enderecoDto)
        {
            Result resultado = _service.AtualizaEndereco(id, enderecoDto);
            if(resultado.IsFailed) return NotFound();
            return NoContent();
        }


        [HttpDelete("{id}")]
        public IActionResult DeletaEndereco(int id)
        {
            Result resultado = _service.DeletaEndereco(id);
            if(resultado.IsFailed) return NotFound();
            return NoContent();
        }

    }
}
