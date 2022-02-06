using System;
using System.ComponentModel.DataAnnotations;
using FilmesAPI.Models;

namespace cinemaAPI.Models
{
    public class Sessao
    {
        [Key]
        [Required]
        public int id { get; set; }
        public virtual Cinema Cinema { get; set; }
        public virtual Filme Filme { get; set; }
        public int CinemaId { get; set; }
        public int FilmeId { get; set; }
        public DateTime HorarioDeEncerramento { get; set; }
        
    }
}
