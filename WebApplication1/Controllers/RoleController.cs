using Application.Commands;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers;


[ApiController]
[Route("[controller]")]

[Authorize(Policy = "AdminPolicy")]
public class RoleController: ControllerBase
{
    
    private readonly IMediator _mediator;
    
    public RoleController(IMediator mediator)
    {
        _mediator = mediator;
     
    }
    
    
    [HttpPost ("Role")]
    public async Task<Role> Post([FromQuery]  string name)
    {
        var model = new CreateRoleCommand(name);
        
      

        return await _mediator.Send(model);
    }
}