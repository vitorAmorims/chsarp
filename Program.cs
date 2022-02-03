using System;

namespace FactoryMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("------------------Pizzaria--------------------");
            Console.WriteLine("Informe o local (S) São Paulo ou (R) Rio de janeiro");
            var localEscolhido = Console.ReadLine().ToUpper();

            Console.WriteLine("Escolha a pizza (M) Mussarela ou (C) Calabreza");
            var pizzaEscolhida = Console.ReadLine().ToUpper();

            try
            {
                PizzaFactoryMethod pizzaria = PizzaSimpleFactory.CriarPizzaria(localEscolhido);

                var pizza = pizzaria.MontaPizza(pizzaEscolhida);

                Console.WriteLine(pizza.Preparar());
                Console.WriteLine("\nPizza concluída com sucesso!!");   
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Erro: "+ ex.Message);
            }
            Console.ReadLine();
        }
    }
}
