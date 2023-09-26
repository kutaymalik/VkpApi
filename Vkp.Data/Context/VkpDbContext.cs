using Microsoft.EntityFrameworkCore;
using Vkp.Base.Model;
using Vkp.Data.Configurations;
using Vkp.Data.Domain;

namespace Vkp.Data.Context;

public class VkpDbContext : DbContext
{
    public VkpDbContext(DbContextOptions<VkpDbContext> options) : base(options)
    {

    }

    public DbSet<User> Users { get; set; }
    public DbSet<Candidate> Candidates { get; set; }
    public DbSet<Vote> Votes { get; set; }

    public override int SaveChanges()
    {
        var entries = ChangeTracker.Entries().Where(e => e.Entity is BaseModel && (e.State == EntityState.Added || e.State == EntityState.Modified));
        
        foreach(var entry in entries)
        {
            if(entry.State == EntityState.Added)
            {
                ((BaseModel)entry.Entity).CreatedAt = DateTime.UtcNow;
            }
            ((BaseModel)entry.Entity).UpdatedAt = DateTime.UtcNow;
        }

        return base.SaveChanges();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CandidateConfiguration());
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new VoteConfiguration());
        base.OnModelCreating(modelBuilder);
    }
}
