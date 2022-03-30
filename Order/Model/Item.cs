using System;
using FluentValidation;
using FluentValidation.Results;

namespace Order.Model
{
    public abstract class Item: AbstractValidator<Item>
    {
        public ValidationResult ValidationResult { get; private set; }
        public Item(string produto, string marca, int preco)
        {
            this.Produto = produto;
            this.Marca = marca;
            this.Preco = preco;

        }
        public string Produto { get; set; }
        public string Marca { get; set; }
        public int Preco { get; set; }

    }
    public class ItemValidator : AbstractValidator<Item>
    {
        public ItemValidator()
        {
            RuleFor(x => x.Produto)
                .NotEmpty().WithMessage("Name product can't be empty.")
                .MaximumLength(30).WithMessage("Produto length must be maximum 30.");

            RuleFor(x => x.Marca)
                .NotEmpty().WithMessage("Marca can't be empty.")
                .MaximumLength(20).WithMessage("Marca length must be maximum 20.");

            RuleFor(x => x.Preco)
                .LessThan(2).WithMessage("Preco must be greater than or equal to 3.");
        }
    }
}
