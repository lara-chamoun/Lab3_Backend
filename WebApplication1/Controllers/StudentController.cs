using Application.Commands;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers;


[ApiController]
[Route("[controller]")]

[Authorize(Policy = "StudentPolicy")]
public class StudentController: ControllerBase
{
    
    private readonly IMediator _mediator;
    
    public StudentController(IMediator mediator)
    {
        _mediator = mediator;
     
    }
    
    
    [HttpPost ("ClassEnrollment")]
    public async Task<ClassEnrollment> Post([FromQuery] int course_id, int student_id)
    {
        var model = new ClassEnrollmentCommand(course_id ,student_id);
        return await _mediator.Send(model);
    }
}