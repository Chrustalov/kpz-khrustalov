namespace HospitalApi.Models;

public partial class Feedback
{
    public long Id { get; set; }

    public decimal Score { get; set; }

    public string? Comment { get; set; }

    public long PatientId { get; set; }

    public long AppointmentId { get; set; }

    public virtual Patient Patient { get; set; } = null!;

    public virtual Appointment Appointment { get; set; } = null!;
}
