using Application.Common.Interfaces;
using Domain;
using Domain.Resumes.ValueObjects;
using ErrorOr;
using MediatR;

namespace Application.Resumes.Queries.GetResume
{
    public class GetResumeQueryHandler : IRequestHandler<GetResumeQuery, ErrorOr<Resume>>
    {
        private readonly IResumeRepository _resumeRepository;

        public GetResumeQueryHandler(IResumeRepository repository)
        {
            _resumeRepository = repository;
        }

        public async Task<ErrorOr<Resume>> Handle(GetResumeQuery request, CancellationToken cancellationToken)
        {
            var resume = await _resumeRepository.GetResumeByIdAsync(ResumeId.Create(Guid.Parse(request.Id)));

            return resume is null
                ? Error.NotFound(code: "RESUME_NOT_FOUND", description: "The resume could not be found.")
                : resume;
        }
    }
}