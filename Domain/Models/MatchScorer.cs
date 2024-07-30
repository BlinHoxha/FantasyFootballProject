using Domain.BaseEntities.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class MatchScorer : BaseEntity<Guid>
    {
        public int MatchID { get; set; }
        public Match? Match { get; set; }

        // Foreign key for the player who scored
        public Guid? PlayerID { get; set; }
        // Navigation property for the player who scored
        public Player? Player { get; set; }

        public int? ScoringMinute { get; set; } // Time in minutes when the goal was scored
        public GoalsScoredType? GoalsScoredType { get; set;}

    }
}
