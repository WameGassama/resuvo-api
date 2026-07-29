using Domain.Common.Models;
using Domain.Resumes.ValueObjects;

namespace Domain
{
    public class Resume : AggregateRoot<ResumeId>
    {
        public UserId UserId { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public TemplateId TemplateId { get; private set; }
        public PersonalDetails PersonalDetails { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }

        private Resume(
            ResumeId resumeId,
            UserId userId,
            string name,
            TemplateId templateId,
            PersonalDetails personalDetails,
            DateTime createdAt,
            DateTime updatedAt) : base(resumeId)
        {
            UserId = userId;
            Name = name;
            TemplateId = templateId;
            PersonalDetails = personalDetails;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }

        public static Resume Create(UserId userId,
            string name,
            TemplateId templateId,
            PersonalDetails personalDetails,
            DateTime createdAt,
            DateTime updatedAt)
        {
            return new(ResumeId.CreateUnique(), userId, name, templateId, personalDetails, createdAt, updatedAt);
        }

        public void Rename(string name)
        {
            Name = name;
            UpdatedAt = DateTime.UtcNow;
        }

        public void UpdatePersonalDetails(PersonalDetails personalDetails)
        {
            PersonalDetails = personalDetails;
            UpdatedAt = DateTime.UtcNow;
        }

        private Resume()
        {

        }
    }
}
