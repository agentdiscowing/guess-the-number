namespace GuessTheNumber.DAL
{
    using GuessTheNumber.DAL.Entities;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class GameContext : IdentityDbContext
    {
        public GameContext(DbContextOptions<GameContext> options)
            : base(options)
        {
        }

        public DbSet<Game> Games { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Guess>().ToTable("Guesses");

            modelBuilder.Entity<Guess>().HasKey(q =>
            new
            {
                q.GameId,
                q.UserId,
                q.Number
            });

            modelBuilder.Entity<Game>().HasOne(g => g.Owner).WithMany().HasForeignKey(g => g.OwnerId);

            modelBuilder.Entity<Game>().HasOne(g => g.Winner).WithMany().HasForeignKey(g => g.WinnerId);

            modelBuilder.Entity<Guess>().HasOne(a => a.User).WithMany().HasForeignKey(a => a.UserId);

            modelBuilder.Entity<Guess>().HasOne(a => a.Game).WithMany(g => g.Attempts).HasForeignKey(a => a.GameId);
        }
    }
}