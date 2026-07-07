using Application.Common.Interfaces;
using ErrorOr;
using MediatR;

namespace Application.Resumes.Queries.GetResumes
{
    public class GetResumesQueryHandler : IRequestHandler<GetResumesQuery, ErrorOr<IReadOnlyList<ResumeDTO>>>
    {
        private readonly IResumeRepository _resumeRepository;

        public GetResumesQueryHandler(IResumeRepository repository)
        {
            _resumeRepository = repository;
        }

        public async Task<ErrorOr<IReadOnlyList<ResumeDTO>>> Handle(GetResumesQuery request, CancellationToken cancellationToken)
        {
            var resumes = await _resumeRepository.GetResumesByUserIdAsync(UserId.Create(request.UserId));

            return resumes
                .Select(r => new ResumeDTO(r.Id.Value, r.UserId.Value, r.Name, r.TemplateId, r.CreatedAt, r.UpdatedAt))
                .ToList();
        }
    }
}
