using System.Collections.Generic;
using Universitile01.Models;

public interface IAnnouncementService
{
    List<Announcement> GetAllAnnouncements();
    void MarkAsRead(int announcementId, string userId);
}