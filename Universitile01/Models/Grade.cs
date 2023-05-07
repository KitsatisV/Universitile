using System;
using System.Collections.Generic;

namespace Universitile01.Models;

public partial class Grade
{
    public string StudentsAspnetusersId { get; set; } = null!;

    public int ModulesModuleId { get; set; }

    public double Grade1 { get; set; }

    public virtual Module ModulesModule { get; set; } = null!;
}
