using System;
using Order.Model;
using Xunit;

namespace Order.Tests
{
    public class Order
    {
        [Fact(DisplayName = "Deve calcular o total da venda")]
        public void DeveCalcularASomaDasVendas()
        {
            //Arrange
            var vendas = new Venda();
            vendas.lista.Add(new LeiteA("Parmalat", 5));
            vendas.lista.Add(new CartelaDeOvos("Granjão", 10));
            vendas.lista.Add(new ChocolateEmPo("Todynho", 15));
            vendas.lista.Add(new DetergenteLiquido("Minuamo", 5));
            vendas.lista.Add(new Agua("Cristal", 2));
            
            //Action
            var total = vendas.getSubTotal();
            var soma = 37;
        
            //Assert
            Assert.Equal(total, soma);
        }

        [Fact(DisplayName = "Deve calcular o total de impostos")]
        public void DeveCalcularOTotaldeImpostos()
        {
            //Arrange
            var vendas = new Venda();
            vendas.lista.Add(new LeiteA("Parmalat", 5)); //0.1 -> 0.5
            vendas.lista.Add(new CartelaDeOvos("Granjão", 10)); //0.2 -> 2
            vendas.lista.Add(new ChocolateEmPo("Todynho", 15)); //0.3 -> 4.5
            vendas.lista.Add(new DetergenteLiquido("Minuamo", 5)); //0.5 -> 2.5
            vendas.lista.Add(new Agua("Cristal", 2));
            
            
            //Action
            var total = vendas.getTaxes(new DateTime(2022,01,30));
            var soma = 9.5;
        
            //Assert
            Assert.Equal(total, soma);
        }

        [Fact(DisplayName = "Deve calcular o total de impostos em Janeiro")]
        public void DeveCalcularOTotaldeImpostosEmMarco()
        {
            //Arrange
            var vendas = new Venda();
            vendas.lista.Add(new LeiteA("Parmalat", 5)); //0.1 -> 0.5
            vendas.lista.Add(new CartelaDeOvos("Granjão", 10)); //0.2 -> 2
            vendas.lista.Add(new ChocolateEmPo("Todynho", 15)); //0.3 -> 4.5
            vendas.lista.Add(new DetergenteLiquido("Minuamo", 5));
            vendas.lista.Add(new Agua("Cristal", 2));
            
            
            //Action
            var total = vendas.getTaxes(new DateTime(2022,03,30));
            var soma = 7.0;
        
            //Assert
            Assert.Equal(total, soma);
        }

        [Fact(DisplayName = "Deve calcular o total da compra mais o total de impostos.")]
        public void DeveCalcularOTotalGeral()
        {
            //Arrange
            var vendas = new Venda();
            vendas.lista.Add(new LeiteA("Parmalat", 5)); //0.1 -> 0.5
            vendas.lista.Add(new CartelaDeOvos("Granjão", 10)); //0.2 -> 2
            vendas.lista.Add(new ChocolateEmPo("Todynho", 15)); //0.3 -> 4.5
            vendas.lista.Add(new DetergenteLiquido("Minuamo", 5)); //0.5 -> 2.5
            vendas.lista.Add(new Agua("Cristal", 2));
            
            //Action
            var total = vendas.getTotal(new DateTime(2022,01,30));
            var soma = 46.50;
        
            //Assert
            Assert.Equal(total, soma);
        }
    }
}
