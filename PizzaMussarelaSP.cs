namespace FactoryMethod
{
    public class PizzaMussarelaSP : Pizza
    {
        public PizzaMussarelaSP()
        {
            Nome = "Pizza de Mussarela Paulista.";
            Massa = "Massa fina crocante paulista.";
            Molho = "Molho de tomate italiano.";
            ingredientes.Add("Queijo Parmesão");
            ingredientes.Add("Azeitonas verdes");
        }
    }
}
