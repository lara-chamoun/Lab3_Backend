using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class ClassEnrollment
{
    public long Id { get; set; }

    public long CourseId { get; set; }

    public long StudentId { get; set; }

    public virtual TeacherPerCourse Class { get; set; } = null!;

    public virtual User Student { get; set; } = null!;
}
