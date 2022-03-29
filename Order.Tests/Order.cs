using System;
using Order.Model;
using Xunit;

namespace Order.Tests
{
    public class Order
    {
        [Fact(DisplayName = "Order test")]
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
            var soma = 25;
        
            //Assert
            Assert.Equal(total, soma);
        }
    }
}
