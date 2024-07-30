using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class CodeNameNumberDescription
    {
        public int Number { get; set; }
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string Description { get; set; }
    }
}
