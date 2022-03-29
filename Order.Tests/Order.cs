using System;
using Order.Model;
using Xunit;

namespace Order.Tests
{
    public class Order
    {
        [Fact(DisplayName = "Deve calcular o total da venda")]
        public void DeveRetornarASomaDasVendas()
        {
            //Arrange
            var vendas = new Venda();
            vendas.lista.Add(new Item("Leite A", "Parmalat", 5));
            vendas.lista.Add(new Item("Cartela de ovos", "Granjão", 10));
            vendas.lista.Add(new Item("Chocolate em pó", "Todynho", 15));
            vendas.lista.Add(new Item("Detergente liquido", "Minuamo", 5));
            
            //Action
            var total = vendas.getSubTotal();
            var soma = 35;
        
            //Assert
            Assert.Equal(total, soma);
        }

        [Fact(DisplayName = "Deve calcular o total de impostos")]
        public void DeveRetornarOTotaldeImpostos()
        {
            //Arrange
            var vendas = new Venda();
            vendas.lista.Add(new Item("Leite A", "Parmalat", 5)); //0.1 -> 0.5
            vendas.lista.Add(new Item("Cartela de ovos", "Granjão", 10)); //0.2 -> 2
            vendas.lista.Add(new Item("Chocolate em pó", "Todynho", 15)); //0.3 -> 4.5
            vendas.lista.Add(new Item("Detergente liquido", "Minuamo", 5)); //0.5 -> 2.5
            
            //Action
            var total = vendas.getTaxes();
            var soma = 9.5;
        
            //Assert
            Assert.Equal(total, soma);
        }
    }
}
