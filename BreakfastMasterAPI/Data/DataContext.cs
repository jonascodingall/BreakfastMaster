using BreakfastMasterAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BreakfastMasterAPI.Data
{
    public class DataContext : DbContext
    {
        public DbSet<UserModel> Users { get; set; }
        public DbSet<GroupModel> Groups { get; set; }
        public DbSet<BreadRollModel> BreadRolls { get; set; }
        public DbSet<UserBreadRollModel> UserBreadRolls { get; set; } // Neue DbSet für die Join-Tabelle

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserModel>()
                .HasOne(u => u.Group)
                .WithMany(g => g.Users)
                .HasForeignKey(u => u.GroupId);

            modelBuilder.Entity<UserBreadRollModel>()
                .HasKey(ub => new { ub.UserId, ub.BreadRollId });

            modelBuilder.Entity<UserBreadRollModel>()
                .HasOne(ub => ub.User)
                .WithMany(u => u.UserBreadRolls)
                .HasForeignKey(ub => ub.UserId);

            modelBuilder.Entity<UserBreadRollModel>()
                .HasOne(ub => ub.BreadRoll)
                .WithMany(br => br.UserBreadRolls)
                .HasForeignKey(ub => ub.BreadRollId);
        }
    }
}
