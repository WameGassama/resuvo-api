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
                request.JobTitle == "" ? null : request.JobTitle ?? currentDetails.JobTitle,
                request.Photo == "" ? null : request.Photo ?? currentDetails.Photo,
                request.FirstName == "" ? null : request.FirstName ?? currentDetails.FirstName,
                request.LastName == "" ? null : request.LastName ?? currentDetails.LastName,
                Email.Create(request.Email == "" ? null : request.Email ?? currentDetails.Email?.Value),
                request.Phone == "" ? null : request.Phone ?? currentDetails.Phone,
                request.Address == "" ? null : request.Address ?? currentDetails.Address,
                request.PostalCode == "" ? null : request.PostalCode ?? currentDetails.PostalCode,
                request.City == "" ? null : request.City ?? currentDetails.City,
                request.Country == "" ? null : request.Country ?? currentDetails.Country);

            resume.UpdatePersonalDetails(personalDetails);

            await _resumeRepository.UpdateAsync(resume);

            await _unitOfWork.CommitChangesAsync();

            return resume;
        }
    }
}