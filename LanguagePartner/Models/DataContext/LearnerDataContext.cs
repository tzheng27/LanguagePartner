using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LanguagePartner.Models.DataContext
{
    public class LearnerDataContext : IdentityDbContext
    {
        public LearnerDataContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Learner> Learners { get; set; }

       
    }
}
