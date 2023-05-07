using System;
using System.Collections.Generic;

namespace Universitile01.Models;

public partial class Session
{
   
    public Session(int eventId, string tittle, DateTime dateStart, DateTime dateEnd, int modulesModuleId)
    {
        EventId = eventId;
        Tittle = tittle;
        DateStart = dateStart;
        DateEnd = dateEnd;
        ModulesModuleId = modulesModuleId;
    }
    public int EventId { get; set; }
    public string Tittle { get; set; } = null!;

    public DateTime DateStart { get; set; }

    public DateTime DateEnd { get; set; }

    public int ModulesModuleId { get; set; }

    public virtual Module ModulesModule { get; set; } = null!;
}
