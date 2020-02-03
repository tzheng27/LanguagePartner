using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace LanguagePartner.Models.DataContext
{
    public class LearnerDataContext : DbContext
    {
        public DbSet<Learner> Learners { get; set; }

        public LearnerDataContext(DbContextOptions<LearnerDataContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
