namespace INT.Application.Application.Core
{
    public class BaseDto
    {
        public long CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public long? LastModifiedBy { get; set; }
        public DateTime? LastModifiedOn { get; set; }
    }
}
