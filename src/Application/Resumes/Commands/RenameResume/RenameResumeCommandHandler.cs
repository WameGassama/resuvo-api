using Application.Common.Interfaces;
using Application.Resumes.Commands.RenameResume;
using Domain;
using Domain.Resumes.ValueObjects;
using ErrorOr;
using MediatR;

public class RenameResumeCommandHandler : IRequestHandler<RenameResumeCommand, ErrorOr<Resume>>
{
    private readonly IResumeRepository _resumeRepository;
    private readonly IUnitOfWork _unitOfWork;

    public RenameResumeCommandHandler(IResumeRepository resumeRepository, IUnitOfWork unitOfWork)
    {
        _resumeRepository = resumeRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ErrorOr<Resume>> Handle(RenameResumeCommand request, CancellationToken cancellationToken)
    {
        var resume = await _resumeRepository.GetResumeByIdAsync(ResumeId.Create(Guid.Parse(request.ResumeId)));

        resume.Rename(request.Name);

        await _resumeRepository.UpdateAsync(resume);

        await _unitOfWork.CommitChangesAsync();

        return resume;
    }
}