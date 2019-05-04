using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GlobalHockeyConnections.Models;

namespace GlobalHockeyConnections.Models
{
    public class GlobalHockeyConnectionsContext : DbContext
    {
        public GlobalHockeyConnectionsContext (DbContextOptions<GlobalHockeyConnectionsContext> options)
            : base(options)
        {
        }

        public DbSet<GlobalHockeyConnections.Models.Person> Person { get; set; }

        public DbSet<GlobalHockeyConnections.Models.Location> Location { get; set; }

        public DbSet<GlobalHockeyConnections.Models.ShowCaseDescription> ShowCaseDescription { get; set; }

        public DbSet<GlobalHockeyConnections.Models.ShowCase> ShowCase { get; set; }
    }
}
