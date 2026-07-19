using Domain;
using ErrorOr;
using MediatR;

namespace Application.Resumes.Queries.GetResumes
{
    public record GetResumesQuery(string UserId) : IRequest<ErrorOr<IReadOnlyList<Resume>>>;
}