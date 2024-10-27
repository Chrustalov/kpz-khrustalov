using System.ComponentModel.DataAnnotations;

namespace HospitalApi.DTOs
{
    public class CreateContactInformationDto
    {
        [Required(ErrorMessage = "First name is required.")]
        [StringLength(55, ErrorMessage = "First name cannot exceed 55 characters.")]
        public string FirstName { get; set; } = null!;

        [Required(ErrorMessage = "Last name is required.")]
        [StringLength(55, ErrorMessage = "Last name cannot exceed 55 characters.")]
        public string LastName { get; set; } = null!;

        [Required(ErrorMessage = "Birth date is required.")]
        public DateTime BirthOfDate { get; set; }

        [Required(ErrorMessage = "Phone number is required.")]
        [StringLength(30, ErrorMessage = "Phone number cannot exceed 30 characters.")]
        public string PhoneNumber { get; set; } = null!;

        [StringLength(255, ErrorMessage = "Additional information cannot exceed 255 characters.")]
        public string AdditionalInformation { get; set; } = null!;
    }
}
