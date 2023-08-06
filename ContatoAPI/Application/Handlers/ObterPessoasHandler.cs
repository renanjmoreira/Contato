using ContatoAPI.Application.Commands;
using ContatoAPI.Application.Queries;
using ContatoAPI.Domain.Models;
using ContatoAPI.Infrastructure;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ContatoAPI.Application.Handlers
{
    public class ObterPessoasHandler : IRequestHandler<ObterPessoasCommand, ICollection<Pessoa>>
    {
        private readonly ContextoBd _context;

        public ObterPessoasHandler(ContextoBd context)
        {
            _context = context;
        }

        public async Task<ICollection<Pessoa>> Handle(ObterPessoasCommand request, CancellationToken cancellationToken)
        {
            return await _context.Pessoas.Include(x => x.Contatos).ToListAsync(cancellationToken);
        }
    }
}
