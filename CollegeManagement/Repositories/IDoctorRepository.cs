using CollegeManagement.Models;

namespace CollegeManagement.Repositories
{
    public interface IDoctorRepository
    {
        Task<Doctor?> GetDoctorDashboardDataAsync(long doctorId);
        Task<IEnumerable<Subject>?> GetSubjectDataAsync(long doctorId);

    }
}
