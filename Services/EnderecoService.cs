using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using cinemaAPI.Data.Dtos.Endereco;
using cinemaAPI.Models;
using FilmesApi.Data;
using FluentResults;

namespace cinemaAPI.Services
{
    public class EnderecoService
    {
        private AppDbContext _context;
        private IMapper _mapper;
        public EnderecoService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ReadEnderecoDto AdicionaEndereco(CreateEnderecoDto enderecoDto)
        {
            Endereco endereco = _mapper.Map<Endereco>(enderecoDto);
            _context.Enderecos.Add(endereco);
            _context.SaveChanges();
            return _mapper.Map<ReadEnderecoDto>(endereco);
        }

        internal List<ReadEnderecoDto> RecuperaEnderecos(string logradouro)
        {
            List<Endereco> enderecos = _context.Enderecos.ToList();
            if(enderecos == null)
            {
                return null;
            }
            if(!string.IsNullOrEmpty(logradouro))
            {
                var query = from endereco in enderecos
                    where endereco.Logradouro.Equals(logradouro)
                    select endereco;

                enderecos = query.ToList();
            }

            return _mapper.Map<List<ReadEnderecoDto>>(enderecos);
        }

        public ReadEnderecoDto RecuperaEnderecosPorId(int id)
        {
            Endereco endereco = _context.Enderecos.FirstOrDefault(endereco => endereco.Id == id);
            if(endereco != null)
            {
                ReadEnderecoDto enderecoDto = _mapper.Map<ReadEnderecoDto>(endereco);
                return enderecoDto;
            }
            return null;
        }

        public Result AtualizaEndereco(int id, UpdateEnderecoDto enderecoDto)
        {
            Endereco endereco = _context.Enderecos.FirstOrDefault(endereco => endereco.Id == id);
            if(endereco == null)
            {
                return Result.Fail("Não encontrou o endereco!!");
            }
            _mapper.Map(enderecoDto, endereco);
            _context.SaveChanges();
            return Result.Ok();
        }

        public Result DeletaEndereco(int id)
        {
            Endereco endereco = _context.Enderecos.FirstOrDefault(endereco => endereco.Id == id);
            if (endereco == null)
            {
                return Result.Fail("Não encontrou o endereço!!");
            }
            _context.Remove(endereco);
            _context.SaveChanges();
            return Result.Ok();
        }
    }
}
