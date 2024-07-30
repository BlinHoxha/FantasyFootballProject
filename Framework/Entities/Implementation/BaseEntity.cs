using Domain.BaseEntities.Interface;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Framework.Entities.Implementation
{
    public abstract class BaseEntity<TEntityId> : IBaseEntity<TEntityId>
    {
        [Key]
        [Column("ID")]
        public TEntityId? Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
    }
}
