using Microsoft.EntityFrameworkCore;
using SistemaWeb.Models;

namespace SisitemaWeb.Models
{
    public class Contexto: DbContext
    {
        public Contexto(DbContextOptions<Contexto> options): base(options) { }

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Conta> Conta { get; set; }
        public DbSet<Tipo> Tipos { get; set; }
        public DbSet<Classificacao> Classificacao { get; set; }

    }
}
