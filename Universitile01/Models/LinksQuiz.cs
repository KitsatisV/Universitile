using System;
using System.Collections.Generic;

namespace Universitile01.Models;

public partial class LinksQuiz
{
    public int LinkId { get; set; }

    public string? Quizzes { get; set; }

    public int ModulesModuleId { get; set; }

    public virtual Module ModulesModule { get; set; } = null!;
}
