using Universitile01.Data;
using Universitile01.Models;

namespace Universitile01.Services
{
    public class TeacherService
    {
        private readonly ApplicationDbContext _dbContext;

        public TeacherService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<PerosnalInfo> GetAllTeachers()
        {

            return _dbContext.PerosnalInfo.ToList();
        }
    }
}
