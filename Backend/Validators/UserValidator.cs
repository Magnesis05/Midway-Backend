
using Backend.Dto;
using Backend.Models;
using FluentValidation;

namespace Backend.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x.first_name).NotEmpty();
            RuleFor(x => x.last_name).NotEmpty();
            RuleFor(x=> x.password).NotEmpty();
            RuleFor(x => x.email).EmailAddress();
        }
    }
}
