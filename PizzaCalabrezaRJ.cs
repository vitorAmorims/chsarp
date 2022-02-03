namespace FactoryMethod
{
    public class PizzaCalabrezaRJ : Pizza
    {
        public PizzaCalabrezaRJ()
        {
            Nome = "Pizza de Calabreza Carioca.";
            Massa = "Massa fina crocante carioca.";
            Molho = "Molho de tomate apimentado.";
            ingredientes.Add("Calabreza cortadas em rodelas.");
            ingredientes.Add("Azeitonas verdes.");
            ingredientes.Add("Ovos cozinhos em fatia.");
            ingredientes.Add("Cebola rocha fatiada.");
        }
    }
}
