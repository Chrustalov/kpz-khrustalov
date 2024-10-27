using Microsoft.EntityFrameworkCore;
using HospitalApi.Models;

namespace HospitalApi.Repositories
{
    public class PatientRepository : Repository<Patient>, IPatientRepository
    {
        private readonly HospitalContext _context;

        public PatientRepository(HospitalContext context) : base(context) 
        {
            _context = context;
        }

        public new async Task AddAsync(Patient patient)
        {
            _context.Patients.Add(patient);
            await _context.SaveChangesAsync();
        }

        public new async Task<IEnumerable<Patient>> GetAllAsync()
        {
            return await _context.Patients
                .Include(c => c.ContactInformation)
                .ToListAsync();
        }

        public new async Task<Patient?> GetByIdAsync(int id)
        {
            return await _context.Patients
                .Include(c => c.ContactInformation)
                .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
