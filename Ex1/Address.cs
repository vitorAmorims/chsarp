using FluentValidation;
using FluentValidation.Results;

namespace Ex1
{
    public class Address
    {
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string Town { get; set; }
        public string County { get; set; }
        public string Postcode { get; set; }
    }
    public class AddressValidator : AbstractValidator<Address>
    {
        public AddressValidator()
        {
            RuleFor(address => address.Postcode).NotNull().WithMessage("PostalCode vazio.");
        }
    }
}
