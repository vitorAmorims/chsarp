namespace jogoRPG.src.Models
{
    public abstract class EntidadeBase
    {
        protected EntidadeBase(int id, int lv, int hP, int mP)
        {
            Id = id;
            Lv = lv;
            HP = hP;
            MP = mP;
        }

        public int Id { get; private set; }
        public int Lv { get; private set; }
        public int HP { get; private set; }
        public int MP { get; private set; }                
    }
}
