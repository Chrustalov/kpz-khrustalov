using Microsoft.EntityFrameworkCore;
using HospitalApi.Models;

namespace HospitalApi.Repositories
{
    public class DepartmentRepository : Repository<Department>, IDepartmentRepository
    {
        private readonly HospitalContext _context;

        public DepartmentRepository(HospitalContext context) : base(context) 
        {
            _context = context;
        }

        public new async Task AddAsync(Department department)
        {
            _context.Departments.Add(department);
            await _context.SaveChangesAsync();
        }

        public new async Task<IEnumerable<Department>> GetAllAsync()
        {
            return await _context.Departments.ToListAsync();
        }

        public new async Task<Department?> GetByIdAsync(int id)
        {
            return await _context.Departments.FirstOrDefaultAsync(c => c.Id == id);
        }

        public new async Task UpdateAsync(Department department)
        {
            _context.Departments.Update(department);
            await _context.SaveChangesAsync();
        }
    }
}
