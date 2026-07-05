using Application.Common.Errors;
using Application.Resumes.Queries.GetResume;
using Domain;
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
    }
}
