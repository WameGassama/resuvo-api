using Application.Common.Interfaces;
using Domain;
using Domain.Resumes.ValueObjects;
using ErrorOr;
using MediatR;

namespace Application.Resumes.Commands.UpdatePersonalDetails
{
    public class UpdatePersonalDetailsCommandHandler : IRequestHandler<UpdatePersonalDetailsCommand, ErrorOr<Resume>>
    {
        private readonly IResumeRepository _resumeRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdatePersonalDetailsCommandHandler(IResumeRepository resumeRepository, IUnitOfWork unitOfWork)
        {
            _resumeRepository = resumeRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ErrorOr<Resume>> Handle(UpdatePersonalDetailsCommand request, CancellationToken cancellationToken)
        {
            var resume = await _resumeRepository.GetResumeByIdAsync(ResumeId.Create(Guid.Parse(request.ResumeId)));

            if (resume is null)
            {
                return Error.NotFound(code: "RESUME_NOT_FOUND", description: "The resume could not be found.");
            }

            var currentDetails = resume.PersonalDetails;

            var personalDetails = PersonalDetails.Create(
                request.JobTitle ?? currentDetails.JobTitle,
                request.Photo ?? currentDetails.Photo,
                request.FirstName ?? currentDetails.FirstName,
                request.LastName ?? currentDetails.LastName,
                Email.Create(request.Email ?? currentDetails.Email.Value),
                request.Phone ?? currentDetails.Phone,
                request.Address ?? currentDetails.Address,
                request.PostalCode ?? currentDetails.PostalCode,
                request.City ?? currentDetails.City,
                request.Country ?? currentDetails.Country);

            resume.UpdatePersonalDetails(personalDetails);

            await _resumeRepository.UpdateAsync(resume);

            await _unitOfWork.CommitChangesAsync();

            return resume;
        }
    }
}