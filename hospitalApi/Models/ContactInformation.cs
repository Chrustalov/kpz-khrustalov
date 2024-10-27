namespace HospitalApi.Models;

public partial class ContactInformation
{
    public long Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public DateTime BirthOfDate { get; set; }

    public string PhoneNumber { get; set; } = null!;

    public string AdditionalInformation { get; set; } = null!;

    public long? PatientId { get; set; }

    public long? DoctorId { get; set; }

    public virtual Patient? Patient { get; set; }

    public virtual Doctor? Doctor { get; set; }
}
