using System;

namespace Real_Word.src.Model
{
    public class VicePresident : Approver
    {
        public override void ProcessRequest(Purchase purchase)
        {
            if (purchase.Amount < 25000.0)
            {
                Console.WriteLine("{0} approved request# {1}",
                    this.GetType().Name, purchase.Number);
            }
            Successor.ProcessRequest(purchase);
        }
    }
}
