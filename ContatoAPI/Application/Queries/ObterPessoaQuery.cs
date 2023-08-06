using ContatoAPI.Domain.Models;
using MediatR;

namespace ContatoAPI.Application.Queries
{
    public class ObterPessoaQuery : IRequest<Pessoa?>
    {
        public int Id { get; set; }
    }
}
