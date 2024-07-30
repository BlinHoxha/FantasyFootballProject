using Domain.BaseEntities.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class TablePosition : BaseEntity<Guid>
    {
        public CodeNameNumberDescription? TableRanking { get; set; }
    }
}
