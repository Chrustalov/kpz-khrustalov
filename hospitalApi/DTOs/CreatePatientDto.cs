using System.ComponentModel.DataAnnotations;

namespace HospitalApi.DTOs
{
    public class CreatePatientDto 
    {
        [Required(ErrorMessage = "Medical History is required.")]
        public string MedicalHistory { get; set; } = null!;

        public CreateContactInformationDto ContactInformation { get; set; } = null!;
    }
}
