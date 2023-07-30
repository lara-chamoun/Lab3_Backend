using Domain.Entities;
using MediatR;

namespace Application.Commands;

public record TeacherCourseEnrollmentCommand (int teacher_id, int course_id, DateTime start_time, DateTime end_time) : IRequest<SessionTime>
{
    
}