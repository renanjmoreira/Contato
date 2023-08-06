using ContatoAPI.Domain.Enums;
using ContatoAPI.Domain.Objects;
using FluentValidation;

namespace ContatoAPI.Domain.Models
{
    public class Contato : Entidade
    {
        public TipoContato TipoContato { get; private set; }
        public string Valor { get; private set; }

        public Contato(TipoContato tipoContato, string valor)
        {
            TipoContato = tipoContato;
            Valor = valor;
        }
    }

    public class ContatoValidator : AbstractValidator<Contato>
    {
        public ContatoValidator()
        {
            RuleFor(contato => contato.TipoContato).NotEmpty().WithMessage("O tipo de contato é obrigatório.");
            RuleFor(contato => contato.Valor).NotEmpty().WithMessage("O valor do contato é obrigatório.");
        }
    }
}
