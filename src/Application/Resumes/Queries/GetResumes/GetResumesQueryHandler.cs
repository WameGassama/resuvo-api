using Application.Common.Interfaces;
using Domain;
using Domain.Resumes.ValueObjects;
using ErrorOr;
using MediatR;

namespace Application.Resumes.Queries.GetResumes
{
    public class GetResumesQueryHandler : IRequestHandler<GetResumesQuery, ErrorOr<IReadOnlyList<Resume>>>
    {
        private readonly IResumeRepository _resumeRepository;

        public GetResumesQueryHandler(IResumeRepository repository)
        {
            _resumeRepository = repository;
        }

        public async Task<ErrorOr<IReadOnlyList<Resume>>> Handle(GetResumesQuery request, CancellationToken cancellationToken)
        {
            var resumes = await _resumeRepository.GetResumesByUserIdAsync(UserId.Create(request.UserId));

            return resumes.ToList();
        }
    }
}
