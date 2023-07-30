using Domain.Entities;

namespace Application.IServices;

public interface IRolesService
{
    public Task <Role> AddRole( string name);
}