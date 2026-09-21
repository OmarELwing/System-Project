using CollegeManagement.DTOs;
using CollegeManagement.Repositories;

namespace CollegeManagement.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository _doctorRepository;
        public DoctorService(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        public async Task<DoctorDashboardDto?> GetDashboardAsync(long doctorId)
        {
            var doctor = await _doctorRepository.GetDoctorDashboardDataAsync(doctorId);
            if (doctor == null)
            {
                return null;
            }
            string today = DateTime.Today.DayOfWeek
            .ToString()
            .ToUpperInvariant();
            var dashboard = new DoctorDashboardDto
            {
                DoctorName = $"{doctor.FirstName} {doctor.LastName}",
                SubjectsCount = doctor.SubjectDoctors
                           .Select(sd => sd.SubjectId)
                           .Distinct()
                           .Count()
            };
            foreach (var subjectDoctor in doctor.SubjectDoctors)
            {
                if (today == subjectDoctor.DayOfWeek)
                {
                    dashboard.TodaySchedule.Add(new TodayScheduleDto
                    {
                        SubjectName = subjectDoctor.Subject.Name,
                        Classroom = subjectDoctor.Classroom?.Name ?? "Not Assigned",
                        StartTime = subjectDoctor.StartTime,
                        EndTime = subjectDoctor.EndTime
                    });
                }
            }
            return dashboard;
        }

        public async Task<IEnumerable<SubjectDto>?> GetSubjectAsync(long doctorId)
        {
            var subjects = await _doctorRepository.GetSubjectDataAsync(doctorId);
            if (subjects == null)
            {
                return null;
            }
            var subjectDtos =  subjects.Select(s => new SubjectDto
            {
                Code = s.Code,
                Name = s.Name,
                Description = s.Description
            });
            return subjectDtos;
        }
    }
}
