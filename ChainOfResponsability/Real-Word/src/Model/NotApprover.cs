using System;

namespace Real_Word.src.Model
{
    public class NotApprover : Approver
    {
        public override void ProcessRequest(Purchase purchase)
        {
            if (purchase.Amount >= 100000.0)
            {
                Console.WriteLine("{0} not approved request# {1}",
                    this.GetType().Name, purchase.Number);
            }
            
        }
    }
}
