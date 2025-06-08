using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.DTOs;
using WebApplication2.Exceptions;
using WebApplication2.Models;

namespace WebApplication2.Services;

public interface IDbService
{
    public Task<IEnumerable<GetStudentResponse>> GetStudentDetails();
    public Task<GetCourseResponse>  CreateCourseWithEnroll(CreateCourseRequest request);

}
public class DbService(MyDbContext data) : IDbService
{
    public async Task<IEnumerable<GetStudentResponse>> GetStudentDetails()
    {
        return await data.Students.Select(p => new GetStudentResponse
        {
            
            
            Id = p.Id,
            LastName = p.LastName,
            FirstName = p.FirstName,
            Email = p.Email,

            Enrollments = p.Enrollments.Select(e => new EnrollmentResponse
            {
                ID = e.Course.Id,
                Title = e.Course.Title,
                Teacher = e.Course.Teacher,
                EnrollmentDate = e.EnrollmentDate,
                

            })
            
        }).ToListAsync();
    }
    

    public async Task<GetCourseResponse> CreateCourseWithEnroll(CreateCourseRequest request)
    {
        //1. walidujemy dane
        //2. tworzymy kurs
        //3. tworzyny enrollment
        

        var missingStudents = request.Students
            .Where(m => !data.Students.Any(db => db.Id == m.Id));

        foreach (var student in missingStudents)
        {
            var Student = new Student
            {
                Id = student.Id,
                Email = student.Email,
                FirstName = student.FirstName,
                LastName = student.LastName,
            };
            await data.AddAsync(Student);
        }
        
        
        var Course = new Course()
        {
            Title = request.Title,
            Credits = request.Credits,
            Teacher = request.Teacher,
        };
        
        await data.AddAsync(Course);


        foreach (var student in request.Students)
        {
            var Enrollment = new Enrollment()
            {
                Course_ID = request.CourseId,
                Student_ID = student.Id,
                EnrollmentDate = request.EnrollmentDate
            };
            await data.AddAsync(Enrollment);

        }
        

        
        
        await data.SaveChangesAsync();

        return new GetCourseResponse()
        {
            message = "Course created successfully",
        };    
    }
}