using Domain.BaseEntities.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class PlayerFieldPosition : BaseEntity<Guid>
    {
        // Composite primary key
        public Guid? PlayerID { get; set; }
        public Player? Player { get; set; }
        public Guid? FieldPositionID { get; set; }
        public FieldPosition? FieldPosition { get; set; }

    }
}
