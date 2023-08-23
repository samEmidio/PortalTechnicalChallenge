using FluentValidation;
using PortalTechnicalChallenge.Application.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/// <summary>
/// fluent validation para criacao de usuario
/// </summary>

namespace PortalTechnicalChallenge.Application.Validation.User
{
    public class CreateUserValidation : AbstractValidator<CreateUserViewModel>
    {
        public CreateUserValidation()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("O nome do usuario não pode estar vazio");

            RuleFor(x => x.LastName).NotEmpty().WithMessage("O sobrenome do usuario não pode estar vazio");

            RuleFor(x => x.Email).NotEmpty().WithMessage("O Email é necessario")
                     .EmailAddress().WithMessage("Um Email valido é necessario");

        }
    }
}
