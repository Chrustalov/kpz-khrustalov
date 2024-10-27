using System.ComponentModel.DataAnnotations;

namespace HospitalApi.DTOs
{
    public class CreateDoctorDto 
    {
        [Required(ErrorMessage = "Hire date is required.")]
        public DateTime HireDate { get; set; }

        [Required(ErrorMessage = "Department ID is required.")]
        public long DepartmentId { get; set; }

        [Required(ErrorMessage = "Status is required.")]
        [StringLength(50, ErrorMessage = "Status cannot exceed 50 characters.")]
        public string Status { get; set; } = null!;

        [Required(ErrorMessage = "Position is required.")]
        [StringLength(100, ErrorMessage = "Position cannot exceed 100 characters.")]
        public string Position { get; set; } = null!;

        [Required(ErrorMessage = "Specialization is required.")]
        [StringLength(100, ErrorMessage = "Specialization cannot exceed 100 characters.")]
        public string Specialization { get; set; } = null!;

        [Range(0, int.MaxValue, ErrorMessage = "Experience cannot be negative.")]
        public int Experience { get; set; } = 0;

        public CreateContactInformationDto ContactInformation { get; set; } = null!;
    }
}
