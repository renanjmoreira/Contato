using MediatR;

namespace ContatoAPI.Application.Commands
{
    public class RemoverPessoaCommand : IRequest
    {
        public int Id { get; set; }
    }
}
