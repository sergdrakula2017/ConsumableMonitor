using ConsumableMonitor.Models;
using Microsoft.EntityFrameworkCore;

namespace ConsumableMonitor.Data;

public class ConsumableMonitorDataContext : DbContext
{
    public ConsumableMonitorDataContext(DbContextOptions<ConsumableMonitorDataContext> options) : base(options) { }
    public DbSet<ConsumableModel> ConsumableModels { get; set; } = null!;
    public DbSet<ConsumableModelFamily> ConsumableModelsFamilies { get; set; } = null!;
    public DbSet<EquipmentModel> EquipmentModels { get; set; } = null!;
    public DbSet<EquipmentSlotDescriptor> EquipmentSlotDescriptors { get; set; } = null!;
    public DbSet<EquipmentSlot> EquipmentSlots { get; set; } = null!;
    public DbSet<Equipment> Equipments { get; set; } = null!;
    public DbSet<Consumable> Consumables { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ConsumableModel>(entity =>
        {
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Producer);
            entity.HasIndex(x => x.Producer).IsUnique(false);
            entity.Property(x => x.Model);
            entity.HasIndex(x => x.Model).IsUnique(false);
            entity.HasAlternateKey(x => new {x.Producer, x.Model});

            entity.HasOne(x => x.Family).WithMany(x => x.Models).IsRequired();
        });

        modelBuilder.Entity<ConsumableModelFamily>(entity =>
        {
            entity.HasKey(x => x.Id);

            entity.HasMany(x => x.Models).WithOne(x => x.Family).HasForeignKey(x => x.FamilyId);
            entity.HasMany(x => x.SlotDescriptors).WithOne(x => x.ConsumableModelFamily).HasForeignKey(x => x.ConsumableModelFamilyId);
        });

        modelBuilder.Entity<EquipmentModel>(entity =>
        {
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Producer);
            entity.HasIndex(x => x.Producer).IsUnique(false);
            entity.Property(x => x.Model);
            entity.HasIndex(x => x.Model).IsUnique(false);
            entity.HasAlternateKey(x => new {x.Producer, x.Model});

            entity.HasMany(x => x.SlotDescriptors).WithOne(x => x.EquipmentModel).HasForeignKey(x => x.ModelId).IsRequired();
        });

        modelBuilder.Entity<EquipmentSlotDescriptor>(entity =>
        {
            entity.HasKey(x => new {x.ModelId, x.SlotNumber});
            entity.HasIndex(x => x.ModelId).IsUnique(false);
            entity.HasOne(x => x.EquipmentModel).WithMany(x => x.SlotDescriptors).HasForeignKey(x => x.ModelId).IsRequired();
            entity.HasOne(x => x.ConsumableModelFamily).WithMany(x => x.SlotDescriptors).HasForeignKey(x => x.ConsumableModelFamilyId).IsRequired();
        });

        modelBuilder.Entity<EquipmentSlot>(entity =>
        {
            entity.HasKey(x => new {x.EquipmentId, x.SlotNumber});
            entity.HasIndex(x => x.EquipmentId).IsUnique(false);

            entity.HasOne(x => x.Equipment).WithMany(x => x.Slots).HasForeignKey(x => x.EquipmentId);
            entity.HasOne(x => x.Installed).WithOne(x => x.InstalledIn).HasForeignKey<EquipmentSlot>(x => new {x.EquipmentId, x.SlotNumber}).IsRequired(false);
        });

        modelBuilder.Entity<Equipment>(entity =>
        {
            entity.HasKey(x => x.Id);
            entity.HasIndex(x => x.SerialNumber).IsUnique(false);
            entity.Property(x => x.Alias);
            entity.Property(x => x.Description);
            entity.Property(x => x.Scrapped);
            entity.Property(x => x.Cost).HasColumnType("money");

            entity.HasOne(x => x.Model).WithMany(x => x.Equipments).HasForeignKey(x => x.ModelId);
            entity.HasMany(x => x.Slots).WithOne(x => x.Equipment).HasForeignKey(x => x.EquipmentId);
        });

        modelBuilder.Entity<Consumable>(entity =>
        {
            entity.HasKey(x => x.Id);
            entity.HasIndex(x => x.SerialNumber).IsUnique(false);
            entity.Property(x => x.Alias);
            entity.Property(x => x.Description);
            entity.Property(x => x.Scrapped);
            entity.Property(x => x.Cost).HasColumnType("money");

            entity.HasOne(x => x.Model).WithMany(x => x.Consumables).HasForeignKey(x => x.ModelId);
            entity.HasOne(x => x.InstalledIn).WithOne(x => x.Installed).HasForeignKey<Consumable>(x => new {x.InstalledInEquipmentId, x.InstalledInNumber}).IsRequired(false);
        });
    }
}