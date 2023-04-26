using System;
using System.Collections.Generic;

namespace Universitile01.Models;

public partial class CourseLeader
{
    public int CoursesCourseId { get; set; }

    public string AspnetusersId { get; set; } = null!;

    public virtual Aspnetuser Aspnetusers { get; set; } = null!;

    public virtual Course CoursesCourse { get; set; } = null!;
}
