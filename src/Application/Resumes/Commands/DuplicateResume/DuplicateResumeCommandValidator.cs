using FluentValidation;

namespace Application.Resumes.Commands.DuplicateResume
{
    public class DuplicateResumeCommandValidator : AbstractValidator<DuplicateResumeCommand>
    {
        public DuplicateResumeCommandValidator()
        {
            RuleFor(x => x.ResumeId)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Resume ID cannot be empty.")
                .Must(id => Guid.TryParse(id, out _)).WithMessage("Resume ID must be a valid UUID.");
            RuleFor(x => x.UserId).NotEmpty()
                .WithMessage("User ID cannot be empty.")
                .Length(32)
                .WithMessage("User ID must be 32 characters.");
        }
    }
}
