using Domain.Entities;
using MediatR;

namespace Application.Commands;


    public record CreateCourseCommand (string email, string name,int maxStudentNumber) : IRequest<Domain.Entities.Course>
    {
    
    }
