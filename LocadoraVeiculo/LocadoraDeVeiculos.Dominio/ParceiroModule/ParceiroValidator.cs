using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.ParceiroModule
{
    public class ParceiroValidator : AbstractValidator<Parceiro>
    {
        public ParceiroValidator()
        {
            RuleFor(x => x.Nome)
                .NotEmpty()
                .WithMessage("O {PropertyName} do Parceiro é obrigatório, e não pode ser nulo")
                .Length(2, 20)
                .WithMessage("O {PropertyName} do Parceiro precisa ter entre {MinLength} e {MaxLength} caracteres");
        }
    }
}
