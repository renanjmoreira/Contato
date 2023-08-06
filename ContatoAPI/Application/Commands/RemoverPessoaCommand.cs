using MediatR;

namespace ContatoAPI.Application.Commands
{
    public class RemoverPessoaCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
