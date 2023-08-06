using ContatoAPI.Domain.Enums;
using FluentValidation;
using MediatR;

namespace ContatoAPI.Application.Commands
{
    public class EditarPessoaCommand : IRequest
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public List<ContatoEditarPessoa> Contatos { get; set; }
    }

    public class ContatoEditarPessoa
    {
        public TipoContato TipoContato { get; set; }
        public string Valor { get; set; }
    }

    public class EditarPessoaCommandValidator : AbstractValidator<EditarPessoaCommand>
    {
        public EditarPessoaCommandValidator()
        {
            RuleFor(command => command.Nome).NotEmpty().WithMessage("O nome é obrigatório.");
            RuleForEach(pessoa => pessoa.Contatos).SetValidator(new ContatoEditarPessoaValidator());
        }
    }

    public class ContatoEditarPessoaValidator : AbstractValidator<ContatoEditarPessoa>
    {
        public ContatoEditarPessoaValidator()
        {
            RuleFor(contato => contato.TipoContato).NotEmpty().WithMessage("O tipo de contato é obrigatório.");
            RuleFor(contato => contato.Valor).NotEmpty().WithMessage("O valor do contato é obrigatório.");
        }
    }
}
