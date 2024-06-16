using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTestsDb.Models;

namespace TechTestsDb.Data
{
    internal class TechTestsDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Models.Type> Types { get; set; }
        public DbSet<Description> Descriptions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<AnswerValue> AnswerValues { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=LEGA\SQLEXPRESS;Database=TechTestsDb;Trusted_Connection=True;TrustServerCertificate=True");
        }
    }
}
