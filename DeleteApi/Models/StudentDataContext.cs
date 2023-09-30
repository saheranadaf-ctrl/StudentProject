using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DeleteApi.Models;

public partial class StudentDataContext : DbContext
{
    public StudentDataContext()
    {
    }

    public StudentDataContext(DbContextOptions<StudentDataContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>(entity =>
        {
            entity.ToTable("Student");

            entity.Property(e => e.StudentId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Student_ID");
            entity.Property(e => e.Class)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Gender)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("gender");
            entity.Property(e => e.GradeId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("GradeID");
            entity.Property(e => e.NationalIty)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("NationalITy");
            entity.Property(e => e.ParentAnsweringSurvey)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.ParentschoolSatisfaction)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.PlaceofBirth)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Raisedhands).HasColumnName("raisedhands");
            entity.Property(e => e.Relation)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.SectionId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SectionID");
            entity.Property(e => e.Semester)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.StageId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("StageID");
            entity.Property(e => e.StudentAbsenceDays)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Topic)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.VisItedResources).HasColumnName("VisITedResources");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
