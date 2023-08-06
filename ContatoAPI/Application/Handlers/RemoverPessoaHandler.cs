using ContatoAPI.Application.Commands;
using ContatoAPI.Infrastructure;
using FluentValidation;
using MediatR;

namespace ContatoAPI.Application.Handlers
{
    public class RemoverPessoaHandler : IRequestHandler<RemoverPessoaCommand>
    {
        private readonly ContextoBd _context;

        public RemoverPessoaHandler(ContextoBd context)
        {
            _context = context;
        }

        public async Task Handle(RemoverPessoaCommand request, CancellationToken cancellationToken)
        {
            var pessoa = await _context.Pessoas.FindAsync(request.Id);

            if (pessoa != null)
            {
                _context.Pessoas.Remove(pessoa);
                await _context.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
