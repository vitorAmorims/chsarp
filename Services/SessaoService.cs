using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using cinemaAPI.Data.Dtos.Sessao;
using cinemaAPI.Models;
using FilmesApi.Data;
using FluentResults;

namespace cinemaAPI.Services
{
    public class SessaoService
    {
        private AppDbContext _context;
        private IMapper _mapper;
        public SessaoService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ReadSessaoDto CadastrarSessao(CreateSessaoDto sessaoDto)
        {
            Sessao sessao = _mapper.Map<Sessao>(sessaoDto);
            _context.Sessoes.Add(sessao);
            _context.SaveChanges();
            return _mapper.Map<ReadSessaoDto>(sessao);
        }

        public ReadSessaoDto RecuperarSessaoPorId(int id)
        {
            var sessao = _context.Sessoes.FirstOrDefault(s => s.id == id);
            if (sessao != null)
            {
                ReadSessaoDto readSessaoDto = _mapper.Map<ReadSessaoDto>(sessao);
                return readSessaoDto;
            }
            return null;
        }

        public List<ReadSessaoDto> ExibirSessoes()
        {
            List<Sessao> lista = _context.Sessoes.ToList();
            if(lista != null)
            {
                return _mapper.Map<List<ReadSessaoDto>>(lista);
            }
            return null;
        }

        public Result DeletarSessao(int id)
        {
            var sessao = _context.Sessoes.FirstOrDefault(s => s.id == id);
            if (sessao != null)
            {
                _context.Remove(sessao);
                return Result.Ok();
            }
            return Result.Fail("Não encontrou a sessão!!");
        }
    }
}
