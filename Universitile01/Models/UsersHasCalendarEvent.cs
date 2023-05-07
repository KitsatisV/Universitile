using System;
using System.Collections.Generic;

namespace Universitile01.Models;

public partial class UsersHasCalendarEvent
{
    public string AspnetusersId { get; set; } = null!;

    public int SessionsEventId { get; set; }

    public virtual Aspnetuser Aspnetusers { get; set; } = null!;
}
