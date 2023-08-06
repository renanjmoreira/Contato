using ContatoAPI.Domain.Models;
using MediatR;

namespace ContatoAPI.Application.Queries
{
    public class ObterPessoaCommand : IRequest<Pessoa?>
    {
        public Guid Id { get; set; }
    }
}
