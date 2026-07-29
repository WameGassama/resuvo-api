using Domain;
using ErrorOr;
using MediatR;

namespace Application.Resumes.Commands.UpdatePersonalDetails
{
    public record UpdatePersonalDetailsCommand(
        string ResumeId,
        string? JobTitle,
        string? Photo,
        string? FirstName,
        string? LastName,
        string? Email,
        string? Phone,
        string? Address,
        string? PostalCode,
        string? City,
        string? Country) : IRequest<ErrorOr<Resume>>;
}