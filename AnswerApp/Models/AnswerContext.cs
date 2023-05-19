using Microsoft.EntityFrameworkCore;
using AnswerApp.Models.Entity;

namespace AnswerApp.Models
{
    public class AnswerContext : DbContext
    {
        public AnswerContext(DbContextOptions<AnswerContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.UseSerialColumns();
        }

        public DbSet<Answer> Answers { get; set; }
    }
}
