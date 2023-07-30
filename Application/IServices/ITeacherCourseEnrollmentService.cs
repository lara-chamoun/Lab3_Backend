using Domain.Entities;

namespace Application.IServices;

public interface ITeacherCourseEnrollmentService
{
    public Task <SessionTime> AddTeacherPerCourse(int teacher_id, int course_id, DateTime start_time, DateTime end_time);
}