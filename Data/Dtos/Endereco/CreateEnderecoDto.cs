using System.ComponentModel.DataAnnotations;

namespace cinemaAPI.Data.Dtos.Endereco
{
    public class CreateEnderecoDto
    {
        [Required]
        public string Logradouro { get; set; }
        [Required]
        public string Bairro { get; set; }
        public int Numero { get; set; }
    }
}
