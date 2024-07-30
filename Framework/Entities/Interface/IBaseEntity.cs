using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Entities.Interface
{
    public interface IBaseEntity<TEntityId> : IAuditableEntity
    {
        public TEntityId? Id { get; set; }
        bool IsDeleted { get; set; }
    }
}
