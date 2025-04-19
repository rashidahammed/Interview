namespace INT.Domain.Domain.Core.Model
{
    public interface ISoftDeleteEntity
    {
        public bool IsDeleted { get; set; }
    }
}
