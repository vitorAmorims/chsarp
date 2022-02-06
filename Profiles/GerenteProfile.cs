using System.Linq;
using AutoMapper;
using cinemaAPI.Data.Dtos.Gerente;
using cinemaAPI.Models;

namespace cinemaAPI.Profiles
{
    public class GerenteProfile : Profile
    {
        public GerenteProfile()
        {
            CreateMap<CreateGerenteDto, Gerente>();
            CreateMap<Gerente, ReadGerenteDto>()
                .ForMember(gerente => gerente.Cinemas, opts => opts
                .MapFrom(gerente => gerente.Cinemas.Select
                (c => new { c.Id, c.Nome, c.Endereco, c.EnderecoId })));
            CreateMap<UpdateGerenteDto, Gerente>();
        }
    }
}
