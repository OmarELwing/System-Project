using CollegeManagement.Data;
using CollegeManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace CollegeManagement.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly CollegeManagementDbContext _context;

        public StudentRepository(CollegeManagementDbContext context)
        {
            _context = context;
        }

        private IQueryable<Student> GetStudentData()
        {
            return _context.Students
                .Include(s => s.Enrollments)
                    .ThenInclude(e => e.Subject)
                        .ThenInclude(s => s.SubjectDoctors)
                            .ThenInclude(sd => sd.Doctor)
                .Include(s => s.Enrollments)
                    .ThenInclude(e => e.Subject)
                        .ThenInclude(s => s.SubjectDoctors)
                            .ThenInclude(sd => sd.Classroom);
        }

        public async Task<Student?> GetStudentScheduleDataAsync(long studentId)
        {
            return await GetStudentData()
                .FirstOrDefaultAsync(s => s.Id == studentId);
        }

        public async Task<Student?> GetStudentSubjectsDataAsync(long studentId)
        {
            return await GetStudentData()
                .FirstOrDefaultAsync(s => s.Id == studentId);
        }

        public async Task<Student?> GetStudentSubjectDetailsDataAsync(long studentId, long subjectId)
        {
            return await GetStudentData()
                .FirstOrDefaultAsync(s =>
                    s.Id == studentId &&
                    s.Enrollments.Any(e => e.SubjectId == subjectId));
        }

        public async Task<Student?> GetStudentDashboardDataAsync(long studentId)
        {
            return await GetStudentData()
                .FirstOrDefaultAsync(s => s.Id == studentId);
        }
    }
}