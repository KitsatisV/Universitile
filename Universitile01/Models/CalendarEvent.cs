using System;
using System.Collections.Generic;

namespace Universitile01.Models;

public partial class CalendarEvent
{
    public int EventId { get; set; }

    public string Tittle { get; set; } = null!;

    public DateTime DateStart { get; set; }

    public DateTime DateEnd { get; set; }

    public string Description { get; set; } = null!;

    public virtual ICollection<Aspnetuser> Aspnetusers { get; set; } = new List<Aspnetuser>();
}
