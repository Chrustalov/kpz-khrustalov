namespace HospitalApi.DTOs 
{
    public class PatientDto
    {
        public long Id { get; set; }
        public string? MedicalHistory { get; set; } = null!;

        public ContactInformationDto ContactInformation { get; set; } = null!;
    }
}

