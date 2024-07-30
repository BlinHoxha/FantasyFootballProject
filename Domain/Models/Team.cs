using Domain.BaseEntities.Implementation;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Team : BaseEntity<Guid>
    {
        [Required]
        [MaxLength(100)]
        public string? TeamName { get; set; }
        public string? CoachName { get; set; }
        public string? CaptainName { get; set; }
        public string? ViceCaptainName { get; set; }
        public CodeNameNumberDescription? ActualForm { get; set; }
        public int TablePosition { get; set; }
        //public ICollection<InjuredPlayer> InjuredPlayers { get; set; }

        // Navigation property for one-to-many relationship with Player
        public ICollection<Player>? Players { get; set; }

    }
}
