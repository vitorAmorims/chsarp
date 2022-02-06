using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using cinemaAPI.Data.Dtos.Gerente;
using cinemaAPI.Models;
using FilmesApi.Data;
using FluentResults;

namespace cinemaAPI.Services
{
    public class GerenteService
    {
        private IMapper _mapper;
        private AppDbContext _context;
        public GerenteService(AppDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public ReadGerenteDto Adicionargerente(CreateGerenteDto gerenteDto)
        {
            Gerente gerente = _mapper.Map<Gerente>(gerenteDto);
            _context.Gerentes.Add(gerente);
            _context.SaveChanges();
            return _mapper.Map<ReadGerenteDto>(gerente);
        }

        public ReadGerenteDto RecuperaGerentePorId(int id)
        {
            var gerente = _context.Gerentes.FirstOrDefault(g => g.Id == id);
            if (gerente != null)
            {
                ReadGerenteDto gerenteDto = _mapper.Map<ReadGerenteDto>(gerente);
                return gerenteDto;
            }
            return null;
        }

        public List<ReadGerenteDto> ExibirGerentes(string nomeDogerente)
        {
            List<Gerente> lista = _context.Gerentes.ToList();
            if(lista == null) return null;
            if(!string.IsNullOrEmpty(nomeDogerente))
            {
                var query = from gerente in lista
                    where gerente.Nome.Equals(nomeDogerente)
                    select gerente;

                lista = query.ToList();
            }
            return _mapper.Map<List<ReadGerenteDto>>(lista);
        }

        public Result AtualizarGerente(int id, UpdateGerenteDto gerenteDto)
        {
            Gerente gerente = _context.Gerentes.FirstOrDefault(gerente => gerente.Id == id);
            if(gerente == null)
            {
                return Result.Fail("gerente não encontrado");
            }
            _mapper.Map(gerenteDto, gerente);
            _context.SaveChanges();
            return Result.Ok();
        }

        public Result DeletaGerente(int id)
        {
            Gerente gerente = _context.Gerentes.FirstOrDefault(gerente => gerente.Id == id);
            if (gerente == null)
            {
                return Result.Fail("Gerente não encontrado!");
            }
            _context.Remove(gerente);
            _context.SaveChanges();
            return Result.Ok();
        }
    }
}
