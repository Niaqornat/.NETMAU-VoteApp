using Microsoft.EntityFrameworkCore;
using LibModels;

namespace WebApplication3.Models
{
    public class VoteContext : DbContext
    {
        public VoteContext(DbContextOptions options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 25464464654,
                Name = "Batuhan",
                SurName = "Çetin",
                IsVoted = false
            });
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 23454545454,
                Name = "Cenk",
                SurName = "Çetin",
                IsVoted = false
            });
            modelBuilder.Entity<Candidate>().HasData(new Candidate
            {
                Id = 12341234123,
                Name = "Cenk",
                SurName = "Tosun",
                IsVoted = false,
                VoteCount = 0
            });
            modelBuilder.Entity<Candidate>().HasData(new Candidate
            {
                Id = 23412312341,
                Name = "Ceren",
                SurName = "Taş",
                IsVoted = false,
                VoteCount = 0
            });
            modelBuilder.Entity<Candidate>().HasData(new Candidate
            {
                Id = 23123412341,
                Name = "Kazım",
                SurName = "Eroğlu",
                IsVoted = false,
                VoteCount = 0
            });
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Candidate> Candidates { get; set; }
    }
}
