using Domain.BaseEntities.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class FormRate : BaseEntity<Guid>
    {
        public CodeNameNumberDescription? Form { get; set; }
    }
}
