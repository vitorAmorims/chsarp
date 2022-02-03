using System;

namespace FactoryMethod
{
    public class PizzaMussarelaRJ : Pizza
    {
        public PizzaMussarelaRJ()
        {
            Nome = "Pizza de Mussarela Carioca.";
            Massa = "Massa fina crocante carioca.";
            Molho = "Molho de tomate italiano.";
            ingredientes.Add("Queijo Parmesão");
            ingredientes.Add("Azeitonas verdes");
        }
    }
}
