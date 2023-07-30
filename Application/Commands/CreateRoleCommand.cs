using Domain.Entities;
using MediatR;

namespace Application.Commands;

public record CreateRoleCommand (string name) : IRequest<Role>
{
    
}