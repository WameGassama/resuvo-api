using System.Runtime;
using System.Security.Claims;
using Application.Common.Errors;
using Application.Resumes.Queries.GetResume;
using Application.Resumes.Queries.GetResumes;
using ErrorOr;
using GraphQL.Common;
using GraphQL.Contracts.Models;
using HotChocolate.Authorization;
using MediatR;

namespace GraphQL.Queries
{
    [QueryType]
    public static partial class ResumeQueries
    {
        [Authorize]
        public static async Task<FieldResult<Resume, NotFoundError, ValidationError>> GetResumeAsync([GraphQLType(typeof(NonNullType<IdType>))] string id, [Service] ISender sender)
        {
            var query = new GetResumeQuery(id);

            var result = await sender.Send(query);

            foreach (var error in result.Errors)
            {
                if (error.Type == ErrorType.NotFound)
                {
                    return new NotFoundError(error.Description);
                }

                if (error.Type == ErrorType.Validation)
                {
                    return new ValidationError(error.Description);
                }
            }

            return new Resume(result.Value.Id.Value.ToString(), result.Value.UserId.Value, result.Value.Name, result.Value.TemplateId.Value.ToString(), new PersonalDetails(result.Value.PersonalDetails.JobTitle,
                                                      result.Value.PersonalDetails.Photo,
                                                      result.Value.PersonalDetails.FirstName,
                                                      result.Value.PersonalDetails.LastName,
                                                      result.Value.PersonalDetails.Email?.Value,
                                                      result.Value.PersonalDetails.Phone,
                                                      result.Value.PersonalDetails.Address,
                                                      result.Value.PersonalDetails.PostalCode,
                                                      result.Value.PersonalDetails.City,
                                                      result.Value.PersonalDetails.Country), result.Value.CreatedAt, result.Value.UpdatedAt);
        }

        [Authorize]
        public static async Task<IReadOnlyList<Resume>> GetResumesAsync([GraphQLType(typeof(NonNullType<IdType>))] string userId, [Service] ISender sender)
        {
            var query = new GetResumesQuery(userId);

            var result = await sender.Send(query);

            return result.Value.Select(resume => new Resume(resume.Id.Value.ToString(), resume.UserId.Value, resume.Name, resume.TemplateId.Value.ToString(), new PersonalDetails(resume.PersonalDetails.JobTitle,
                                                      resume.PersonalDetails.Photo,
                                                      resume.PersonalDetails.FirstName,
                                                      resume.PersonalDetails.LastName,
                                                      resume.PersonalDetails.Email?.Value,
                                                      resume.PersonalDetails.Phone,
                                                      resume.PersonalDetails.Address,
                                                      resume.PersonalDetails.PostalCode,
                                                      resume.PersonalDetails.City,
                                                      resume.PersonalDetails.Country), resume.CreatedAt, resume.UpdatedAt)).ToList();
        }
    }
}
