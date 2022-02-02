using System;
using DIO.Series.Enum;
using FluentValidation;
using FluentValidation.Results;


namespace DIO.Series.Models
{
    public class Serie : Entidadebase
    {
        public Serie(int id, Genero genero, string titulo, string descricao, int ano)
        {
            this.Id = id;
            this.Genero = genero;
            this.Titulo = titulo;
            this.Descricao = descricao;
            this.Ano = ano;
            this.Excluido = false;

        }
        public Genero Genero { get; private set; }
        public string Titulo { get; private set; }
        public string Descricao { get; private set; }
        public int Ano { get; private set; }
        private bool Excluido { get; set; }
        public ValidationResult ValidationResult { get; private set; }

        public override string ToString()
        {
            string retorno = "";
            retorno += "Gênero: \t" + this.Genero + Environment.NewLine;
            retorno += "Titulo: \t" + this.Titulo + Environment.NewLine;
            retorno += "Descrição:     \t" + this.Descricao + Environment.NewLine;
            retorno += "Ano de Início: \t" + this.Ano + Environment.NewLine;
            retorno += "Excluido: \t" + this.Excluido;
            return retorno;
        }
        public string retornaTitulo()
        {
            return this.Titulo;
        }

        public int retornaId()
        {
            return this.Id;
        }
        public bool retornaExcluido()
        {
            return this.Excluido;
        }
        public void Excluir()
        {
            this.Excluido = true;
        }
    }
    public class SerieValidator : AbstractValidator<Serie>
    {
        public SerieValidator()
        {
            RuleFor(s => s.retornaTitulo())
                .NotEmpty().WithMessage("Titulo can't be empty.")
                .MaximumLength(50).WithMessage("Titulo length must be maximum 50 character.");

            RuleFor(s => s.Descricao)
                .NotEmpty().WithMessage("Descricao can't be empty.")
                .MaximumLength(50).WithMessage("Descricao length must be maximum 50.");

            RuleFor(s => s.Ano)
                .GreaterThanOrEqualTo(1900).WithMessage("O ano da serie deve ser maior ou superior 1900");
        }
    }
}
