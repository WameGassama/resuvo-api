using System.Runtime;
using Application.Common.Errors;
using Application.Resumes.Queries.GetResume;
using Application.Resumes.Queries.GetResumes;
using ErrorOr;
using GraphQL.Common;
using GraphQL.Contracts.Models;
using MediatR;

namespace GraphQL.Queries
{
    [QueryType]
    public static partial class ResumeQueries
    {
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

            return new Resume(result.Value.Id.Value.ToString(), result.Value.UserId.Value, result.Value.Name, result.Value.TemplateId.Value.ToString(), result.Value.CreatedAt, result.Value.UpdatedAt);
        }

        public static async Task<IReadOnlyList<Resume>> GetResumesAsync([GraphQLType(typeof(NonNullType<IdType>))] string userId, [Service] ISender sender)
        {
            var query = new GetResumesQuery(userId);

            var result = await sender.Send(query);

            return result.Value.Select(resume => new Resume(resume.Id.Value.ToString(), resume.UserId.Value, resume.Name, resume.TemplateId.Value.ToString(), resume.CreatedAt, resume.UpdatedAt)).ToList();
        }
    }
}
