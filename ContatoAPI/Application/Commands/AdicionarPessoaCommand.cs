using ContatoAPI.Domain.Enums;
using FluentValidation;
using MediatR;

namespace ContatoAPI.Application.Commands
{
    public class AdicionarPessoaCommand : IRequest
    {
        public string Nome { get; set; }
        public List<ContatoAdicionarPessoa> Contatos { get; set; }
    }

    public class ContatoAdicionarPessoa
    {
        public TipoContato TipoContato { get; set; }
        public string Valor { get; set; }
    }

    public class AdicionarPessoaCommandValidator : AbstractValidator<AdicionarPessoaCommand>
    {
        public AdicionarPessoaCommandValidator()
        {
            RuleFor(command => command.Nome).NotEmpty().WithMessage("O nome é obrigatório.");
            RuleForEach(pessoa => pessoa.Contatos).SetValidator(new ContatoAdicionarPessoaValidator());
        }
    }

    public class ContatoAdicionarPessoaValidator : AbstractValidator<ContatoAdicionarPessoa>
    {
        public ContatoAdicionarPessoaValidator()
        {
            RuleFor(contato => contato.TipoContato).NotEmpty().WithMessage("O tipo de contato é obrigatório.");
            RuleFor(contato => contato.Valor).NotEmpty().WithMessage("O valor do contato é obrigatório.");
        }
    }
}
