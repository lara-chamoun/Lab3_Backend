using Application.Commands;
using Application.IServices;
using Application.Models;
using Domain.Entities;
using MediatR;

namespace Application.Handlers;

public class RegisterUserHandler: IRequestHandler<RegisterUserCommand, User>
{
    private readonly IRegisterUserService _userService;
    public RegisterUserHandler(IRegisterUserService service)
    {
        _userService = service;
    }
    public async Task<User> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        return await _userService.RegisterUser(request.name,request.email,request.password,request.role_id);
    }
}