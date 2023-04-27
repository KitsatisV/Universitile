using System;
using System.Collections.Generic;

namespace Universitile01.Models;

public partial class Announcement
{
    public int AnnouncementsId { get; set; }

    public DateTime Date { get; set; }

    public string Message { get; set; } = null!;

    public bool Importance { get; set; }

    public virtual ICollection<UsersHasAnnouncement> UsersHasAnnouncements { get; set; } = new List<UsersHasAnnouncement>();
    public bool IsRead { get; internal set; }
}
