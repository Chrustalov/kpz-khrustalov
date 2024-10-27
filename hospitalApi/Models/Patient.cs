namespace HospitalApi.Models;

public partial class Patient
{
    public long Id { get; set; }

    public string? MedicalHistory { get; set; }

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    public virtual ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();

    public virtual ContactInformation? ContactInformation { get; set; }
}
