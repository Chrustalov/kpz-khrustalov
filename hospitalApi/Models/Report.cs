namespace HospitalApi.Models;

public partial class Report
{
    public long Id { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public int AppointmentsCount { get; set; } = 0;

    public int PatientsCount { get; set; } = 0;

    public decimal FeedbackScore { get; set; } = 0;

    public long DoctorId { get; set; }

    public virtual Doctor Doctor { get; set; } = null!;
}
