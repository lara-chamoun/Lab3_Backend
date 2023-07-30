using Application.Commands;
using Application.IServices;
using Domain.Entities;
using MediatR;

namespace Application.Handlers;

public class CreateCourseHandler: IRequestHandler<CreateCourseCommand, Course>
{
    private readonly ICoursesService _courseService;
    public CreateCourseHandler(ICoursesService service)
    {
        _courseService = service;
    }
    public async Task<Course> Handle(CreateCourseCommand request, CancellationToken cancellationToken)
    {
        return await _courseService.AddCourse(request.email,request.name,request.maxStudentNumber);
    }
}