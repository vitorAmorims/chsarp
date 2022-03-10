using System;
using jogoRPG.src.Models;
using FluentValidation.Results;

namespace jogoRPG
{
    class Program
    {
        static void Main(string[] args)
        {
            Arus guerreiroArus = new Arus("Arus", 42, 471, 72);
            guerreiroArus.Info();
            ValidarObjArus(guerreiroArus);

            Wedge guerreiroWedge = new Wedge("Wedge", 42, 471, 89);
            guerreiroWedge.Info();
            ValidarObjWedge(guerreiroWedge);

            Ienica magaIenica = new Ienica("Ienica", 42, 600, 481);
            magaIenica.Info();
            ValidarObjIenica(magaIenica);

            Topapa magoTopapa = new Topapa("Topapa", 42, 120, 620);
            magoTopapa.Info();
            ValidarObjTopapa(magoTopapa);
        }
        private static void ValidarObjTopapa(Topapa magoTopapa)
        {
            TopapaValidator validator = new TopapaValidator();
            ValidationResult results = validator.Validate(magoTopapa);
            Console.WriteLine("Objeto criado com sucesso: " + results.IsValid);
            foreach (var item in results.Errors)
            {
                Console.WriteLine(item.ToString());
            }
        }

        private static void ValidarObjIenica(Ienica magaIenica)
        {
            IenicaValidator validator = new IenicaValidator();
            ValidationResult results = validator.Validate(magaIenica);
            Console.WriteLine("Objeto criado com sucesso: " + results.IsValid);
            foreach (var item in results.Errors)
            {
                Console.WriteLine(item.ToString());
            }
        }

        private static void ValidarObjWedge(Wedge guerreiroWedge)
        {
            WedgeValidator validator = new WedgeValidator();
            ValidationResult results = validator.Validate(guerreiroWedge);
            Console.WriteLine("Objeto criado com sucesso: " + results.IsValid);
            foreach (var item in results.Errors)
            {
                Console.WriteLine(item.ToString());
            }

        }

        private static void ValidarObjArus(Arus guerreiroArus)
        {
            ArusValidator validator = new ArusValidator();
            ValidationResult results = validator.Validate(guerreiroArus);
            Console.WriteLine("Objeto criado com sucesso: " + results.IsValid);
            foreach (var item in results.Errors)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}
