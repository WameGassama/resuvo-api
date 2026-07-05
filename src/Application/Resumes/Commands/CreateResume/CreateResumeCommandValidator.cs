using Domain;
using FluentValidation;

namespace Application.Resumes.Commands.CreateResume
{
    public class CreateResumeCommandValidator : AbstractValidator<CreateResumeCommand>
    {
        public CreateResumeCommandValidator()
        {
            RuleFor(x => x.UserId).NotEmpty().WithMessage("User ID must be a valid UUID");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name cannot be empty.");
            RuleFor(x => x.TemplateId).NotEmpty().WithMessage("Template ID cannot be empty.");
        }
    }
}