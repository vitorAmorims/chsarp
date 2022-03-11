using System;
using jogoRPG.src.Enum;
using FluentValidation;
using jogoRPG.src.Interfaces;

namespace jogoRPG.src.Models
{
    public class Topapa : EntidadeBase, IBase, ICombate
    {
        public Topapa(string name, int lv, int hP, int mP) : base(name, lv, hP, mP)
        {
            this.Genre = Genero.BlackWizard;
            this.SetLv(lv);
            this.SetHp(hP);
            this.SetMp(mP);
            this.Setname(name);
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
            Console.WriteLine("O magico das Trevas: " + this.GetName());
            Console.WriteLine($"Genero: {this.GetGenre()} " +
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
    public class TopapaValidator : AbstractValidator<Topapa>
    {
        public TopapaValidator()
        {
            RuleFor(a => a.GetName())
            .MaximumLength(30).WithMessage("O nome deve possuir no máximo 30 caracteres");

            RuleFor(a => a.GetLv())
            .Equal(42).WithMessage("O valor de Lv deve ser 42");

            RuleFor(a => a.GetMp())
            .InclusiveBetween(611, 641).WithMessage("O valor HP deve estar entre 611-641");

            RuleFor(a => a.GetHp())
            .InclusiveBetween(106, 385).WithMessage("O valor HP deve estar entre 106-385");
        }

    }
}
