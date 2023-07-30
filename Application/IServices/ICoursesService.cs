using Domain.Entities;

namespace Application.IServices;

public interface ICoursesService
{
   public Task <Course> AddCourse( string email,string name,int maxStudentNumber);
}