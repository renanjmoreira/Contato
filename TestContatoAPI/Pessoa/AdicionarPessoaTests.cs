using ContatoAPI.Application.Commands;
using ContatoAPI.Application.Handlers;
using ContatoAPI.Infrastructure;
using FluentValidation.TestHelper;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace TestContatoAPI.Pessoa
{
    public class AdicionarPessoaTests
    {
        private readonly AdicionarPessoaCommandValidator _validator;

        public AdicionarPessoaTests()
        {
            _validator = new AdicionarPessoaCommandValidator();
        }

        [Fact]
        public async Task AdicionarPessoaHandler_DeveRetornarPessoaValida()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ContextoBd>()
                .UseInMemoryDatabase(databaseName: "TestDb").Options;

            using (var dbContext = new ContextoBd(options))
            {
                var handler = new AdicionarPessoaHandler(dbContext, _validator);
                var command = new AdicionarPessoaCommand { Nome = "Teste", Contatos = new List<ContatoAdicionarPessoa>() };

                // Act
                await handler.Handle(command, default);
            }

            // Assert
            using (var dbContext = new ContextoBd(options))
            {
                var pessoa = dbContext.Pessoas.FirstOrDefault(p => p.Nome == "Teste");
                Assert.NotNull(pessoa);
            }
        }

        [Fact]
        public void Deve_ValidarComandoValido()
        {
            // Arrange
            var command = new AdicionarPessoaCommand { Nome = "Nome válido" };

            // Act
            var result = _validator.TestValidate(command);

            // Assert
            result.ShouldNotHaveAnyValidationErrors();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void Deve_FalharParaComandoComNomeInvalido(string nome)
        {
            // Arrange
            var command = new AdicionarPessoaCommand { Nome = nome };

            // Act
            var result = _validator.TestValidate(command);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Nome);
        }
    }
}