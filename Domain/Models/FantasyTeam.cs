using Domain.BaseEntities.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class FantasyTeam : BaseEntity<Guid>
    {
        public string? TeamName { get; set; }
        public int? TotalPoints { get; set; }

        // Foreign key for the corresponding user
        public Guid? UserID { get; set; }
        // Navigation property for the corresponding user
        public User? User { get; set; }
        public CodeNameNumberDescription? CodeNameNumberDescription { get; set; }

        // Navigation property for one-to-many relationship with FantasyTeamPlayer
        public ICollection<Player>? FantasyPlayers { get; set; }

    }
}
