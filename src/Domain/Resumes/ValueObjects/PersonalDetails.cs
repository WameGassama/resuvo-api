using System.Text.RegularExpressions;
using Domain.Common.Models;
using Throw;

namespace Domain.Resumes.ValueObjects
{
    public sealed class PersonalDetails : ValueObject
    {
        public string? JobTitle { get; private set; }
        public string? Photo { get; private set; }
        public string? FirstName { get; private set; }
        public string? LastName { get; private set; }
        public Email? Email { get; private set; }
        public string? Phone { get; private set; }
        public string? Address { get; private set; }
        public string? PostalCode { get; private set; }
        public string? City { get; private set; }
        public string? Country { get; private set; }

        private PersonalDetails(string? jobTitle,
                                string? photo,
                                string? firstName,
                                string? lastName,
                                Email? email,
                                string? phone,
                                string? address,
                                string? postalCode,
                                string? city,
                                string? country)
        {
            JobTitle = jobTitle;
            Photo = photo;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Phone = phone;
            Address = address;
            PostalCode = postalCode;
            City = city;
            Country = country;
        }

        public static PersonalDetails Create(string? jobTitle,
                                             string? photo,
                                             string? firstName,
                                             string? lastName,
                                             Email? email,
                                             string? phone,
                                             string? address,
                                             string? postalCode,
                                             string? city,
                                             string? country)
        {

            return new(jobTitle,
                       photo,
                       firstName,
                       lastName,
                       email,
                       phone,
                       address,
                       postalCode,
                       city,
                       country);
        }


        protected override IEnumerable<object?> GetEqualityComponents()
        {
            yield return JobTitle;
            yield return Photo;
            yield return FirstName;
            yield return LastName;
            yield return Email;
            yield return Phone;
            yield return Address;
            yield return PostalCode;
            yield return City;
            yield return Country;
        }
    }
}