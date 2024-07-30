using Domain.BaseEntities.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class UserAddress : BaseEntity<Guid>
    {
        public string? City { get; set; }
        public string? Country { get; set; }
        public string? PostalCode { get; set; }       
    }
}
