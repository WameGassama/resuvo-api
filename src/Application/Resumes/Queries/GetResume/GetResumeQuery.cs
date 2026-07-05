using ErrorOr;
using MediatR;

namespace Application.Resumes.Queries.GetResume
{
    public record GetResumeQuery(Guid Id) : IRequest<ErrorOr<GetResumePayload>>;
}