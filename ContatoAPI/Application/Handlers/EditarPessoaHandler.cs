using ContatoAPI.Application.Commands;
using ContatoAPI.Domain.Objects;
using ContatoAPI.Infrastructure;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ContatoAPI.Application.Handlers
{
    public class EditarPessoaHandler : IRequestHandler<EditarPessoaCommand>
    {
        private readonly ContextoBd _context;
        private readonly IValidator<EditarPessoaCommand> _validator;

        public EditarPessoaHandler(ContextoBd context, IValidator<EditarPessoaCommand> validator)
        {
            _context = context;
            _validator = validator;
        }

        public async Task Handle(EditarPessoaCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            var pessoa = await _context.Pessoas.Where(x => x.Id == request.Id).Include(x => x.Contatos).FirstAsync(cancellationToken) ?? throw new Exception("Pessoa não encontrada");
            pessoa.AlterarNome(request.Nome);

            _context.PessoaContatos.RemoveRange(pessoa.Contatos);

            foreach (var contato in request.Contatos)
            {
                pessoa.AdicionarContato(contato.TipoContato, contato.Valor);
            }

            _context.Pessoas.Entry(pessoa).State = EntityState.Modified;
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
