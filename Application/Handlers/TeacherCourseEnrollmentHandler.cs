using Application.Commands;
using Application.IServices;
using Domain.Entities;
using MediatR;

namespace Application.Handlers;

public class TeacherCourseEnrollmentHandler: IRequestHandler<TeacherCourseEnrollmentCommand, SessionTime>
{
    private readonly ITeacherCourseEnrollmentService _courseService;
    public TeacherCourseEnrollmentHandler(ITeacherCourseEnrollmentService service)
    {
        _courseService = service;
    }
    public async Task<SessionTime> Handle(TeacherCourseEnrollmentCommand request, CancellationToken cancellationToken)
    {
        return await _courseService.AddTeacherPerCourse(request.teacher_id,request.course_id,request.start_time,request.end_time);
    }
}