using AutoMarketApp.Infrastructure.Data.Dtos;
using Microsoft.EntityFrameworkCore;

namespace AutoMarketApp.Infrastructure.Data;

internal sealed class AutoMarketAppDbContext(DbContextOptions<AutoMarketAppDbContext> options) : DbContext(options)
{
    public DbSet<CarDto> Cars { get; set; }
    public DbSet<CustomerDto> Customers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CarDto>(builder =>
        {
            builder.HasKey(c => c.Vin);
            builder.ToTable("Cars");
            
            builder.OwnsOne(c => c.Reservation, reservation =>
            {
                reservation.Property(r => r.ReservationDate).HasColumnName("ReservationDate");
                reservation.Property(r => r.CustomerId).HasColumnName("ReservationCustomerId");
                reservation.Property(r => r.ExpirationDate).HasColumnName("ReservationExpirationDate");

                reservation
                    .HasOne<CustomerDto>()
                    .WithMany()
                    .HasForeignKey(r => r.CustomerId);
            });
            
            builder.OwnsOne(c => c.Sale, sale =>
            {
                sale.Property(s => s.SaleDate).HasColumnName("SaleDate");
                sale.Property(s => s.CustomerId).HasColumnName("SaleCustomerId");

                sale
                    .HasOne<CustomerDto>()
                    .WithMany()
                    .HasForeignKey(r => r.CustomerId);
            });
        });

        modelBuilder.Entity<CustomerDto>(builder =>
        {
            builder.HasKey(c => c.Id);
            builder.ToTable("Customers");
            
            builder.Property(c => c.Name).IsRequired();
            builder.Property(c => c.Email).IsRequired();
            builder.Property(c => c.Phone).IsRequired();
        });
    }
}