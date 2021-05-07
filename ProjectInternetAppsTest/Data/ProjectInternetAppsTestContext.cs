using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectInternetAppsTest.Models;

namespace ProjectInternetAppsTest.Data
{
    public class ProjectInternetAppsTestContext : DbContext
    {
        public ProjectInternetAppsTestContext (DbContextOptions<ProjectInternetAppsTestContext> options)
            : base(options)
        {
        }

        public DbSet<ProjectInternetAppsTest.Models.Category> Category { get; set; }

        public DbSet<ProjectInternetAppsTest.Models.Order> Order { get; set; }

        public DbSet<ProjectInternetAppsTest.Models.Product> Product { get; set; }

        public DbSet<ProjectInternetAppsTest.Models.User> User { get; set; }
    }
}
