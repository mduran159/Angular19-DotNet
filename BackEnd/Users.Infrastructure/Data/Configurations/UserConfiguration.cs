using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Users.Domain.Models;

namespace Users.Infrastructure.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            // Table configuration
            builder.ToTable("Users");

            // PK configuration
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id)
                   .ValueGeneratedOnAdd()
                   .HasDefaultValueSql("NEWID()");

            // Properties configuration
            builder.Property(u => u.FirstName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(u => u.LastName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(u => u.Age)
                .IsRequired()
                .HasDefaultValue(0);

            builder.Property(u => u.Gender)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(u => u.Country)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(u => u.Address)
                .IsRequired()
                .HasMaxLength(250);

            builder.Property(u => u.Phone)
                .IsRequired();

            builder.Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasIndex(u => u.Email).IsUnique(); // Make email a unique field
        }
    }
}
