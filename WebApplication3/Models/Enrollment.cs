using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Models;

[Table("Enrollment")]
public class Enrollment
{
    
    [Column("ID")]
    [Key]
    public int Id { get; set; }
    
    [Column("Student_ID")]
    public int Student_ID { get; set; }
    
    [Column("Course_ID")]
    public int Course_ID { get; set; }
    
    public DateTime EnrollmentDate { get; set; }
    
    [ForeignKey(nameof(Student_ID))]
    public virtual Student? Student { get; set; }
    
    [ForeignKey(nameof(Course_ID))]
    public virtual Course? Course { get; set; }
}