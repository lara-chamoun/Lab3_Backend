using Application.Commands;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers;

[ApiController]
[Route("[controller]")]

[Authorize(Policy = "AdminPolicy")]

public class AdminController: ControllerBase
{
    
    private readonly IMediator _mediator;
    
    public AdminController(IMediator mediator)
    {
        _mediator = mediator;
     
    }
    
    [HttpPost ("AddCourseCommand")]
    public async Task<Course> Post2([FromQuery] string email, string name,int maxStudentNumber)
    {
        var model = new CreateCourseCommand(email ,name,maxStudentNumber);
        return await _mediator.Send(model);
    }
    
}