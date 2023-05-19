using Microsoft.EntityFrameworkCore;
using QuestionApp.Models.Entity;

namespace QuestionApp.Models
{
    public class QuestionContext : DbContext
    {
        public QuestionContext(DbContextOptions<QuestionContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
           builder.UseSerialColumns();
        }

        public DbSet<Question> Questions { get; set; }
    }
}
