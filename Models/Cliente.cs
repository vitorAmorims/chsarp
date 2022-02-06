using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using FilmesAPI.Models;

namespace cinemaAPI.Models
{
    public class Cliente
    {
        [Key]
         [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo de nome é obrigatório")]
        public string Nome { get; set; }
        
        public virtual Filme Filme { get; set; }
        public int FilmeId { get; set; }
    }
}
