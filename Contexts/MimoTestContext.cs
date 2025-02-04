using Microsoft.EntityFrameworkCore;
using MimoAssignment.Models;
using MimoAssignment.Models.Domain;
using MimoAssignment.Models.Lookups;

namespace MimoAssignment.Contexts;

public partial class MimoTestContext : DbContext
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        ConfigureChapterEntity(modelBuilder);
        ConfigureCourseEntity(modelBuilder);
        ConfigureCoursesToChaptersLookupEntity(modelBuilder);
        ConfigureLessonEntity(modelBuilder);
        ConfigureUserEntity(modelBuilder);
        ConfigureUserToAchievementLookupEntity(modelBuilder);
        ConfigureUserToLessonLookupEntity(modelBuilder);

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    #region Constructors

    public MimoTestContext()
    {
    }

    public MimoTestContext(DbContextOptions<MimoTestContext> options) : base(options)
    {
    }

    #endregion

    #region DbSets

    public virtual DbSet<Achievement> Achievements { get; set; }
    public virtual DbSet<Chapter> Chapters { get; set; }
    public virtual DbSet<Course> Courses { get; set; }
    public virtual DbSet<CoursesToChaptersLookup> CoursesToChaptersLookups { get; set; }
    public virtual DbSet<Lesson> Lessons { get; set; }
    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<UserToAchievementLookup> UserToAchievementLookups { get; set; }
    public virtual DbSet<UserToLessonLookup> UserToLessonLookups { get; set; }

    #endregion

    #region Constants

    private const string TableCoursesToChapters = "CoursesToChaptersLookup";
    private const string TableUserToAchievement = "UserToAchievementLookup";
    private const string TableUserToLesson = "UserToLessonLookup";
    private const string DateTimeType = "DATETIME";

    #endregion

    #region Private Methods

    private void ConfigureChapterEntity(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Chapter>(entity =>
        {
            entity.Property(e => e.ChapterId).ValueGeneratedNever();
            entity.HasOne(d => d.Course).WithMany(p => p.Chapters)
                .HasForeignKey(d => d.CourseId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });
    }

    private void ConfigureCourseEntity(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Course>(entity => { entity.Property(e => e.CourseId).ValueGeneratedNever(); });
    }

    private void ConfigureCoursesToChaptersLookupEntity(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CoursesToChaptersLookup>(entity =>
        {
            entity.HasNoKey().ToTable(TableCoursesToChapters);
            entity.HasOne(d => d.Chapter).WithMany()
                .HasForeignKey(d => d.ChapterId)
                .OnDelete(DeleteBehavior.ClientSetNull);
            entity.HasOne(d => d.Course).WithMany()
                .HasForeignKey(d => d.CourseId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });
    }

    private void ConfigureLessonEntity(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Lesson>(entity =>
        {
            entity.Property(e => e.LessonId)
                .ValueGeneratedNever()
                .HasColumnName("LessonID");
            entity.HasOne(d => d.Chapter).WithMany(p => p.Lessons)
                .HasForeignKey(d => d.ChapterId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });
    }

    private void ConfigureUserEntity(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(e => e.UserId).ValueGeneratedNever();
            entity.HasOne(d => d.Course).WithMany(p => p.Users)
                .HasForeignKey(d => d.CourseId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });
    }

    private void ConfigureUserToAchievementLookupEntity(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserToAchievementLookup>(entity =>
        {
            entity.HasNoKey().ToTable(TableUserToAchievement);
            entity.HasOne(d => d.Achievement).WithMany()
                .HasForeignKey(d => d.AchievementId)
                .OnDelete(DeleteBehavior.ClientSetNull);
            entity.HasOne(d => d.User).WithMany()
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });
    }

    private void ConfigureUserToLessonLookupEntity(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserToLessonLookup>(entity =>
        {
            entity.HasNoKey().ToTable(TableUserToLesson);
            entity.Property(e => e.LessonId).HasColumnName("LessonID");
            entity.Property(e => e.TimeCompleted).HasColumnType(DateTimeType);
            entity.Property(e => e.TimeStarted).HasColumnType(DateTimeType);
            entity.HasOne(d => d.Lesson).WithMany()
                .HasForeignKey(d => d.LessonId)
                .OnDelete(DeleteBehavior.ClientSetNull);
            entity.HasOne(d => d.User).WithMany()
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });
    }

    #endregion
}