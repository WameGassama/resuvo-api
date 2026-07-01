using Application.Resumes.Commands.CreateResume;
using Application.Resumes.Commands.DeleteResume;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;

namespace GraphQL.Mutations
{
    [MutationType]
    public static partial class ResumeMutations
    {
        public static async Task<CreateResumePayload> CreateResumeAsync(CreateResumeCommand input, [Service] ISender sender)
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

        public static async Task<DeleteResumePayload> DeleteResumeAsync(DeleteResumeCommand input, [Service] ISender sender)
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