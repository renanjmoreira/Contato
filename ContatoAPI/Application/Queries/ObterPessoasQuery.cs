using ContatoAPI.Domain.Models;
using MediatR;

namespace ContatoAPI.Application.Queries
{
    public class ObterPessoasQuery : IRequest<ICollection<Pessoa>>
    {
    }
}
