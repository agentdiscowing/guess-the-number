namespace GuessTheNumber.DAL
{
    using GuessTheNumber.Core.Entities;
    using Microsoft.EntityFrameworkCore;

    public class GameContext : DbContext
    {
        public GameContext(DbContextOptions<GameContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Game> Games { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Attempt>().HasKey(q =>
            new
            {
                q.GameId,
                q.UserId,
                q.Number
            });

            modelBuilder.Entity<Game>().HasOne(g => g.Owner).WithMany(u => u.Games).HasForeignKey(g => g.OwnerId);

            modelBuilder.Entity<Game>().HasOne(g => g.Winner).WithMany().HasForeignKey(g => g.WinnerId);

            modelBuilder.Entity<Attempt>().HasOne(a => a.User).WithMany().HasForeignKey(a => a.UserId);

            modelBuilder.Entity<Attempt>().HasOne(a => a.Game).WithMany(g => g.Attempts).HasForeignKey(a => a.GameId);

            modelBuilder.Entity<User>().HasIndex(u => new { u.Email, u.Username }).IsUnique();
        }

    }
}