using ContatoAPI.Application.Queries;
using ContatoAPI.Domain.Models;
using ContatoAPI.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ContatoAPI.Application.Handlers
{
    public class ObterPessoaHandler : IRequestHandler<ObterPessoaQuery, Pessoa?>
    {
        private readonly ContextoBd _context;

        public ObterPessoaHandler(ContextoBd context)
        {
            _context = context;
        }

        public async Task<Pessoa?> Handle(ObterPessoaQuery request, CancellationToken cancellationToken)
        {
            return await _context.Pessoas.FindAsync(request.Id, cancellationToken);
        }
    }
}
