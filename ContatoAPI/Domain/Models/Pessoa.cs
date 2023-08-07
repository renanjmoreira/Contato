using ContatoAPI.Domain.Enums;
using ContatoAPI.Domain.Objects;

namespace ContatoAPI.Domain.Models
{
    public class Pessoa : Entidade
    {
        public string Nome { get; private set; }

        private readonly List<Contato> _contatos = new();
        public IReadOnlyList<Contato> Contatos => _contatos.AsReadOnly();

        public Pessoa(string nome)
        {
            Nome = nome;
        }

        public void AlterarNome(string nome)
        {
            Nome = nome;
        }

        public void AdicionarContato(TipoContato tipoContato, string valor)
        {
            var contato = new Contato(tipoContato, valor);
            _contatos.Add(contato);
        }

        public bool RemoverContato(int id)
        {
            var contato = _contatos.Find(x => x.Id == id);
            if (contato == null)
            {
                throw new Exception("Contato não encontrado.");
            }

            return _contatos.Remove(contato);
        }
    }
}
