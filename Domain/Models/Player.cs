using Domain.BaseEntities.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Player : BaseEntity<Guid>
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int? Age { get; set; }
        public int? Goals { get; set; }
        public int? Assists { get; set; }
        public bool? IsAvailable { get; set; }
        public AvailabilityStatus? AvailabilityStatus { get; set; }
        public Guid? TeamId { get; set; }
        public Team? Team { get; set; }

        // Navigation property for many-to-many relationship with FieldPosition through PlayerFieldPosition
        public ICollection<PlayerFieldPosition>? PlayerFieldPositions { get; set; }

        // Navigation property for the favorite position
        public FieldPosition? FavoritePosition { get; set; }
    }
}
