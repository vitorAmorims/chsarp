using System;
using Xunit;
using FluentValidation;
using FluentValidation.Results;
using Faker;


namespace Ex1.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void DeveRetornarMensagensNomeMaiorQue30Caracteres()
        {
            Customer cliente = new Customer(1, "Vitoraaaasaadsdjkshhskhdhsoiduiosudosjsiuyusydosuiysfif", Faker.Name.First(), Faker.Internet.Email(), 1.0m);
            Address endereco = new Address();

            CustomerValidator validator = new CustomerValidator();

            ValidationResult results = validator.Validate(cliente);

            var esperado = "Name length must be maximum 30.";

            if (!results.IsValid)
            {
                foreach (var failure in results.Errors)
                {
                    Console.WriteLine("Property " + failure.PropertyName + " failed validation. Error was: " + failure.ErrorMessage);
                    Assert.Equal(esperado, failure.ErrorMessage);
                }
            }

            Assert.False(results.IsValid);
        }

        [Fact]
        public void DeveRetornarErroComAoPassarNomeVazio()
        {
            Customer cliente = new Customer(1, "", "Amorim", "vitor@teste.com.br", 1.0m);
            Address endereco = new Address();

            CustomerValidator validator = new CustomerValidator();

            ValidationResult results = validator.Validate(cliente);

            var esperado = "Name can't be empty.";

            if (!results.IsValid)
            {
                foreach (var failure in results.Errors)
                {
                    Console.WriteLine("Property " + failure.PropertyName + " failed validation. Error was: " + failure.ErrorMessage);
                    Assert.Equal(esperado, failure.ErrorMessage);
                }
            }

            Assert.False(results.IsValid);
        }

        [Fact]
        public void DeveRetornarErroComEmailVazio()
        {
            Customer cliente = new Customer(1, "Vitor", "Amorim", null, 1.0m);
            Address endereco = new Address();

            CustomerValidator validator = new CustomerValidator();

            ValidationResult results = validator.Validate(cliente);

            var esperado = "E-mail can't be empty.";


            if (!results.IsValid)
            {
                foreach (var failure in results.Errors)
                {
                    Console.WriteLine("Property " + failure.PropertyName + " failed validation. Error was: " + failure.ErrorMessage);
                    Assert.Equal(esperado, failure.ErrorMessage);
                }
            }
        }

        [Fact]
        public void DeveRetornarMessagemDeErroComEmailInvalido()
        {
            Customer cliente = new Customer(1, "Vitor", "Amorim", "vitor", 1.0m);
            Address endereco = new Address();

            CustomerValidator validator = new CustomerValidator();
            ValidationResult results = validator.Validate(cliente);

            var esperado = "E-mail is not in valid format.";

            if (!results.IsValid)
            {
                foreach (var failure in results.Errors)
                {
                    Console.WriteLine("Property " + failure.PropertyName + " failed validation. Error was: " + failure.ErrorMessage);
                    Assert.Equal(esperado, failure.ErrorMessage);
                }
            }
            Assert.False(results.IsValid);
        }

        [Fact]
        public void DeveRetornarMensagemDeErroComEmailMaiorQueVinteCaracteres()
        {
            Customer cliente = new Customer(1, "Vitor", "Amorim", "vitor@bemvindadisneylandiameuamigo.com.br", 1.0m);
            Address endereco = new Address();

            CustomerValidator validator = new CustomerValidator();
            ValidationResult results = validator.Validate(cliente);

            var esperado = "E-mail length must be maximum 20.";

            if (!results.IsValid)
            {
                foreach (var failure in results.Errors)
                {
                    Console.WriteLine("Property " + failure.PropertyName + " failed validation. Error was: " + failure.ErrorMessage);
                    Assert.Equal(esperado, failure.ErrorMessage);
                }
            }
            Assert.False(results.IsValid);
        }

        [Fact]
        public void DeveRetorMensagemDeErroComEnderecoPostalVazio()
        {
            Address endereco = new Address();

            AddressValidator validator = new AddressValidator();
            var results = validator.Validate(endereco);

            var esperado = "PostalCode vazio.";

            if (!results.IsValid)
            {
                foreach (var failure in results.Errors)
                {
                    Console.WriteLine("Property " + failure.PropertyName + " failed validation. Error was: " + failure.ErrorMessage);
                    Assert.Equal(esperado, failure.ErrorMessage);
                }
            }
            Assert.False(results.IsValid);
        }
    }
}
