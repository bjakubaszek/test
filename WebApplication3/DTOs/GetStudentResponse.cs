namespace WebApplication2.DTOs;

public class GetStudentResponse
{

    public int Id { get; set; }
    
    public string FirstName { get; set; } 
    
    public string LastName { get; set; } 
    
    public string? Email { get; set; }

    public IEnumerable<EnrollmentResponse> Enrollments { get; set; }
}


public class EnrollmentResponse
{
    public string Title { get; set; } 
    public int ID { get; set; }
    public string Teacher { get; set; }
    
    public DateTime EnrollmentDate { get; set; }

}