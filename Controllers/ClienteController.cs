using Microsoft.AspNetCore.Mvc;
using FluentResults;
using cinemaAPI.Services;
using cinemaAPI.Data.Dtos.Cliente;
using System.Collections.Generic;

namespace cinemaAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : ControllerBase
    {
        private ClienteService _service;
        public ClienteController(ClienteService service)
        {
            this._service = service;
        }

        [HttpPost]
        public IActionResult AdicionarCliente([FromBody] CreateClienteDto clienteDto)
        {
            ReadClienteDto readDto = _service.AdicionaCliente(clienteDto);
            
            return CreatedAtAction(nameof(RecuperaClientePorId), new { Id = readDto.Id }, readDto);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaClientePorId(int id)
        {
            ReadClienteDto readDto = _service.RecuperaClientePorId(id);
            if(readDto != null) return Ok(readDto);
            return NotFound();
        }

        [HttpGet]
        public IActionResult RecuperaClientes([FromQuery] string nomeDoCliente)
        {
            List<ReadClienteDto> lista = _service.RecuperaClientes(nomeDoCliente);
            if(lista == null) return NotFound();
            return Ok(lista);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaCliente(int id, [FromBody] UpdateClienteDto clienteDto)
        {
            Result resultado = _service.AtualizaCliente(id, clienteDto);
            if(resultado.IsFailed) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarCliente(int id)
        {
            ReadClienteDto readDto = _service.RecuperaClientePorId(id);
            if(readDto == null) return NotFound();

            Result resultado = _service.DeletarCliente(id);
            if(resultado.IsSuccess)
            {
                return Ok();
            }
            return NotFound();
        }
    }
}
