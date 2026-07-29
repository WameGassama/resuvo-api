using Domain;
using FluentValidation;

namespace Application.Resumes.Commands.CreateResume
{
    public class CreateResumeCommandValidator : AbstractValidator<CreateResumeCommand>
    {
        public CreateResumeCommandValidator()
        {
            RuleFor(x => x.UserId).NotEmpty()
                .WithMessage("User ID cannot be empty.")
                .Length(32)
                .WithMessage("User ID must be 32 characters.");
            RuleFor(x => x.Title).NotEmpty().WithMessage("Title cannot be empty.");
            RuleFor(x => x.TemplateId)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Template ID cannot be empty.")
                .Must(id => Guid.TryParse(id, out _)).WithMessage("Template ID must be a valid UUID.");
        }
    }
}