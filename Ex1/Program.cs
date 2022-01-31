using System;
using FluentValidation;
using FluentValidation.Results;


namespace Ex1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Customer cliente = new Customer(1, "Vitoraaaasaadsdjkshhskhdhsoiduiosudosjsiuyusydosuiysfif", "Amorim", "vitor", 1.0m);
            Address endereco = new Address();
            // endereco.Postcode = "999999999";

            cliente.Address = endereco;

            CustomerValidator validator = new CustomerValidator();

            ValidationResult results = validator.Validate(cliente);

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
