using System.ComponentModel.DataAnnotations;
using WebApplication2.Models;

namespace WebApplication2.DTOs;

public class CreateCourseRequest
{
    
    [Required]
    [MaxLength(150)]
    public string Title { get; set; } = string.Empty;
    
    public int CourseId { get; set; }
    
    [MaxLength(300)]
    public string Credits { get; set; } = string.Empty;
    
    [MaxLength(150)]
    public string Teacher { get; set; } = string.Empty; 
    
    public List<Student> Students { get; set; }
    public DateTime EnrollmentDate { get; set; }
}