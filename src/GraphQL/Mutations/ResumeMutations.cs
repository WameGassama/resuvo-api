using Application.Common.Errors;
using Application.Resumes.Commands.CreateResume;
using Application.Resumes.Commands.DeleteResume;
using GraphQL.Common;
using MediatR;

namespace GraphQL.Mutations
{
    [MutationType]
    public static partial class ResumeMutations
    {
        [Error<ValidationError>]
        [Error<NotFoundError>]
        public static async Task<FieldResult<CreateResumePayload>> CreateResumeAsync(Guid userId, string name, string templateId, [Service] ISender sender)
        {
            var input = new CreateResumeCommand(userId, name, templateId);

            var result = await sender.Send(input);

            return MutationResult.From(result);
        }

        [Error<NotFoundError>]
        public static async Task<FieldResult<DeleteResumePayload>> DeleteResumeAsync(Guid id, [Service] ISender sender)
        {
            var input = new DeleteResumeCommand(id);

            var result = await sender.Send(input);

            return MutationResult.From(result);
        }
    }
}