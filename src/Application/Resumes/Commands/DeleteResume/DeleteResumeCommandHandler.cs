using Application.Common.Interfaces;
using Application.Resumes.Commands.DeleteResume;
using Domain;
using ErrorOr;
using MediatR;

namespace Application.Resumes.Commands.DeleteResume
{
    public class DeleteResumeCommandHandler : IRequestHandler<DeleteResumeCommand, ErrorOr<DeleteResumePayload>>
    {
        private readonly IResumeRepository _resumeRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteResumeCommandHandler(IResumeRepository resumesRepository, IUnitOfWork unitOfWork)
        {
            _resumeRepository = resumesRepository;
            _unitOfWork = unitOfWork;
        }

        async Task<ErrorOr<DeleteResumePayload>> IRequestHandler<DeleteResumeCommand, ErrorOr<DeleteResumePayload>>.Handle(DeleteResumeCommand request, CancellationToken cancellationToken)
        {
            var resume = await _resumeRepository.GetResumeByIdAsync(ResumeId.Create(request.Id));

            if (resume is null)
            {
                return Error.NotFound(code: "RESUME_NOT_FOUND", description: "The resume could not be found.");
            }

            await _resumeRepository.DeleteResumeAsync(resume);

            await _unitOfWork.CommitChangesAsync();

            return new DeleteResumePayload(true);
        }
    }
}