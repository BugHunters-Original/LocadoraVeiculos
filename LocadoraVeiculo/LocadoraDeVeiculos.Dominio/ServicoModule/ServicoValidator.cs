using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.ServicoModule
{
    public class ServicoValidator : AbstractValidator<Servico>
    {
        public ServicoValidator()
        {
            RuleFor(x=>x.Nome)
                .NotEmpty()
                .WithMessage("O {PropertyName} do Serviço é obrigatório, e não pode ser nulo")
                .Length(2, 20)
                .WithMessage("O {PropertyName} do Serviço precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(x => x.Preco)
                .NotNull()
                .WithMessage("O {PropertyName} do Serviço é obrigatório, e não pode ser nulo")
                .GreaterThan(0)
                .WithMessage("O {PropertyName} do Serviço não pode ser menor que 0");

            RuleFor(x => x.CalculoTipo)
                .NotEqual(Servico.TipoCalculo.Fixo)
                .NotEqual(Servico.TipoCalculo.Diario)
                .WithMessage("O {PropertyName} do Serviço está inválido");
        }
    }
}
