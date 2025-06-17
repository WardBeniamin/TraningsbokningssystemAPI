using FluentValidation;
using TraningsbokningssystemAPI.Models;

namespace TraningsbokningssystemAPI.Validators
{
    public class KundValidator : AbstractValidator<Kund>
    {
        public KundValidator()
        {
            RuleFor(k => k.Namn)
                .NotEmpty().WithMessage("Namn får inte vara tomt")
                .MinimumLength(2).WithMessage("Namn måste vara minst 2 tecken");
        }
    }
}
