using Domain;
using Domain.Resumes.ValueObjects;

namespace Application.Common.Interfaces
{
    public interface IResumeRepository
    {
        Task AddResumeAsync(Resume resume);
        Task<Resume?> GetResumeByIdAsync(ResumeId id);
        Task UpdateAsync(Resume resume);
        Task<List<Resume>> GetResumesByUserIdAsync(UserId userId);
        Task DeleteResumeAsync(Resume resume);
    }
}