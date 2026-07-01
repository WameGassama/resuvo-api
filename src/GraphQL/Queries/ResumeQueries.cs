using Application.Resumes.Queries.GetResume;
using Domain;
using ErrorOr;
using MediatR;

namespace GraphQL.Queries
{
    [QueryType]
    public static partial class ResumeQueries
    {
        public static async Task<GetResumePayload> GetResumeAsync(GetResumeQuery input, [Service] ISender sender)
        {
            var result = await sender.Send(input);

            return result.MatchFirst(
                payload => payload,
                error => throw new GraphQLException(ErrorBuilder.New()
                .SetMessage(error.Description)
                .SetCode(error.Code)
                .Build())
            );
        }
    }
}
