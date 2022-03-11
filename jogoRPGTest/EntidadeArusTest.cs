using FluentValidation.Results;
using jogoRPG.src.Models;
using Xunit;
using Xunit.Abstractions;

namespace jogoRPGTest
{
    public class EntidadeArusTest
    {
        private readonly ITestOutputHelper _output;

        public EntidadeArusTest(ITestOutputHelper output)
        {
            this._output = output;
        }

        [Fact(DisplayName = "Deve retornar mensagem de erro referente a validação do Nome.")]
        public void DeveRetornarMensagemDeErroNomeSuperiorDezCaracteres()
        {
            //arrange
            Arus arus = new Arus("Arus o destemido", 42, 475, 72);
            ArusValidator validator = new ArusValidator();
            ValidationResult results = validator.Validate(arus);
            var esperado = "O nome deve possuir no máximo 10 caracteres.";

            //action
            if (!results.IsValid)
            {
                foreach (var failure in results.Errors)
                {
                    //_output.WriteLine("Property " + failure.PropertyName + " failed validation. Error was: " + failure.ErrorMessage);
                    //assert
                    Assert.Equal(esperado, failure.ErrorMessage);
                }
            }

            //Assert
            Assert.False(results.IsValid);
        }
        [Fact(DisplayName = "Deve retornar mesagem de erro refernye ao valor de Lv.")]
        public void DeveRetornarMensagemDeErroValorDeLv()
        {
            //arrange
            Arus arus = new Arus("Arus", 41, 475, 72);
            ArusValidator validator = new ArusValidator();
            ValidationResult results = validator.Validate(arus);
            var esperado = "O valor de Lv deve ser 42.";

            //action
            if (!results.IsValid)
            {
                foreach (var failure in results.Errors)
                {
                    //_output.WriteLine("Property " + failure.PropertyName + " failed validation. Error was: " + failure.ErrorMessage);
                    //assert
                    Assert.Equal(esperado, failure.ErrorMessage);
                }
            }

            //Assert
            Assert.False(results.IsValid);
        }
        [Fact(DisplayName = "Deve retornar mensagem de erro referente ao valor de MP")]
        public void DeveRetornarMensagemDeErroValorDeMp()
        {
            //arrange
            Arus arus = new Arus("Arus", 42, 475, 71);
            ArusValidator validator = new ArusValidator();
            ValidationResult results = validator.Validate(arus);
            var esperado = "O valor de MP deve ser 72.";

            //action
            if (!results.IsValid)
            {
                foreach (var failure in results.Errors)
                {
                    //_output.WriteLine("Property " + failure.PropertyName + " failed validation. Error was: " + failure.ErrorMessage);
                    //assert
                    Assert.Equal(esperado, failure.ErrorMessage);
                }
            }

            //Assert
            Assert.False(results.IsValid);
        }
        
        [Fact(DisplayName = "Deve retornar mensagem de erro referente ao valor de HP inválido.")]
        public void DeveRetornarMensagemDeErroValorDeHp()
        {
            //arrange
            Arus arus = new Arus("Arus", 42, 800, 72);
            ArusValidator validator = new ArusValidator();
            ValidationResult results = validator.Validate(arus);
            var esperado = "O valor HP não deve estar entre 469-749.";

            //action
            if (!results.IsValid)
            {
                foreach (var failure in results.Errors)
                {
                    //_output.WriteLine("Property " + failure.PropertyName + " failed validation. Error was: " + failure.ErrorMessage);
                    //assert
                    Assert.Equal(esperado, failure.ErrorMessage);
                }
            }

            //Assert
            Assert.False(results.IsValid);
        }

        [Fact(DisplayName = "Deve criar o objeto e passar nas validações")]
        public void DeveRetornarTrueNaValidacaoDoObjetoCriado()
        {
            //arrange
            Arus arus = new Arus("Arus", 42, 489, 72);
            ArusValidator validator = new ArusValidator();
            ValidationResult results = validator.Validate(arus);

            //action
            if(results.IsValid)
                Assert.True(true, results.IsValid.ToString());
        }
    }
}
