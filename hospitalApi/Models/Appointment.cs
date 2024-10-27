namespace HospitalApi.Models;

public class Appointment
{
    public long Id { get; set; }

    public DateTime AppointmentDate { get; set; }

    public TimeSpan StartTime { get; set; }

    public TimeSpan EndTime { get; set; }

    public long DoctorId { get; set; }

    public long PatientId { get; set; }

    public string Reason { get; set; } = null!;

    public virtual Patient? Patient { get; set; }

    public virtual Doctor? Doctor { get; set; }

    public virtual Feedback? Feedback { get; set; }
}
