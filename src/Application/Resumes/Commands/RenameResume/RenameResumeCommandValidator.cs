using FluentValidation;

namespace Application.Resumes.Commands.RenameResume
{
    public class RenameResumeCommandValidator : AbstractValidator<RenameResumeCommand>
    {
        public RenameResumeCommandValidator()
        {
            RuleFor(x => x.ResumeId)
                    .Cascade(CascadeMode.Stop)
                    .NotEmpty()
                    .WithMessage("Resume ID cannot be empty.")
                    .Must(id => Guid.TryParse(id, out _))
                    .WithMessage("Resume ID must be a valid UUID.");
            RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Name cannot be empty.");
        }
    }
}