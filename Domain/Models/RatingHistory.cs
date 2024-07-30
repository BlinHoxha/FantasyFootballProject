using Domain.BaseEntities.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class RatingHistory : BaseEntity<Guid>
    {

        // Foreign key for the corresponding player
        public Guid? PlayerID { get; set; }
        // Navigation property for the corresponding player
        public Player? Player { get; set; }

        public int Rating { get; set; }

    } 
}
