using System;
using FilmesAPI.Models;

namespace cinemaAPI.Data.Dtos.Sessao
{
    public class ReadSessaoDto
    {
        public int id { get; set; }
        public virtual Cinema Cinema { get; set; }
        public virtual Filme Filme { get; set; }
        public DateTime HorarioDeEncerramento { get; set; }
        public DateTime HorarioDeInicio { get; set; }
    }
}
