using ApiRest.Entities;
using ApiRest.Entities.Base;
using ApiRest.Entities.Catalogs;
using ApiRest.Entities.Configs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ApiRest.Database.Context;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new EnergyCatalogEntityConfig());
        modelBuilder.ApplyConfiguration(new FuelCatalogEntityConfig());
        modelBuilder.ApplyConfiguration(new IssuanceCatalogEntityConfig());
        modelBuilder.ApplyConfiguration(new PetroleumCatalogEntityConfig());
        modelBuilder.ApplyConfiguration(new TravelCatalogEntityConfig());
        modelBuilder.ApplyConfiguration(new DerivativeCatalogEntityConfig());
        modelBuilder.ApplyConfiguration(new EnergyTypeCatalogEntityConfig());

        modelBuilder.ApplyConfiguration(new EnergyConsumptionEntityConfig());
        modelBuilder.ApplyConfiguration(new FuelConsumptionEntityConfig());
        modelBuilder.ApplyConfiguration(new PetroleumConsumptionEntityConfig());
        modelBuilder.ApplyConfiguration(new TravelEntityConfig());
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        IEnumerable<EntityEntry> entries = ChangeTracker
            .Entries()
            .Where(e => e.Entity is BaseEntityTimestamp && e.State is EntityState.Added or EntityState.Modified);

        foreach (EntityEntry entityEntry in entries)
        {
            switch (entityEntry.State)
            {
                case EntityState.Added:
                    ((BaseEntityTimestamp)entityEntry.Entity).CreatedAt = DateTime.UtcNow;
                    ((BaseEntityTimestamp)entityEntry.Entity).Active = true;
                    break;
                case EntityState.Modified:
                    ((BaseEntityTimestamp)entityEntry.Entity).UpdatedAt = DateTime.UtcNow;
                    Entry((BaseEntityTimestamp)entityEntry.Entity).Property(x => x.CreatedAt).IsModified = false;
                    break;
                case EntityState.Detached:
                case EntityState.Unchanged:
                case EntityState.Deleted:
                default:
                    continue;
            }
        }

        return await base.SaveChangesAsync(cancellationToken);
    }

    #region Tables

    public virtual DbSet<EnergyCatalogEntity> EnergyCatalogEntities { get; set; } = null!;
    public virtual DbSet<FuelCatalogEntity> FuelCatalogEntities { get; set; } = null!;
    public virtual DbSet<PetroleumCatalogEntity> PetroleumCatalogEntities { get; set; } = null!;
    public virtual DbSet<IssuanceCatalogEntity> IssuanceCatalogEntities { get; set; } = null!;
    public virtual DbSet<DerivativeCatalogEntity> DerivativeCatalogEntities { get; set; } = null!;
    public virtual DbSet<TravelEntity> TravelEntities { get; set; } = null!;
    public virtual DbSet<TravelCatalogEntity> TravelCatalogEntities { get; set; } = null!;
    public virtual DbSet<EnergyConsumptionEntity> EnergyConsumptionEntities { get; set; } = null!;
    public virtual DbSet<EnergyTypeCatalogEntity> EnergyTypeCatalogEntities { get; set; } = null!;
    public virtual DbSet<FuelConsumptionEntity> FuelConsumptionEntities { get; set; } = null!;
    public virtual DbSet<PetroleumConsumptionEntity> PetroleumConsumptionEntities { get; set; } = null!;

    #endregion
}