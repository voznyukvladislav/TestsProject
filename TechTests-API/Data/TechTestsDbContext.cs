using Microsoft.EntityFrameworkCore;
using TechTests_API.Models;

namespace TechTests_API.Data
{
    public class TechTestsDbContext : DbContext
    {
        internal DbSet<Category> Categories { get; set; }
        internal DbSet<Models.Type> Types { get; set; }
        internal DbSet<Description> Descriptions { get; set; }
        internal DbSet<Answer> Answers { get; set; }
        internal DbSet<Question> Questions { get; set; }
        internal DbSet<AnswerValue> AnswerValues { get; set; }

        public TechTestsDbContext(DbContextOptions options): base(options)
        {

        }
    }
}
