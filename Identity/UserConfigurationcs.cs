using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
namespace Identity;

public class UserConfigurationcs : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.Property(b => b.Password)
            .HasMaxLength(10)
            .IsRequired();
        builder.Property(b => b.Name)
            .HasMaxLength(12)
            .IsRequired();
    }
}