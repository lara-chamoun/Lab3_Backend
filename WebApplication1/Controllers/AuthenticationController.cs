using Application.Commands;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers;
[ApiController]
[Route("[controller]")]




public class AuthenticationController: ControllerBase
{
    
    private readonly IMediator _mediator;
    
    public AuthenticationController(IMediator mediator)
    {
        _mediator = mediator;
     
    }
    [HttpPost("RegisterNewUser")]
    public async Task<User> CreateUser([FromQuery]string name, string email, string password , int role_id)
    {
        
        var model = new RegisterUserCommand(name,email,password,role_id);
        return await _mediator.Send(model);

    }
    
}