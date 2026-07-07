using Application.Common.Errors;
using Application.Resumes;
using Application.Resumes.Queries.GetResume;
using Application.Resumes.Queries.GetResumes;
using ErrorOr;
using GraphQL.Common;
using MediatR;

namespace GraphQL.Queries
{
    [QueryType]
    public static partial class ResumeQueries
    {
        public static async Task<FieldResult<GetResumePayload, NotFoundError>> GetResumeAsync(Guid id, [Service] ISender sender)
        {
            var query = new GetResumeQuery(id);

            var result = await sender.Send(query);

            foreach (var error in result.Errors)
            {
                if (error.Type == ErrorType.NotFound)
                {
                    return new NotFoundError(error.Description);
                }
            }

            return result.Value;
        }

        public static async Task<IReadOnlyList<ResumeDTO>> GetResumesAsync(Guid userId, [Service] ISender sender)
        {
            var query = new GetResumesQuery(userId);

            var result = await sender.Send(query);

            return result.Value;
        }
    }
}
