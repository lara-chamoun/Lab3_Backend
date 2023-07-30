using Application.IServices;
using Domain.Entities;
using NpgsqlTypes;
using Persistence;


namespace Application.Services;

public class CoursesService : ICoursesService
{
        private readonly PostgresContext _dbContext;
        private ICoursesService _courseIServiceImplementation;

        public CoursesService(PostgresContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Course> AddCourse(string email, string name, int maxStudentNumber)
        {
            // Retrieve the user based on the provided email
            var user = _dbContext.Users.FirstOrDefault(u => u.Email == email);

            // Check if the user exists and their RoleId is 2student
            if (user != null && user.RoleId == 2)
            {
              
                NpgsqlRange<DateOnly> enrolmentDateRange = new NpgsqlRange<DateOnly>(new DateOnly(2023, 5, 20), new DateOnly(2024, 12, 10));
                var course = new Course
                {
                    Name = name,
                    MaxStudentsNumber = maxStudentNumber,
                    EnrolmentDateRange = enrolmentDateRange // Convert to string before saving
                };

                _dbContext.Courses.Add(course);
                _dbContext.SaveChanges();



               // try
               // {
                //    _dbContext.SaveChanges();
               // }
              //  catch (Exception ex)
              //  {
                    // Log the exception for debugging purposes
              //      Console.WriteLine($"Error saving changes: {ex.Message}");
                    // Handle the exception based on your application's requirements
              //      throw;
              //  }
                var enrollment = new TeacherPerCourse
                {
                    TeacherId = user.RoleId,
                    CourseId = course.Id
                };

                _dbContext.TeacherPerCourse.Add(enrollment);
                _dbContext.SaveChanges();
                return course;
            }
            else
            {
                // The user is not authorized to add a course
                throw new UnauthorizedAccessException("You are not authorized to add a course.");
            }
        }
}