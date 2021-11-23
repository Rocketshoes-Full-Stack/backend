using Microsoft.EntityFrameworkCore;
using RocketShoes.Entity;

namespace RocketShoes
{
    public class LojaContext : DbContext
    {
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<UsuarioMaster> UsuariosMaster { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Compra> Compras { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=josue-desktop;Initial Catalog=loja;Integrated Security=True;Pooling=False");
        }
    }

    
}
