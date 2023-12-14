using Backend.Models;
using FluentValidation;

namespace Backend.Validators
{
    public class UsersValidator : AbstractValidator<Users>
    {
        public UsersValidator()
        {
            RuleFor(x => x.first_name).NotNull();
            RuleFor(x => x.last_name).NotNull();
            RuleFor(x=> x.password).NotNull();
            RuleFor(x => x.email).EmailAddress();
        }
    }
}
