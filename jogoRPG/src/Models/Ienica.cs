using jogoRPG.src.Enum;
using FluentValidation;
using System;

namespace jogoRPG.src.Models
{
    public class Ienica:EntidadeBase
    {
        public Ienica(string name, int lv, int hP, int mP) : base(name, lv, hP, mP)
        {
            this.Genre = Genero.WhiteWizard;
            this.Setname(name);
            this.SetLv(lv);
            this.SetHp(hP);
            this.SetMp(mP);
        }

        public Genero Genre { get; private set; }

        public Genero GetGenero()
        {
            return this.Genre;
        }

        public override void Info()
        {
            Console.WriteLine($"A bruxa de mágia branca, seu nome: {this.GetName()}");
            Console.WriteLine($"Genero: {this.GetGenero()} " +
            $"Lv: {this.GetLv()} HP: {this.GetHp()} MP: {this.GetMp()}");
        }
    }
    public class IenicaValidator: AbstractValidator<Ienica>
    {
        public IenicaValidator()
        {
            RuleFor(a => a.GetName())
            .MaximumLength(20).WithMessage("O nome deve possuir no máximo 20 caracteres");

            RuleFor(a => a.GetLv())
            .Equal(42).WithMessage("O valor de Lv deve ser 42");

            RuleFor(a => a.GetMp())
            .InclusiveBetween(474, 482).WithMessage("O valor de MP deve ser entre 474 e 482");

            RuleFor(a => a.GetHp())
            .InclusiveBetween(325, 601).WithMessage("O valor HP não deve estar entre 325-601");
        }
    }
}
