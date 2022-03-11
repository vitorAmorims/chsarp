using System;

namespace jogoRPG.src.Models
{
    public abstract class EntidadeBase
    {
        protected EntidadeBase(string name, int lv, int hP, int mP)
        {
            Id = Guid.NewGuid();
            this.Name = name;
            this.SetLv(lv);
            this.SetHp(hP);
            this.SetMp(mP);
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public int Lv { get; private set; }
        public int HP { get; private set; }
        public int MP { get; private set; }

        public Guid GetGuid()
        {
            return this.Id;
        }


        public string GetName()
        {
            return this.Name;
        }

        public void Setname(string name)
        {
            this.Name = name;
        }

        public int GetLv()
        {
            return this.Lv;
        }

        public void SetLv(int value)
        {
            this.Lv = value;
        }
        public int GetHp()
        {
            return this.HP;
        }

        public void SetHp(int value)
        {
            this.HP = value;
        }

        public int GetMp()
        {
            return this.MP;
        }

        public void SetMp(int value)
        {
            this.MP = value;
        }
        virtual public void Info() { }
    }
}
