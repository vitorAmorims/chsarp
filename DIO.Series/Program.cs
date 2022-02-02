using System;
using DIO.Series.Enum;
using DIO.Series.Models;
using FluentValidation.Results;

namespace DIO.Series
{
    class Program
    {
        static void Main(string[] args)
        {
            Serie serie = new Serie(1, Enum.Genero.Acao,"Titulo teste","teste de descrição", 2000);
            SerieValidator validator = new SerieValidator();
            ValidationResult results = validator.Validate(serie);
            Console.WriteLine($"validação: {results.IsValid}");
            if (!results.IsValid)
            {
                foreach (var failure in results.Errors)
                {
                    Console.WriteLine("Property " + failure.PropertyName + " failed validation. Error was: " + failure.ErrorMessage);
                }
            }

        }
    }
}
