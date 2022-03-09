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

        public int GetLv()
        {
            return this.Lv;
        }

        public void SetLv(int value)
        {
            this.Lv -= value;
        }
        public int GetHp()
        {
            return this.HP;
        }

        public void SetHp(int value)
        {
            this.HP -= value;
        }

        public int GetMp()
        {
            return this.MP;
        }

        public void SetMp(int value)
        {
            this.MP -= value;
        }

        public override string ToString()
        {
            return $"id:{Id}\t ({Lv}\t {HP}\t {MP}\t";
        }

    }
}
