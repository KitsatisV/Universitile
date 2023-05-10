using System;
using System.Collections.Generic;

namespace Universitile01.Models;

public partial class SessionHasStudent
{
    public SessionHasStudent(int sessionEventId, string studentsAspnetusersId, bool isPresent)
    {
        SessionEventId = sessionEventId;
        StudentsAspnetusersId = studentsAspnetusersId;
        IsPresent = isPresent;
    }

    public SessionHasStudent()
    {
        
    }

    public int SessionEventId { get; set; }

    public string StudentsAspnetusersId { get; set; } = null!;

    public bool IsPresent { get; set; }
}
