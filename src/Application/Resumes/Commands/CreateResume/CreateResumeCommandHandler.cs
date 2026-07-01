using Application.Common.Interfaces;
using Application.Resumes.Commands.CreateResume;
using Domain;
using ErrorOr;
using MediatR;

namespace Application.Resumes.Commands.CreateResume
{
    public class CreateResumeCommandHandler : IRequestHandler<CreateResumeCommand, ErrorOr<CreateResumePayload>>
    {
        private readonly IResumeRepository _resumeRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateResumeCommandHandler(IResumeRepository resumesRepository, IUnitOfWork unitOfWork)
        {
            _resumeRepository = resumesRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ErrorOr<CreateResumePayload>> Handle(CreateResumeCommand request, CancellationToken cancellationToken)
        {
            var resume = Resume.Create(
                UserId.Create(request.UserId),
                request.Name,
                request.TemplateId,
                DateTime.UtcNow,
                DateTime.UtcNow
            );

            await _resumeRepository.AddResumeAsync(resume);
            await _unitOfWork.CommitChangesAsync();

            return new CreateResumePayload(resume.Id.Value,
                                           resume.UserId.Value,
                                           resume.Name,
                                           resume.TemplateId,
                                           resume.CreatedAt,
                                           resume.UpdatedAt);
        }
    }
}