using System;
using System.Collections.Generic;

namespace Universitile01.Models;

public partial class LinksAssignment
{
    public int AssignmentId { get; set; }

    public string? Assignments { get; set; }

    public int ModulesModuleId { get; set; }

    public virtual Module ModulesModule { get; set; } = null!;
}
