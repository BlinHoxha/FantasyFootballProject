using Domain.BaseEntities.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Card : BaseEntity<Guid>
    {
        public CodeNameNumberDescription? CodeNameNumber { get; set; }
    }
}
