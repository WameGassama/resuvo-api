using Application.Common.Interfaces;
using Domain;
using Domain.Resumes.ValueObjects;
using ErrorOr;
using MediatR;

namespace Application.Resumes.Commands.RetitleResume
{
    public class RetitleResumeCommandHandler : IRequestHandler<RetitleResumeCommand, ErrorOr<Resume>>
    {
        private readonly IResumeRepository _resumeRepository;
        private readonly IUnitOfWork _unitOfWork;

        public RetitleResumeCommandHandler(IResumeRepository resumeRepository, IUnitOfWork unitOfWork)
        {
            _resumeRepository = resumeRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ErrorOr<Resume>> Handle(RetitleResumeCommand request, CancellationToken cancellationToken)
        {
            var resume = await _resumeRepository.GetResumeByIdAsync(ResumeId.Create(Guid.Parse(request.ResumeId)));

            resume.Retitle(request.Title);

            await _resumeRepository.UpdateAsync(resume);

            await _unitOfWork.CommitChangesAsync();

            return resume;
        }
    }
}
