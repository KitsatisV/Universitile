using Universitile01.Data;
using Universitile01.Models;

namespace Universitile01.Services
{
    public class TeacherService
    {
        private readonly UniversitiledatabaseContext _dbContext;

        public TeacherService(UniversitiledatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<PerosnalInfo> GetAllTeachers()
        {

            return _dbContext.PerosnalInfos.ToList();
        }
    }
}
