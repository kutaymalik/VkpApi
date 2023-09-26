using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vkp.Data.Domain;

namespace Vkp.Data.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("UserId");
        builder.Property(x => x.TCKN).IsRequired().HasMaxLength(11);
        builder.Property(x => x.Password).IsRequired();
        builder.Property(x => x.CreatedAt).IsRequired();
        builder.Property(x => x.UpdatedAt);

        builder.HasOne(x => x.Vote)
            .WithOne(x => x.User)
            .HasForeignKey<Vote>(x => x.UserId);
    }
}
