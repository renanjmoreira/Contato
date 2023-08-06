using ContatoAPI.Domain.Models;
using MediatR;

namespace ContatoAPI.Application.Queries
{
    public class ObterPessoasCommand : IRequest<ICollection<Pessoa>>
    {
    }
}
