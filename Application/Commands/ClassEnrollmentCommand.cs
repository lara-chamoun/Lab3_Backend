using Domain.Entities;
using MediatR;

namespace Application.Commands;


public record ClassEnrollmentCommand (int course_id, int student_id) : IRequest<ClassEnrollment>
{
    
}