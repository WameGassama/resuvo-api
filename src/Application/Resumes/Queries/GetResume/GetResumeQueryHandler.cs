using Application.Common.Interfaces;
using ErrorOr;
using MediatR;

namespace Application.Resumes.Queries.GetResume
{
    public class GetResumeQueryHandler : IRequestHandler<GetResumeQuery, ErrorOr<GetResumePayload>>
    {
        private readonly IResumeRepository _resumeRepository;

        private readonly IUnitOfWork _unitOfWork;

        public GetResumeQueryHandler(IUnitOfWork unitOfWork, IResumeRepository repository)
        {
            _resumeRepository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ErrorOr<GetResumePayload>> Handle(GetResumeQuery request, CancellationToken cancellationToken)
        {
            var resume = await _resumeRepository.GetResumeByIdAsync(ResumeId.Create(request.Id));

            return resume is null
                ? Error.NotFound(code: "RESUME_NOT_FOUND", description: "The resume could not be found.")
                : new GetResumePayload(resume.Id.Value, resume.UserId.Value, resume.Name, resume.TemplateId, resume.CreatedAt, resume.UpdatedAt);
        }
    }
}