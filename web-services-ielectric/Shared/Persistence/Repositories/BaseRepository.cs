using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web_services_ielectric.Persistence.Contexts;

namespace web_services_ielectric.Persistence.Repositories
{
    public class BaseRepository
    {
        protected readonly AppDbContext _context;

        public BaseRepository (AppDbContext context)
        {
            _context = context;
        }
    }
}
