using CollegeManagement.Data;
using CollegeManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace CollegeManagement.Repositories
{
    public class DoctorRepository : IDoctorRepository

    {
        private readonly CollegeManagementDbContext _context;
        public DoctorRepository(CollegeManagementDbContext context)
        {
            _context = context;
        }
        public async Task<Doctor?> GetDoctorDashboardDataAsync(long doctorId)
        {
            return await _context.Doctors
       .Include(d => d.SubjectDoctors)
                .ThenInclude(sd => sd.Subject)
            .Include(d => d.SubjectDoctors)
                .ThenInclude(sd => sd.Classroom)
            .FirstOrDefaultAsync(d => d.Id == doctorId);
        }
    }
}
