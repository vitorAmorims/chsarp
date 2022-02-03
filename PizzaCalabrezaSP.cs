namespace FactoryMethod
{
    public class PizzaCalabrezaSP : Pizza
    {
        public PizzaCalabrezaSP()
        {
            Nome = "Pizza de Calabreza Paulista.";
            Massa = "Massa fina crocante paulista.";
            Molho = "Molho de tomate italiano.";
            ingredientes.Add("Calabreza ralada");
            ingredientes.Add("Azeitonas verdes");
            ingredientes.Add("Ovos cozinhos em fatia.");
        }
    }
}
