using Application.Common.Errors;
using ErrorOr;

namespace GraphQL.Common
{
    public static class MutationResult
    {
        public static FieldResult<T> From<T>(ErrorOr<T> result)
        {
            if (!result.IsError)
            {
                return result.Value;
            }

            var errors = new List<object>();

            foreach (var error in result.Errors)
            {
                switch (error.Type)
                {
                    case ErrorType.Validation:
                        errors.Add(new ValidationError(error.Description));
                        break;

                    case ErrorType.NotFound:
                        errors.Add(new NotFoundError(error.Description));
                        break;
                }
            }

            return new FieldResult<T>(errors);
        }
    }
}
