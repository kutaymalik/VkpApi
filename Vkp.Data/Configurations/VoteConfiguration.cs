using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vkp.Data.Domain;

namespace Vkp.Data.Configurations;

public class VoteConfiguration : IEntityTypeConfiguration<Vote>
{
    public void Configure(EntityTypeBuilder<Vote> builder)
    {
        builder.ToTable("Votes");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("VoteId");
        builder.Property(x => x.UserId).IsRequired();
        builder.Property(x => x.CandidateId).IsRequired();
        builder.Property(x => x.VoteDate).IsRequired();
        builder.Property(x => x.CreatedAt).IsRequired();
        builder.Property(x => x.UpdatedAt);

        builder.HasOne(x => x.User)
            .WithOne(x => x.Vote)
            .HasForeignKey<Vote>(x => x.UserId);
    }
}