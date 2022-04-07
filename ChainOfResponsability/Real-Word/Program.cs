using System;
using Real_Word.src.Model;

namespace Real_Word
{
    class Program
    {
        static void Main()
        {
    
            Chain chain = new Chain();
            
            Purchase p = new Purchase(2034, 350.00, "Supplies");
            chain.ChainOfResponsability(p);

            p = new Purchase(2035, 32590.10, "Project X");
            chain.ChainOfResponsability(p);

            p = new Purchase(2036, 122100.00, "Project Y");
            chain.ChainOfResponsability(p);

            // Wait for user
            Console.ReadKey();

        }
    }
}
