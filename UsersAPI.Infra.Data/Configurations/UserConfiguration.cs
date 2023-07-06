using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UsersAPI.Domain.Entities;

namespace UsersAPI.Infra.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u=> u.Id);
            builder.Property(u=> u.Name).HasMaxLength(150).IsRequired();
            builder.Property(u=>u.Email).HasMaxLength(50).IsRequired();
            builder.Property(u=>u.Password).HasMaxLength(40).IsRequired();
            builder.Property(u=>u.CreatedAt).IsRequired();

            builder.HasIndex(u => u.Email).IsUnique();
        }
    }
}
