using Domain;
using Domain.Resumes.ValueObjects;
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

        private static void ConfigureResumesTable(EntityTypeBuilder<Resume> builder)
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
            builder.Property(r => r.TemplateId)
                .HasConversion(id => id.Value,
                           value => TemplateId.Create(value));
        }
    }
}