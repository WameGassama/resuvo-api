using Domain;

namespace Application.Common.Interfaces
{
    public interface IResumeRepository
    {
        Task AddResumeAsync(Resume resume);
        Task<Resume?> GetResumeByIdAsync(ResumeId id);

        Task DeleteResumeAsync(Resume resume);
    }
}