using FluentValidation;

namespace Application.Resumes.Commands.DeleteResume
{
    public class DeleteResumeCommandValidator : AbstractValidator<DeleteResumeCommand>
    {
        public DeleteResumeCommandValidator()
        {
            RuleFor(x => x.Id)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Resume ID cannot be empty.")
                .Must(id => Guid.TryParse(id, out _)).WithMessage("Resume ID must be a valid UUID.");
        }
    }
}
