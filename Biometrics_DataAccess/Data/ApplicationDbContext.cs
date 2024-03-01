using Biometrics_Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biometrics_DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
        public DbSet<ManageUser> ManageUser { get; set; }
        public DbSet<TrackUser> TrackUser { get; set; }
        public DbSet<Registration> Registration { get; set; }

    }
}
