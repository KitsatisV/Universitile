using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using Universitile01.Data;
using MySqlConnector;
using System.Data;

namespace Universitile01.Services
{
    public class DataService
    {
        private readonly DataContext _context;

        public DataService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Universitile01.Data.Module>> GetModuleAsync()
        {
            return await _context.GetModulesUsingSql();
            // return await _context.Modules.ToListAsync(); 
        }
    }
}