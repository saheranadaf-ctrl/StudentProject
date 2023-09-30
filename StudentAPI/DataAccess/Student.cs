using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentAPI.DataAccess;

public partial class Student
{
    [Key]
    [Required(ErrorMessage = "Student ID is required.")]
    [StringLength(8, MinimumLength = 8, ErrorMessage = "Student ID must be 8 characters long.")]
    [RegularExpression("^S\\d{7}$", ErrorMessage = "Student ID must start with 'S' followed by 7 digits.")]
    public string StudentId { get; set; } = null!;

    [Required(ErrorMessage = "Gender is required.")]
    public string? Gender { get; set; }

    [Required(ErrorMessage = "Gender is required.")]
    public string? NationalIty { get; set; }

    [Required(ErrorMessage = "Gender is required.")]
    public string? PlaceofBirth { get; set; }

    [Required(ErrorMessage = "Gender is required.")]
    public string? StageId { get; set; }

    [Required(ErrorMessage = "Gender is required.")]
    public string? GradeId { get; set; }

    [Required(ErrorMessage = "Gender is required.")]
    public string? SectionId { get; set; }

    [Required(ErrorMessage = "Gender is required.")]
    public string? Topic { get; set; }

    [Required(ErrorMessage = "Gender is required.")]
    public string? Semester { get; set; }

     [Required(ErrorMessage = "Gender is required.")]
    public string? Relation { get; set; }

    [Required(ErrorMessage = "Raised Hands is required.")]
    [Range(0, 100, ErrorMessage = "Raised Hands must be between 0 and 100.")]
    public double? Raisedhands { get; set; }

    [Required(ErrorMessage = "VisItedResources View is required.")]
    [Range(0, 100, ErrorMessage = "VisItedResources View must be between 0 and 100.")]
    public double? VisItedResources { get; set; }

    [Required(ErrorMessage = "AnnouncementsView View is required.")]
    [Range(0, 100, ErrorMessage = "VisItedResources View must be between 0 and 100.")]
    public double? AnnouncementsView { get; set; }

    public double? Discussion { get; set; }

    public string? ParentAnsweringSurvey { get; set; }

    public string? ParentschoolSatisfaction { get; set; }

    public string? StudentAbsenceDays { get; set; }

    public double? StudentMarks { get; set; }

    public string? Class { get; set; }
}
