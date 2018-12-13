using Microsoft.EntityFrameworkCore;

namespace LivrariaVirtual.Models
{
    public class LivrariaContexto : DbContext
    {
        public LivrariaContexto(DbContextOptions<LivrariaContexto> options)
            : base(options)
        {
        }

        public DbSet<Avaliacao> Avaliacoes { get; set; }
        public DbSet<Livro> Livros { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
    }
}