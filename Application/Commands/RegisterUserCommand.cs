
using Domain.Entities;
using MediatR;

namespace Application.Commands;

public record RegisterUserCommand (string name,string email,string password,int role_id) : IRequest<User>
{
    
}