using Domain.BaseEntities.Implementation;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class MatchResult : BaseEntity<Guid>
    {
        public string? OpponentTeam {  get; set; }
        //public MatchEpilogue? Result {  get; set; }
        public string? Scoreline {  get; set; }
        public DateTime MatchDate { get; set; }
        public int TeamId { get; set; }

        // Navigation property to represent the team
        public Team? Team { get; set; }
    }
}
