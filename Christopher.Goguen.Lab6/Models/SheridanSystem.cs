namespace Christopher.Goguen.Lab6.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class SheridanSystem : DbContext
    {
        public SheridanSystem()
            : base("name=SheridanSystem")
        {
        }

        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Inventory> Inventories { get; set; }
        public virtual DbSet<RentalOrder> RentalOrders { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasMany(e => e.RentalOrders)
                .WithRequired(e => e.Employee)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Inventory>()
                .HasMany(e => e.RentalOrders)
                .WithMany(e => e.Inventories)
                .Map(m => m.ToTable("InventoryRentalOrder").MapLeftKey("Inventories_InventoryId").MapRightKey("RentalOrders_RentalOrderId"));
        }
    }
}
