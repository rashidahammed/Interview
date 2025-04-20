namespace INT.Domain.Domain.Core.Model
{
    public interface IAuditableEntity
    {
        public long CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public long? LastModifiedBy { get; set; }
        public DateTime? LastModifiedOn { get; set; }
    }
}
