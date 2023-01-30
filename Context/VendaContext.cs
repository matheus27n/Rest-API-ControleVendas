using DesafioFinal.Models;
using Microsoft.EntityFrameworkCore;

namespace DesafioFinal.Context
{
    public class VendaContext : DbContext
    {
        public VendaContext(DbContextOptions<VendaContext> options) : base(options)
        {
        }

        public DbSet<Vendedor> Vendedores { get; set; }
        public DbSet<Venda> Vendas { get; set; }
    }
}