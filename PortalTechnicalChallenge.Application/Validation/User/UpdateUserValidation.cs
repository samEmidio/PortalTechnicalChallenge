using FluentValidation;
using PortalTechnicalChallenge.Application.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// fluent validation para update de usuario
/// </summary>

namespace PortalTechnicalChallenge.Application.Validation.User
{
    public class UpdateUserValidation : AbstractValidator<UpdateUserViewModel>
    {
        public UpdateUserValidation()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("O nome do usuario não pode estar vazio");

            RuleFor(x => x.LastName).NotEmpty().WithMessage("O sobrenome do usuario não pode estar vazio");

            RuleFor(x => x.Email).NotEmpty().WithMessage("O Email é necessario")
                     .EmailAddress().WithMessage("Um Email valido é necessario");

            RuleFor(x => x.Age).GreaterThan(0).WithMessage("A idade não pode ser igual a zero");

            RuleFor(x => x.Id).GreaterThan(0).WithMessage("O id não pode ser igual a zero");
        }
    }
}
