using Domain.Entities;

namespace Application.IServices;

public interface IClassEnrollmentService
{
    public Task <ClassEnrollment> AddCourseEnrollment( int course_id, int student_id);
}