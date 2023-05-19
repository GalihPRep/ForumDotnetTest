using Microsoft.EntityFrameworkCore;
using AccountApp.Models.Entities;

namespace Project000.Models
{
    public class AccountContext : DbContext
    {
        public AccountContext(DbContextOptions<AccountContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
          
            builder.UseSerialColumns();
            //builder.Entity<Account>()
            //    .HasMany(thing => thing.Questions)
            //    .WithOne(thing => thing.Author)
            //    .HasForeignKey(thing => thing.AuthorUsername)
            //    .OnDelete(DeleteBehavior.Cascade);
            //builder.Entity<Account>()
            //    .HasMany(thing => thing.Answers)
            //    .WithOne(thing => thing.Author)
            //    .HasForeignKey(thing => thing.AuthorUsername)
            //    .OnDelete(DeleteBehavior.Cascade);
            //builder.Entity<Question>()
            //    .HasMany(thing => thing.Answers)
            //    .WithOne(thing => thing.Question)
            //    .HasForeignKey(thing => thing.QuestionId)
            //    .OnDelete(DeleteBehavior.Cascade);
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Question> Questions { get; set; }
    }
}
