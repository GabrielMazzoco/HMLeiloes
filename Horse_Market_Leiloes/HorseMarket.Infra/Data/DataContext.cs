using HorseMarket.Core.Aggregate;
using HorseMarket.Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;

namespace HorseMarket.Infra.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Leilao> Leiloes { get; set; }

        public DataContext(DbContextOptions options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new LeilaoMap());
            modelBuilder.ApplyConfiguration(new CavaloMap());
            modelBuilder.ApplyConfiguration(new FotoMap());
            modelBuilder.ApplyConfiguration(new HarasMap());
            modelBuilder.ApplyConfiguration(new LanceMap());
            modelBuilder.ApplyConfiguration(new LocalidadeMap());
            modelBuilder.ApplyConfiguration(new LoteMap());
            modelBuilder.ApplyConfiguration(new UserMap());
        }
    }
}
