using Microsoft.EntityFrameworkCore;
using TechTests_API.Models;

namespace TechTests_API.Data
{
    public class TechTestsDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Models.Type> Types { get; set; }
        public DbSet<Description> Descriptions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<AnswerValue> AnswerValues { get; set; }
        public DbSet<QuestionGroup> QuestionGroups { get; set; }
        public DbSet<Result> Results { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Question_QuestionGroup> Question_QuestionGroup { get; set; }
        public DbSet<Category_Question> Category_Questions { get; set; }

        public TechTestsDbContext()
        {
            
        }

        public TechTestsDbContext(DbContextOptions options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasIndex(r => r.Login)
                .IsUnique();

            modelBuilder.Entity<Question_QuestionGroup>()
                .HasKey(q => new { q.QuestionId, q.QuestionGroupId });

            modelBuilder.Entity<Category_Question>()
                .HasKey(cq => new { cq.CategoryId, cq.QuestionId });
        }
    }
}
