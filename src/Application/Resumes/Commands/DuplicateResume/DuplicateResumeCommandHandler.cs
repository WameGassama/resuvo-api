using Application.Common.Interfaces;
using Application.Resumes;
using Application.Resumes.Commands.DuplicateResume;
using Domain;
using Domain.Resumes.ValueObjects;
using ErrorOr;
using MediatR;

public class DuplicateResumeCommandHandler : IRequestHandler<DuplicateResumeCommand, ErrorOr<Resume>>
{
    private readonly IResumeRepository _resumeRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DuplicateResumeCommandHandler(IResumeRepository resumeRepository, IUnitOfWork unitOfWork)
    {
        _resumeRepository = resumeRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ErrorOr<Resume>> Handle(DuplicateResumeCommand request, CancellationToken cancellationToken)
    {
        var resumeToBeDuplicated = await _resumeRepository.GetResumeByIdAsync(ResumeId.Create(Guid.Parse(request.ResumeId)));

        if (resumeToBeDuplicated is null)
        {
            return Error.NotFound(code: "RESUME_NOT_FOUND", description: "The resume could not be found.");
        }

        var resume = Resume.Create(
            UserId.Create(request.UserId),
            resumeToBeDuplicated.Name,
            resumeToBeDuplicated.TemplateId,
            DateTime.UtcNow,
            DateTime.UtcNow
        );

        await _resumeRepository.AddResumeAsync(resume);
        await _unitOfWork.CommitChangesAsync();

        return resume;
    }
}