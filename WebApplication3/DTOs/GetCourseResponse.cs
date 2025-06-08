using WebApplication2.Models;

namespace WebApplication2.DTOs;

public class GetCourseResponse
{

    public string message { get; set; } = "kurs został utworzony i studenci zapisani";
    
    public IEnumerable<GetCourseResponse> CourseResponses { get; set; }
    
    public IEnumerable<GetEnrollmentsResponse> EnrollmentsResponses { get; set; }

}

public class GetEnrollmentsResponse
{
    public int studentId { get; set; }
    public string firstName { get; set; }
    public string lastName { get; set; }
    public string email { get; set; }
    public DateTime enrollmentDate { get; set; }
    
}