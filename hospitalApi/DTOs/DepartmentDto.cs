namespace HospitalApi.DTOs
{
    public class DepartmentDto
    {
        public long Id { get; set; }

        public string Name { get; set; } = null!;

        public string Location { get; set; } = null!;

        public virtual ICollection<DoctorDto> Doctors { get; set; } = new List<DoctorDto>();
    }
}
