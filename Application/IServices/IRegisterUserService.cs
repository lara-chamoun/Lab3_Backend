using Domain.Entities;

namespace Application.IServices;

public interface IRegisterUserService
{
    public Task <User> RegisterUser( string name,string email,string password,int role_id);
}