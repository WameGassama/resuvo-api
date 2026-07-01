using Application.Common.Interfaces;
using Domain;
using Infrastructure.Common.Persistence;
using Microsoft.EntityFrameworkCore;

public class ResumeRepository : IResumeRepository
{
    private readonly ResumeDBContext _dBContext;

    public ResumeRepository(ResumeDBContext dBContext)
    {
        _dBContext = dBContext;
    }

    public async Task AddResumeAsync(Resume resume)
    {
        await _dBContext.Resumes.AddAsync(resume);
    }

    public async Task<Resume?> GetResumeByIdAsync(ResumeId id)
    {
        var result = await _dBContext.Resumes.FirstOrDefaultAsync(r => r.Id == id);

        return result;
    }
}