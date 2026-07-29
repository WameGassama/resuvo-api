using FluentValidation;

namespace Application.Resumes.Commands.UpdatePersonalDetails
{
    public class UpdatePersonalDetailsCommandValidator : AbstractValidator<UpdatePersonalDetailsCommand>
    {
        public UpdatePersonalDetailsCommandValidator()
        {
            RuleFor(x => x.ResumeId)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("Resume ID cannot be empty.")
                .Must(id => Guid.TryParse(id, out _))
                .WithMessage("Resume ID must be a valid UUID.");

            RuleFor(x => x.Email)
                .Matches(@"^[^@\s]+@[^@\s]+\.[^@\s]+$")
                .WithMessage("Email address is not valid.")
                .When(x => x.Email is not null);
        }
    }
}