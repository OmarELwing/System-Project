using CollegeManagement.DTOs;

namespace CollegeManagement.Services
{
    public interface IDoctorService
    {
        Task<DoctorDashboardDto?> GetDashboardAsync(long doctorId);

    }
}
