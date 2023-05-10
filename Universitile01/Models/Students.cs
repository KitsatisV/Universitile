namespace Universitile01.Models
{
    public class Students
    {
        public int CoursesCourseId { get; set; }
        public string AspNetUsersId { get; set; }

        public virtual Course Course { get; set; }
        public virtual Aspnetuser Aspnetuser { get; set; }
    }
}