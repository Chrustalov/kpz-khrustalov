using Microsoft.EntityFrameworkCore;
using HospitalApi.Models;

namespace HospitalApi.Repositories
{
    public class DoctorRepository : Repository<Doctor>, IDoctorRepository
    {
        private readonly HospitalContext _context;

        public DoctorRepository(HospitalContext context) : base(context) 
        {
            _context = context;
        }

        public new async Task AddAsync(Doctor doctor)
        {
            _context.Doctors.Add(doctor);
            await _context.SaveChangesAsync();
        }

        public new async Task<IEnumerable<Doctor>> GetAllAsync()
        {
            return await _context.Doctors
                .Include(c => c.ContactInformation)
                .ToListAsync();
        }

        public new async Task<Doctor?> GetByIdAsync(int id)
        {
            return await _context.Doctors
                .Include(c => c.ContactInformation)
                .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
