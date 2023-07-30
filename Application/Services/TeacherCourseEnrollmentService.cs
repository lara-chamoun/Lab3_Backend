using Application.IServices;
using Domain.Entities;
using Persistence;

namespace Application.Services;

public class TeacherCourseEnrollmentService : ITeacherCourseEnrollmentService
{
    
    private readonly PostgresContext _db;

    public TeacherCourseEnrollmentService(PostgresContext db)
    {
        _db = db;
    }



    public async Task<SessionTime> AddTeacherPerCourse( int teacher_id, int course_id, DateTime start_time, DateTime end_time)
    {
        TimeSpan _duration = end_time - start_time;
        int totalMinutes = (int)_duration.TotalMinutes;
        var sessiontime = new SessionTime { StartTime = start_time,EndTime = end_time,Duration = totalMinutes};
        _db.SessionTime.Add(sessiontime);
        _db.SaveChanges();

        var teacherpercourse = new TeacherPerCourse { TeacherId = teacher_id, CourseId = course_id };
        _db.TeacherPerCourse.Add(teacherpercourse);
        _db.SaveChanges();

        var teacherpersession = new TeacherPerCoursePerSessionTime
            { TeacherPerCourseId = teacherpercourse.Id, SessionTimeId = sessiontime.Id };
        _db.TeacherPerCoursePerSessionTimes.Add(teacherpersession);
        _db.SaveChanges();
        
        
        
        return sessiontime;
    }
}