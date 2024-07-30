

namespace Framework.DTO.Interface
{
    public interface IBaseDtoEntity<TEntityId>
    {
        TEntityId? Id { get; set; }
    }
}
