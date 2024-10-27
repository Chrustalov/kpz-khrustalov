using Microsoft.EntityFrameworkCore;

namespace HospitalApi.Models;

public partial class HospitalContext : DbContext
{
    public HospitalContext()
    {
    }

    public HospitalContext(DbContextOptions<HospitalContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Doctor> Doctors { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Patient> Patients { get; set; }

    public virtual DbSet<ContactInformation> ContactInformations { get; set; }

    public virtual DbSet<Feedback> Feedbacks { get; set; }

    public virtual DbSet<Report> Reports { get; set; }

    public virtual DbSet<Appointment> Appointments { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("Host=localhost;Database=system_hospital;Username=postgres;Password=ipak21027");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.ToTable("Department");
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Location)
                .HasMaxLength(255)
                .HasColumnName("location");
            entity.HasMany(d => d.Doctors)
                .WithOne(p => p.Department)
                .HasForeignKey(p => p.DepartmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("doctor_fk_department_id");
        });

        modelBuilder.Entity<Doctor>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.ToTable("Doctor");
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.HireDate)
                .HasColumnType("date")
                .HasColumnName("hire_date");
            entity.Property(e => e.DepartmentId)
                .HasColumnName("department_id");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasColumnName("status");
            entity.Property(e => e.Position)
                .HasMaxLength(100)
                .HasColumnName("position");
            entity.Property(e => e.Specialization)
                .HasMaxLength(100)
                .HasColumnName("specialization");
            entity.Property(e => e.Experience)
                .HasDefaultValue(0)
                .HasColumnName("experience");
            entity.HasOne(d => d.Department)
                .WithMany(p => p.Doctors)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("doctor_fk_department_id");
            entity.HasOne(d => d.ContactInformation)
                .WithOne(c => c.Doctor)
                .HasForeignKey<ContactInformation>(c => c.DoctorId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("doctor_fk_contact_information_id");
        });

        modelBuilder.Entity<Patient>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.ToTable("Patient");
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.MedicalHistory)
                .HasColumnType("text")
                .HasColumnName("medical_history");
            entity.HasOne(p => p.ContactInformation)
                .WithOne(c => c.Patient)
                .HasForeignKey<ContactInformation>(c => c.PatientId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("patient_fk_contact_information_id");
            entity.HasMany(p => p.Appointments)
                .WithOne(a => a.Patient)
                .HasForeignKey(a => a.PatientId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("appointment_fk_patient_id");
            entity.HasMany(p => p.Feedbacks)
                .WithOne(f => f.Patient)
                .HasForeignKey(f => f.PatientId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("feedback_fk_patient_id");
        });

        modelBuilder.Entity<ContactInformation>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.ToTable("ContactInformation");
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.FirstName)
                .HasMaxLength(55)
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(55)
                .HasColumnName("last_name");
            entity.Property(e => e.BirthOfDate)
                .HasColumnType("date")
                .HasColumnName("birth_of_date");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(30)
                .HasColumnName("phone_number");
            entity.Property(e => e.AdditionalInformation)
                .HasMaxLength(255)
                .HasColumnName("additional_information");
            entity.HasOne(d => d.Patient)
                .WithOne(p => p.ContactInformation)
                .HasForeignKey<ContactInformation>(d => d.PatientId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("contact_info_fk_patient_id");
            entity.HasOne(d => d.Doctor)
                .WithOne(p => p.ContactInformation)
                .HasForeignKey<ContactInformation>(d => d.DoctorId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("contact_info_fk_doctor_id");
        });

        modelBuilder.Entity<Feedback>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.ToTable("Feedback");
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Score)
                .HasColumnType("decimal(2, 1)")
                .HasColumnName("score");
            entity.Property(e => e.Comment)
                .HasMaxLength(500)
                .HasColumnName("comment");
            entity.HasOne(f => f.Patient)
                .WithMany(p => p.Feedbacks)
                .HasForeignKey(f => f.PatientId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("feedback_fk_patient_id");
            entity.HasOne(f => f.Appointment)
                .WithOne(a => a.Feedback)
                .HasForeignKey<Feedback>(f => f.AppointmentId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("feedback_fk_appointment_id");
        });

        modelBuilder.Entity<Appointment>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.ToTable("Appointment");
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AppointmentDate)
                .HasColumnType("date")
                .HasColumnName("appointment_date");
            entity.Property(e => e.StartTime)
                .HasColumnName("start_time");
            entity.Property(e => e.EndTime)
                .HasColumnName("end_time");
            entity.Property(e => e.DoctorId)
                .HasColumnName("doctor_id");
            entity.Property(e => e.PatientId)
                .HasColumnName("patient_id");
            entity.Property(e => e.Reason)
                .HasMaxLength(255)
                .HasColumnName("reason");
            entity.HasOne(a => a.Feedback)
                .WithOne(f => f.Appointment)
                .HasForeignKey<Feedback>(f => f.AppointmentId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("appointment_fk_feedback_id");
            entity.HasOne(a => a.Patient)
                .WithMany(p => p.Appointments)
                .HasForeignKey(a => a.PatientId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("appointment_fk_patient_id");
            entity.HasOne(a => a.Doctor)
                .WithMany(d => d.Appointments)
                .HasForeignKey(a => a.DoctorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("appointment_fk_doctor_id");
        });

        modelBuilder.Entity<Report>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.ToTable("Report");
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.StartDate)
                .HasColumnType("date")
                .HasColumnName("start_date");
            entity.Property(e => e.EndDate)
                .HasColumnType("date")
                .HasColumnName("end_date");
            entity.Property(e => e.AppointmentsCount)
                .HasDefaultValue(0)
                .HasColumnName("appointments_count");
            entity.Property(e => e.PatientsCount)
                .HasDefaultValue(0)
                .HasColumnName("patients_count");
            entity.Property(e => e.FeedbackScore)
                .HasColumnType("decimal(2, 1)")
                .HasDefaultValue(0)
                .HasColumnName("feedback_score");
            entity.HasOne(r => r.Doctor)
                .WithMany(d => d.Reports)
                .HasForeignKey(r => r.DoctorId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("report_fk_doctor_id");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
