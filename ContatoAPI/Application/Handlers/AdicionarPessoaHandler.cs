using ContatoAPI.Application.Commands;
using ContatoAPI.Domain.Models;
using ContatoAPI.Infrastructure;
using FluentValidation;
using MediatR;

namespace ContatoAPI.Application.Handlers
{
    public class AdicionarPessoaHandler : IRequestHandler<AdicionarPessoaCommand>
    {
        private readonly ContextoBd _context;
        private readonly IValidator<AdicionarPessoaCommand> _validator;

        public AdicionarPessoaHandler(ContextoBd context, IValidator<AdicionarPessoaCommand> validator)
        {
            _context = context;
            _validator = validator;
        }

        public async Task Handle(AdicionarPessoaCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            var pessoa = new Pessoa(request.Nome);

            foreach (var contato in request.Contatos)
            {
                pessoa.AdicionarContato(contato.TipoContato, contato.Valor);
            }

            _context.Pessoas.Add(pessoa);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
