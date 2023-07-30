using Application.IServices;
using Domain.Entities;
using Persistence;

namespace Application.Services;

public class ClassEnrollmentService : IClassEnrollmentService
{
    
    private readonly PostgresContext _db;
    private readonly MailService _mailService;

    public ClassEnrollmentService(PostgresContext db,MailService mailService)
    {
        _db = db;
        _mailService = mailService;
    }



    public async Task<ClassEnrollment> AddCourseEnrollment( int course_id,int student_id)
    {
        var classenrollment = new ClassEnrollment { CourseId= course_id, StudentId = student_id};
        _db.ClassEnrollment.Add(classenrollment);
        _db.SaveChanges();
        
        
        // Get student's email from the Users table based on the student_id.
        var student = _db.Users.FirstOrDefault(u => u.Id == student_id);
        if (student != null)
        {
            // Get the course name from the Courses table based on the course_id.
            var course = _db.Courses.FirstOrDefault(c => c.Id == course_id);
            if (course != null)
            {
                // Create the email content with relevant information.
                var subject = "Course Enrollment Confirmation";
                var body = $"Dear {student.Name},\n\nYou have successfully enrolled in the course '{course.Name}'.\n\nThank you for enrolling!";
                
                // Send the email using the MailService.
                await _mailService.SendEmailAsync(student.Email, subject, body);
            }
        }
        return classenrollment;
    }
}