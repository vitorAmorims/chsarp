namespace Real_Word.src.Model
{
    public class Chain
    {
        public void ChainOfResponsability(Purchase purchase)
        {
            Approver director = new Director();
            Approver vicePresident = new VicePresident();
            Approver president = new President();
            Approver notApprover = new NotApprover();

            director.SetSuccessor(vicePresident);
            vicePresident.SetSuccessor(president);
            president.SetSuccessor(notApprover);
            director.ProcessRequest(purchase);
        }
    }
}
