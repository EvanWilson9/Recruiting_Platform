using Microsoft.EntityFrameworkCore;
using server.Models.Entities;

namespace server.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options) {}

    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Player> Players { get; set; } = null!;
    public DbSet<School> Schools { get; set; } = null!;
    public DbSet<AthleticCareer> AthleticCareers { get; set; } = null!;
    public DbSet<PlayerSchool> PlayerSchools { get; set; } = null!;
    public DbSet<RefreshToken> RefreshTokens { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // 1. User <-> Player (1-to-1)
        modelBuilder.Entity<User>()
            .HasOne(user => user.Player)
            .WithOne(player => player.User)
            .HasForeignKey<Player>(player => player.UserId)
            .OnDelete(DeleteBehavior.Cascade);
        
        // 2. Player <-> PlayerSchool (1-to-Many)
        modelBuilder.Entity<PlayerSchool>()
            .HasOne(ps => ps.Player)
            .WithMany(p => p.PlayerSchools)
            .HasForeignKey(ps => ps.PlayerId)
            .OnDelete(DeleteBehavior.Cascade);

        // 3. School <-> PlayerSchool (1-to-Many)
        modelBuilder.Entity<PlayerSchool>()
            .HasOne(ps => ps.School)
            .WithMany()
            .HasForeignKey(ps => ps.SchoolId)
            .OnDelete(DeleteBehavior.Restrict);

        // 4. Player <-> AthleticCareer (1-to-Many)
        modelBuilder.Entity<AthleticCareer>()
            .HasOne(ac => ac.Player)
            .WithMany(p => p.AthleticCareers)
            .HasForeignKey(ac => ac.PlayerId)
            .OnDelete(DeleteBehavior.Cascade);

        // 5. School <-> AthleticCareer (1-to-Many)
        modelBuilder.Entity<AthleticCareer>()
            .HasOne(ac => ac.School)
            .WithMany()
            .HasForeignKey(ac => ac.SchoolId)
            .OnDelete(DeleteBehavior.Restrict);

        //
        //Refresh Token Logic (Subject to change)
        //
        modelBuilder.Entity<RefreshToken>()
            .Property(rt => rt.CreatedAt)
            .HasDefaultValueSql("NOW()");

        modelBuilder.Entity<RefreshToken>()
            .HasOne(rt => rt.User)
            .WithMany() // add a `List<RefreshToken>` nav property on User if you want it queryable from that side
            .HasForeignKey(rt => rt.UserId)
            .OnDelete(DeleteBehavior.Cascade); // deleting a user cleans up their refresh tokens

        modelBuilder.Entity<RefreshToken>()
            .HasIndex(rt => rt.UserId); // you'll query "all active tokens for this user" on every refresh
    }
}