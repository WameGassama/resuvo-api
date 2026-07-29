using FluentValidation;

namespace Application.Resumes.Commands.RetitleResume
{
    public class RetitleResumeCommandValidator : AbstractValidator<RetitleResumeCommand>
    {
        public RetitleResumeCommandValidator()
        {
            RuleFor(x => x.ResumeId)
                    .Cascade(CascadeMode.Stop)
                    .NotEmpty()
                    .WithMessage("Resume ID cannot be empty.")
                    .Must(id => Guid.TryParse(id, out _))
                    .WithMessage("Resume ID must be a valid UUID.");
            RuleFor(x => x.Title)
            .NotEmpty()
            .WithMessage("Title cannot be empty.");
        }
    }
}
