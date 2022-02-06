using AutoMapper;
using cinemaAPI.Data.Dtos.Cliente;
using cinemaAPI.Models;

namespace cinemaAPI.Profiles
{
    public class ClienteProfile: Profile
    {
        public ClienteProfile()
        {
            CreateMap<CreateClienteDto, Cliente>();
            CreateMap<Cliente, ReadClienteDto>();
            CreateMap<UpdateClienteDto, Cliente>();
        }
    }
}
