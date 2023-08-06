namespace ContatoAPI.Domain.Objects
{
    public class Entidade
    {
        public Guid Id { get; private set; }

        public Entidade()
        {
            Id = Guid.NewGuid();
        }
    }
}
