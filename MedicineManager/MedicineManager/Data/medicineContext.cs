using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MedicineManager.Data
{
    public partial class medicineContext : DbContext
    {
        public medicineContext()
        {
        }

        public medicineContext(DbContextOptions<medicineContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Address> Addresses { get; set; } = null!;
        public virtual DbSet<Cart> Carts { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<City> Cities { get; set; } = null!;
        public virtual DbSet<District> Districts { get; set; } = null!;
        public virtual DbSet<Manufactory> Manufactories { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<OrderProduct> OrderProducts { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<ProductUnit> ProductUnits { get; set; } = null!;
        public virtual DbSet<Unit> Units { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<Ward> Wards { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Database=medicine;User Id=postgres;Password=1234;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(u => u.Addresses)
                .WithOne(a => a.User)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<City>()
                .HasMany(u => u.Addresses)
                .WithOne(a => a.City)
                .OnDelete(DeleteBehavior.Cascade);
            
            modelBuilder.Entity<Address>(entity =>
            {
                entity.ToTable("address", "customer");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Address1).HasColumnName("address");

                entity.Property(e => e.CityId).HasColumnName("city_id");

                entity.Property(e => e.DistrictId).HasColumnName("district_id");

                entity.Property(e => e.IsDefault)
                    .HasColumnName("is_default")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.WardId).HasColumnName("ward_id");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Addresses)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("address_city_id_fkey");

                entity.HasOne(d => d.District)
                    .WithMany(p => p.Addresses)
                    .HasForeignKey(d => d.DistrictId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("address_district_id_fkey");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Addresses)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("address_user_id_fkey");

                entity.HasOne(d => d.Ward)
                    .WithMany(p => p.Addresses)
                    .HasForeignKey(d => d.WardId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("address_ward_id_fkey");
            });

            modelBuilder.Entity<Cart>(entity =>
            {
                entity.ToTable("cart", "medicine");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreateAt)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_at")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Number).HasColumnName("number");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.UpdateAt)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("update_at")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Carts)
                    .HasPrincipalKey(p => p.Id)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("cart_product_id_fkey");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Carts)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("cart_user_id_fkey");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("category", "medicine");

                entity.HasIndex(e => e.Name, "category_name_key")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreateAt)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_at")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.CreateBy).HasColumnName("create_by");

                entity.Property(e => e.IsActive)
                    .HasColumnName("is_active")
                    .HasDefaultValueSql("true");

                entity.Property(e => e.Name)
                    .HasColumnType("character varying")
                   
                    .HasColumnName("name");

                entity.Property(e => e.UpdateAt)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("update_at")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.UpdateBy).HasColumnName("update_by");

                entity.HasOne(d => d.CreateByNavigation)
                    .WithMany(p => p.CategoryCreateByNavigations)
                    .HasForeignKey(d => d.CreateBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("category_create_by_fkey");

                entity.HasOne(d => d.UpdateByNavigation)
                    .WithMany(p => p.CategoryUpdateByNavigations)
                    .HasForeignKey(d => d.UpdateBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("category_update_by_fkey");
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.ToTable("city", "customer");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasColumnType("character varying")
                     .HasColumnName("name");
            });

            modelBuilder.Entity<District>(entity =>
            {
                entity.ToTable("district", "customer");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CityId).HasColumnName("city_id");

                entity.Property(e => e.Name)
                    .HasColumnType("character varying")
                    .HasColumnName("name");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Districts)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("district_city_id_fkey");
            });

            modelBuilder.Entity<Manufactory>(entity =>
            {
                entity.ToTable("manufactory", "medicine");

                entity.HasIndex(e => e.Name, "manufactory_name_key")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Country)
                    .HasColumnType("character varying")
                    .HasColumnName("country");

                entity.Property(e => e.CreateAt)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_at")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.CreateBy).HasColumnName("create_by");

                entity.Property(e => e.IsActive)
                    .HasColumnName("is_active")
                    .HasDefaultValueSql("true");

                entity.Property(e => e.Name)
                    .HasColumnType("character varying")
                    .HasColumnName("name");

                entity.Property(e => e.UpdateAt)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("update_at")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.UpdateBy).HasColumnName("update_by");

                entity.HasOne(d => d.CreateByNavigation)
                    .WithMany(p => p.ManufactoryCreateByNavigations)
                    .HasForeignKey(d => d.CreateBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("manufactory_create_by_fkey");

                entity.HasOne(d => d.UpdateByNavigation)
                    .WithMany(p => p.ManufactoryUpdateByNavigations)
                    .HasForeignKey(d => d.UpdateBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("manufactory_update_by_fkey");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("order", "medicine");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreateAt)
                    .HasColumnName("create_at")
                    .HasDefaultValueSql("CURRENT_DATE");

                entity.Property(e => e.Status)
                    .HasColumnType("character varying")
                    .HasColumnName("status");

                entity.Property(e => e.Total).HasColumnName("total");

                entity.Property(e => e.UpdateAt)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("update_at")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("order_user_id_fkey");
            });

            modelBuilder.Entity<OrderProduct>(entity =>
            {
                entity.ToTable("order_product", "medicine");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Number).HasColumnName("number");

                entity.Property(e => e.OrderId).HasColumnName("order_id");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderProducts)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("order_product_order_id_fkey");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.OrderProducts)
                    .HasPrincipalKey(p => p.Id)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("order_product_product_id_fkey");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.Name })
                    .HasName("product_pkey");

                entity.ToTable("product", "medicine");

                entity.HasIndex(e => e.Id, "product_id_unique")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasColumnType("character varying")
                    .HasColumnName("name");

                entity.Property(e => e.Category).HasColumnName("category");

                entity.Property(e => e.CreateAt)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_at")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.CreateBy).HasColumnName("create_by");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.ExpDate).HasColumnName("exp_date");

                entity.Property(e => e.IsActive)
                    .HasColumnName("is_active")
                    .HasDefaultValueSql("true");

                entity.Property(e => e.Manufactory).HasColumnName("manufactory");

                entity.Property(e => e.NoteProduct).HasColumnName("note_product");

                entity.Property(e => e.NumberStock).HasColumnName("number_stock");

                entity.Property(e => e.Print).HasColumnName("print");

                entity.Property(e => e.UpdateAt)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("update_at")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.UpdateBy).HasColumnName("update_by");

                entity.HasOne(d => d.CategoryNavigation)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.Category)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("product_category_fkey");

                entity.HasOne(d => d.CreateByNavigation)
                    .WithMany(p => p.ProductCreateByNavigations)
                    .HasForeignKey(d => d.CreateBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("product_create_by_fkey");

                entity.HasOne(d => d.ManufactoryNavigation)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.Manufactory)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("product_manufactory_fkey");

                entity.HasOne(d => d.UpdateByNavigation)
                    .WithMany(p => p.ProductUpdateByNavigations)
                    .HasForeignKey(d => d.UpdateBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("product_update_by_fkey");
            });

            modelBuilder.Entity<ProductUnit>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("product_unit", "medicine");

                entity.Property(e => e.CreateAt)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_at")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.CreateBy).HasColumnName("create_by");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.UnitId).HasColumnName("unit_id");

                entity.Property(e => e.UpdateAt)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("update_at")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.UpdateBy).HasColumnName("update_by");

                entity.HasOne(d => d.CreateByNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.CreateBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("product_unit_create_by_fkey");

                entity.HasOne(d => d.Product)
                    .WithMany()
                    .HasPrincipalKey(p => p.Id)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("product_unit_product_id_fkey");

                entity.HasOne(d => d.Unit)
                    .WithMany()
                    .HasForeignKey(d => d.UnitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("product_unit_unit_id_fkey");

                entity.HasOne(d => d.UpdateByNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.UpdateBy)
                    .HasConstraintName("product_unit_update_by_fkey");
            });

            modelBuilder.Entity<Unit>(entity =>
            {
                entity.ToTable("unit", "medicine");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Abbreviation)
                    .HasColumnType("character varying")
                    .HasColumnName("abbreviation");

                entity.Property(e => e.CreateAt)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_at")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.CreateBy).HasColumnName("create_by");

                entity.Property(e => e.Description)
                    .HasColumnType("character varying")
                    .HasColumnName("description");

                entity.Property(e => e.Name)
                    .HasColumnType("character varying")
                    .HasColumnName("name");

                entity.Property(e => e.UpdateAt)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("update_at")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.UpdateBy).HasColumnName("update_by");

                entity.HasOne(d => d.CreateByNavigation)
                    .WithMany(p => p.UnitCreateByNavigations)
                    .HasForeignKey(d => d.CreateBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("unit_create_by_fkey");

                entity.HasOne(d => d.UpdateByNavigation)
                    .WithMany(p => p.UnitUpdateByNavigations)
                    .HasForeignKey(d => d.UpdateBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("unit_update_by_fkey");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user", "customer");

                entity.HasIndex(e => e.Email, "user_email_key")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Email)
                    .HasColumnType("character varying")
                    .HasColumnName("email");

                entity.Property(e => e.FullName)
                    .HasColumnType("character varying")
                    .HasColumnName("full_name");

                entity.Property(e => e.IsActive)
                    .HasColumnName("is_active")
                    .HasDefaultValueSql("true");

                entity.Property(e => e.Password)
                    .HasColumnType("character varying")
                    .HasColumnName("password");

                entity.Property(e => e.PhoneNumber)
                    .HasColumnType("character varying")
                    .HasColumnName("phone_number");

                entity.Property(e => e.UpdateAt)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("update_at")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Username)
                    .HasColumnType("character varying")
                    .HasColumnName("username");
            });

            modelBuilder.Entity<Ward>(entity =>
            {
                entity.ToTable("ward", "customer");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DistrictId).HasColumnName("district_id");

                entity.Property(e => e.Name)
                    .HasColumnType("character varying")
                    .HasColumnName("name");

                entity.HasOne(d => d.District)
                    .WithMany(p => p.Wards)
                    .HasForeignKey(d => d.DistrictId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("ward_district_id_fkey");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
