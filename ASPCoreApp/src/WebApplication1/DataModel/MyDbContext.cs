using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.DataModel
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions options) : base(options){ }
        public DbSet<Candidate> Candidates { get; set; }
    }
}
