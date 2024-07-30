

namespace Framework.DTO.Implementation
{
    public abstract class BaseDtoEntity<TEntityId> : IBaseDtoEntity<TEntityId>, IAuditableEntity
    {
        public TEntityId? Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
    }
}
