using System.Security.Claims;
using Application.Common.Errors;
using Application.Resumes.Commands.CreateResume;
using Application.Resumes.Commands.DeleteResume;
using Application.Resumes.Commands.DuplicateResume;
using GraphQL.Common;
using GraphQL.Contracts.Models;
using GraphQL.Contracts.Payloads;
using HotChocolate.Authorization;
using MediatR;

namespace GraphQL.Mutations
{
    [MutationType]
    public static partial class ResumeMutations
    {
        [Error<ValidationError>]
        [Error<NotFoundError>]
        [Authorize]
        public static async Task<FieldResult<CreateResumePayload>> CreateResumeAsync(ClaimsPrincipal claimsPrincipal, [GraphQLType(typeof(NonNullType<IdType>))] string name, [GraphQLType(typeof(NonNullType<IdType>))] string templateId, [Service] ISender sender)
        {
            var userId = claimsPrincipal.FindFirstValue(ClaimTypes.NameIdentifier);

            var input = new CreateResumeCommand(userId, name, templateId);

            var result = await sender.Send(input);

            var payload = result.Then(resume => new CreateResumePayload(new Resume(resume.Id.Value.ToString(), resume.UserId.Value, resume.Name, resume.TemplateId.Value.ToString(), new PersonalDetails(
                resume.PersonalDetails.JobTitle, resume.PersonalDetails.Photo,
                resume.PersonalDetails.FirstName, resume.PersonalDetails.LastName,
                resume.PersonalDetails.Email?.Value, resume.PersonalDetails.Phone,
                resume.PersonalDetails.Address, resume.PersonalDetails.PostalCode,
                resume.PersonalDetails.City, resume.PersonalDetails.Country), resume.CreatedAt, resume.UpdatedAt)));

            return MutationResult.From(payload);
        }

        [Error<ValidationError>]
        [Error<NotFoundError>]
        [Authorize]
        public static async Task<FieldResult<DeleteResumePayload>> DeleteResumeAsync([GraphQLType(typeof(NonNullType<IdType>))] string resumeId, [Service] ISender sender)
        {
            var input = new DeleteResumeCommand(resumeId);

            var result = await sender.Send(input);

            var payload = result.Then(_ => new DeleteResumePayload(true));

            return MutationResult.From(payload);
        }

        [Error<ValidationError>]
        [Error<NotFoundError>]
        // [Authorize]
        public static async Task<FieldResult<DuplicateResumePayload>> DuplicateResumeAsync(ClaimsPrincipal claimsPrincipal, [GraphQLType(typeof(NonNullType<IdType>))] string resumeId, [GraphQLType(typeof(NonNullType<IdType>))][Service] ISender sender)
        {
            var userId = claimsPrincipal.FindFirstValue(ClaimTypes.NameIdentifier);

            var input = new DuplicateResumeCommand(resumeId, userId);

            var result = await sender.Send(input);

            var payload = result.Then(resume => new DuplicateResumePayload(new Resume(resume.Id.Value.ToString(), resume.UserId.Value, resume.Name, resume.TemplateId.Value.ToString(), new PersonalDetails(resume.PersonalDetails.JobTitle,
                                                      resume.PersonalDetails.Photo,
                                                      resume.PersonalDetails.FirstName,
                                                      resume.PersonalDetails.LastName,
                                                      resume.PersonalDetails.Email?.Value,
                                                      resume.PersonalDetails.Phone,
                                                      resume.PersonalDetails.Address,
                                                      resume.PersonalDetails.PostalCode,
                                                      resume.PersonalDetails.City,
                                                      resume.PersonalDetails.Country), resume.CreatedAt, resume.UpdatedAt)));

            return MutationResult.From(payload);
        }
    }
}