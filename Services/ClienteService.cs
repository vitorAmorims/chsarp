using System;
using System.Collections.Generic;
using AutoMapper;
using cinemaAPI.Data.Dtos.Cliente;
using cinemaAPI.Models;
using FilmesApi.Data;
using System.Linq;
using FluentResults;

namespace cinemaAPI.Services
{
    public class ClienteService
    {
        private AppDbContext _context;
        private IMapper _mapper;
        public ClienteService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ReadClienteDto AdicionaCliente(CreateClienteDto clienteDto)
        {
            Cliente cliente = _mapper.Map<Cliente>(clienteDto);
            _context.Clientes.Add(cliente);
            _context.SaveChanges();
            return _mapper.Map<ReadClienteDto>(cliente);
        }

        public ReadClienteDto RecuperaClientePorId(int id)
        {
            Cliente cliente = _context.Clientes.FirstOrDefault(cliente => cliente.Id == id);
            if(cliente != null)
            {
                ReadClienteDto clienteDto = _mapper.Map<ReadClienteDto>(cliente);
                return clienteDto;
            }
            return null;
        }

        public List<ReadClienteDto> RecuperaClientes(string nomeDoCliente)
        {
            List<Cliente> clientes = _context.Clientes.ToList();
            if(clientes == null)
            {
                return null;
            }
            if(!string.IsNullOrEmpty(nomeDoCliente))
            {
                var query = from cliente in clientes
                    where cliente.Nome == nomeDoCliente
                    select cliente;

                clientes = query.ToList();
            }

            return _mapper.Map<List<ReadClienteDto>>(clientes);
        }

        public Result AtualizaCliente(int id, UpdateClienteDto clienteDto)
        {
            Cliente cliente = _context.Clientes.FirstOrDefault(cliente => cliente.Id == id);
            if(cliente == null)
            {
                return Result.Fail("Cliente não encontrado");
            }
            _mapper.Map(clienteDto, cliente);
            _context.SaveChanges();
            return Result.Ok();
        }

        public Result DeletarCliente(int id)
        {
            Cliente cliente = _context.Clientes.FirstOrDefault(cliente => cliente.Id == id);
            if (cliente == null)
            {
                return Result.Fail("Cliente não encontrado!");
            }
            _context.Remove(cliente);
            _context.SaveChanges();
            return Result.Ok();
        }
    }
}
