using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using comp6324WebAppIdentify.Models;

namespace comp6324WebAppIdentify.Models
{
    public class comp6324WebAppIdentifyContext : DbContext
    {
        public comp6324WebAppIdentifyContext (DbContextOptions<comp6324WebAppIdentifyContext> options)
            : base(options)
        {
        }

        public DbSet<comp6324WebAppIdentify.Models.Job> Job { get; set; }
        public DbSet<comp6324WebAppIdentify.Models.Measurement> Measurement { get; set; }
        public DbSet<comp6324WebAppIdentify.Models.TestSchedule> TestSchedule { get; set; }
    }
}
