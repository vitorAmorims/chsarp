using AutoMapper;
using cinemaAPI.Data.Dtos.Endereco;
using cinemaAPI.Models;

namespace cinemaAPI.Profiles
{
    public class EnderecoProfile : Profile
    {
        public EnderecoProfile()
        {
            CreateMap<CreateEnderecoDto, Endereco>();
            CreateMap<Endereco, ReadEnderecoDto>();
            CreateMap<UpdateEnderecoDto, Endereco>();
        }

    }
}
