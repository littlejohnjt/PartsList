using Microsoft.EntityFrameworkCore;
using PartsList.Shared.Models;

namespace PartsList.Server.Data
{
    public partial class PartsListContext : DbContext
    {
        public PartsListContext() { }

        public PartsListContext(DbContextOptions<PartsListContext> options) : base(options) { }

        public virtual DbSet<Vendor> Vendors { get; set; }

        public virtual DbSet<Part> Parts { get; set; }

        public virtual DbSet<InventoryItem> Inventory { get; set; }

        public virtual DbSet<AssemblyItem> AssemblyItems { get; set; }

        public virtual DbSet<AssemblyConfiguration> AssemblyConfigurations { get; set; }

        public virtual DbSet<ComponentAssembly> ComponentsAssemblies { get; set; }

        public virtual DbSet<PurchaseLineItem> PurchaseLineItems { get; set; }

        public virtual DbSet<PurchaseOrder> PurchaseOrders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=PartsList");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Vendor>().ToTable("Vendor");
            modelBuilder.Entity<Part>().ToTable("Part");
            modelBuilder.Entity<InventoryItem>().ToTable("InventoryItem");
            modelBuilder.Entity<AssemblyItem>().ToTable("AssemblyItem");
            modelBuilder.Entity<AssemblyConfiguration>().ToTable("AssemblyConfiguration");
            modelBuilder.Entity<ComponentAssembly>().ToTable("ComponentAssembly");
            modelBuilder.Entity<PurchaseLineItem>().ToTable("PurchaseLineItem");
            modelBuilder.Entity<PurchaseOrder>().ToTable("PurchaseOrder");
        }
    }
}
