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

        public List<PersonalInfo> GetAllTeachers()
        {

            return _dbContext.PersonalInfos.ToList();
        }
    }
}
