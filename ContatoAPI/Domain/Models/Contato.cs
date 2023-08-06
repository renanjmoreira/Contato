using ContatoAPI.Domain.Enums;
using ContatoAPI.Domain.Objects;
using FluentValidation;

namespace ContatoAPI.Domain.Models
{
    public class Contato : Entidade
    {
        public TipoContato TipoContato { get; private set; }
        public string Valor { get; private set; }

        public Contato(TipoContato tipoContato, string valor)
        {
            TipoContato = tipoContato;
            Valor = valor;
        }
    }
}
