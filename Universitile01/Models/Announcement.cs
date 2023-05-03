using System;
using System.Collections.Generic;

namespace Universitile01.Models;

public partial class Announcement
{
    public Announcement(int announcementsId, DateTime date, string message, bool importance)
    {
        AnnouncementsId = announcementsId;
        Date = date;
        Message = message;
        Importance = importance;
    }

    public int AnnouncementsId { get; set; }

    public DateTime Date { get; set; }

    public string Message { get; set; } = null!;

    public bool Importance { get; set; }

    public virtual ICollection<UsersHasAnnouncement> UsersHasAnnouncements { get; set; } = new List<UsersHasAnnouncement>();

    
}
