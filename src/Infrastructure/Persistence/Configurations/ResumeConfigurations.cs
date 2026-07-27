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
                personalDetailsBuilder.Property(personalDetails => personalDetails.JobTitle).HasColumnName("job_title");
                personalDetailsBuilder.Property(personalDetails => personalDetails.Photo).HasColumnName("photo");
                personalDetailsBuilder.Property(personalDetails => personalDetails.FirstName).HasColumnName("first_name");
                personalDetailsBuilder.Property(personalDetails => personalDetails.LastName).HasColumnName("last_name");
                personalDetailsBuilder.Property(personalDetails => personalDetails.Email).HasConversion(email => email == null ? null : email.Value,
                                                        value => value == null ? null : Email.Create(value)).HasColumnName("email");
                personalDetailsBuilder.Property(personalDetails => personalDetails.Phone).HasColumnName("phone");
                personalDetailsBuilder.Property(personalDetails => personalDetails.Address).HasColumnName("address");
                personalDetailsBuilder.Property(personalDetails => personalDetails.PostalCode).HasColumnName("postal_code");
                personalDetailsBuilder.Property(personalDetails => personalDetails.City).HasColumnName("city");
                personalDetailsBuilder.Property(personalDetails => personalDetails.Country).HasColumnName("country");

            });
        }
    }
}