using System;
using FluentValidation;
using FluentValidation.Results;

namespace Ex1
{
    public class Customer : AbstractValidator<Customer>
    {
        public Customer(int id, string surname, string forename, string email, decimal discount)
        {
            this.Id = id;
            this.Surname = surname;
            this.Forename = forename;
            this.Email = email;
            this.Discount = discount;
        }
        public int Id { get; set; }
        public string Surname { get; set; }
        public string Forename { get; set; }
        public string Email { get; set; }

        public decimal Discount { get; set; }

        public Address Address { get; set; }

        public ValidationResult ValidationResult { get; private set; }
    }
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(c => c.Surname)
                .NotEmpty().WithMessage("Name can't be empty.")
                .MaximumLength(30).WithMessage("Name length must be maximum 30.");

            RuleFor(c => c.Email)
                .NotEmpty().WithMessage("E-mail can't be empty.")
                .Matches(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$").WithMessage("E-mail is not in valid format.")
                .MaximumLength(20).WithMessage("E-mail length must be maximum 20.");

            RuleFor(customer => customer.Address).SetValidator(new AddressValidator());
        }
    }
}
