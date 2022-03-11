using System;
using FluentValidation;
using jogoRPG.src.Enum;
using jogoRPG.src.Interfaces;

namespace jogoRPG.src.Models
{
    public class Arus : EntidadeBase, IBase, ICombate
    {
        public Arus(string name, int lv, int hP, int mP) : base(name, lv, hP, mP)
        {
            Genre = Genero.Knight;
            this.Setname(name);
            this.SetLv(lv);
            this.SetHp(hP);
            this.SetMp(mP);
        }

        public Genero Genre { get; private set; }

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
            Console.WriteLine($"Genero: {GetGenre()} Nome: {this.GetName()} " +
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
    public class ArusValidator : AbstractValidator<Arus>
    {
        public ArusValidator()
        {
            RuleFor(a => a.GetName())
            .MaximumLength(10).WithMessage("O nome deve possuir no máximo 10 caracteres");

            RuleFor(a => a.GetLv())
            .Equal(42).WithMessage("O valor de Lv deve ser 42");

            RuleFor(a => a.GetMp())
            .Equal(72).WithMessage("O valor de MP deve ser 72");

            RuleFor(a => a.GetHp())
            .InclusiveBetween(469, 749).WithMessage("O valor HP não deve estar entre 469-749");
        }
    }
}
