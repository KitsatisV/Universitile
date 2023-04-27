using System.Collections.Generic;
using System.Linq;
using Universitile01.Data;
using Universitile01.Models;

public class AnnouncementService : IAnnouncementService
{
    private readonly ApplicationDbContext _dbContext;
    private string userId;

    public AnnouncementService(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public List<Announcement> GetAllAnnouncements()
    {
        return _dbContext.Announcements
       .Select(a => new Announcement
       {
           AnnouncementsId = a.AnnouncementsId,
           Date = a.Date,
           Message = a.Message,
           Importance = a.Importance,
           IsRead = !a.UsersHasAnnouncements.Any(uha => uha.AspnetusersId == userId && uha.IsRead[0] == 1)
       })
       .ToList();
    }

    public void MarkAsRead(int announcementId, string userId)
    {
        var userHasAnnouncement = _dbContext.UsersHasAnnouncements
            .FirstOrDefault(uha => uha.AnnouncementsAnnouncementsId == announcementId && uha.AspnetusersId == userId);

        if (userHasAnnouncement == null)
        {
            userHasAnnouncement = new UsersHasAnnouncement
            {
                AnnouncementsAnnouncementsId = announcementId,
                AspnetusersId = userId,
                IsRead = new byte[] { 1 } 
            };
            _dbContext.UsersHasAnnouncements.Add(userHasAnnouncement);
        }
        else
        {
            userHasAnnouncement.IsRead = new byte[] { 1 }; 
        }

        _dbContext.SaveChanges();
    }
}
