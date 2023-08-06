using ContatoAPI.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace ContatoAPI.Infrastructure
{
    public class ContextoBd : DbContext
    {
        public ContextoBd(DbContextOptions<ContextoBd> options) : base(options)
        {
        }

        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Contato> PessoaContatos { get; set; }
    }
}
