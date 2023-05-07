using System;
using System.Collections.Generic;

namespace Universitile01.Models;

public partial class Session
{
    public int EventId { get; set; }

    public string Tittle { get; set; } = null!;

    public DateTime DateStart { get; set; }

    public DateTime DateEnd { get; set; }

    public int ModulesModuleId { get; set; }

    public virtual Module ModulesModule { get; set; } = null!;
}
