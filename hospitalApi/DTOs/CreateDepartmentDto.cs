using System.ComponentModel.DataAnnotations;

namespace HospitalApi.DTOs
{
    public class CreateDepartmentDto
    {
        [Required(ErrorMessage = "Name is required.")]
        [StringLength(45, ErrorMessage = "Name cannot exceed 50 characters.")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "Location is required.")]
        [StringLength(45, ErrorMessage = "Location cannot exceed 50 characters.")]
        public string Location { get; set; } = null!;
    }
}
