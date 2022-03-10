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
            ArusValidator validator = new ArusValidator();
            ValidationResult results = validator.Validate(guerreiroArus);
            Console.WriteLine("Objeto criado com sucesso: "+results.IsValid);
            foreach (var item in results.Errors)
            {
                Console.WriteLine(item.ToString());
            }
            
            Wedge guerreiroWedge = new Wedge("Wedge", 42, 471, 89);
            guerreiroArus.Info();
            WedgeValidator validator1 = new WedgeValidator();
            ValidationResult results1 = validator1.Validate(guerreiroWedge);
            Console.WriteLine("Objeto criado com sucesso: "+results1.IsValid);
            foreach (var item in results1.Errors)
            {
                Console.WriteLine(item.ToString());
            }

            Ienica magaIenica = new Ienica("Ienica", 42, 600, 481);
            magaIenica.Info();
            IenicaValidator validator2 = new IenicaValidator();
            ValidationResult results2 = validator2.Validate(magaIenica);
            Console.WriteLine("Objeto criado com sucesso: "+results1.IsValid);
            foreach (var item in results2.Errors)
            {
                Console.WriteLine(item.ToString());
            }

            Topapa magoTopapa = new Topapa("Topapa", 42, 120, 620);
            magoTopapa.Info();
            TopapaValidator validator3 = new TopapaValidator();
            ValidationResult results3 = validator3.Validate(magoTopapa);
            Console.WriteLine("Objeto criado com sucesso: "+results1.IsValid);
            foreach (var item in results3.Errors)
            {
                Console.WriteLine(item.ToString());
            }

            
        }
    }
}
