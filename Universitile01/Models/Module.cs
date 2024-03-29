﻿using System;
using System.Collections.Generic;

namespace Universitile01.Models;

public partial class Module
{
    public int ModuleId { get; set; }

    public string ModuleName { get; set; } = null!;

    public string ModuleDescription { get; set; } = null!;

    public int ModuleDuration { get; set; }

    public int CoursesCourseId { get; set; }

    public virtual Course CoursesCourse { get; set; } = null!;

    public virtual ICollection<Grade> Grades { get; set; } = new List<Grade>();

    public virtual ICollection<LinksAssignment> LinksAssignments { get; set; } = new List<LinksAssignment>();

    public virtual ICollection<LinksQuiz> LinksQuizzes { get; set; } = new List<LinksQuiz>();

    public virtual ICollection<Session> Sessions { get; set; } = new List<Session>();

    public virtual ICollection<Aspnetuser> Aspnetusers { get; set; } = new List<Aspnetuser>();
}
