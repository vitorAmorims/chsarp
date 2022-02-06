using System.ComponentModel.DataAnnotations;

namespace cinemaAPI.Data.Dtos.Gerente
{
    public class UpdateGerenteDto
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string Nome { get; set; }

    }
}
