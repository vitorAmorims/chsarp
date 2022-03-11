using System;
using jogoRPG.src.Enum;
using FluentValidation;
using jogoRPG.src.Interfaces;

namespace jogoRPG.src.Models
{
    public class Wedge: EntidadeBase, IBase, ICombate
    {
        public Wedge(string name, int lv, int hP, int mP) : base(name, lv, hP, mP)
        {
            Genre = Genero.Ninja;
            this.Setname(name);
            this.SetLv(lv);
            this.SetHp(hP);
            this.SetMp(mP);
        }

        protected Genero Genre { get; private set; }

        public void Andar()
        {
            throw new NotImplementedException();
        }

        public void Atacar()
        {
            throw new NotImplementedException();
        }

        public void Comer()
        {
            throw new NotImplementedException();
        }

        public void Defender()
        {
            throw new NotImplementedException();
        }

        public void Falar()
        {
            throw new NotImplementedException();
        }

        public Genero GetGenre()
        {
            return this.Genre;
        }

        override public void Info()
        {
            Console.WriteLine($"Considerado guerreiro de classe A do Genero: {GetGenre()} Nome: {this.GetName()} " +
            $"Lv: {this.GetLv()} HP: {this.GetHp()} MP: {this.GetMp()}");
        }

        public void Pular()
        {
            throw new NotImplementedException();
        }

        public void VireDireita()
        {
            throw new NotImplementedException();
        }

        public void VireEsquerda()
        {
            throw new NotImplementedException();
        }
    }
    public class WedgeValidator: AbstractValidator<Wedge>
    {
        public WedgeValidator()
        {
            RuleFor(a => a.GetName())
            .MaximumLength(5).WithMessage("O nome deve possuir no máximo 5 caracteres");

            RuleFor(a => a.GetLv())
            .Equal(42).WithMessage("O valor de Lv deve ser 42");

            RuleFor(a => a.GetMp())
            .Equal(89).WithMessage("O valor de MP deve ser 89");

            RuleFor(a => a.GetHp())
            .InclusiveBetween(292, 574).WithMessage("O valor HP não deve estar entre 469-749");
        }
    }
}
