using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<AvailabilityStatus> AvailabilityStatuses { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<CodeNameNumberDescription> CodeNameNumberDescription { get; set; }
        public DbSet<FantasyTeam> FantasyTeams { get; set; }
        public DbSet<FieldPosition> FieldPositions { get; set; }
        public DbSet<Fixture> Fixtues { get; set; }
        public DbSet<FormRate> FormRates { get; set; }
        public DbSet<GameWeek> GameWeeks { get; set; }
        public DbSet<GoalsScoredType> GoalsScoredTypes { get; set; }
        public DbSet<League> Leagues { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<MatchAssist> MatchAssists { get; set; }
        public DbSet<MatchCardBooking> MatchCardBookings { get; set; }
        public DbSet<MatchResult> MatchResults { get; set; }
        public DbSet<MatchScorer> MatchScorers { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<PlayerFieldPosition> PlayerFieldPositions { get; set; }
        public DbSet<PlayerPerformance> PlayerPerformances { get; set; }
        public DbSet<RatingHistory> RatingHistories { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Season> Seasons { get; set; }
        public DbSet<TablePosition> TablePositions { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
