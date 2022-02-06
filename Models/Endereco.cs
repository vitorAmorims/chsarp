using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using FilmesAPI.Models;

namespace cinemaAPI.Models
{
    public class Endereco
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string Logradouro { get; set; }
        [Required]
        public string Bairro { get; set; }
        public int Numero { get; set; }
        [JsonIgnore]
        public virtual Cinema Cinema { get; set; }

    }
}
