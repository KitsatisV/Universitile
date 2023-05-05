using System;
using System.Collections.Generic;

namespace Universitile01.Models;

public partial class Course
{
    public int CourseId { get; set; }

    public string CourseName { get; set; } = null!;

    public string CourseDescription { get; set; } = null!;

    public int CourseDuration { get; set; }

    public virtual ICollection<Module> Modules { get; set; } = new List<Module>();

    public virtual ICollection<Aspnetuser> Aspnetusers { get; set; } = new List<Aspnetuser>();
}
