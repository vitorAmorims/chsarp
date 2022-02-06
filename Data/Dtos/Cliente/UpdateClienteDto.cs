using System.ComponentModel.DataAnnotations;

namespace cinemaAPI.Data.Dtos.Cliente
{
    public class UpdateClienteDto
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string Nome { get; set; }
    }
}
