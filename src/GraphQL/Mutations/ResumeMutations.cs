using System.Security.Claims;
using Application.Common.Errors;
using Application.Resumes.Commands.CreateResume;
using Application.Resumes.Commands.DeleteResume;
using Application.Resumes.Commands.DuplicateResume;
using Application.Resumes.Commands.RetitleResume;
using Application.Resumes.Commands.UpdatePersonalDetails;
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
        public static async Task<FieldResult<CreateResumePayload>> CreateResumeAsync(ClaimsPrincipal claimsPrincipal, string title, [GraphQLType(typeof(NonNullType<IdType>))] string templateId, [Service] ISender sender)
        {
            var userId = claimsPrincipal.FindFirstValue(ClaimTypes.NameIdentifier);

            var input = new CreateResumeCommand(userId, title, templateId);

            var result = await sender.Send(input);

            var payload = result.Then(resume => new CreateResumePayload(new Resume(resume.Id.Value.ToString(), resume.UserId.Value, resume.Title, resume.TemplateId.Value.ToString(), new PersonalDetails(
                resume.PersonalDetails.JobTitle, resume.PersonalDetails.Photo,
                resume.PersonalDetails.FirstName, resume.PersonalDetails.LastName,
                resume.PersonalDetails.Email.Value, resume.PersonalDetails.Phone,
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
        [Authorize]
        public static async Task<FieldResult<DuplicateResumePayload>> DuplicateResumeAsync(ClaimsPrincipal claimsPrincipal, [GraphQLType(typeof(NonNullType<IdType>))] string resumeId, [Service] ISender sender)
        {
            var userId = claimsPrincipal.FindFirstValue(ClaimTypes.NameIdentifier);

            var input = new DuplicateResumeCommand(resumeId, userId);

            var result = await sender.Send(input);

            var payload = result.Then(resume => new DuplicateResumePayload(new Resume(resume.Id.Value.ToString(), resume.UserId.Value, resume.Title, resume.TemplateId.Value.ToString(), new PersonalDetails(resume.PersonalDetails.JobTitle,
                                                      resume.PersonalDetails.Photo,
                                                      resume.PersonalDetails.FirstName,
                                                      resume.PersonalDetails.LastName,
                                                      resume.PersonalDetails.Email.Value,
                                                      resume.PersonalDetails.Phone,
                                                      resume.PersonalDetails.Address,
                                                      resume.PersonalDetails.PostalCode,
                                                      resume.PersonalDetails.City,
                                                      resume.PersonalDetails.Country), resume.CreatedAt, resume.UpdatedAt)));

            return MutationResult.From(payload);
        }

        [Error<ValidationError>]
        [Error<NotFoundError>]
        [Authorize]
        public static async Task<FieldResult<RetitleResumePayload>> RetitleResumeAsync([GraphQLType(typeof(NonNullType<IdType>))] string resumeId, string title, [Service] ISender sender)
        {
            var input = new RetitleResumeCommand(resumeId, title);

            var result = await sender.Send(input);

            var payload = result.Then(resume => new RetitleResumePayload(new Resume(resume.Id.Value.ToString(), resume.UserId.Value, resume.Title, resume.TemplateId.Value.ToString(), new PersonalDetails(resume.PersonalDetails.JobTitle,
                                                      resume.PersonalDetails.Photo,
                                                      resume.PersonalDetails.FirstName,
                                                      resume.PersonalDetails.LastName,
                                                      resume.PersonalDetails.Email.Value,
                                                      resume.PersonalDetails.Phone,
                                                      resume.PersonalDetails.Address,
                                                      resume.PersonalDetails.PostalCode,
                                                      resume.PersonalDetails.City,
                                                      resume.PersonalDetails.Country), resume.CreatedAt, resume.UpdatedAt)));

            return MutationResult.From(payload);
        }

        [Error<ValidationError>]
        [Error<NotFoundError>]
        [Authorize]
        public static async Task<FieldResult<UpdatePersonalDetailsPayload>> UpdatePersonalDetailsAsync(
            [GraphQLType(typeof(NonNullType<IdType>))] string resumeId,
            string? jobTitle,
            string? photo,
            string? firstName,
            string? lastName,
            string? email,
            string? phone,
            string? address,
            string? postalCode,
            string? city,
            string? country,
            [Service] ISender sender)
        {
            var input = new UpdatePersonalDetailsCommand(resumeId, jobTitle, photo, firstName, lastName, email, phone, address, postalCode, city, country);

            var result = await sender.Send(input);

            var payload = result.Then(resume => new UpdatePersonalDetailsPayload(new Resume(resume.Id.Value.ToString(), resume.UserId.Value, resume.Title, resume.TemplateId.Value.ToString(), new PersonalDetails(resume.PersonalDetails.JobTitle,
                                                      resume.PersonalDetails.Photo,
                                                      resume.PersonalDetails.FirstName,
                                                      resume.PersonalDetails.LastName,
                                                      resume.PersonalDetails.Email.Value,
                                                      resume.PersonalDetails.Phone,
                                                      resume.PersonalDetails.Address,
                                                      resume.PersonalDetails.PostalCode,
                                                      resume.PersonalDetails.City,
                                                      resume.PersonalDetails.Country), resume.CreatedAt, resume.UpdatedAt)));

            return MutationResult.From(payload);
        }
    }
}