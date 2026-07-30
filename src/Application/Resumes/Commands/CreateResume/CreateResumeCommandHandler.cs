using Application.Common.Interfaces;
using Domain;
using Domain.Resumes.ValueObjects;
using ErrorOr;
using MediatR;

namespace Application.Resumes.Commands.CreateResume
{
    public class CreateResumeCommandHandler : IRequestHandler<CreateResumeCommand, ErrorOr<Resume>>
    {
        private readonly IResumeRepository _resumeRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateResumeCommandHandler(IResumeRepository resumesRepository, IUnitOfWork unitOfWork)
        {
            _resumeRepository = resumesRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ErrorOr<Resume>> Handle(CreateResumeCommand request, CancellationToken cancellationToken)
        {
            var personalDetails = PersonalDetails.Create("", "", "", "", Email.Create(""), "", "", "", "", "");

            var resume = Resume.Create(
                UserId.Create(request.UserId),
                request.Title,
                TemplateId.Create(Guid.Parse(request.TemplateId)),
                personalDetails,
                DateTime.UtcNow,
                DateTime.UtcNow
            );

            await _resumeRepository.AddResumeAsync(resume);
            await _unitOfWork.CommitChangesAsync();

            return resume;
        }
    }
}