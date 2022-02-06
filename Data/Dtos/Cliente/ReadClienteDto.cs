using cinemaAPI.Models;
using FilmesAPI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace cinemaAPI.Data.Dtos.Cliente
{
    public class ReadClienteDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public Filme Filme { get; set; }
    }
}
