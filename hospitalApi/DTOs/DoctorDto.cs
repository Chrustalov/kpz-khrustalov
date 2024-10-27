namespace HospitalApi.DTOs 
{
    public class DoctorDto
    {
        public long Id { get; set; }
        public DateTime HireDate { get; set; }
        public long DepartmentId { get; set; }
        public string Status { get; set; } = null!;
        public string Position { get; set; } = null!;
        public string Specialization { get; set; } = null!;
        public int Experience { get; set; } = 0;

        public ContactInformationDto ContactInformation { get; set; } = null!;
    }
}

