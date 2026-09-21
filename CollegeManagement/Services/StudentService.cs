using CollegeManagement.DTOs;
using CollegeManagement.Models;
using CollegeManagement.Repositories;

namespace CollegeManagement.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        private static readonly string[] Days =
        {
            "SUNDAY",
            "MONDAY",
            "TUESDAY",
            "WEDNESDAY",
            "THURSDAY",
            "FRIDAY",
            "SATURDAY"
        };

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        private string GetStudentName(Student student)
        {
            return $"{student.FirstName} {student.LastName}";
        }

        private string GetDoctorName(Doctor doctor)
        {
            return $"{doctor.FirstName} {doctor.LastName}";
        }

        private string GetClassroomName(SubjectDoctor subjectDoctor)
        {
            return subjectDoctor.Classroom?.Name ?? "Not Assigned";
        }

        public async Task<StudentScheduleDto?> GetScheduleAsync(long studentId)
        {
            var student = await _studentRepository.GetStudentScheduleDataAsync(studentId);

            if (student == null)
            {
                return null;
            }

            var schedule = new StudentScheduleDto
            {
                StudentName = GetStudentName(student),
                Today = DateOnly.FromDateTime(DateTime.Today),
                TodayDay = DateTime.Today.DayOfWeek.ToString().ToUpperInvariant()
            };

            foreach (var day in Days)
            {
                var scheduleDay = new StudentScheduleDayDto
                {
                    Day = day
                };

                foreach (var enrollment in student.Enrollments)
                {
                    foreach (var subjectDoctor in enrollment.Subject.SubjectDoctors)
                    {
                        if (subjectDoctor.DayOfWeek == day)
                        {
                            scheduleDay.Classes.Add(new StudentScheduleClassDto
                            {
                                StartTime = subjectDoctor.StartTime,
                                EndTime = subjectDoctor.EndTime,
                                SubjectName = enrollment.Subject.Name,
                                SubjectCode = enrollment.Subject.Code,
                                DoctorName = GetDoctorName(subjectDoctor.Doctor),
                                Classroom = GetClassroomName(subjectDoctor)
                            });
                        }
                    }
                }

                scheduleDay.Classes = scheduleDay.Classes
                    .OrderBy(c => c.StartTime)
                    .ToList();

                schedule.Days.Add(scheduleDay);
            }

            return schedule;
        }

        public async Task<StudentSubjectsDto?> GetSubjectsAsync(long studentId)
        {
            var student = await _studentRepository.GetStudentSubjectsDataAsync(studentId);

            if (student == null)
            {
                return null;
            }

            var subjects = new List<StudentSubjectDto>();

            foreach (var enrollment in student.Enrollments)
            {
                var subjectDoctor = enrollment.Subject.SubjectDoctors.FirstOrDefault();

                if (subjectDoctor == null)
                {
                    continue;
                }

                subjects.Add(new StudentSubjectDto
                {
                    SubjectName = enrollment.Subject.Name,
                    CreditHours = 3,
                    SubjectCode = enrollment.Subject.Code,
                    DoctorName = GetDoctorName(subjectDoctor.Doctor),
                    Day = subjectDoctor.DayOfWeek,
                    StartTime = subjectDoctor.StartTime,
                    Classroom = GetClassroomName(subjectDoctor)
                });
            }

            return new StudentSubjectsDto
            {
                SubjectsCount = subjects.Count,
                Subjects = subjects
            };
        }

        public async Task<StudentSubjectDetailsDto?> GetSubjectDetailsAsync(long studentId, long subjectId)
        {
            var student = await _studentRepository.GetStudentSubjectDetailsDataAsync(studentId, subjectId);

            if (student == null)
            {
                return null;
            }

            var enrollment = student.Enrollments
                .FirstOrDefault(e => e.SubjectId == subjectId);

            if (enrollment == null)
            {
                return null;
            }

            var subject = enrollment.Subject;

            var result = new StudentSubjectDetailsDto
            {
                SubjectName = subject.Name,
                SubjectCode = subject.Code,
                CreditHours = 3,
                Description = subject.Description ?? "No Description"
            };

            foreach (var subjectDoctor in subject.SubjectDoctors)
            {
                result.Doctors.Add(new StudentSubjectDoctorDto
                {
                    DoctorName = GetDoctorName(subjectDoctor.Doctor),
                    Day = subjectDoctor.DayOfWeek,
                    StartTime = subjectDoctor.StartTime,
                    EndTime = subjectDoctor.EndTime,
                    Classroom = GetClassroomName(subjectDoctor)
                });
            }

            return result;
        }

        public async Task<StudentDashboardDto?> GetDashboardAsync(long studentId)
        {
            var student = await _studentRepository.GetStudentDashboardDataAsync(studentId);

            if (student == null)
            {
                return null;
            }

            var today = DateTime.Now.DayOfWeek.ToString().ToUpperInvariant();
            var currentTime = TimeOnly.FromDateTime(DateTime.Now);

            var upcomingClass = student.Enrollments
                .SelectMany(e => e.Subject.SubjectDoctors.Select(sd => new
                {
                    Subject = e.Subject,
                    SubjectDoctor = sd
                }))
                .Where(x =>
                    x.SubjectDoctor.DayOfWeek == today &&
                    x.SubjectDoctor.StartTime.HasValue &&
                    x.SubjectDoctor.StartTime.Value >= currentTime)
                .OrderBy(x => x.SubjectDoctor.StartTime)
                .FirstOrDefault();

            if (upcomingClass == null)
            {
                return new StudentDashboardDto
                {
                    StudentName = GetStudentName(student),
                    StudentCode = student.StudentCode,
                    TimeUntil = "No upcoming classes",
                    TodayClass = null
                };
            }

            var timeDifference = upcomingClass.SubjectDoctor.StartTime!.Value.ToTimeSpan()
                - currentTime.ToTimeSpan();

            string timeUntil;

            if (timeDifference.TotalMinutes < 60)
            {
                timeUntil = $"In {Math.Max(1, (int)timeDifference.TotalMinutes)} min";
            }
            else
            {
                var hours = (int)timeDifference.TotalHours;
                var minutes = timeDifference.Minutes;

                timeUntil = minutes == 0
                    ? $"In {hours} hour{(hours > 1 ? "s" : "")}"
                    : $"In {hours} hour{(hours > 1 ? "s" : "")} {minutes} min";
            }

            return new StudentDashboardDto
            {
                StudentName = GetStudentName(student),
                StudentCode = student.StudentCode,
                TimeUntil = timeUntil,
                TodayClass = new TodayScheduleDto
                {
                    SubjectName = upcomingClass.Subject.Name,
                    StartTime = upcomingClass.SubjectDoctor.StartTime,
                    EndTime = upcomingClass.SubjectDoctor.EndTime,
                    Classroom = GetClassroomName(upcomingClass.SubjectDoctor)
                }
            };
        }
    }
}