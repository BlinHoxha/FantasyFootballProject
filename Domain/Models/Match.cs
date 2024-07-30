using Domain.BaseEntities.Implementation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    [Index(nameof(HomeTeam), nameof(AwayTeam), nameof(GameWeek), IsUnique = true)]
    public class Match : BaseEntity<Guid>
    {
        public Guid? HomeTeamId { get; set; }
        public Team? HomeTeam { get; set; }

        public Guid? AwayTeamId { get; set; }
        public Team? AwayTeam { get; set; }

        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public string? Stadium { get; set; }
        public string? FinalScore { get; set; }
        public bool? IsFinished { get; set; }
        public Address? Location { get; set; }

        public Guid? GameWeekId { get; set; }

        // Navigation property for the corresponding game week
        public GameWeek? GameWeek { get; set; }

        // Navigation property for one-to-many relationship with MatchScorers
        public ICollection<MatchScorer>? MatchScorers { get; set; }
        public ICollection<MatchAssist>? MatchAssists { get; set; }
        public ICollection<MatchCardBooking>? MatchBookings { get; set; }

    }
}
