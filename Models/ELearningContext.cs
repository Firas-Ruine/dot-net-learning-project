using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace e_learning.Models;

public partial class ELearningContext : DbContext
{
    public ELearningContext()
    {
    }

    public ELearningContext(DbContextOptions<ELearningContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Assignment> Assignments { get; set; }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<DiscussionPost> DiscussionPosts { get; set; }

    public virtual DbSet<DiscussionTopic> DiscussionTopics { get; set; }

    public virtual DbSet<Enrollment> Enrollments { get; set; }

    public virtual DbSet<Grade> Grades { get; set; }

    public virtual DbSet<Question> Questions { get; set; }

    public virtual DbSet<Quiz> Quizzes { get; set; }

    public virtual DbSet<QuizSubmission> QuizSubmissions { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Submission> Submissions { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=e_learning;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Assignment>(entity =>
        {
            entity.HasKey(e => e.AssignmentId).HasName("PK__assignme__DA8918143F3AF336");

            entity.ToTable("assignments");

            entity.Property(e => e.AssignmentId).HasColumnName("assignment_id");
            entity.Property(e => e.CourseId).HasColumnName("course_id");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.DueDate).HasColumnName("due_date");
            entity.Property(e => e.Title)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("title");

            entity.HasOne(d => d.Course).WithMany(p => p.Assignments)
                .HasForeignKey(d => d.CourseId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__assignmen__cours__300424B4");
        });

        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.CourseId).HasName("PK__courses__8F1EF7AE6CCFC0A4");

            entity.ToTable("courses");

            entity.Property(e => e.CourseId).HasColumnName("course_id");
            entity.Property(e => e.CourseName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("course_name");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.EndDate).HasColumnName("end_date");
            entity.Property(e => e.InstructorId).HasColumnName("instructor_id");
            entity.Property(e => e.StartDate).HasColumnName("start_date");

            entity.HasOne(d => d.Instructor).WithMany(p => p.Courses)
                .HasForeignKey(d => d.InstructorId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__courses__instruc__29572725");
        });

        modelBuilder.Entity<DiscussionPost>(entity =>
        {
            entity.HasKey(e => e.PostId).HasName("PK__discussi__AA1260384AEC13B2");

            entity.ToTable("discussion_posts");

            entity.Property(e => e.PostId).HasColumnName("PostID");
            entity.Property(e => e.PostDate).HasColumnName("post_date");
            entity.Property(e => e.PostText)
                .HasColumnType("text")
                .HasColumnName("post_text");
            entity.Property(e => e.TopicId).HasColumnName("topic_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Topic).WithMany(p => p.DiscussionPosts)
                .HasForeignKey(d => d.TopicId)
                .HasConstraintName("FK__discussio__topic__46E78A0C");

            entity.HasOne(d => d.User).WithMany(p => p.DiscussionPosts)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__discussio__user___47DBAE45");
        });

        modelBuilder.Entity<DiscussionTopic>(entity =>
        {
            entity.HasKey(e => e.TopicId).HasName("PK__discussi__D5DAA3E95CFB2FE5");

            entity.ToTable("discussion_topics");

            entity.Property(e => e.TopicId).HasColumnName("topic_id");
            entity.Property(e => e.CourseId).HasColumnName("course_id");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.EndDate).HasColumnName("end_date");
            entity.Property(e => e.StartDate).HasColumnName("start_date");
            entity.Property(e => e.Title)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("title");

            entity.HasOne(d => d.Course).WithMany(p => p.DiscussionTopics)
                .HasForeignKey(d => d.CourseId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__discussio__cours__440B1D61");
        });

        modelBuilder.Entity<Enrollment>(entity =>
        {
            entity.HasKey(e => e.EnrollmentId).HasName("PK__enrollme__6D24AA7A3359EFC1");

            entity.ToTable("enrollments");

            entity.Property(e => e.EnrollmentId).HasColumnName("enrollment_id");
            entity.Property(e => e.CourseId).HasColumnName("course_id");
            entity.Property(e => e.EnrollmentDate).HasColumnName("enrollment_date");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Course).WithMany(p => p.Enrollments)
                .HasForeignKey(d => d.CourseId)
                .HasConstraintName("FK__enrollmen__cours__2D27B809");

            entity.HasOne(d => d.User).WithMany(p => p.Enrollments)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__enrollmen__user___2C3393D0");
        });

        modelBuilder.Entity<Grade>(entity =>
        {
            entity.HasKey(e => e.GradeId).HasName("PK__grades__3A8F732C9A424B16");

            entity.ToTable("grades");

            entity.Property(e => e.GradeId).HasColumnName("grade_id");
            entity.Property(e => e.Feedback)
                .HasColumnType("text")
                .HasColumnName("feedback");
            entity.Property(e => e.Grade1)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("grade");
            entity.Property(e => e.GradingDate).HasColumnName("grading_date");
            entity.Property(e => e.InstructorId).HasColumnName("instructor_id");
            entity.Property(e => e.SubmissionId).HasColumnName("submission_id");

            entity.HasOne(d => d.Instructor).WithMany(p => p.Grades)
                .HasForeignKey(d => d.InstructorId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__grades__instruct__37A5467C");

            entity.HasOne(d => d.Submission).WithMany(p => p.Grades)
                .HasForeignKey(d => d.SubmissionId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__grades__submissi__36B12243");
        });

        modelBuilder.Entity<Question>(entity =>
        {
            entity.HasKey(e => e.QuestionId).HasName("PK__question__2EC21549A973D50A");

            entity.ToTable("questions");

            entity.Property(e => e.QuestionId).HasColumnName("question_id");
            entity.Property(e => e.CorrectAnswer)
                .HasColumnType("text")
                .HasColumnName("correct_answer");
            entity.Property(e => e.QuestionText)
                .HasColumnType("text")
                .HasColumnName("question_text");
            entity.Property(e => e.QuizId).HasColumnName("quiz_id");
            entity.Property(e => e.Type)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("type");

            entity.HasOne(d => d.Quiz).WithMany(p => p.Questions)
                .HasForeignKey(d => d.QuizId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__questions__quiz___3D5E1FD2");
        });

        modelBuilder.Entity<Quiz>(entity =>
        {
            entity.HasKey(e => e.QuizId).HasName("PK__quizzes__2D7053ECCFDC9565");

            entity.ToTable("quizzes");

            entity.Property(e => e.QuizId).HasColumnName("quiz_id");
            entity.Property(e => e.CourseId).HasColumnName("course_id");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.EndDate).HasColumnName("end_date");
            entity.Property(e => e.StartDate).HasColumnName("start_date");
            entity.Property(e => e.Title)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("title");

            entity.HasOne(d => d.Course).WithMany(p => p.Quizzes)
                .HasForeignKey(d => d.CourseId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__quizzes__course___3A81B327");
        });

        modelBuilder.Entity<QuizSubmission>(entity =>
        {
            entity.HasKey(e => e.SubmissionId).HasName("PK__quiz_sub__9B5355955ECFD86C");

            entity.ToTable("quiz_submissions");

            entity.Property(e => e.SubmissionId).HasColumnName("submission_id");
            entity.Property(e => e.QuizId).HasColumnName("quiz_id");
            entity.Property(e => e.Score)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("score");
            entity.Property(e => e.SubmissionDate).HasColumnName("submission_date");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Quiz).WithMany(p => p.QuizSubmissions)
                .HasForeignKey(d => d.QuizId)
                .HasConstraintName("FK__quiz_subm__quiz___412EB0B6");

            entity.HasOne(d => d.User).WithMany(p => p.QuizSubmissions)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__quiz_subm__user___403A8C7D");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__roles__760965CCA99B4CDE");

            entity.ToTable("roles");

            entity.Property(e => e.RoleId).HasColumnName("role_id");
            entity.Property(e => e.RoleName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("role_name");
        });

        modelBuilder.Entity<Submission>(entity =>
        {
            entity.HasKey(e => e.SubmissionId).HasName("PK__submissi__9B53559539E2E324");

            entity.ToTable("submissions");

            entity.Property(e => e.SubmissionId).HasColumnName("submission_id");
            entity.Property(e => e.AssignmentId).HasColumnName("assignment_id");
            entity.Property(e => e.FilePath)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("file_path");
            entity.Property(e => e.SubmissionDate).HasColumnName("submission_date");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Assignment).WithMany(p => p.Submissions)
                .HasForeignKey(d => d.AssignmentId)
                .HasConstraintName("FK__submissio__assig__32E0915F");

            entity.HasOne(d => d.User).WithMany(p => p.Submissions)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__submissio__user___33D4B598");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__users__B9BE370FAC9DB9D8");

            entity.ToTable("users");

            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Firstname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("firstname");
            entity.Property(e => e.Lastname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("lastname");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.RoleId).HasColumnName("role_id");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("username");

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK__users__role_id__267ABA7A");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
