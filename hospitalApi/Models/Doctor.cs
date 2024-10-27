namespace HospitalApi.Models;

public partial class Doctor
{
    public long Id { get; set; }

    public DateTime HireDate { get; set; }

    public long DepartmentId { get; set; }

    public string Status { get; set; } = null!;

    public string Position { get; set; } = null!;

    public string Specialization { get; set; } = null!;

    public int Experience { get; set; } = 0;

    public virtual Department Department { get; set; } = null!;

    public virtual ContactInformation? ContactInformation { get; set; }

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    public virtual ICollection<Report> Reports { get; set; } = new List<Report>();
}
