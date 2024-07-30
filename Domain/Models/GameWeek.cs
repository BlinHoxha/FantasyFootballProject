using Domain.BaseEntities.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class GameWeek : BaseEntity<Guid>
    {
        public CodeNameNumberDescription? CodeNameNumber { get; set; }
        // Navigation property for one-to-many relationship with Match
        public ICollection<Match>? Matches { get; set; }
    }
}
