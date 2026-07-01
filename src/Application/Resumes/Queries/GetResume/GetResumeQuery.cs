using ErrorOr;
using MediatR;

namespace Application.Resumes.Queries.GetResume
{
    public record GetResumeQuery : IRequest<ErrorOr<GetResumePayload>>
    {
        public required Guid Id { get; init; }
    }
}