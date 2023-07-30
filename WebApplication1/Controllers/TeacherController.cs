using Application.Commands;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers;

[ApiController]
[Route("[controller]")]

[Authorize(Policy = "TeacherPolicy")]

public class TeacherController: ControllerBase
{
    
    private readonly IMediator _mediator;
    
    public TeacherController(IMediator mediator)
    {
        _mediator = mediator;
     
    }
    
    [HttpPost ("TeacherAddCourseCommand")]
    public async Task<SessionTime> Post3([FromQuery] int teacher_id, int course_id, DateTime start_time, DateTime end_time)
    {
        var model = new TeacherCourseEnrollmentCommand(teacher_id,course_id,start_time,end_time);
        return await _mediator.Send(model);
    }
    
}