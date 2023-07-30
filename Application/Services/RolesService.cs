using Application.Handlers;
using Application.IServices;
using Domain.Entities;
using Persistence;

namespace Application.Services;

public class RolesService : IRolesService
{
    
    private readonly PostgresContext _db;
    private readonly CreatEventHandlerMicroservice _event;

    public RolesService(PostgresContext db,CreatEventHandlerMicroservice myevent)
    {
        _db = db;
        _event = myevent;
    }



      public async Task<Role> AddRole( string name)
      {
          var role = new Role {  Name = name };
          _db.Roles.Add(role);
          _db.SaveChanges();
          
          var logMessage = "A new role was added: Role ID - ";
          
          var hostName = "localhost";
          var userName = "guest";
          var password = "guest";
          var queueName = "MyQueue";
          
          // aften student enrollment now call SendMessageToRabbitMQ
          _event.SendMessageToRabbitMQ(logMessage,hostName,userName,password,queueName);
        

          return role;
      }
}