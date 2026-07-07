using ErrorOr;
using MediatR;

namespace Application.Resumes.Queries.GetResumes
{
    public record GetResumesQuery(Guid UserId) : IRequest<ErrorOr<IReadOnlyList<ResumeDTO>>>;
}