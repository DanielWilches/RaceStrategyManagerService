using Domain.Layer.Entities;
using Microsoft.EntityFrameworkCore;

namespace InterfaceAdapter.Layer.DataContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }


        public DbSet<ApiKeysEntity> ApiKeys { get; set; }
        public DbSet<ClientsEntity> Clients { get; set; }
        public DbSet<PilotsEntity> Pilots { get; set; }
        public DbSet<StrategiesEntity> Strategies { get; set; }
        public DbSet<TiresEntity> Tires { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region Pilots 
            modelBuilder.Entity<PilotsEntity>().ToTable("Pilots");
            modelBuilder.Entity<PilotsEntity>()
                .HasIndex(c => c.Id)
                .HasDatabaseName("IX_Pilots_d")
                .IsUnique();
            #endregion

            #region Tires
            modelBuilder.Entity<TiresEntity>().ToTable("Tires");
            modelBuilder.Entity<TiresEntity>()
                .HasIndex(c => c.Id)
                .HasDatabaseName("IX_Tires_Id")
                .IsUnique();
            #endregion

            #region clients
            modelBuilder.Entity<ClientsEntity>().ToTable("Clients");
            modelBuilder.Entity<ClientsEntity>()
            .HasIndex(c => c.Email)
            .HasDatabaseName("IX_Clients_Email")
            .IsUnique();

            modelBuilder.Entity<ClientsEntity>()
                .HasIndex(c => c.Id)
                .HasDatabaseName("IX_Clients_Id")
                .IsUnique();

            #endregion

            #region Strategies
            modelBuilder.Entity<StrategiesEntity>().ToTable("Strategies");
            modelBuilder.Entity<StrategiesEntity>()
                .HasIndex(c => c.Id)
                .HasDatabaseName("IX_Strategies_Id")
                .IsUnique();
            #endregion

            #region ApiKeys
            modelBuilder.Entity<ApiKeysEntity>().ToTable("ApiKeys");
            modelBuilder.Entity<ApiKeysEntity>()
                .HasIndex(c => c.Id)
                .HasDatabaseName("IX_ApiKeys_Id")
                .IsUnique();
            #endregion
        }

    }
}
