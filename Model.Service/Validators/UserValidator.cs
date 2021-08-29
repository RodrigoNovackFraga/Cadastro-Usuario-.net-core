using FluentValidation;
using Model.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Service.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Por favor insira o nome.")
                .NotNull().WithMessage("Por favor insira o nome.");

            RuleFor(c => c.Email)
                .NotEmpty().WithMessage("Por favor insira o email.")
                .NotNull().WithMessage("Por favor insira o email.")
                .EmailAddress().WithMessage("E-mail inválido");
        }
    }
}
