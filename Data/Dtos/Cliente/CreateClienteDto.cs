using System.ComponentModel.DataAnnotations;
namespace cinemaAPI.Data.Dtos.Cliente
{
    public class CreateClienteDto
    {
        public string Nome { get; set; }
        public int FilmeId { get; set; }
    }
}
