using Microsoft.EntityFrameworkCore;
using WakesAutocare.Web.Models;

namespace WakesAutocare.Web.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Service> Services { get; set; } = null!;
    public DbSet<Location> Locations { get; set; } = null!;
    public DbSet<ServiceLocationPage> ServiceLocationPages { get; set; } = null!;
    public DbSet<CaseStudy> CaseStudies { get; set; } = null!;
    public DbSet<ContentSnippet> ContentSnippets { get; set; } = null!;
    public DbSet<ContactMessage> ContactMessages { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Service entity configuration
        modelBuilder.Entity<Service>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.HasIndex(e => e.Slug).IsUnique();
            entity.Property(e => e.Title).IsRequired().HasMaxLength(200);
        });

        // Location entity configuration
        modelBuilder.Entity<Location>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.HasIndex(e => e.Slug).IsUnique();
            entity.Property(e => e.Name).IsRequired().HasMaxLength(200);
        });

        // ServiceLocationPage entity configuration
        modelBuilder.Entity<ServiceLocationPage>(entity =>
        {
            entity.HasKey(e => e.Id);

            // Composite unique index on ServiceId and LocationId
            entity.HasIndex(e => new { e.ServiceId, e.LocationId }).IsUnique();

            entity.HasOne(e => e.Service)
                .WithMany(s => s.ServiceLocationPages)
                .HasForeignKey(e => e.ServiceId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(e => e.Location)
                .WithMany(l => l.ServiceLocationPages)
                .HasForeignKey(e => e.LocationId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        // CaseStudy entity configuration
        modelBuilder.Entity<CaseStudy>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.HasIndex(e => e.Slug).IsUnique();
            entity.Property(e => e.Title).IsRequired().HasMaxLength(200);

            entity.HasOne(e => e.Service)
                .WithMany(s => s.CaseStudies)
                .HasForeignKey(e => e.ServiceId)
                .OnDelete(DeleteBehavior.SetNull);
        });

        // ContentSnippet entity configuration
        modelBuilder.Entity<ContentSnippet>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired().HasMaxLength(200);

            entity.HasOne(e => e.Service)
                .WithMany()
                .HasForeignKey(e => e.ServiceId)
                .OnDelete(DeleteBehavior.SetNull);

            entity.HasOne(e => e.Location)
                .WithMany()
                .HasForeignKey(e => e.LocationId)
                .OnDelete(DeleteBehavior.SetNull);
        });

        // ContactMessage entity configuration
        modelBuilder.Entity<ContactMessage>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Email).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Message).IsRequired().HasMaxLength(2000);
            entity.Property(e => e.DateSubmitted).HasDefaultValueSql("GETUTCDATE()");
            entity.HasIndex(e => e.DateSubmitted);
        });

        // Seed initial data
        SeedData(modelBuilder);
    }

    private void SeedData(ModelBuilder modelBuilder)
    {
        // Seed Services
        modelBuilder.Entity<Service>().HasData(
            new Service { Id = 1, Slug = "diagnostics", Title = "Vehicle Diagnostics", Summary = "Computer diagnostics and fault finding", Icon = "fa-laptop", DisplayOrder = 1 },
            new Service { Id = 2, Slug = "servicing", Title = "Car Servicing", Summary = "Full and interim vehicle servicing", Icon = "fa-clipboard-check", DisplayOrder = 2 },
            new Service { Id = 3, Slug = "clutch-replacement", Title = "Clutch Replacement", Summary = "Expert clutch replacement and repair", Icon = "fa-cog", DisplayOrder = 3 },
            new Service { Id = 4, Slug = "timing-belt", Title = "Timing Belt Replacement", Summary = "Cambelt and wet belt replacement", Icon = "fa-wrench", DisplayOrder = 4 },
            new Service { Id = 5, Slug = "repairs", Title = "Vehicle Repairs", Summary = "General automotive repairs", Icon = "fa-tools", DisplayOrder = 5 },
            new Service { Id = 6, Slug = "mobile-mechanic", Title = "Mobile Mechanic", Summary = "Mobile service across the South Coast", Icon = "fa-truck", DisplayOrder = 6 },
            new Service { Id = 7, Slug = "mot", Title = "MOT Testing", Summary = "MOT testing and preparation", Icon = "fa-certificate", DisplayOrder = 7 },
            new Service { Id = 8, Slug = "pre-purchase-inspection", Title = "Pre-Purchase Inspection", Summary = "New and used car inspections", Icon = "fa-search", DisplayOrder = 8 }
        );

        // Seed Locations (South Coast areas)
        modelBuilder.Entity<Location>().HasData(
            new Location { Id = 1, Slug = "portsmouth", Name = "Portsmouth", County = "Hampshire", PostcodePrefix = "PO", DisplayOrder = 1 },
            new Location { Id = 2, Slug = "waterlooville", Name = "Waterlooville", County = "Hampshire", PostcodePrefix = "PO7", DisplayOrder = 2 },
            new Location { Id = 3, Slug = "fareham", Name = "Fareham", County = "Hampshire", PostcodePrefix = "PO", DisplayOrder = 3 },
            new Location { Id = 4, Slug = "havant", Name = "Havant", County = "Hampshire", PostcodePrefix = "PO9", DisplayOrder = 4 },
            new Location { Id = 5, Slug = "gosport", Name = "Gosport", County = "Hampshire", PostcodePrefix = "PO12", DisplayOrder = 5 },
            new Location { Id = 6, Slug = "southsea", Name = "Southsea", County = "Hampshire", PostcodePrefix = "PO4", DisplayOrder = 6 },
            new Location { Id = 7, Slug = "emsworth", Name = "Emsworth", County = "Hampshire", PostcodePrefix = "PO10", DisplayOrder = 7 },
            new Location { Id = 8, Slug = "hayling-island", Name = "Hayling Island", County = "Hampshire", PostcodePrefix = "PO11", DisplayOrder = 8 },
            new Location { Id = 9, Slug = "southampton", Name = "Southampton", County = "Hampshire", PostcodePrefix = "SO", DisplayOrder = 9 },
            new Location { Id = 10, Slug = "chichester", Name = "Chichester", County = "West Sussex", PostcodePrefix = "PO19", DisplayOrder = 10 }
        );
    }
}
