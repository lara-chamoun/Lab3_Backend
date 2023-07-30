using Application.Commands;
using Application.IServices;
using Domain.Entities;
using MediatR;

namespace Application.Handlers;

public class ClassEnrollmentHandler: IRequestHandler<ClassEnrollmentCommand, ClassEnrollment>
{
    private readonly IClassEnrollmentService _courseService;
    public ClassEnrollmentHandler(IClassEnrollmentService service)
    {
        _courseService = service;
    }

    public async Task<ClassEnrollment> Handle(ClassEnrollmentCommand request, CancellationToken cancellationToken)
    {
        return await _courseService.AddCourseEnrollment(request.course_id,request.student_id);
    }
}