using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class ResumeConfigurations : IEntityTypeConfiguration<Resume>
    {
        public void Configure(EntityTypeBuilder<Resume> builder)
        {
            ConfigureResumesTable(builder);
        }

        private void ConfigureResumesTable(EntityTypeBuilder<Resume> builder)
        {
            builder.ToTable("resumes");

            builder.HasKey(r => r.Id);
            builder.Property(r => r.Id)
                .ValueGeneratedNever()
                .HasConversion(id => id.Value,
                               value => ResumeId.Create(value));

            builder.Property(r => r.UserId)
                .HasConversion(id => id.Value,
                               value => UserId.Create(value));
        }
    }
}