using ContatoAPI.Application.Commands;
using ContatoAPI.Application.Queries;
using ContatoAPI.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ContatoAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PessoaController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PessoaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET api/pessoa
        [HttpGet]
        public async Task<IActionResult> GetPessoas()
        {
            var query = new ObterPessoasQuery();
            var pessoas = await _mediator.Send(query);
            return Ok(pessoas);
        }

        // GET api/pessoa/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPessoa(int id)
        {
            var query = new ObterPessoaQuery{ Id = id };
            var pessoa = await _mediator.Send(query);

            if (pessoa == null)
            {
                return NotFound();
            }

            return Ok(pessoa);
        }

        // POST api/pessoa
        [HttpPost]
        public async Task<IActionResult> CriarPessoa([FromBody] AdicionarPessoaCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        // PUT api/pessoa/5
        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarPessoa(int id, [FromBody] EditarPessoaCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            await _mediator.Send(command);

            return NoContent();
        }

        // DELETE api/pessoa/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoverPessoa(int id)
        {
            var command = new RemoverPessoaCommand { Id = id };
            await _mediator.Send(command);

            return NoContent();
        }
    }
}
