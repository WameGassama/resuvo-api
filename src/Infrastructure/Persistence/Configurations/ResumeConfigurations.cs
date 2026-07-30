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

            builder.HasKey(resume => resume.Id);
            builder.Property(resume => resume.Id)
                .ValueGeneratedNever()
                .HasConversion(id => id.Value,
                               value => ResumeId.Create(value));
            builder.Property(resume => resume.UserId)
                .HasConversion(id => id.Value,
                               value => UserId.Create(value));
            builder.Property(resume => resume.TemplateId)
                .HasConversion(id => id.Value,
                           value => TemplateId.Create(value));

            // Owned type 
            builder.ComplexProperty(resume => resume.PersonalDetails, personalDetailsBuilder =>
            {
                personalDetailsBuilder.Property(personalDetails => personalDetails.JobTitle).HasColumnName("job_title").IsRequired();
                personalDetailsBuilder.Property(personalDetails => personalDetails.Photo).HasColumnName("photo").IsRequired();
                personalDetailsBuilder.Property(personalDetails => personalDetails.FirstName).HasColumnName("first_name").IsRequired();
                personalDetailsBuilder.Property(personalDetails => personalDetails.LastName).HasColumnName("last_name").IsRequired();
                personalDetailsBuilder.Property(personalDetails => personalDetails.Email).HasConversion(email => email.Value,
                                                        value => Email.Create(value)).HasColumnName("email").IsRequired();
                personalDetailsBuilder.Property(personalDetails => personalDetails.Phone).HasColumnName("phone").IsRequired();
                personalDetailsBuilder.Property(personalDetails => personalDetails.Address).HasColumnName("address").IsRequired();
                personalDetailsBuilder.Property(personalDetails => personalDetails.PostalCode).HasColumnName("postal_code").IsRequired();
                personalDetailsBuilder.Property(personalDetails => personalDetails.City).HasColumnName("city").IsRequired();
                personalDetailsBuilder.Property(personalDetails => personalDetails.Country).HasColumnName("country").IsRequired();

            });
        }
    }
}