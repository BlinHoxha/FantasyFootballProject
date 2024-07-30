using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Entities.Interface
{
    public interface IAuditableEntity
    {
        public DateTime CreatedDate { get; set; }

        public string CreatedBy { get; set; }

        public DateTime UpdateDate { get; set; }

        public string UpdatedBy { get; set; }
    }
}
