using System;
using System.Collections.Generic;

namespace Universitile01.Models;

public partial class SessionHasStudent
{
    public int SessionEventId { get; set; }

    public string StudentsAspnetusersId { get; set; } = null!;

    public bool IsPresent { get; set; }
}
