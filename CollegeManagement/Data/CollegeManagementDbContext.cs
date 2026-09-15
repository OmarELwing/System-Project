using System;
using System.Collections.Generic;
using CollegeManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace CollegeManagement.Data;

public partial class CollegeManagementDbContext : DbContext
{
    public CollegeManagementDbContext()
    {
    }

    public CollegeManagementDbContext(DbContextOptions<CollegeManagementDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Assessment> Assessments { get; set; }

    public virtual DbSet<AssessmentGrade> AssessmentGrades { get; set; }

    public virtual DbSet<Attendance> Attendances { get; set; }

    public virtual DbSet<Classroom> Classrooms { get; set; }

    public virtual DbSet<Doctor> Doctors { get; set; }

    public virtual DbSet<Enrollment> Enrollments { get; set; }

    public virtual DbSet<PerformanceEvaluation> PerformanceEvaluations { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<Subject> Subjects { get; set; }

    public virtual DbSet<SubjectDoctor> SubjectDoctors { get; set; }

    public virtual DbSet<User> Users { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Assessment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_assessments");

            entity.ToTable("assessments");

            entity.HasIndex(e => e.DoctorId, "idx_assessments_doctor_id");

            entity.HasIndex(e => e.SubjectId, "idx_assessments_subject_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.DoctorId).HasColumnName("doctor_id");
            entity.Property(e => e.DueDate).HasColumnName("due_date");
            entity.Property(e => e.Name)
                .HasMaxLength(150)
                .HasColumnName("name");
            entity.Property(e => e.SubjectId).HasColumnName("subject_id");
            entity.Property(e => e.Type)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("type");

            entity.HasOne(d => d.Doctor).WithMany(p => p.Assessments)
                .HasForeignKey(d => d.DoctorId)
                .HasConstraintName("fk_assessments_doctor");

            entity.HasOne(d => d.Subject).WithMany(p => p.Assessments)
                .HasForeignKey(d => d.SubjectId)
                .HasConstraintName("fk_assessments_subject");
        });

        modelBuilder.Entity<AssessmentGrade>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_assessment_grades");

            entity.ToTable("assessment_grades", tb =>
                {
                    tb.HasTrigger("trg_assessment_grades_before_insert");
                    tb.HasTrigger("trg_assessment_grades_before_update");
                });

            entity.HasIndex(e => e.StudentId, "idx_assessment_grades_student_id");

            entity.HasIndex(e => new { e.AssessmentId, e.StudentId }, "uq_assessment_grade_student").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AssessmentId).HasColumnName("assessment_id");
            entity.Property(e => e.Grade)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("grade");
            entity.Property(e => e.StudentId).HasColumnName("student_id");

            entity.HasOne(d => d.Assessment).WithMany(p => p.AssessmentGrades)
                .HasForeignKey(d => d.AssessmentId)
                .HasConstraintName("fk_assessment_grades_assessment");

            entity.HasOne(d => d.Student).WithMany(p => p.AssessmentGrades)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_assessment_grades_student");
        });

        modelBuilder.Entity<Attendance>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_attendance");

            entity.ToTable("attendance");

            entity.HasIndex(e => e.SubjectDoctorId, "idx_attendance_subject_doctor_id");

            entity.HasIndex(e => new { e.EnrollmentId, e.SubjectDoctorId, e.Date }, "uq_attendance_class_date").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.EnrollmentId).HasColumnName("enrollment_id");
            entity.Property(e => e.Status)
                .HasMaxLength(7)
                .IsUnicode(false)
                .HasColumnName("status");
            entity.Property(e => e.SubjectDoctorId).HasColumnName("subject_doctor_id");

            entity.HasOne(d => d.Enrollment).WithMany(p => p.Attendances)
                .HasForeignKey(d => d.EnrollmentId)
                .HasConstraintName("fk_attendance_enrollment");

            entity.HasOne(d => d.SubjectDoctor).WithMany(p => p.Attendances)
                .HasForeignKey(d => d.SubjectDoctorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_attendance_subject_doctor");
        });

        modelBuilder.Entity<Classroom>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_classrooms");

            entity.ToTable("classrooms");

            entity.HasIndex(e => e.Name, "uq_classrooms_name").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Capacity).HasColumnName("capacity");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Doctor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_doctors");

            entity.ToTable("doctors");

            entity.HasIndex(e => e.DoctorCode, "uq_doctors_code").IsUnique();

            entity.HasIndex(e => e.UserId, "uq_doctors_user_id").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DoctorCode)
                .HasMaxLength(30)
                .HasColumnName("doctor_code");
            entity.Property(e => e.FirstName)
                .HasMaxLength(100)
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(100)
                .HasColumnName("last_name");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithOne(p => p.Doctor)
                .HasForeignKey<Doctor>(d => d.UserId)
                .HasConstraintName("fk_doctors_user");
        });

        modelBuilder.Entity<Enrollment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_enrollments");

            entity.ToTable("enrollments");

            entity.HasIndex(e => e.SubjectId, "idx_enrollments_subject_id");

            entity.HasIndex(e => new { e.StudentId, e.SubjectId }, "uq_enrollments_student_subject").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.StudentId).HasColumnName("student_id");
            entity.Property(e => e.SubjectId).HasColumnName("subject_id");

            entity.HasOne(d => d.Student).WithMany(p => p.Enrollments)
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("fk_enrollments_student");

            entity.HasOne(d => d.Subject).WithMany(p => p.Enrollments)
                .HasForeignKey(d => d.SubjectId)
                .HasConstraintName("fk_enrollments_subject");
        });

        modelBuilder.Entity<PerformanceEvaluation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_performance_evaluations");

            entity.ToTable("performance_evaluations");

            entity.HasIndex(e => e.DoctorId, "idx_performance_doctor_id");

            entity.HasIndex(e => e.EnrollmentId, "idx_performance_enrollment_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(sysdatetime())")
                .HasColumnName("created_at");
            entity.Property(e => e.DoctorId).HasColumnName("doctor_id");
            entity.Property(e => e.EnrollmentId).HasColumnName("enrollment_id");
            entity.Property(e => e.Score)
                .HasColumnType("decimal(4, 2)")
                .HasColumnName("score");

            entity.HasOne(d => d.Doctor).WithMany(p => p.PerformanceEvaluations)
                .HasForeignKey(d => d.DoctorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_performance_doctor");

            entity.HasOne(d => d.Enrollment).WithMany(p => p.PerformanceEvaluations)
                .HasForeignKey(d => d.EnrollmentId)
                .HasConstraintName("fk_performance_enrollment");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_students");

            entity.ToTable("students");

            entity.HasIndex(e => e.StudentCode, "uq_students_code").IsUnique();

            entity.HasIndex(e => e.UserId, "uq_students_user_id").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.FirstName)
                .HasMaxLength(100)
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(100)
                .HasColumnName("last_name");
            entity.Property(e => e.StudentCode)
                .HasMaxLength(30)
                .HasColumnName("student_code");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithOne(p => p.Student)
                .HasForeignKey<Student>(d => d.UserId)
                .HasConstraintName("fk_students_user");
        });

        modelBuilder.Entity<Subject>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_subjects");

            entity.ToTable("subjects");

            entity.HasIndex(e => e.Code, "uq_subjects_code").IsUnique();

            entity.HasIndex(e => e.Name, "uq_subjects_name").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Code)
                .HasMaxLength(30)
                .HasColumnName("code");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(150)
                .HasColumnName("name");
        });

        modelBuilder.Entity<SubjectDoctor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_subject_doctors");

            entity.ToTable("subject_doctors");

            entity.HasIndex(e => e.ClassroomId, "idx_subject_doctors_classroom_id");

            entity.HasIndex(e => e.DoctorId, "idx_subject_doctors_doctor_id");

            entity.HasIndex(e => new { e.SubjectId, e.DoctorId }, "uq_subject_doctor").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ClassroomId).HasColumnName("classroom_id");
            entity.Property(e => e.DayOfWeek)
                .HasMaxLength(9)
                .IsUnicode(false)
                .HasColumnName("day_of_week");
            entity.Property(e => e.DoctorId).HasColumnName("doctor_id");
            entity.Property(e => e.EndTime).HasColumnName("end_time");
            entity.Property(e => e.StartTime).HasColumnName("start_time");
            entity.Property(e => e.SubjectId).HasColumnName("subject_id");

            entity.HasOne(d => d.Classroom).WithMany(p => p.SubjectDoctors)
                .HasForeignKey(d => d.ClassroomId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("fk_subject_doctors_classroom");

            entity.HasOne(d => d.Doctor).WithMany(p => p.SubjectDoctors)
                .HasForeignKey(d => d.DoctorId)
                .HasConstraintName("fk_subject_doctors_doctor");

            entity.HasOne(d => d.Subject).WithMany(p => p.SubjectDoctors)
                .HasForeignKey(d => d.SubjectId)
                .HasConstraintName("fk_subject_doctors_subject");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_users");

            entity.ToTable("users");

            entity.HasIndex(e => e.Username, "uq_users_username").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(sysdatetime())")
                .HasColumnName("created_at");
            entity.Property(e => e.PasswordHash)
                .HasMaxLength(255)
                .HasColumnName("password_hash");
            entity.Property(e => e.Role)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("role");
            entity.Property(e => e.Username)
                .HasMaxLength(100)
                .HasColumnName("username");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
