using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace BackGroundScheduler.ApplicationDbContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
      
    }
}
