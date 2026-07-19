using FluentValidation;

namespace Application.Resumes.Queries.GetResume
{
    public class GetResumeQueryValidator : AbstractValidator<GetResumeQuery>
    {
        public GetResumeQueryValidator()
        {
            RuleFor(x => x.Id)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Resume ID cannot be empty.")
                .Must(id => Guid.TryParse(id, out _)).WithMessage("Resume ID must be a valid UUID.");
        }
    }
}
