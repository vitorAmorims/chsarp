using System;
using Xunit;
using Xunit.Abstractions;
using DIO.Series.Enum;
using DIO.Series.Models;
using FluentValidation.Results;
using System.Linq;

namespace DIO.Series.Test
{
    public class SerieTest
    {
        private readonly ITestOutputHelper output;

        public SerieTest(ITestOutputHelper output)
    {
        this.output = output;
    }

        [Fact(DisplayName = "Deve retornar a mensagem para propriedade Titulo vazio.")]
        public void DeveRetornarMensagemDeErroParaTituloVazio()
        {
            //arrange
            Serie serie = new Serie(1, DIO.Series.Enum.Genero.Acao, "", "Retorno da Fênix.", 2000);
            SerieValidator validator = new SerieValidator();
            ValidationResult results = validator.Validate(serie);
            var esperado = "Titulo can't be empty.";

            //act
            if (!results.IsValid)
            {
                foreach (var failure in results.Errors)
                {
                    output.WriteLine("Property " + failure.PropertyName + " failed validation. Error was: " + failure.ErrorMessage);
                    //assert
                    Assert.Equal(esperado, failure.ErrorMessage);
                }
            }

            //assert
            Assert.False(results.IsValid);
        }

        [Fact(DisplayName = "Deve retornar a mensagem para propriedade Titulo com mais de 50 caracteres")]
        public void DeveRetornarMensagemDeErroParaTituloMais50Caracteres()
        {
            //arrange
            Serie serie = new Serie(1, DIO.Series.Enum.Genero.Acao, "X-menaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "Retorno da Fênix.", 2000);
            SerieValidator validator = new SerieValidator();
            ValidationResult results = validator.Validate(serie);
            var esperado = "Name length must be maximum 50 character.";

            //act
            if (!results.IsValid)
            {
                foreach (var failure in results.Errors)
                {
                    output.WriteLine("Property " + failure.PropertyName + " failed validation. Error was: " + failure.ErrorMessage);
                    //assert
                    Assert.Equal(esperado, failure.ErrorMessage);
                }
            }

            //assert
            Assert.False(results.IsValid);
        }

        [Fact(DisplayName = "Não deve retornar mensagem de erro de validação para da propriedade Titulo")]
        public void DeveRetornarTrueNasValidacoesParaPropriedadeTitulo()
        {
            //arrange
            Serie serie = new Serie(1, DIO.Series.Enum.Genero.Acao, "X-men", "Retorno da Fênix.", 2000);
            SerieValidator validator = new SerieValidator();
            ValidationResult results = validator.Validate(serie);
            bool esperado = true;

            //act

            //assert
            Assert.True(results.IsValid);
            Assert.Equal(esperado, results.IsValid);
        }

        [Fact(DisplayName = "Deve retornar 3 mensagens de erro de validação para objeto serie")]
        public void DeveRetornarTresMensagensDeErroDeValidacaoParaobjetoSerie()
        {
            //Arrange
            Serie serie = new Serie(1, DIO.Series.Enum.Genero.Acao, "X-men2222222222222222222222222222222222222222222222222222222222222", "", 1800);
            SerieValidator validator = new SerieValidator();
            var esperado = 3;

            //Act
            ValidationResult results = validator.Validate(serie);

            if (!results.IsValid)
            {
                foreach (var failure in results.Errors)
                {
                    output.WriteLine("Property " + failure.PropertyName + " failed validation. Error was: " + failure.ErrorMessage);
                }
            }
            
            //Assert
            Assert.False(results.IsValid);
            Assert.Equal(esperado, results.Errors.Count());
        }

        [Fact(DisplayName = "Deve retornar a mensagem para propriedade Titulo vazio.")]
        public void DeveRetornarMensagemDeErroParaDescricaoVazio()
        {
            //arrange
            Serie serie = new Serie(1, DIO.Series.Enum.Genero.Acao, "X-men", "", 2000);
            SerieValidator validator = new SerieValidator();
            ValidationResult results = validator.Validate(serie);
            var esperado = "Descricao can't be empty.";

            //act
            if (!results.IsValid)
            {
                foreach (var failure in results.Errors)
                {
                    output.WriteLine("Property " + failure.PropertyName + " failed validation. Error was: " + failure.ErrorMessage);
                    //assert
                    Assert.Equal(esperado, failure.ErrorMessage);
                }
            }

            //assert
            Assert.False(results.IsValid);
        }

        [Fact(DisplayName = "Deve retornar a mensagem para propriedade Descricao com mais de 50 caracteres")]
        public void DeveRetornarMensagemDeErroParaDescricaoMais50Caracteres()
        {
            //arrange
            Serie serie = new Serie(1, DIO.Series.Enum.Genero.Acao, "X-men", "Retorno da Fênixaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa.", 2000);
            SerieValidator validator = new SerieValidator();
            ValidationResult results = validator.Validate(serie);
            var esperado = "Descricao length must be maximum 50.";

            //act
            if (!results.IsValid)
            {
                foreach (var failure in results.Errors)
                {
                    output.WriteLine("Property " + failure.PropertyName + " failed validation. Error was: " + failure.ErrorMessage);
                    //assert
                    Assert.Equal(esperado, failure.ErrorMessage);
                }
            }

            //assert
            Assert.False(results.IsValid);
        }

        [Fact(DisplayName = "O ano deve ser superior a 1900")]
        public void DeveRetornarMensagemDeErroParaAnoInferior1900()
        {
            //arrange
            Serie serie = new Serie(1, DIO.Series.Enum.Genero.Acao, "X-men", "Retorno da Fênix.", 1800);
            SerieValidator validator = new SerieValidator();
            ValidationResult results = validator.Validate(serie);
            var esperado = "O ano da serie deve ser maior ou superior 1900";

            //act
            if (!results.IsValid)
            {
                foreach (var failure in results.Errors)
                {
                    output.WriteLine("Property " + failure.PropertyName + " failed validation. Error was: " + failure.ErrorMessage);
                    //assert
                    Assert.Equal(esperado, failure.ErrorMessage);
                }
            }

            //assert
            Assert.False(results.IsValid);
        }
    }
}
